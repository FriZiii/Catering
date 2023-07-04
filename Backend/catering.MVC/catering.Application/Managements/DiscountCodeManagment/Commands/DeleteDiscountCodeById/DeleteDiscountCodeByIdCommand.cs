using MediatR;

namespace catering.Application.Managements.DiscountCodeManagment.Commands.DeleteDiscountCodeById
{
    public class DeleteDiscountCodeByIdCommand : IRequest
    {
        public DeleteDiscountCodeByIdCommand(int id)
        {
            Id = id;
        }

        public int Id { get; }
    }
}
