using DomainLayer.Entities;
using MediatR;

namespace ApplicationLayer.Queries.EmployeeQuery;

public class GetEmployeeByIdQuery : IRequest<Employee>
{
    public int Id { get; set; }
}