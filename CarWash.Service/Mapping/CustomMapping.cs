using CarWash.Entity.Dtos.Customer;
using CarWash.Entity.Dtos.Employee;
using CarWash.Entity.Dtos.VehicleDtos;
using CarWash.Entity.Entities;

namespace CarWash.Service.Mapping
{
    internal class CustomMapping : AutoMapper.Profile
    {
        public CustomMapping()
        {
            CreateMap<CreateEmployeeDto, User>()
            .ForMember(dest => dest.NormalizedEmail, opt => opt.MapFrom(src => src.Email.ToUpper()))
            .ForMember(dest => dest.NormalizedUserName, opt => opt.MapFrom(src => src.UserName.ToUpper()))
            .ForMember(dest => dest.FullName, opt => opt.MapFrom(src => $"{src.FirstName} {src.LastName}"));


            #region VehicleDto Mapping

            CreateMap<VehicleUpdateDto, Vehicle>();

            CreateMap<VehicleCreateDto, Vehicle>();

            CreateMap<Vehicle, VehicleListDto>();

            #endregion

            #region BrandDto Mapping

            CreateMap<Brand, BrandDto>();

            #endregion
            CreateMap<CreateCustomerDto, User>()
            .ForMember(dest => dest.NormalizedEmail, opt => opt.MapFrom(src => src.Email.ToUpper()))
            .ForMember(dest => dest.NormalizedUserName, opt => opt.MapFrom(src => src.UserName.ToUpper()))
            .ForMember(dest => dest.FullName, opt => opt.MapFrom(src => $"{src.FirstName} {src.LastName}"));

            CreateMap<CreateEmployeeAttandaceDto, EmployeeAttendance>();
        }
    }
}