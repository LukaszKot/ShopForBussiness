using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ShopForBussiness.Domain
{
    public class DomainException : ShopForBusinessException
    {
        public DomainException(string message) : base(message)
        {
        }
    }
}