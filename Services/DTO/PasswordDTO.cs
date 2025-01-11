using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.DTO
{
    public  class  PasswordDTO
    {
        public int UserId { get; set; }
        public int PasswordTaskId { get; set; }
        public string? DefaultMessage { get; set; }
        public TimeSpan ReminderInterval { get; set; }
      
    }
}
