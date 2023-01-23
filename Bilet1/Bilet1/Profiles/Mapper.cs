using AutoMapper;
using Bilet1.Models;
using Bilet1.ViewModels.RecentPostViewModels;

namespace Bilet1.Profiles
{
    public class Mapper:Profile
    {
        public Mapper()
        {
            CreateMap<RecentPost, RecentPostGetVM>();
            
        }
    }
}
