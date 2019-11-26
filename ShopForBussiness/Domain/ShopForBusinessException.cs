using System;

namespace ShopForBussiness.Domain
{
    public class ShopForBusinessException : Exception
    {
        public string DomainMessage { get; private set; }
        public ShopForBusinessException(string message) : base()
        {
            DomainMessage = message;
        }
    }
}