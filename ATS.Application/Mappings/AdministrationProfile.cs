using ATS.Application.DTO_s.Administration.Authentication;
using ATS.Application.DTO_s.Administration.Modules;
using ATS.Application.DTO_s.Administration.Roles;
using ATS.Application.DTO_s.Administration.UserRole;
using ATS.Application.DTO_s.Administration.Users;
using ATS.Domain.DapperModels;
using ATS.Domain.Models;
using AutoMapper;

namespace ATS.Application.Mappings
{
    public class AdministrationProfile : Profile
    {
        public AdministrationProfile()
        {
            CreateMap<Role, CreateRoleDTO>().ReverseMap();
            CreateMap<Role, UpdateRoleDTO>().ReverseMap();
            CreateMap<Role, ListRolesDTO>().ReverseMap();

            CreateMap<UserRole, CreateUserRoleDTO>().ReverseMap();
            CreateMap<UserRole, ListUserRoleDTO>().ReverseMap();

            CreateMap<User, CreateUserDTO>().ReverseMap();
            CreateMap<User, UpdateUserDTO>().ReverseMap();
            CreateMap<User, ListUserDTO>().ReverseMap();

            CreateMap<User, LoginDTO>().ReverseMap();
            CreateMap<LoginResponse, LoginResponseDTO>()
                .ForMember(dest => dest.UserId, opt => opt.MapFrom(src => src.Id));

            CreateMap<User, RegisterUserDTO>().ReverseMap();
            CreateMap<ChangePasswordDTO, User>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.UserId));

            CreateMap<ResetPasswordDTO, User>()
                .ForMember(dest => dest.Password, opt => opt.MapFrom(src => src.NewPassword));

            CreateMap<ConfirmEmailDTO, User>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.UserId));

            CreateMap<Module, ModuleDTO>().ReverseMap();
            CreateMap<Menu, MenuItemDTO>().ReverseMap();
        }
    }
}
