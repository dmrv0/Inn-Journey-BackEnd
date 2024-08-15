using MediatR;
using SednaReservationAPI.Application.Repositories.RoomExtensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SednaReservationAPI.Application.Features.Commands.RoomExtension
{
    public class CreateRoomExtensionCommandHandler : IRequestHandler<CreateRoomExtensionCommandRequest, CreateRoomExtensionCommandResponse>
    {

        readonly IWriteRepositoryRoomExtensions _writeRepositoryRoomExtensions;

        public CreateRoomExtensionCommandHandler(IWriteRepositoryRoomExtensions writeRepositoryRoomExtensions)
        {
            _writeRepositoryRoomExtensions = writeRepositoryRoomExtensions;
        }

        public async Task<CreateRoomExtensionCommandResponse> Handle(CreateRoomExtensionCommandRequest request, CancellationToken cancellationToken)
        {
            // Örneğin, `request` birden fazla `RoomExtension`'ı içeren bir koleksiyon ise
            var roomExtensions = request.RoomExtensions.Select(re => new Domain.Entities.RoomExtension
            {
                roomId = re.roomId,
                iconUrl = re.IconUrl,
                Name = re.Name
            }).ToList();

            await _writeRepositoryRoomExtensions.AddRangeAsync(roomExtensions);
            await _writeRepositoryRoomExtensions.SaveAsync();

            return new()
            {
                Success = true,
            };

           
        }
    }
}
