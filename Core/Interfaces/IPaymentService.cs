using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Entities;
using Core.Entities.OrderAggregate;

namespace Core.Interfaces
{
    public interface IPaymentService
    {
        Task<CustomerBasket> CreateOrUpdatePaymentIntent(string baskId);

        Task<Order> UpadateOrderPaymentSucceeded(string paymentIntentId);
        Task<Order> UpadateOrderPaymentFailed(string paymentIntentId);
    }
}