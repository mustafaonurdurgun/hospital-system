using Business.Models.Request.Create;
using Business.Models.Request.Update;
using Business.Models.Response;
using Business.Services.Interface;
using Core.Results;
using Infrastructure.Data.Postgres.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Web.Controllers.Base;

namespace Web.Controllers
{
   
    public class UserController : BaseCRUDController<User, int, RegisterDto, UpdateUserDTO, UserProfileDto>
    {
        IUserService _service;
        public UserController(IUserService service) : base(service)
        {
            _service = service;
        }

        [HttpPut]
        public virtual async Task<ActionResult<Result>> ChangePassword(PasswordChangeDTO pwDto)
           => await _service.ChangePasswordAsync(pwDto);
    }
}
