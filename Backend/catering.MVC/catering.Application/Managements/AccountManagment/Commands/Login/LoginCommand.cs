using catering.Application.Managements.AccountManagment.AccountDtos;
using MediatR;

namespace catering.Application.Managements.AccountManagment.Commands.Login
{
    public class LoginCommand : LoginInputDto, IRequest
    {

    }
}
