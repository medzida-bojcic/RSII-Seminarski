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
            CreateMap<Food4You.Services.Database.KorisnikUloga, Food4You.Model.KorisniciUloge>();
            CreateMap<Food4You.Services.Database.Grad, Food4You.Model.Grad>();
            CreateMap<Food4You.Services.Database.Kategorija, Food4You.Model.Kategorija>();
            CreateMap<KategorijaUpsertRequest, Food4You.Services.Database.Kategorija>();

            CreateMap<Food4You.Services.Database.Meni, Model.Meni>()
                .ForMember(x => x.Kategorija, db => db.MapFrom(src => src.Kategorija.Naziv))
                .ReverseMap();
            CreateMap<MeniUpsertRequest, Food4You.Services.Database.Meni>();


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

            CreateMap<Food4You.Services.Database.Narudzba, Model.Narudzba>()
                .ForMember(x => x.Korisnik, db => db.MapFrom(src => src.Korisnik.Ime + " " + src.Korisnik.Prezime))
                .ForMember(x => x.StatusNarudzbe, db => db.MapFrom(src => src.StatusNarudzbe.Naziv));
            CreateMap<Food4You.Model.Requests.NarudzbaUpsertRequest, Model.Narudzba>();
            CreateMap<NarudzbaUpsertRequest, Food4You.Services.Database.Narudzba>();


            CreateMap<Food4You.Services.Database.Recenzije, Model.Recenzije>();
            CreateMap<RecenzijaUpsertRequest, Food4You.Services.Database.Recenzije>();

            CreateMap<Food4You.Services.Database.StatusNarudzbe, Model.StatusNarudzbe>();
            CreateMap<StatusNarudzbeSearchObject, Model.StatusNarudzbe>();

            CreateMap<Food4You.Services.Database.NarudzbaStavke, Model.NarudzbaStavke>();
            //CreateMap<NarudzbaStavkeSearchObject, Model.NarudzbaStavke>();
            CreateMap<NarudzbaStavkeUpsertRequest, Food4You.Services.Database.NarudzbaStavke>();
            CreateMap<NarudzbaStavkeUpsertRequest, Food4You.Services.Database.NarudzbaStavke>();

            CreateMap<Food4You.Services.Database.Uplatum, Model.Uplata>();
            CreateMap<Food4You.Model.Requests.UplataUpsertRequest, Food4You.Services.Database.Uplatum>();
        }
    }
}
