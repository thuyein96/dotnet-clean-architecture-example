using ApplicationLayer.Commands;
using ApplicationLayer.Queries.EmployeeQuery;
using DomainLayer.Entities;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class EmployeeController : ControllerBase
{
    private readonly IMediator _mediator;

    public EmployeeController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    public async Task<IActionResult> Get() 
        => Ok(await _mediator.Send(new GetEmployeeListQuery()));

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(int id) 
        => Ok(await _mediator.Send(new GetEmployeeByIdQuery { Id = id }));

    [HttpPost]
    public async Task<IActionResult> Add([FromBody] Employee employeeDto) 
        => Ok(await _mediator.Send(new CreateEmployeeCommand { Employee = employeeDto }));

    [HttpPut]
    public async Task<IActionResult> Update([FromBody] Employee employeeDto)
        => Ok(await _mediator.Send(new UpdateEmployeeCommand { Employee = employeeDto }));

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
        => Ok(await _mediator.Send(new DeleteEmployeeCommand { Id = id }));
}