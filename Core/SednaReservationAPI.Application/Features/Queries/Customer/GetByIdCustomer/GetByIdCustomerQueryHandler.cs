using MediatR;
using SednaReservationAPI.Application.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SednaReservationAPI.Application.Features.Queries.Customer.GetByIdCustomer
{
    public class GetByIdCustomerQueryHandler : IRequestHandler<GetByIdCustomerQueryRequest, GetByIdCustomerQueryResponse>
    {
        readonly ICustomerReadRepository _customerReadRepository;

        public GetByIdCustomerQueryHandler(ICustomerReadRepository customerReadRepository)
        {
            _customerReadRepository = customerReadRepository;
        }

        public async Task<GetByIdCustomerQueryResponse> Handle(GetByIdCustomerQueryRequest request, CancellationToken cancellationToken)
        {
            var customer = await _customerReadRepository.GetByIdAsync(request.Id, false);
            var response = new GetByIdCustomerQueryResponse
            {
                Id = customer.Id.ToString(),
                Name = customer.Name,
                Email = customer.Email,
                Password = customer.Password,
                Phone = customer.Phone,
                Age = customer.Age,
                Gender = customer.Gender
            };
            return response;
        }
    }
}
