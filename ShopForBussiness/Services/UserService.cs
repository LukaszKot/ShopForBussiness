using AutoMapper;
using ShopForBussiness.Domain;
using ShopForBussiness.Dto;
using ShopForBussiness.Repositories;
using System.Threading.Tasks;

namespace ShopForBussiness.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IEncrypter _encrypter;
        private readonly IMapper _mapper;
        public UserService(IUserRepository userRepository, IEncrypter encrypter, IMapper mapper)
        {
            _userRepository = userRepository;
            _encrypter = encrypter;
            _mapper = mapper;
        }

        public async Task<UserDto> GetUser(int id)
        {
            var user = await _userRepository.GetAsync(id);
            return _mapper.Map<UserDto>(user);
        }

        public async Task<string> LoginAsync(string email, string password)
        {
            try
            {
                var user = await _userRepository.GetAsync(email);
                if (user == null) throw new ServiceException(Messages.INVALID_CREDENTIALS);
                var hash = _encrypter.GetHash(password, user.Salt);
                if (hash != user.Hash) throw new ServiceException(Messages.INVALID_CREDENTIALS);
                return user.ID.ToString();
            }
            catch (ShopForBusinessException ex)
            {
                return ex.DomainMessage;
            }
        }

        public async Task<string> RegisterAsync(string email, string password, string passwordRetyped, bool isRegulationsChecked)
        {
            try
            {
                var user = await _userRepository.GetAsync(email);
                if (user != null) throw new ServiceException(Messages.USER_WITH_THAT_EMAIL_ALREADY_EXISTS);
                if (password != passwordRetyped) throw new ServiceException(Messages.PASSWORDS_HAS_TO_BE_IDENTICAL);
                string salt = _encrypter.GetSalt();
                string hash = _encrypter.GetHash(password, salt);
                if (!isRegulationsChecked) throw new ServiceException(Messages.REGULATIONS_HAS_TO_BE_ACCEPTED);
                user = new User(1, email, hash, salt);
                await _userRepository.AddAsync(user);
            }
            catch(ShopForBusinessException ex)
            {
                return ex.DomainMessage;
            }
            return Messages.USER_CREATED;
        }
    }
}