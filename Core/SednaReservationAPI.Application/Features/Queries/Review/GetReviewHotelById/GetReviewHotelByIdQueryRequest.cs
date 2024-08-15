using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SednaReservationAPI.Application.Features.Queries.Review.GetReviewHotelById
{
    public class GetReviewHotelByIdQueryRequest:IRequest<GetReviewHotelByIdQueryResponse>
    {
        public string? HotelId {  get; set; }
        public int Page { get; set; }
        public int Size { get; set; }
    }
}
