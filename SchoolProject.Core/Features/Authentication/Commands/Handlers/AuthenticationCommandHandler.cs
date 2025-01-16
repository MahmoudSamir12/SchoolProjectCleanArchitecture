using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Localization;
using SchoolProject.Core.Bases;
using SchoolProject.Core.Features.Authentication.Commands.Models;
using SchoolProject.Core.Resources;
using SchoolProject.Data.Entities.Identity;
using SchoolProject.Service.IServices;

namespace SchoolProject.Core.Features.Authentication.Commands.Handlers
{
    public class AuthenticationCommandHandler : ResponseHandler,
                                    IRequestHandler<SignInCommand, Response<string>>
    {
        private readonly IMapper _mapper;
        private readonly IAuthenticationService _authenticationService;
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;
        private readonly IStringLocalizer<SharedResources> _localizer;

        public AuthenticationCommandHandler(IMapper mapper, UserManager<User> userManager,
                                IAuthenticationService authenticationService,
                                SignInManager<User> signInManager,
                                IStringLocalizer<SharedResources> localizer) : base(localizer)
        {
            _mapper = mapper;
            _authenticationService = authenticationService;
            _userManager = userManager;
            _signInManager = signInManager;
            _localizer = localizer;
        }

        #region SignInHandler

        public async Task<Response<string>> Handle(SignInCommand request, CancellationToken cancellationToken)
        {
            var user = await _userManager.FindByEmailAsync(request.Email);
            if (user == null)
                return BadRequest<string>(_localizer[SharedResourcesKeys.EmailIsNotExist]);

            var signInResult = await _signInManager.CheckPasswordSignInAsync(user, request.Password, false);
            if (!signInResult.Succeeded)
                return BadRequest<string>(_localizer[SharedResourcesKeys.PasswordNotCorrect]);

            var accesstoken = await _authenticationService.GetJWTToken(user);

            return Success(accesstoken);
        }

        #endregion
    }
}
