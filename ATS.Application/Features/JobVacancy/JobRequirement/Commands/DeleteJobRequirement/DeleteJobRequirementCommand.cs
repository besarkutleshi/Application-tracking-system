using MediatR;

namespace ATS.Application.Features.JobVacancy.JobRequirement.Commands.DeleteJobRequirement
{
    public record DeleteJobRequirementCommand(int jobRequirementId) : IRequest<bool>;
}
