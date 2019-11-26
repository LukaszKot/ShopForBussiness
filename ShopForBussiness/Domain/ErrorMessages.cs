namespace ShopForBussiness.Domain
{
    public static class ErrorMessages
    {
        public static string INVALID_ID_WAS_GIVEN => "Podano niepoprawne id.";
        public static string GIVEN_EMAIL_IS_ALREADY_IN_USE => "Podany email już jest w użyciu.";
        public static string INVALID_ROLE_WAS_GIVEN => "Podano niewłaściwą rolę.";
        public static string INVALID_PRIZE => "Cena musi być większa od zera.";
        public static string INVALID_AMOUNT => "Ilość musi być większa lub równa zero.";
        public static string INVALID_NAME => "Podano niepoprawne imię.";
        public static string INVALID_SURNAME => "Podano niepoprawne nazwisko.";
        public static string INVALID_STREET_NAME => "Podano niepoprawną nazwę ulicy.";
        public static string INVALID_PROPERTY_NUMBER => "Podano nieprawny numer domu.";
        public static string INVALID_NUMBER_OF_PREMISES => "Podano niepoprawny numer mieszkania.";
        public static string INVALID_ZIPCODE => "Podano niepoprawny kod pocztowy.";
        public static string INVALID_CITY => "Podano niepoprawną nazwę miasta.";
        public static string INVALID_ORDER_STATUS => "Nieporawny status zamówienia";
    }
}