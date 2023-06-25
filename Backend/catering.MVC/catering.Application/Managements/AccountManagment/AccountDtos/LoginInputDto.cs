using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace catering.Application.Managements.AccountManagment.AccountDtos
{
    public class LoginInputDto
    {
        public string Email { get; set; } = default!;
        public string Password { get; set; } = default!;
    }
}
