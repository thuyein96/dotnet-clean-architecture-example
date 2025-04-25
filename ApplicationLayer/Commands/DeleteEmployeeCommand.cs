using ApplicationLayer.DTOs;
using MediatR;

namespace ApplicationLayer.Commands;

public class DeleteEmployeeCommand : IRequest<ServiceResponse>
{
    public int Id { get; set; }
}