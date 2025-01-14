using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Localization;
using SchoolProject.Core.Bases;
using SchoolProject.Core.Features.Users.Queries.DTOs;
using SchoolProject.Core.Features.Users.Queries.Models;
using SchoolProject.Core.Resources;
using SchoolProject.Core.Wrappers;
using SchoolProject.Data.Entities.Identity;

namespace SchoolProject.Core.Features.Users.Queries.Handlers
{
    public class UserQueryHandler : ResponseHandler,
                    IRequestHandler<GetUsersPaginationQuery, PaginatedResult<GetUserPaginatedListQueryDto>>,
                    IRequestHandler<GetUserByIdQuery, Response<GetUserByIdDto>>

    {
        private readonly IMapper _mapper;
        private readonly UserManager<User> _userManager;
        private readonly IStringLocalizer<SharedResources> _localizer;

        public UserQueryHandler(IMapper mapper, UserManager<User> userManager,
                        IStringLocalizer<SharedResources> localizer) : base(localizer)
        {
            _mapper = mapper;
            _userManager = userManager;
            _localizer = localizer;
        }

        #region PaginatedUsersHandler
        public async Task<PaginatedResult<GetUserPaginatedListQueryDto>> Handle(GetUsersPaginationQuery request, CancellationToken cancellationToken)
        {
            var users = _userManager.Users.AsQueryable();
            var paginatedList = await _mapper.ProjectTo<GetUserPaginatedListQueryDto>(users)
                                                .ToPaginatedListAsync(request.PageNumber, request.PageSize);

            return paginatedList;
        }
        #endregion

        #region UserByIdHandler
        public async Task<Response<GetUserByIdDto>> Handle(GetUserByIdQuery request, CancellationToken cancellationToken)
        {
            //var user = await _userManager.FindByIdAsync(request.Id.ToString());
            //OR
            var user = await _userManager.Users.FirstOrDefaultAsync(u => u.Id.Equals(request.Id));
            if (user == null) return NotFound<GetUserByIdDto>(_localizer[SharedResourcesKeys.NotFound]);
            var userResult = _mapper.Map<GetUserByIdDto>(user);
            return Success(userResult);
        }
        #endregion
    }
}
