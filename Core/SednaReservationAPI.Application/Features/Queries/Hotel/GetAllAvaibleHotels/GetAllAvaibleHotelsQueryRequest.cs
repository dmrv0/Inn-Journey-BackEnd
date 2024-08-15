using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SednaReservationAPI.Application.Features.Queries.Hotel.GetAllAvaibleHotels
{
    public class GetAllAvaibleHotelsQueryRequest: IRequest<GetAllAvaibleHotelsQueryResponse>
    {
        public int Page { get; set; }
        public int Size { get; set; }
        public DateTime CheckIn { get; set; }
        public DateTime CheckOut { get; set; }
    }
}
