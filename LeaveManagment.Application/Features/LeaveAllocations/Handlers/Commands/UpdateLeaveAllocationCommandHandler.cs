using AutoMapper;
using LeaveManagment.Application.DTOs.LeaveAllocation.Validators;
using LeaveManagment.Application.Exceptions;
using LeaveManagment.Application.Features.LeaveAllocations.Requests.Commands;
using LeaveManagment.Application.Contracts.Persistence;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace LeaveManagment.Application.Features.LeaveAllocations.Handlers.Commands
{
    public class UpdateLeaveAllocationCommandHandler : IRequestHandler<UpdateLeaveAllocationCommandRequest, Unit>
    {

        private readonly ILeaveAllocationRepository _leaveAllocationRepository;
        private readonly IMapper _mapper;
        private readonly ILeaveTypeRepository _leaveTypeRepository;

        public UpdateLeaveAllocationCommandHandler(ILeaveAllocationRepository leaveAllocationRepository, IMapper mapper, ILeaveTypeRepository leaveTypeRepository)
        {
            _leaveAllocationRepository = leaveAllocationRepository;
            _mapper = mapper;
            _leaveTypeRepository = leaveTypeRepository;

        }

        public async Task<Unit> Handle(UpdateLeaveAllocationCommandRequest request, CancellationToken cancellationToken)
        {

            var valodator = new UpdateLeaveAllocationDtoValidator(_leaveTypeRepository);
            var validationResult = await valodator.ValidateAsync(request.UpdateLeaveAllocationDto);

            if (!validationResult.IsValid)
                throw new ValidationException(validationResult);


            var leaveAllocation = await _leaveAllocationRepository.Get(request.UpdateLeaveAllocationDto.Id);
            _mapper.Map(request.UpdateLeaveAllocationDto, leaveAllocation);

            await _leaveAllocationRepository.Update(leaveAllocation);

            return Unit.Value;
        }
    }
}
