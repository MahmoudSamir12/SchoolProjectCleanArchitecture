using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Localization;
using SchoolProject.Core.Bases;
using SchoolProject.Core.Features.Users.Commands.Models;
using SchoolProject.Core.Resources;
using SchoolProject.Data.Entities.Identity;
using SchoolProject.Service.IServices;

namespace SchoolProject.Core.Features.Users.Commands.Handlers
{
    public class UserCommandHandler : ResponseHandler,
                                IRequestHandler<AddUserCommand, Response<string>>,
                                IRequestHandler<EditUserCommand, Response<string>>,
                                IRequestHandler<DeleteUserCommand, Response<string>>,
                                IRequestHandler<ChangeUserPasswordCommand, Response<string>>
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

        #region AddUserHandler
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
                return BadRequest<string>(_localizer[SharedResourcesKeys.FailedToAddUser]);
            //return BadRequest<string>(createUser.Errors.FirstOrDefault().Description);

            return Created("");
        }
        #endregion

        #region EditUserHandler
        public async Task<Response<string>> Handle(EditUserCommand request, CancellationToken cancellationToken)
        {
            var existedUser = await _userManager.Users.FirstOrDefaultAsync(u => u.Id.Equals(request.Id));
            //if (existedUser == null) return NotFound<string>(_localizer[SharedResourcesKeys.NotFound]);
            if (existedUser == null) return NotFound<string>();

            var newUser = _mapper.Map(request, existedUser);

            //Check if the entered UserName is existed or not
            var userUserName = await _userManager.Users.FirstOrDefaultAsync(x => x.UserName == newUser.UserName && x.Id != newUser.Id);
            if (userUserName != null)
                return BadRequest<string>(_localizer[SharedResourcesKeys.UserNameIsExist]);

            var result = await _userManager.UpdateAsync(newUser);
            if (result.Succeeded)
                return Success((string)_localizer[SharedResourcesKeys.Updated] + " " + $"{newUser.Id}");
            //return Success($"Updated Successfully {newUser.Id}");
            else
                return BadRequest<string>(_localizer[SharedResourcesKeys.UpdatedFailed]);
        }
        #endregion

        #region DeleteUserHandler
        public async Task<Response<string>> Handle(DeleteUserCommand request, CancellationToken cancellationToken)
        {
            var checkedUser = await _userManager.Users.FirstOrDefaultAsync(u => u.Id.Equals(request.Id));
            if (checkedUser == null) return NotFound<string>(_localizer[SharedResourcesKeys.DeletedFailed]);

            var result = await _userManager.DeleteAsync(checkedUser);
            if (result.Succeeded)
                return Deleted<string>(_localizer[SharedResourcesKeys.Deleted] + " " + $"{checkedUser.Id}");
            else
                return BadRequest<string>();
        }
        #endregion

        #region ChangeUserPasswordHandler
        public async Task<Response<string>> Handle(ChangeUserPasswordCommand request, CancellationToken cancellationToken)
        {
            var user = await _userManager.Users.FirstOrDefaultAsync(u => u.Id.Equals(request.Id));
            //if (existedUser == null) return NotFound<string>(_localizer[SharedResourcesKeys.NotFound]);
            if (user == null) return NotFound<string>();

            //var newUser = _mapper.Map(request, existedUser);

            var result = await _userManager.ChangePasswordAsync(user, request.CurrentPassword, request.NewPassword);
            #region Another way
            //var user1 = await _userManager.HasPasswordAsync(user);
            //await _userManager.RemovePasswordAsync(user);
            //await _userManager.AddPasswordAsync(user, request.NewPassword);
            #endregion

            if (result.Succeeded)
                return Success((string)_localizer[SharedResourcesKeys.Updated]);
            else
                //return BadRequest<string>(_localizer[SharedResourcesKeys.ChangePasswordFailed]);
                return BadRequest<string>(result.Errors.FirstOrDefault().Description);
        }
        #endregion
    }
}
