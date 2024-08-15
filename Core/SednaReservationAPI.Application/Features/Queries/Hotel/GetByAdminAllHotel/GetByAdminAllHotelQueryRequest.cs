using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SednaReservationAPI.Application.Features.Queries.Hotel.GetUserByIdHotel
{
    public class GetByAdminAllHotelQueryRequest : IRequest<List<GetByAdminAllHotelQueryResponse>>
    {
        public string userId { get; set; }

    }
}
