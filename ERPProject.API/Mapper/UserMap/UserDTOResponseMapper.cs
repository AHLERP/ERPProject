using AutoMapper;
using ERPProject.Entity.DTO.UserDTO;
using ERPProject.Entity.Poco;

namespace ERPProject.API.Mapper.UserMap
{
    public class UserDTOResponseMapper:Profile
    {
        public UserDTOResponseMapper()
        {
            CreateMap<User, UserDTOResponse>().
                ForMember(dest => dest.DepartmentName, opt =>
                {
                    opt.MapFrom(src => src.Department.Name);
                }).
                ForMember(dest => dest.RoleName, opt =>
                {
                    opt.MapFrom(src => src.Role.Name);
                }).ReverseMap();
                //.ForMember(dest => dest.PasswordHash, opt =>
                //{
                //    opt.MapFrom(src => BCrypt.Net.BCrypt.HashPassword(src.Password));
                //}).
                //ReverseMap();
        }
    }
}
