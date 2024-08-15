using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SednaReservationAPI.Application.Features.Queries.Reservation.GetHotelByIdReservation
{
    public class GetHotelByIdReservationQueryResponse
    {

        public List<Domain.Entities.Reservation> rezervations { get; set; }
        public int TotalCount { get; set; }
    }




}
