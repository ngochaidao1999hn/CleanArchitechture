using CleanArchitechture.Application.Dtos.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitechture.Application.Services.Auth
{
    public interface ITokenService
    {
        string GenerateToken(GetUserDto user);
    }
}
