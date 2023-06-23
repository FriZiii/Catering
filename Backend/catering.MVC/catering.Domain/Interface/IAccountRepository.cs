using catering.Domain.Entities.User.RegisterInput;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace catering.Domain.Interface
{
    public interface IAccountRepository
    {
        Task RegisterUser(AccountRegisterInput registerInput);
    }
}
