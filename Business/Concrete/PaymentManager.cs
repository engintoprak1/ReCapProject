using System;
using System.Collections.Generic;
using System.Text;
using Business.Abstract;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;

namespace Business.Concrete
{
    public class PaymentManager : IPaymentService
    {
      
        public IResult Pay(CreditCard card)
        {
            return new SuccessResult("Ödeme başarılı");
        }

       
    }
}
