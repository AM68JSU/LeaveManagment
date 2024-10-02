using LeaveManagment.Application.DTOs.LeaveType;
using LeaveManagment.Application.Features.LeaveTypes.Requests.Commands;
using LeaveManagment.Application.Features.LeaveTypes.Requests.Queries;
using LeaveManagment.Application.Responses;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace LeaveManagment.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]    
    [Authorize]
    public class LeaveTypesController : ControllerBase
    {
        private readonly IMediator _mediator;

        public LeaveTypesController(IMediator mediator)
        {
            _mediator = mediator;
        }

        // GET: api/<LeaveTypesController>
        [HttpGet]
        public async Task<ActionResult<List<LeaveTypeDto>>> Get()
        {
            var leavetypes = await _mediator.Send(new GetLeaveTypeListQueryRequest());
            return  Ok(leavetypes);
        }

        // GET api/<LeaveTypesController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<LeaveTypeDto>> Get(int id)
        {
            var leavetype = await _mediator.Send(new GetLeaveTypeDetailQueryRequest { Id=id});
            return Ok(leavetype);
        }

        // POST api/<LeaveTypesController>
        [HttpPost]
        public async Task<ActionResult<BaseCommandResponse>> Post([FromBody] CreateLeaveTypeDto leaveType)
        {
            var command = new CreateLeaveTypeCommandRequest { CreateLeaveTypeDto= leaveType };
           var response= await _mediator.Send(command);
            return Ok(response);
        }

        // PUT api/<LeaveTypesController>/5
        [HttpPut("{id}")]
        public async Task<ActionResult<BaseCommandResponse>> Put(int id, [FromBody] UpdateLeaveTypeDto leaveType)
        {
            var command = new UpdateLeaveTypeCommandRequest { UpdateLeaveTypeDto = leaveType,Id=id };
            var response = await _mediator.Send(command);
            return Ok(response);
        }

        // DELETE api/<LeaveTypesController>/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<BaseCommandResponse>> Delete(int id)
        {
            var command = new DeleteLeaveTypeCommandRequest { Id = id };
            var response = await _mediator.Send(command);
            return Ok(response);
        }
    }
}
