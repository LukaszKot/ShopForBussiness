using System.Collections.Generic;

namespace ShopForBussiness.Domain
{
    public class Order
    {
        public int ID { get; private set; }
        public int UserID { get; private set; }
        public string Status { get; private set; }
        public string Products { get; private set; }
        public virtual User User { get; set; }

        protected Order()
        {

        }

        public Order(int id, int userId, IEnumerable<int> products,string status = "ROZPOCZĘTO")
        {
            ID = id;
            UserID = userId;
            Products = Serialize(products);
            Status = status;
        }

        public void SetStatus(string status)
        {
            if(status!=OrderStatuses.BEGINNED && status!=OrderStatuses.PREPARED_FOR_SENT && status!=OrderStatuses.SENT && status!=OrderStatuses.DELIVERED)
            {
                throw new DomainException(ErrorMessages.INVALID_ORDER_STATUS);
            }
            Status = status;
        }

        private string Serialize(IEnumerable<int> products)
        {
            var serializer = new System.Web.Script.Serialization.JavaScriptSerializer();
            return serializer.Serialize(products);
        }

        private IEnumerable<int> Deserialize(string str)
        {
            var serializer = new System.Web.Script.Serialization.JavaScriptSerializer();
            return serializer.Deserialize<IEnumerable<int>>(str);
        }

        public void SetProducts(IEnumerable<int> products)
        {
            Products = Serialize(products);
        }

        public IEnumerable<int> GetProduct()
        {
            return Deserialize(Products);
        }
    }
}