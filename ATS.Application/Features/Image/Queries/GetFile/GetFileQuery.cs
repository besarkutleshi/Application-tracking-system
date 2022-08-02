using ATS.Application.DTO_s.Applicant.Image;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace ATS.Application.Features.Image.Queries.GetFile
{
    public record GetFileQuery(GetFileDTO getFile) : IRequest<FileContentResult>;
}
