using catering.Application.Managements.AccountManagment.AccountDtos;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace catering.Application.Managements.AccountManagment.Commands.Register
{
    public class RegisterCommand : RegisterInputDto, IRequest
    {

    }
}
