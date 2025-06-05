using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Rental_Strikes_Back.Model;
using static Rental_Strikes_Back.BusinessLogic;

namespace Rental_Strikes_Back
{
    internal interface ILogic
    {
        public List<Film> GetAllFilms();
        public List<Actor> GetAllActors();
        public List<Category> getAllCategories();
        public List<Film> GetMoviesByActorId(int actorId);
        public List<Film> GetAllComedyFilms();
        public List<FilmWithCategory> ShowMoviesByGenere();
        public List<Actor> GetAllComedyActor();
        public List<Film> GetAllMoviesByActor();
        public List<Store> GetStoreNumberByCountry(string? countryName);
        public List<Rental> MovieRentalNumber(int id);
        public List<Tuple<int, string, string, int>> GetActorsByRental();
        public List<Tuple<Film, decimal>> GetMoviesByRentalIncome();

    }
}
