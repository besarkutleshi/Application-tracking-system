using ATS.Application.DTO_s.Administration.Applications;
using ATS.Application.DTO_s.Administration.Applications.Application;
using ATS.Application.DTO_s.Administration.Applications.Interview;
using ATS.Application.DTO_s.Administration.Applications.Question;
using ATS.Domain.Models;
using AutoMapper;

namespace ATS.Application.Mappings
{
    public class ApplicationProfile : Profile
    {
        public ApplicationProfile()
        {
            CreateMap<ATS.Domain.Models.Application, CreateApplicationDTO>().ReverseMap();
            CreateMap<ATS.Domain.Models.Application, ListApplicationsDTO>().ReverseMap();
            CreateMap<ATS.Domain.Models.Application, UpdateApplicationsDTO>().ReverseMap();

            CreateMap<Interview, CreateInterviewDTO>().ReverseMap();
            CreateMap<Interview, ListInterviewsDTO>().ReverseMap();
            CreateMap<Interview, UpdateInterviewDTO>().ReverseMap();

            CreateMap<Note, CreateNoteDTO>().ReverseMap();
            CreateMap<Note, ListApplicationNoteDTO>().ReverseMap();
            CreateMap<Note, ListNotesDTO>().ReverseMap();
            CreateMap<Note, UpdateNoteDTO>().ReverseMap();

            CreateMap<Question, ApplicationQuestionDTO>().ReverseMap();
            CreateMap<Question, CreateApplicationQuestionDTO>().ReverseMap();
            CreateMap<Question, QuestionDTO>().ReverseMap();
        }
    }
}
