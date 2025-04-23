using ApplicationLayer.Contracts;
using ApplicationLayer.DTOs;
using DomainLayer.Entities;
using InfrastructureLayer.Data;
using Microsoft.EntityFrameworkCore;

namespace InfrastructureLayer.Implementations;

public class EmployeeRepo : IEmployee
{
    private readonly AppDbContext _appDbContext;

    public EmployeeRepo(AppDbContext appDbContext)
    {
        _appDbContext = appDbContext;
    }
    public async Task<ServiceResponse> AddAsync(Employee employee)
    {
        _appDbContext.Employees.Add(employee);
        await SaveChangesAsync();
        return new ServiceResponse(true, "User added successfully.");
    }

    public async Task<ServiceResponse> UpdateAsync(Employee employee)
    {
        _appDbContext.Update(employee);
        await SaveChangesAsync();
        return new ServiceResponse(true, "User updated successfully.");
    }

    public async Task<ServiceResponse> DeleteAsync(int Id)
    {
        var employee = await _appDbContext.Employees.FindAsync(Id);
        if (employee == null)
            return new ServiceResponse(false, "User not found.");

        _appDbContext.Employees.Remove(employee);
        await SaveChangesAsync();
        return new ServiceResponse(true, "User deleted successfully.");
    }

    public async Task<List<Employee>> GetAsync() => await _appDbContext.Employees.AsNoTracking().ToListAsync();

    public async Task<Employee> GetByIdAsync(int id) => await _appDbContext.Employees.FindAsync(id);

    private async Task SaveChangesAsync() => await _appDbContext.SaveChangesAsync();
}