using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SednaReservationAPI.Application.Features.Queries.Hotel.GetAllHotel
{
    public class GetAllHotelQueryRequest : IRequest<List<GetAllHotelQueryResponse>>
    {
        public int? Page { get; set; }
        public int? Size { get; set; }
        public bool? MaxStar { get; set; }
        public bool? MaxPrice { get; set; }
       
    }
}
