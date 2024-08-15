using Iyzipay;
using Iyzipay.Model;
using Iyzipay.Request;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SednaReservationAPI.Application.Abstractions.Services;
using SednaReservationAPI.Application.DTOs.User;
using SednaReservationAPI.Application.Features.Commands.AppUser.CreateAppUser;
using SednaReservationAPI.Application.Features.Commands.AppUser.LoginUser;
using SednaReservationAPI.Application.Features.Commands.Payment.CreatePayment;
using SednaReservationAPI.Application.Features.Queries.AppUser.GetByIdUser;
using SednaReservationAPI.Application.Repositories;
using SednaReservationAPI.Domain.Entities.Identity;

namespace SednaReservationAPI.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class Pay2Controller : ControllerBase
    {
        IUserService _service;
        IPaymentWriteRepository _paymentWriteRepository;
        IMediator _mediator;
        public Pay2Controller(IPaymentWriteRepository paymentWriteRepository, IMediator mediator, IUserService service)
        {
            _paymentWriteRepository = paymentWriteRepository;
            _mediator = mediator;
            _service = service;
        }
        [HttpPost]
        public async Task<IActionResult> Pay(Domain.Entities.Pay pay)
        {
           
            AppUser user =  await _service.getByIdUser(pay.UserId);

            Options options = new Options();
            options.ApiKey = "sandbox-1MI6CT9CNRgled7v6pUqORBLT7otH0x2";
            options.SecretKey = "sandbox-hH6vek6yrEdnpxPnNKAnu1YtIL2rZSo6";
            options.BaseUrl = "https://sandbox-api.iyzipay.com";

            CreatePaymentRequest request = new CreatePaymentRequest();
            request.Locale = Locale.TR.ToString();
            request.ConversationId = new Random().Next(111111111, 999999999).ToString(); ;
            request.Price = pay.TotalPrice.ToString();
            request.PaidPrice = pay.TotalPrice.ToString();
            request.Currency = Currency.TRY.ToString();
            request.Installment = 1;
            request.BasketId = pay.Id.ToString();
            request.PaymentChannel = PaymentChannel.WEB.ToString();
            request.PaymentGroup = PaymentGroup.PRODUCT.ToString();

            PaymentCard paymentCard = new PaymentCard();
            paymentCard.CardHolderName = pay.CardHolderName;
            paymentCard.CardNumber = pay.CardNumber;
            paymentCard.ExpireMonth = pay.ExpireMonth;
            paymentCard.ExpireYear = pay.ExpireYear;
            paymentCard.Cvc = pay.Cvc;
            paymentCard.RegisterCard = 0;
            request.PaymentCard = paymentCard;

            Buyer buyer = new Buyer();
            buyer.Id = pay.UserId;
                buyer.Name = user.Name;
            buyer.Surname = user.UserName;
            buyer.GsmNumber = user.PhoneNumber;
            buyer.Email = user.Email;
            buyer.IdentityNumber = "74300864791";
            buyer.LastLoginDate = "2024-07-05 12:43:35";
            buyer.RegistrationDate = "2024-04-21 15:12:09";
            buyer.RegistrationAddress = "Nidakule Göztepe, Merdivenköy Mah. Bora Sok. No:1";
            buyer.Ip = "85.34.78.112";
            buyer.City = "Istanbul";
            buyer.Country = "Turkey";
            buyer.ZipCode = "34732";
            request.Buyer = buyer;

          

            Address shippingAddress = new Address();
            shippingAddress.ContactName = "Jane Doe";
            shippingAddress.City = "Istanbul";
            shippingAddress.Country = "Turkey";
            shippingAddress.Description = "Nidakule Göztepe, Merdivenköy Mah. Bora Sok. No:1";
            shippingAddress.ZipCode = "34742";
            request.ShippingAddress = shippingAddress;

            Address billingAddress = new Address();
            billingAddress.ContactName = "Jane Doe";
            billingAddress.City = "Istanbul";
            billingAddress.Country = "Turkey";
            billingAddress.Description = "Nidakule Göztepe, Merdivenköy Mah. Bora Sok. No:1";
            billingAddress.ZipCode = "34742";
            request.BillingAddress = billingAddress;

            List<BasketItem> basketItems = new List<BasketItem>();
            BasketItem firstBasketItem = new BasketItem();
            firstBasketItem.Id = pay.Id.ToString();
            firstBasketItem.Name = "Binocular";
            firstBasketItem.Category1 = "Collectibles";
            firstBasketItem.Category2 = "Accessories";
            firstBasketItem.ItemType = BasketItemType.PHYSICAL.ToString();
            firstBasketItem.Price = pay.TotalPrice.ToString(); 
            basketItems.Add(firstBasketItem);
   
            request.BasketItems = basketItems;

            Payment payment = Payment.Create(request, options);


            CreatePaymentCommandRequest paymentCommandRequest = new CreatePaymentCommandRequest();
            paymentCommandRequest.ReservationId = pay.Id.ToString();
            paymentCommandRequest.HotelId = pay.HotelId;
            paymentCommandRequest.UserId = pay.UserId;
            paymentCommandRequest.PaymentMethod = "Online";
            paymentCommandRequest.Status = payment.Status;
            paymentCommandRequest.Date = DateTime.UtcNow;
            paymentCommandRequest.Amount = pay.TotalPrice;

            _mediator.Send(paymentCommandRequest);

            return Ok(payment);


        }
    }
}
