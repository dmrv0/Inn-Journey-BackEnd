using MediatR;
using SednaReservationAPI.Application.Repositories.HotelExtensions;
using SednaReservationAPI.Application.Repositories.RoomExtensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SednaReservationAPI.Application.Features.Commands.HotelExtensions.Create
{
    public class CreateHotelExtensionCommandHandler : IRequestHandler<CreateHotelExtensionCommandRequest, CreateHotelExtensionCommandResponse>
    {

        readonly IWriteRepositoryHotelExtensions _writeRepositoryHotelExtensions;

        public CreateHotelExtensionCommandHandler(IWriteRepositoryHotelExtensions WriteRepositoryHotelExtensions)
        {
            _writeRepositoryHotelExtensions = WriteRepositoryHotelExtensions;
        }

        public async Task<CreateHotelExtensionCommandResponse> Handle(CreateHotelExtensionCommandRequest request, CancellationToken cancellationToken)
        {
           
            var hotelExtensions = request.HotelExtensions.Select(re => new Domain.Entities.HotelExtension
            {
                hotelId = re.hotelId,
                iconUrl = re.IconUrl,
                Name = re.Name
            }).ToList();

            await _writeRepositoryHotelExtensions.AddRangeAsync(hotelExtensions);
            await _writeRepositoryHotelExtensions.SaveAsync();

            return new()
            {
                Success = true,
            };


        }
    }
}
