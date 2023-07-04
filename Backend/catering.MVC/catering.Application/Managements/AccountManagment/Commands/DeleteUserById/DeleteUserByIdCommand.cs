using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace catering.Application.Managements.AccountManagment.Commands.DeleteUserById
{
    public class DeleteUserByIdCommand : IRequest
    {
        public DeleteUserByIdCommand(string id)
        {
            Id = id;
        }

        public string Id { get; }
    }
}
