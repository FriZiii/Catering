using catering.Application.Managements.AccountManagment.AccountDtos;
using MediatR;
using Microsoft.AspNetCore.Identity;

namespace catering.Application.Managements.AccountManagment.Querries.Login
{
    public class LoginQuerry : LoginInputDto, IRequest<SignInResult>
    {
    }
}
