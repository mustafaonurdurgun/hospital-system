using Business.Models.Request.Create;
using Business.Models.Request.Update;
using Business.Models.Response;
using Infrastructure.Data.Postgres.Entities;

namespace Business.Utilities.Mapping;

public class Profiles : AutoMapper.Profile
{
    public Profiles()
    {
        CreateMap<RegisterDto, User>();
        CreateMap<CreateAppointmentDTO, Appointment>();
        CreateMap<CreateCommentsDTO, Comments>();
        CreateMap<CreatePrescriptionsDTO, Prescriptions>();
        CreateMap<CreateUserCommentDTO, UserComment>();


        CreateMap<UpdateAppointmentDTO, Appointment>();
        CreateMap<UpdateCommentsDTO, Comments>();
        CreateMap<UpdatePrescriptionsDTO, Prescriptions>();
        CreateMap<UpdateUserCommentsDTO, UserComment>();
        CreateMap<UpdateUserDTO, User>();

        CreateMap<Appointment, AppointmentInfoDTo>();
        CreateMap<Comments, CommentsInfoDTO>();
        CreateMap<Prescriptions, PrescriptionsInfoDTO>();
        CreateMap<UserComment, UserCommentInfoDTO>();
        CreateMap<User, UserProfileDto>();


        CreateMap<PasswordChangeDTO, User>();





    }
}