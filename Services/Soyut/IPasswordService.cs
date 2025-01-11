using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities.Models;
using Services.DTO;

namespace Services.Soyut
{
    public interface IPasswordService : IBaseService<PasswordTask>
    {
        public PasswordDTO CreatePasswordTaskWithReminder(PasswordDTO passwordDTO);
    }
}
