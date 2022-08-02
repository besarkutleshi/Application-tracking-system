using ATS.Application.DTO_s.Administration.Applications;
using FluentValidation;
namespace ATS.Application.Features.Applications.Notes.Commands.CreateNote
{
    public class CreateNoteValidator : AbstractValidator<CreateNoteDTO>
    {
        public CreateNoteValidator()
        {
            RuleFor(a => a.NoteText).NotEmpty();
            RuleFor(a => a.InsertBy).GreaterThan(0);
            RuleFor(a => a.ApplicantProfileId).GreaterThan(0);
            RuleFor(a => a.ApplicationId).GreaterThan(0);
        }
    }
}
