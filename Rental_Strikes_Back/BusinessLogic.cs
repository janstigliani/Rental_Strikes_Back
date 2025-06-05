using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Rental_Strikes_Back.Model;

namespace Rental_Strikes_Back 
{
    internal class BusinessLogic : ILogic
    {
        public ClanDvdRentalContext Context { get; set; } = new ClanDvdRentalContext();
        public BusinessLogic(ClanDvdRentalContext context)
        {
            Context = context;
        }
        public List<Film> GetAllFilms()
        {
            var List = Context.Films.Include(f => f.FilmActors).ToList();
            return List;
        }

        public List<Actor> GetAllActors()
        {
            var list = Context.Actors.ToList();
            return list;
        }
        public List<Category> getAllCategories()
        {
           var list = Context.Categories.ToList();
            return list;
        }

        public List<Film> GetMoviesByActorId(int actorId)
        {
            var movies = Context.Films
                .Where(f => f.FilmActors.Any(fa => fa.ActorId == actorId))
                .ToList();
            return movies;
        }

        public List<Film> GetAllComedyFilms()
        {
            var movies = Context.Films.
                Where(f => f.FilmCategories.Any(fc => fc.Category.Name == "Comedy"))
                .ToList();
            return movies;
        }

        public List<FilmWithCategory> ShowMoviesByGenere()
        {
            var movies = from f in Context.Films
                         join fc in Context.FilmCategories on f.FilmId equals fc.FilmId
                         join c in Context.Categories on fc.CategoryId equals c.CategoryId
                         orderby c.Name
                         select new FilmWithCategory {Film = f, Category = c};

            return movies.ToList();
        }

        public List<Actor> GetAllComedyActor()
        {
            var actors = (from a in Context.Actors
                         join fa in Context.FilmActors on a.ActorId equals fa.ActorId
                         join f in Context.Films on fa.FilmId equals f.FilmId
                         join fc in Context.FilmCategories on f.FilmId equals fc.FilmId
                         where fc.Category.Name == "Comedy"
                         select a)
                         .Distinct()
                         .OrderBy(a => a.ActorId)
                         .ToList();

            return actors;
        }

        public List<Film> GetAllMoviesByActor()
        {
            var movies = from f in Context.Films
                         join fa in Context.FilmActors on f.FilmId equals fa.FilmId
                         join a in Context.Actors on fa.ActorId equals a.ActorId
                         orderby a.LastName
                         select f;
            return movies.ToList();
        }

        public List<Store> GetStoreNumberByCountry(string? countryName)
        {
            var stores = from s in Context.Stores
                         join a in Context.Addresses on s.AddressId equals a.AddressId
                         join c in Context.Cities on a.CityId equals c.CityId
                         join co in Context.Countries on c.CountryId equals co.CountryId
                         where co.Country1 == countryName
                         select s;

            return stores.ToList();
        }

        public List<Rental> MovieRentalNumber(int id)
        {
            var rentals = from f in Context.Films
                          join i in Context.Inventories on f.FilmId equals i.FilmId
                          join r in Context.Rentals on i.InventoryId equals r.InventoryId
                          where f.FilmId == id
                          select r;

            return rentals.ToList();
        }

        public List<Tuple<int, string,string, int>> GetActorsByRental()
        {
            var actorByRental = Context.Payments
                                       .Include(a => a.Rental)
                                       .ThenInclude(r => r.Inventory)
                                       .ThenInclude(f => f.Film)
                                       .ThenInclude(fa => fa.FilmActors)
                                       .ThenInclude(a => a.Actor)
                                       .SelectMany(p => p.Rental.Inventory.Film.FilmActors.Select(fa => fa.Actor))
                                       .GroupBy(a => new { a.ActorId, a.FirstName, a.LastName } )
                                       .OrderBy(g => g.Count())
                                       .Select(g => new Tuple<int, string, string, int >
                                       (
                                           g.Key.ActorId,
                                           g.Key.FirstName,
                                           g.Key.LastName,
                                           g.Count()
                                       ))
                                       .ToList();

            return actorByRental;
        }

        public List<Tuple<Film, decimal>> GetMoviesByRentalIncome()
        {
            var moviesByRentalIncome = Context.Films
                .Include(f => f.Inventories)
                .ThenInclude(i => i.Rentals)
                .ThenInclude(r => r.Payments)
                .OrderBy(f => f.Inventories.Sum(i => i.Rentals.Sum(r => r.Payments.Sum(p => p.Amount))))
                .Select(f => new Tuple<Film,decimal>
                (
                    f,
                    f.Inventories.Sum(i => i.Rentals.Sum(r => r.Payments.Sum(p => p.Amount)))
                ))
                .ToList();

            return moviesByRentalIncome;
        }

        public class FilmWithCategory
        {
            public Film Film { get; set; }
            public Category Category { get; set; }
        }
    }
}
