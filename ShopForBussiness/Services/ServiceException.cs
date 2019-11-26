using ShopForBussiness.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ShopForBussiness.Services
{
    public class ServiceException : ShopForBusinessException
    {
        public ServiceException(string message) : base(message)
        {
        }
    }
}