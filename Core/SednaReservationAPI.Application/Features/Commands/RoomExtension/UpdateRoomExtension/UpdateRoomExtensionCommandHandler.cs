using MediatR;
using Microsoft.EntityFrameworkCore;
using SednaReservationAPI.Application.Repositories.RoomEntensions;
using SednaReservationAPI.Application.Repositories.RoomExtensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace SednaReservationAPI.Application.Features.Commands.RoomExtension.UpdateRoomExtensions
{
    public class CreateRoomExtensionCommandHandler : IRequestHandler<UpdateRoomExtensionCommandRequest, UpdateRoomExtensionCommandResponse>
    {

        readonly IWriteRepositoryRoomExtensions _writeRepositoryRoomExtensions;
        readonly IReadRepositoryRoomExtensions  _readRepositoryRoomExtensions;

        public CreateRoomExtensionCommandHandler(IWriteRepositoryRoomExtensions writeRepositoryRoomExtensions, IReadRepositoryRoomExtensions readRepositoryRoomExtensions)
        {
            _writeRepositoryRoomExtensions = writeRepositoryRoomExtensions;
            _readRepositoryRoomExtensions = readRepositoryRoomExtensions;
        }

        public async Task<UpdateRoomExtensionCommandResponse> Handle(UpdateRoomExtensionCommandRequest request, CancellationToken cancellationToken)
        {
            // 1. Adım: İstenen roomId'ler için filtreleme ifadesi oluşturma
            var requestRoomIds = request.RoomExtensions.Select(re => re.roomId).ToList();
            Expression<Func<Domain.Entities.RoomExtension, bool>> filterExpression =
                re => requestRoomIds.Contains(re.roomId);

            // 2. Adım: Mevcut verileri filtreleme
            var existingRoomExtensions = await _readRepositoryRoomExtensions.GetWhere(filterExpression).ToListAsync();

            if (existingRoomExtensions != null && existingRoomExtensions.Any())
            {
                _writeRepositoryRoomExtensions.RemoveRange(existingRoomExtensions);
                await _writeRepositoryRoomExtensions.SaveAsync();
            }

            // 3. Adım: Yeni verileri ekleme
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
