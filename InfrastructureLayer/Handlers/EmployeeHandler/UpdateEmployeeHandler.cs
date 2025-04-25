using ApplicationLayer.Commands;
using ApplicationLayer.DTOs;
using InfrastructureLayer.Data;
using MediatR;

namespace InfrastructureLayer.Handlers.EmployeeHandler;

public class UpdateEmployeeHandler : IRequestHandler<UpdateEmployeeCommand, ServiceResponse>
{
    private readonly AppDbContext _appDbContext;

    public UpdateEmployeeHandler(AppDbContext appDbContext)
    {
        _appDbContext = appDbContext;
    }
    public async Task<ServiceResponse> Handle(UpdateEmployeeCommand request, CancellationToken cancellationToken)
    {
        _appDbContext.Update(request.Employee);
        await _appDbContext.SaveChangesAsync(cancellationToken);
        return new ServiceResponse(true, "User updated successfully.");
    }
}