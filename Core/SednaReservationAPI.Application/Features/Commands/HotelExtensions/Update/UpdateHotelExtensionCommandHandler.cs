using MediatR;
using Microsoft.EntityFrameworkCore;
using SednaReservationAPI.Application.Repositories.HotelExtensions;
using SednaReservationAPI.Application.Repositories.RoomEntensions;
using SednaReservationAPI.Application.Repositories.RoomExtensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace SednaReservationAPI.Application.Features.Commands.HotelExtensions.Update
{
    public class UpdateHotelExtensionCommandHandler : IRequestHandler<UpdateHotelExtensionCommandRequest, UpdateHotelExtensionCommandResponse>
    {
        readonly IWriteRepositoryHotelExtensions _writeRepositoryHotelExtensions;
        readonly IReadRepositoryHotelExtensions _readRepositoryHotelExtensions;

        public UpdateHotelExtensionCommandHandler(IWriteRepositoryHotelExtensions writeRepositoryHotelExtensions, IReadRepositoryHotelExtensions readRepositoryHotelExtensions)
        {
            _writeRepositoryHotelExtensions = writeRepositoryHotelExtensions;
            _readRepositoryHotelExtensions = readRepositoryHotelExtensions;
        }

        public async Task<UpdateHotelExtensionCommandResponse> Handle(UpdateHotelExtensionCommandRequest request, CancellationToken cancellationToken)
        {
            // 1. Adım: İstenen roomId'ler için filtreleme ifadesi oluşturma
            var requestRoomIds = request.HotelExtensions.Select(re => re.hotelId).ToList();
            Expression<Func<Domain.Entities.HotelExtension, bool>> filterExpression =
                re => requestRoomIds.Contains(re.hotelId);

            // 2. Adım: Mevcut verileri filtreleme
            var existingHotelExtensions = await _readRepositoryHotelExtensions.GetWhere(filterExpression).ToListAsync();

            if (existingHotelExtensions != null && existingHotelExtensions.Any())
            {
                _writeRepositoryHotelExtensions.RemoveRange(existingHotelExtensions);
                await _writeRepositoryHotelExtensions.SaveAsync();
            }

            // 3. Adım: Yeni verileri ekleme
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
