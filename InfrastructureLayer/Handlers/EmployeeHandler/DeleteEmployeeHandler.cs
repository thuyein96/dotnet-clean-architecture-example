using ApplicationLayer.Commands;
using ApplicationLayer.DTOs;
using InfrastructureLayer.Data;
using MediatR;

namespace InfrastructureLayer.Handlers.EmployeeHandler;

public class DeleteEmployeeHandler : IRequestHandler<DeleteEmployeeCommand, ServiceResponse>
{
    private readonly AppDbContext _appDbContext;

    public DeleteEmployeeHandler(AppDbContext appDbContext)
    {
        _appDbContext = appDbContext;
    }
    public async Task<ServiceResponse> Handle(DeleteEmployeeCommand request, CancellationToken cancellationToken)
    {
        var employee = await _appDbContext.Employees.FindAsync(request.Id);
        if (employee == null)
            return new ServiceResponse(false, "User not found.");

        _appDbContext.Employees.Remove(employee);
        await _appDbContext.SaveChangesAsync(cancellationToken);
        return new ServiceResponse(true, "User deleted successfully.");
    }
}