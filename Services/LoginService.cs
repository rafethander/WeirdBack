using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WeirdBack.Dtos;
using WeirdBack.Helper;
using WeirdBack.Models;

namespace WeirdBack.Services
{
    public interface ILoginService
    {
        Task<ApiResults> Login(LoginDtos model);
    }
    public class LoginService:ILoginService
    {
        private readonly WeirdBackDbContext _context;
        public LoginService(WeirdBackDbContext context)
        {
            _context = context;
        }

        public async Task<ApiResults> Login(LoginDtos model)
        {
            var entity = await _context.Login.Where(x => x.Username == model.Username && x.Password == model.Password).FirstOrDefaultAsync();

            if (entity == null)
                return new ApiResults { Data = model.Username, Message = ApiResultMessages.UNW001 };

            return new ApiResults { Data = model.Username, Message = ApiResultMessages.Ok };
        }
    }
}
