using ShopForBussiness.Dto;
using System.Threading.Tasks;

namespace ShopForBussiness.Services
{
    public interface IUserService
    {
        Task<string> RegisterAsync(string email, string password, string passwordRetyped, bool isRegulationsChecked);
        Task<string> LoginAsync(string email, string password);
        Task<UserDto> GetUser(int id);
    }
}
