using MediatR;
using SednaReservationAPI.Application.Repositories.RoomEntensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SednaReservationAPI.Application.Features.Queries.RoomExtensions.GetRoomExtensionsByRoomId
{
    public class GetRoomExtensionsByRoomIdQueryHandler : IRequestHandler<GetRoomExtensionsByRoomIdQueryRequest, List<GetRoomExtensionsByRoomIdQueryResponse>>
    {
        IReadRepositoryRoomExtensions _readRepository;

        public GetRoomExtensionsByRoomIdQueryHandler(IReadRepositoryRoomExtensions readRepository)
        {
            _readRepository = readRepository;
        }

        public async Task<List<GetRoomExtensionsByRoomIdQueryResponse>> Handle(GetRoomExtensionsByRoomIdQueryRequest request, CancellationToken cancellationToken)
        {
         var extensions=  _readRepository.GetWhere(i => i.roomId == request.roomId).Select(ext=> new GetRoomExtensionsByRoomIdQueryResponse
           { 
               Id = ext.Id.ToString(),
               roomId = ext.roomId,
               Name = ext.Name,
               iconUrl = ext.iconUrl,
           }).ToList();

            return await Task.FromResult(extensions);
        }
    }
}
