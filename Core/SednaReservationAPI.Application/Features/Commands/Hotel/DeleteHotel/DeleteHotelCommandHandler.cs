using MediatR;
using SednaReservationAPI.Application.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SednaReservationAPI.Application.Features.Commands.Hotel.DeleteHotel
{
    public class DeleteHotelCommandHandler : IRequestHandler<DeleteHotelCommandRequest, DeleteHotelCommandResponse>
    {
        readonly IHotelWriteRepository _hotelWriteRepository;

        public DeleteHotelCommandHandler(IHotelWriteRepository hotelWriteRepository)
        {
            _hotelWriteRepository = hotelWriteRepository;
        }

        public async Task<DeleteHotelCommandResponse> Handle(DeleteHotelCommandRequest request, CancellationToken cancellationToken)
        {

            await _hotelWriteRepository.RemoveAsync(request.Id);
            await _hotelWriteRepository.SaveAsync();
            return new();

        }
    }
}
