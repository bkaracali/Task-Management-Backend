using Entities.Models;
using Repo.Somut;
using Repo.Soyut;
using Services.DTO;
using Services.Soyut;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Services.Somut
{
    public class PasswordService : BaseService<PasswordTask>, IPasswordService
    {
        protected readonly IPasswordRepository _passwordRepository;
        protected readonly IUserPasswordRepository _userPasswordRepository;
        public PasswordService(IPasswordRepository repository, IUserPasswordRepository userPasswordRepository) : base(repository)
        {
            _passwordRepository = repository;
            _userPasswordRepository = userPasswordRepository;
        }
        public PasswordDTO CreatePasswordTaskWithReminder(PasswordDTO passwordDTO)
        {
            // Yeni bir PasswordTask nesnesi oluştur
            var passwordTask = new PasswordTask
            {
                DefaultMessage = passwordDTO.DefaultMessage,
                ReminderInterval = passwordDTO.ReminderInterval,                
                JobId = 2 // Sabit olarak tanımlandığı belirtildi
            };

            // PasswordTask kaydını veritabanına ekle
            _passwordRepository.Add(passwordTask);
           

            // UserPassword kaydını oluştur ve ekle
            var userPassword = new UserPassword
            {
                PasswordId = passwordTask.PasswordTaskId,
                UserId = passwordDTO.UserId
            };
            _userPasswordRepository.Add(userPassword);


            return new PasswordDTO
            {
                UserId = userPassword.UserId,
                PasswordTaskId = passwordTask.PasswordTaskId,
                DefaultMessage = passwordTask.DefaultMessage,
                ReminderInterval = passwordTask.ReminderInterval,

            };
        }
    }
}
