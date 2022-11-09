using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Core.Entities.OrderAggregate;

namespace Core.Specifications
{
    public class OrderByPaymentIntentIdSpacification : BaseSpecification<Order>
    {
        public OrderByPaymentIntentIdSpacification(string PaymentIntentId) 
                                  : base(o => o.PaymentIntentId == PaymentIntentId)
        {
            
        }
    }
}