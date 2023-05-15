using AutoMapper;
using Food4You.Model;
using Food4You.Model.Requests;

namespace Food4You.Mapper
{
    public class Food4YouMapper : Profile
    {
        public Food4YouMapper()
        {
            CreateMap<Food4You.Services.Database.Drzava, Food4You.Model.Drzava>();
            CreateMap<Food4You.Services.Database.Korisnik, Food4You.Model.Korisnik>();
            CreateMap<Food4You.Services.Database.Uloga, Food4You.Model.Uloge>();
            CreateMap<Food4You.Services.Database.Grad, Food4You.Model.Grad>();
            CreateMap<Food4You.Services.Database.Kategorija, Food4You.Model.Kategorija>();
            CreateMap<KategorijaUpsertRequest, Food4You.Services.Database.Kategorija>();



            CreateMap<Food4You.Model.Requests.KorisnikUpsertRequest, Food4You.Services.Database.Korisnik>();
            CreateMap<Food4You.Model.Requests.KorisnikUpsertRequest, Food4You.Services.Database.Korisnik>().ForAllMembers(opts =>
            {
                opts.Condition((src, dest, srcMember) => srcMember != null);
            });
            CreateMap<Food4You.Model.Requests.DrzavaUpsertRequest, Food4You.Services.Database.Drzava>().ForAllMembers(opts =>
            {
                opts.Condition((src, dest, srcMember) => srcMember != null);
            });
            CreateMap<Food4You.Model.Requests.GradUpsertRequest, Food4You.Services.Database.Grad>().ForAllMembers(opts =>
            {
                opts.Condition((src, dest, srcMember) => srcMember != null);
            });
        }
    }
}
