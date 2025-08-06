using AutoMapper;
using Microsoft.AspNetCore.SignalR;
using MovieReservationSystemAPI.Helpers.DTOs.BookingDTOs;
using MovieReservationSystemAPI.Helpers.DTOs.MovieScheduleDTOs;
using MovieReservationSystemAPI.Helpers.DTOs.ResponseDTOs;
using MovieReservationSystemAPI.Helpers.DTOs.TicketDTOs;
using MovieReservationSystemAPI.SignalR;
using Stripe.BillingPortal;
using Stripe.Checkout;

namespace MovieReservationSystemAPI.Services.Implementation
{
    public class TicketService : ITicketService
    {
        private readonly IHubContext<BookingHub> _hubContext;
        private readonly IEntityBaseRepository<Ticket> _base;
        private readonly IEntityBaseRepository<Seat> _baseSeat;
        private readonly IMapper _mapper;
        public TicketService(IEntityBaseRepository<Ticket> @base, IMapper mapper, IHubContext<BookingHub> hubContext, IEntityBaseRepository<Seat> baseSeat)
        {
            _base = @base;
            _mapper = mapper;
            _hubContext = hubContext;
            _baseSeat = baseSeat;
        }
        public async Task<Ticket> GetById(Guid Id)
        {
            return await _base.Get(ms => ms.Id == Id, "Seat,MovieSchedule,User,Theater");
        }
        public async Task<List<Ticket>> GetAllByUserId(string UserId)
        {
            return await _base.GetAll(ms => ms.UserId == UserId, "Seat,MovieSchedule,User,Theater");
        }
        /*public async Task<List<Ticket>> GetAllByTheaterId(Guid TheaterId)
        {
            return await _base.GetAll(ms => ms.TheaterId == TheaterId, "Seat,MovieSchedule,User,Theater");
        }*/
        public async Task<List<Ticket>> GetAllByMovieScheduleIdId(Guid MovieScheduleIdId)
        {
            return await _base.GetAll(ms => ms.MovieScheduleId == MovieScheduleIdId, "Seat,MovieSchedule,User,Theater");
        }
        public async Task<List<Ticket>> GetAllBySeatId(Guid SeatId)
        {
            return await _base.GetAll(ms => ms.SeatId == SeatId, "Seat,MovieSchedule,User,Theater");
        }
        public async Task<CreateCheckoutSessionResponse> CreateCheckoutSession(BookingRequestDTO model)
        {
            var ticket = await _base.Get(s => s.Id == model.SeatId && s.MovieScheduleId == model.MovieScheduleId);

            if (ticket == null || ticket.IsBooked || (ticket.Lock.HasValue && ticket.Lock > DateTime.UtcNow))
                return new CreateCheckoutSessionResponse() { IsSuccess=false, Msg="Ticket is unavailable"};

            ticket.Lock = DateTime.UtcNow.AddMinutes(5);
            await _base.Update(ticket);
            var seat = await _baseSeat.Get(s => s.Id == model.SeatId);

            var options = new SessionCreateOptions
            {
                PaymentMethodTypes = new List<string> { "card" },
                LineItems = new List<SessionLineItemOptions>
                {
                    new SessionLineItemOptions
                    {
                        PriceData = new SessionLineItemPriceDataOptions
                        {
                            Currency = "usd",
                            UnitAmount = 1200,
                            ProductData = new SessionLineItemPriceDataProductDataOptions
                            {
                                Name = $"Seat {seat.SeatNum} for Movie"
                            },
                        },
                        Quantity = 1,
                    }
                 },
                Mode = "payment",
                SuccessUrl = $"https://yourdomain.com/booking/success?session_id={{CHECKOUT_SESSION_ID}}&seatId={seat.Id}",
                CancelUrl = $"https://yourdomain.com/booking/cancel?seatId={seat.Id}",
            };

            var service = new SessionService();
            Session session = service.Create(options);

            return new CreateCheckoutSessionResponse() { IsSuccess=true, sessionId = session.Id, url = session.Url };
        }
        
        /*
        public async Task<bool> LockTicket(Ticket ticket)
        {
            if (ticket.IsBooked || ticket.Lock > DateTime.UtcNow) return false;
            ticket.Lock = DateTime.UtcNow.AddMinutes(5);
            await _base.Update(ticket);
            return true;
        }
        public async Task<bool> BookTicket(Ticket ticket)
        {
            if (ticket.IsBooked || ticket.Lock < DateTime.UtcNow) return false;




            ticket.IsBooked = true;
            ticket.Lock = null;
            await _base.Update(ticket);

            await _hubContext.Clients.Groups($"MovieSchedule:{ticket.MovieScheduleId}").SendAsync("BookedSeat", new { TicketId = ticket.Id });
            return true;
        }
        */

        public async Task<Ticket> Create(CreateTicketDTO model)
        {
            var Ticket = _mapper.Map<Ticket>(model);
            await _base.Create(Ticket);
            return Ticket;
        }
        public async Task<Ticket> Update(Ticket Ticket, UpdateTicketDTO model)
        {
            _mapper.Map(Ticket, model);
            await _base.Update(Ticket);
            return Ticket;
        }
        public async Task Delete(Ticket Ticket)
        {
            await _base.Remove(Ticket);
        }
    }
}
