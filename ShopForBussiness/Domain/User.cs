using ShopForBussiness.Extensions;
using System;
using System.Collections.Generic;

namespace ShopForBussiness.Domain
{
    public class User
    {
        public int ID { get; private set; }
        public string Email { get; private set; }
        public string Hash { get; private set; }
        public string Salt { get; private set; }
        public string Role { get; private set; }

        public virtual Address Address { get; set; }
        public virtual ICollection<Order> Orders { get; set; }

        protected User() { }
        public User(int id, string email, string hash, string salt, string role="customer")
        {
            SetId(id);
            SetEmail(email);
            SetPassword(hash, salt);
            SetRole(role);
        }

        private void SetId(int id)
        {
            if (id <= 0) throw new DomainException(ErrorMessages.INVALID_ID_WAS_GIVEN);
            ID = id;
        }

        public void SetEmail(string email)
        {
            if (!IsEmailVaild(email))
                throw new DomainException(ErrorMessages.GIVEN_EMAIL_IS_ALREADY_IN_USE);
            Email = email;
        }

        public void SetPassword(string hash, string salt)
        {
            if (!hash.IsNotEmpty()) throw new ArgumentNullException();
            if (!salt.IsNotEmpty()) throw new ArgumentNullException();
            Hash = hash;
            Salt = salt;
        }

        public void SetRole(string role)
        {
            if (role != Roles.Admin && role != Roles.Customer)
                throw new DomainException(ErrorMessages.INVALID_ROLE_WAS_GIVEN);
            Role = role;
        }

        private bool IsEmailVaild(string email)
        {
            try
            {
                var addr = new System.Net.Mail.MailAddress(email);
                return addr.Address == email;
            }
            catch
            {
                return false;
            }
        }

    }
}