using ATS.Application.DTO_s.Administration.Applications;
using FluentValidation;

namespace ATS.Application.Features.Applications.Notes.Commands.UpdateNote
{
    public class UpdateNoteValidator : AbstractValidator<UpdateNoteDTO>
    {
        public UpdateNoteValidator()
        {
            RuleFor(a => a.Id).GreaterThan(0);
            RuleFor(a => a.NoteText).NotEmpty();
            RuleFor(a => a.UpdateBy).GreaterThan(0);
        }
    }
}
