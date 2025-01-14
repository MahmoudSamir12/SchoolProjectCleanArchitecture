using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Localization;
using SchoolProject.Core.Bases;
using SchoolProject.Core.Features.Users.Commands.Models;
using SchoolProject.Core.Resources;
using SchoolProject.Data.Entities.Identity;
using SchoolProject.Service.IServices;

namespace SchoolProject.Core.Features.Users.Commands.Handlers
{
    public class UserCommandHandler : ResponseHandler,
                                IRequestHandler<AddUserCommand, Response<string>>
    {
        private readonly IMapper _mapper;
        private readonly IUserService _userService;
        private readonly UserManager<User> _userManager;
        private readonly IStringLocalizer<SharedResources> _localizer;
        public UserCommandHandler(IMapper mapper, IUserService userService,
                                UserManager<User> userManager,
                                IStringLocalizer<SharedResources> localizer) : base(localizer)
        {
            _mapper = mapper;
            _userService = userService;
            _userManager = userManager;
            _localizer = localizer;
        }

        #region AddUser
        public async Task<Response<string>> Handle(AddUserCommand request, CancellationToken cancellationToken)
        {
            //Check if the entered email is existed or not
            var userEmail = await _userManager.FindByEmailAsync(request.Email);
            //email is exist
            if (userEmail != null)
                return BadRequest<string>(_localizer[SharedResourcesKeys.EmailIsExist]);

            //Check if the entered UserName is existed or not
            var userUserName = await _userManager.FindByNameAsync(request.UserName);
            //userUserName is exist
            if (userUserName != null)
                return BadRequest<string>(_localizer[SharedResourcesKeys.UserNameIsExist]);

            //Mapping
            var IdentityUser = _mapper.Map<User>(request);
            var createUser = await _userManager.CreateAsync(IdentityUser, request.Password);
            if (!createUser.Succeeded)
                //return BadRequest<string>(_localizer[SharedResourcesKeys.FailedToAddUser]);
                return BadRequest<string>(createUser.Errors.FirstOrDefault().Description);

            return Created("");
        }
        #endregion
    }
}
