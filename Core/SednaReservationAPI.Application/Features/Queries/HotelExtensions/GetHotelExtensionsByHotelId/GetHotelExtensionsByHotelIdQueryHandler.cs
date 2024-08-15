using MediatR;
using SednaReservationAPI.Application.Features.Queries.RoomExtensions.GetRoomExtensionsByRoomId;
using SednaReservationAPI.Application.Repositories;
using SednaReservationAPI.Application.Repositories.HotelExtensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SednaReservationAPI.Application.Features.Queries.HotelExtensions.GetHotelExtensionsByHotelId
{
    public class GetHotelExtensionsByHotelIdQueryHandler : IRequestHandler<GetHotelExtensionsByHotelIdQueryRequest, List<GetHotelExtensionsByHotelIdQueryResponse>>
    {
        readonly IReadRepositoryHotelExtensions _readRepositoryHotelExtensions;

        public GetHotelExtensionsByHotelIdQueryHandler(IReadRepositoryHotelExtensions readRepositoryHotelExtensions)
        {
            _readRepositoryHotelExtensions = readRepositoryHotelExtensions;
        }

        public async Task<List<GetHotelExtensionsByHotelIdQueryResponse>> Handle(GetHotelExtensionsByHotelIdQueryRequest request, CancellationToken cancellationToken)
        {
            var extensions = _readRepositoryHotelExtensions.GetWhere(i => i.hotelId == request.hotelId).Select(ext => new GetHotelExtensionsByHotelIdQueryResponse
            {
                Id = ext.Id.ToString(),
                hotelId = ext.hotelId,
                Name = ext.Name,
                iconUrl = ext.iconUrl,
            }).ToList();

            return await Task.FromResult(extensions);
        }
    }
}
