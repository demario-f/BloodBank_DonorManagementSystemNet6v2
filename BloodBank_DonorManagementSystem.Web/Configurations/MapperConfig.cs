using AutoMapper;
using BloodBank_DonorManagementSystem.Web.Data;
using BloodBank_DonorManagementSystem.Web.Models;

namespace BloodBank_DonorManagementSystem.Web.Configurations
{
    public class MapperConfig : Profile
    {
        public MapperConfig()
        {
            CreateMap<Donor, DonorsControllerVM>().ReverseMap();           
        }
    }
}
