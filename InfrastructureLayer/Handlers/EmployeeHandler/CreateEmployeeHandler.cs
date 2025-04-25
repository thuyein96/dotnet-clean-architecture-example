﻿using ApplicationLayer.Commands;
using ApplicationLayer.DTOs;
using InfrastructureLayer.Data;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace InfrastructureLayer.Handlers.EmployeeHandler;

public class CreateEmployeeHandler : IRequestHandler<CreateEmployeeCommand, ServiceResponse>
{
    private readonly AppDbContext _appDbContext;

    public CreateEmployeeHandler(AppDbContext appDbContext)
    {
        _appDbContext = appDbContext;
    }
    public async Task<ServiceResponse> Handle(CreateEmployeeCommand request, CancellationToken cancellationToken)
    {
        var check = await _appDbContext.Employees.FirstOrDefaultAsync(x => x.Name.ToLower() == request.Employee.Name.ToLower());
        if (check != null)
            return new ServiceResponse(false, "User already exists.");

        _appDbContext.Employees.Add(request.Employee);
        await _appDbContext.SaveChangesAsync(cancellationToken);
        return new ServiceResponse(true, "User added successfully.");
    }
}