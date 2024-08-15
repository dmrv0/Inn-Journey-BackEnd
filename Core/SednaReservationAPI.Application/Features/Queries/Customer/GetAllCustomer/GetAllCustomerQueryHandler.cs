using MediatR;
using SednaReservationAPI.Application.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SednaReservationAPI.Application.Features.Queries.Customer.GetAllCustomer
{
    public class GetAllCustomerQueryHandler : IRequestHandler<GetAllCustomerQueryRequest, List<GetAllCustomerQueryResponse>>
    {
        readonly ICustomerReadRepository _customerReadRepository;

        public GetAllCustomerQueryHandler(ICustomerReadRepository customerReadRepository)
        {
            _customerReadRepository = customerReadRepository;
        }

        public Task<List<GetAllCustomerQueryResponse>> Handle(GetAllCustomerQueryRequest request, CancellationToken cancellationToken)
        {
            var customers = _customerReadRepository.GetAll(false)
                .Select(customer => new GetAllCustomerQueryResponse
                {
                    Id = customer.Id.ToString(),
                    Name = customer.Name,
                    Email = customer.Email,
                    Password = customer.Password,
                    Phone = customer.Phone,
                    Age = customer.Age,
                    Gender = customer.Gender
                }).ToList();

            return Task.FromResult(customers);

        }
    }
}
