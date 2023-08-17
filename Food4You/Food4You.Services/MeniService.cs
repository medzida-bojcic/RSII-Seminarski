using AutoMapper;
using Food4You.Model.Requests;
using Food4You.Services.Database;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Food4You.Services
{
    public class MeniService : BaseCRUDService<Model.Meni, Database.Meni, MeniSearchObject, MeniUpsertRequest, MeniUpsertRequest>, IMeniService
    {
        private readonly Food4YouContext context;
        private readonly IMapper mapper;

        public MeniService(Food4YouContext _context, IMapper _mapper) : base(_context, _mapper)
        {
            context = _context;
            mapper = _mapper;
        }

		public List<Model.Meni> GetRecommendedMeni(int korisnikId)
		{
			var korisnici = context.Korisniks.Where(e => e.Id != korisnikId).ToList();

			Dictionary<Database.Korisnik, List<Database.Recenzije>> recenzije = new Dictionary<Database.Korisnik, List<Database.Recenzije>>();
			foreach (var korisnik in korisnici)
			{
				var ocjene = context.Recenzijes
					.Where(e => e.KorisnikId == korisnik.Id)
					.ToList();
				recenzije.Add(korisnik, ocjene);
			}

			var recenzijeKorisnik = context.Recenzijes.Where(e => e.KorisnikId == korisnikId).ToList();

			if (recenzijeKorisnik == null || recenzijeKorisnik.Count == 0)
				return null;

			List<Database.Recenzije> zajednickeOcjeneKorisnik = new List<Database.Recenzije>();
			List<Database.Recenzije> zajednickeOcjeneKorisnik2 = new List<Database.Recenzije>();

			var preporucenaJelaIds = new List<int>();

			foreach (var item in recenzije)
			{
				foreach (var recenzija in recenzijeKorisnik)
				{
					if (item.Value.Any(x => x.MeniId == recenzija.MeniId))
					{
						zajednickeOcjeneKorisnik.Add(recenzija);
						zajednickeOcjeneKorisnik2.Add(item.Value.FirstOrDefault(e => e.MeniId == recenzija.MeniId));
					}
				}

				double slicnost = GetSlicnost(zajednickeOcjeneKorisnik, zajednickeOcjeneKorisnik2);

				if (slicnost > 0.5)
				{
					var dobroOcjenjenaJelaIds = recenzije
						.Select(e => e.Value)
						.SelectMany(e => e)
						.Where(e => e.Ocjena >= 3)
						.Select(e => e.MeniId)
						.Where(e => !preporucenaJelaIds.Contains((int)e))
						.ToList();

					dobroOcjenjenaJelaIds.ForEach(e => {
						if (!preporucenaJelaIds.Contains((int)e))
							preporucenaJelaIds.Add((int)e);
					});
				}

				zajednickeOcjeneKorisnik.Clear();
				zajednickeOcjeneKorisnik2.Clear();
			}

			var preporucenaJela = Context.Set<Database.Meni>()
				.Where(x => preporucenaJelaIds.Contains(x.Id))
				.ToList();

			var result = mapper.Map<List<Model.Meni>>(preporucenaJela);
			return result;
		}

		private double GetSlicnost(List<Database.Recenzije> zajednickeOcjene1, List<Database.Recenzije> zajednickeOcjene2)
		{
			if (zajednickeOcjene1.Count != zajednickeOcjene2.Count)
				return 0;

			int? brojnik = 0, nazivnik1 = 0, nazivnik2 = 0;

			for (int i = 0; i < zajednickeOcjene1.Count; i++)
			{
				brojnik += zajednickeOcjene1[i].Ocjena * zajednickeOcjene2[i].Ocjena;
				nazivnik1 += zajednickeOcjene1[i].Ocjena * zajednickeOcjene1[i].Ocjena;
				nazivnik2 += zajednickeOcjene2[i].Ocjena * zajednickeOcjene2[i].Ocjena;
			}
			nazivnik1 = (int?)Math.Sqrt((double)nazivnik1);
			nazivnik2 = (int?)Math.Sqrt((double)nazivnik2);

			int? nazivnik = nazivnik1 * nazivnik2;
			if (nazivnik == 0)
				return 0;
			else
				return (double)(brojnik / nazivnik);
		}

		public override List<Model.Meni> Get(MeniSearchObject request)
		{
			var query = context.Menis.AsQueryable();

			if (request.KategorijaId != 0)
			{
				query = query.Where(x => x.KategorijaId == request.KategorijaId);
			}

			if (!string.IsNullOrWhiteSpace(request.Naziv))
			{
				query = query.Where(x => x.Naziv.Contains(request.Naziv));
			}

			var list = query.Include(x => x.Kategorija).ToList();

			return mapper.Map<List<Model.Meni>>(list);
		}

	}
}
