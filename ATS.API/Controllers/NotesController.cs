using ATS.Application.DTO_s.Administration.Applications;
using ATS.Application.Features.Applications.Notes.Commands.CreateNote;
using ATS.Application.Features.Applications.Notes.Commands.DeleteNote;
using ATS.Application.Features.Applications.Notes.Commands.UpdateNote;
using ATS.Application.Features.Applications.Notes.Queries.GetCustomNotes;
using ATS.Application.Features.Applications.Notes.Queries.GetNotesByApplicationId;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace ATS.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NotesController : ControllerBase
    {
        private readonly IMediator _mediator;

        public NotesController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> CreateNote(CreateNoteDTO createNote, CancellationToken token)
        {
            var createNoteCommand = new CreateNoteCommand(createNote);
            var note = await _mediator.Send(createNoteCommand, token);

            return note is not null ? Ok() : BadRequest("Can not insert note");
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteNote(int id, CancellationToken token)
        {
            var deleteNoteCommand = new DeleteNoteCommand(id);
            var deleted = await _mediator.Send(deleteNoteCommand, token);

            return deleted ? Ok() : BadRequest("Can not delete note");
        }

        [HttpGet]
        public async Task<IActionResult> GetNotes(CancellationToken token)
        {
            var getCustomNotesQuery = new GetCustomNotesQuery();
            var list = await _mediator.Send(getCustomNotesQuery, token);

            return Ok(list);
        }

        [HttpGet("{applicationId}")]
        public async Task<IActionResult> GetNotesByApplicationsById(int applicationId, CancellationToken token)
        {
            var getNotesByApplicationIdQuery = new GetNotesByApplicationIdQuery(applicationId);
            var list = await _mediator.Send(getNotesByApplicationIdQuery, token);

            return Ok(list);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateNoteDTO(UpdateNoteDTO updateNoteDTO, CancellationToken token)
        {
            var updateNoteCommand = new UpdateNoteCommand(updateNoteDTO);
            var updated = await _mediator.Send(updateNoteCommand, token);

            return updated ? Ok() : BadRequest("Can not update Note");
        }
    }
}
