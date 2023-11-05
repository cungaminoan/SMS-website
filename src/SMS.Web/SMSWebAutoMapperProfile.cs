using AutoMapper;
using SMS.MstSoftwares;

namespace SMS.Web;

public class SMSWebAutoMapperProfile : Profile
{
    public SMSWebAutoMapperProfile()
    {
        //Define your AutoMapper configuration here for the Web project.
        CreateMap<MstSoftware, MstSoftwareDto>();
        CreateMap<MstSoftwareDto, CreateUpdateMstSoftwareDto>();
    }
}
