using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SednaReservationAPI.Application.Features.Queries.Hotel.GetByIdHotel
{
    public class GetByIdHotelQueryRequest : IRequest<GetByIdHotelQueryResponse>
    {
        public string? Id { get; set; }
    }
}
