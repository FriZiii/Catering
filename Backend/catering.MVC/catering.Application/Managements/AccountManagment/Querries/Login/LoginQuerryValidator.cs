using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace catering.Application.Managements.AccountManagment.Querries.Login
{
    public class LoginQuerryValidator : AbstractValidator<LoginQuerry>
    {
        public LoginQuerryValidator()
        {
            RuleFor(c => c.Email)
                .NotEmpty();

            RuleFor(c => c.Password)
                .NotEmpty();
        }
    }
}
