using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace catering.Application.Managements.AccountManagment.AccountDtos
{
    public class RegisterInputDto : DeliveryAdressInputDto
    {
        public string FirstName { get; set; } = default!;
        public string LastName { get; set; } = default!;
        public string Email { get; set; } = default!;
        public string Password { get; set; } = default!;
        public string PasswordConfirm { get; set; } = default!;
        public DateTime BirthDate { get; set; } = default!;
    }
}
