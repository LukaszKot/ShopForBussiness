using ShopForBussiness.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace ShopForBussiness.Repositories
{
    public interface IUserRepository
    {
        Task<User> GetAsync(string email);
        Task AddAsync(User user);
        Task<User> GetAsync(int id);
    }
}