using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ShopForBussiness.Domain
{
    public static class OrderStatuses
    {
        public static string BEGINNED => "ROZPOCZĘTO";
        public static string PREPARED_FOR_SENT => "PRZYGOTOWANO DO WYSYŁKI";
        public static string SENT => "WYSŁANO";
        public static string DELIVERED => "DOSTARCZONO";
    }
}