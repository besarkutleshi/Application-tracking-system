using ATS.Application.DTO_s.Applicant.Image;
using MediatR;

namespace ATS.Application.Features.Image.Queries.ReadFile
{
    public record ReadFileQuery(GetFileDTO getFile) : IRequest<byte[]>;
}
