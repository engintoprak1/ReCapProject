using Business.Abstract;
using Business.BusinessAspects.Autofac;
using Business.Constants;
using Core.Extensions;
using Core.Utilities.Business;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class CreditCardManager : ICreditCardService
    {
        ICreditCardDal _creditCardDal;
        ICustomerService _customerService;
        private IHttpContextAccessor _httpContextAccessor;

        public CreditCardManager(ICreditCardDal creditCardDal, ICustomerService customerService, IHttpContextAccessor httpContextAccessor)
        {
            _creditCardDal = creditCardDal;
            _customerService = customerService;
            _httpContextAccessor = httpContextAccessor;
        }

        [Authentication]
        public IResult Save(CreditCard card)
        {
            int authUserId = _httpContextAccessor.HttpContext.User.GetAuthenticatedUserId();
            var customer = _customerService.GetByUserId(authUserId);
            var result = BusinessRules.Run(IsCardExist(card.CardNumber));
            if (result != null)
            {
                return result;
            }
            card.CustomerId = customer.Data.Id;
            _creditCardDal.Add(card);
            return new SuccessResult(Messages.CreditCardAdded);
        }

        [Authentication]
        public IDataResult<List<CreditCard>> GetCards()
        {
            int authUserId = _httpContextAccessor.HttpContext.User.GetAuthenticatedUserId();
            var customer = _customerService.GetByUserId(authUserId);
            if (customer.Success == false)
            {
                return new ErrorDataResult<List<CreditCard>>();
            }

            var result = _creditCardDal.GetAll(c=>c.CustomerId==customer.Data.Id);
            if (result == null)
            {
                return new ErrorDataResult<List<CreditCard>>(Messages.CreditCardNotFound);
            }
            return new SuccessDataResult<List<CreditCard>>(result);
        }

        private IResult IsCardExist(string cardNumber)
        {
            var result = _creditCardDal.Get(c => c.CardNumber == cardNumber);
            if (result != null)
            {
                return new ErrorResult(Messages.CardAlreadyExist);
            }
            return new SuccessResult();
        }

    }
}
