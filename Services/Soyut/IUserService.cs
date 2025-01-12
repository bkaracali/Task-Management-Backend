using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities.Models;
using Services.DTO;


namespace Services.Soyut
{  
    public interface IUserService : IBaseService<User> 
    {
        LoginDTO AuthUser(string Email,  string password);
        RegisterDTO Register(string name, string Email, string password);
    }
}
