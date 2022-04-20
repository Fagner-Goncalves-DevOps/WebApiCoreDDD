using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services
{
    public class UserService
    {
        /*
        private readonly IMapper _mapper;
        private readonly IUserRepository _repository;


        public UserService( IMapper mapper,
                            IUserRepository repository
                            )
        {
            _mapper = mapper;
            _tokenService = tokenService;
            _repository = repository;
        }

        public UserResponseAuthenticateDto Authenticate(UserRequestAuthenticateViewModel user)
        {
            User _user = repository.GetByEmailAndPassword(user.Email, UtilsService.EncryptPassword(user.Password));
            if (_user == null)
                throw new ApiException("Email/Password not found", HttpStatusCode.NotFound);

            if (!_user.IsAuthorised)
                throw new ApiException("Your account is not activate yet.", HttpStatusCode.NotFound);

            string token = tokenService.GenerateToken(mapper.Map<ContextUserViewModel>(_user));

            UserResponseAuthenticateDto _userResponse = mapper.Map<UserResponseAuthenticateViewModel>(_user);
            _userResponse.Token = token;

            return _userResponse;
        }
        */
    }
}
