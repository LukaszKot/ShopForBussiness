namespace ShopForBussiness.Domain
{
    public class Product
    {
        public int ID { get; private set; }
        public string Name { get; set; }
        public string Category { get; set; }
        public float Prize { get; private set; } 
        public string Description { get; set; }
        public int AmountInMagazine { get; private set; }

        protected Product()
        {

        }

        public Product(int id, string name, string category, float prize, string description, int amountInMagazine)
        {
            ID = id;
            Name = name;
            Category = category;
            SetPrize(prize);
            Description = description;
            SetAmountInMagazine(amountInMagazine);
        }

        public void SetAmountInMagazine(int amountInMagazine)
        {
            if (amountInMagazine <= 0) throw new DomainException(ErrorMessages.INVALID_AMOUNT);
            AmountInMagazine = amountInMagazine;
        }

        public void SetPrize(float prize)
        {
            if (prize <= 0f) throw new DomainException(ErrorMessages.INVALID_PRIZE);
            Prize = prize;
        }
    }
}