using AutoMapper;
using HealthCareScheduler.Dto.Appointment;
using HealthCareScheduler.Dto.Auth;
using HealthCareScheduler.Dto.Branch;
using HealthCareScheduler.Dto.MedicalRecord;
using HealthCareScheduler.Dto.Service;
using HealthCareScheduler.Dto.User;
using HealthCareScheduler.Models;


namespace HealthCareScheduler.Mapper
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<RegisterDto, User>();
			CreateMap<Role, RoleDto>();
			CreateMap<User, UserDto>();
			CreateMap<CreateUserDto, User>();
			CreateMap<UpdateUserDto, User>();

			CreateMap<CreateBranchDto, Branch>();
            CreateMap<UpdateBranchDto, Branch>();
            CreateMap<Branch, BranchDto>();

			CreateMap<CreateServiceDto, Service>();
			CreateMap<UpdateServiceDto, Service>();
			CreateMap<Service, ServiceDto>();

			CreateMap<CreateAppointmentDto, Appointment>();
            CreateMap<UpdateAppointmentDto, Appointment>();
            CreateMap<Appointment, AppointmentDto>();

            CreateMap<CreateMedicalRecordDto, MedicalRecord>();
            CreateMap<UpdateMedicalRecordDto, MedicalRecord>();
            CreateMap<MedicalRecord, MedicalRecordDto>();

            /*CreateMap<FileDetails, FileDetailDto>();
            CreateMap<ImageDetails, ImageDetailDto>();
            

            CreateMap<User, UserDto>();
            CreateMap<CreateUserDto, User>();
            CreateMap<UpdateUserDto, User>();
            /*CreateMap<UpdateUserDto, User>()
                .ForMember(dest => dest.Password, opt => opt.Ignore());*/

			/*CreateMap<CreateMedicalRecordDto, MedicalRecord>();
            CreateMap<UpdateMedicalRecordDto, MedicalRecord>();
            CreateMap<MedicalRecord, MedicalRecordDto>();

            CreateMap<CreateFeedbackDto, Feedback>();
            CreateMap<UpdateFeedbackDto, Feedback>();
            CreateMap<Feedback, FeedbackDto>();*/
		}
    }
}
