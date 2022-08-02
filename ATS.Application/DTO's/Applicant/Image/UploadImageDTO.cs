using Microsoft.AspNetCore.Http;

namespace ATS.Application.DTO_s.Applicant.Image
{
    public class UploadImageDTO
    {
        public IFormFile? File { get; set; }
        public string? Folder { get; set; }
        public int UserId { get; set; }
    }
}
