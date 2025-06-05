using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using Rental_Strikes_Back.Model;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Rental_Strikes_Back
{
    internal class Tui
    {
        public BusinessLogic Logic { get; set; }
        public Tui(BusinessLogic logic)
        {
            Logic = logic;
        }

        public void Run()
        {

            while (true)
            {
                Console.WriteLine("Welcome to CleanRental!");
                Console.WriteLine("1. Show all movies");
                Console.WriteLine("2. Show all commedy movies");
                Console.WriteLine("3. Show all commedy actors");
                Console.WriteLine("4. Show store number by country");
                Console.WriteLine("5. Show movies rental number");
                Console.WriteLine("6. Show actors ordered by rental number");
                Console.WriteLine("7. Show movies ordered by rental income");
                //---------------------------------------------------------------------
                Console.WriteLine("8. Show all movies by genre");
                Console.WriteLine("9. Show all movies by actor");
                Console.WriteLine("10. Show all actors");
                Console.WriteLine("11. Show all categories");
                Console.WriteLine("12. Show all Movies with Actors");
                Console.WriteLine("13. Exit");
                Console.Write("Please select an option: ");
                var input = Console.ReadLine();
                if (input == "1")
                {
                    ShowFilms();
                }
                else if (input == "2")
                {
                    ShowComedyMovies();
                }
                else if (input == "3")
                {
                    ShowComedyActors();
                }
                else if (input == "4")
                {
                    showStoreNumeberByCountry();
                }
                else if (input == "5")
                {
                    ShowMoviesRentalNumber();
                }
                else if (input == "6")
                {
                    ShowActorByRental();
                }
                else if (input == "7")
                {
                    ShowMoviesByRentalIncome();
                }
                else if (input == "8")
                {
                    ShowFilmByGenere();
                }
                else if (input == "9")
                {
                    ShowAllMoviesByActor();
                }
                else if (input == "10")
                {
                    ShowAllActors();
                }
                else if (input == "11")
                {
                    ShowAllCategories();
                }
                else if (input == "12")
                {
                    ShowActorsMovies();
                }
                else if (input == "13")
                {
                    Console.WriteLine("Thank you for using Rental Strikes Back!");
                    break;
                }
                else
                {
                    Console.WriteLine("Invalid option, please try again.");
                }
            }
        }

        private void ShowMoviesByRentalIncome()
        {
            var movies = Logic.GetMoviesByRentalIncome();
            foreach (var movie in movies)
            {
                Console.WriteLine($"Id: {movie.Item1.FilmId}, Title: {movie.Item1.Title}, Release Year: {movie.Item1.ReleaseYear}, Rental Income: {movie.Item2:C}");
            }
        }

        private void ShowActorByRental()
        {
            var actors = Logic.GetActorsByRental();
            foreach (var actor in actors)
            {
                Console.WriteLine($"Id: {actor.Item1}, First Name: {actor.Item2}, Last Name: {actor.Item3}, Rental Count: {actor.Item4}");
            }

        }

        private void ShowFilms()
        {
            var Films = Logic.GetAllFilms();
            foreach (var film in Films)
            {
                Console.WriteLine($"Id: {film.FilmId}, Title: {film.Title}, Release Year: {film.ReleaseYear}");
            }
        }

        private void ShowComedyMovies()
        {
            var movies = Logic.GetAllComedyFilms();
            foreach (var film in movies)
            {
                Console.WriteLine($"Id: {film.FilmId}, Title: {film.Title}, Release Year: {film.ReleaseYear}");
            }
        }

        private void ShowComedyActors()
        {
            var comedyActors = Logic.GetAllComedyActor();
            foreach (var actor in comedyActors)
            {
                Console.WriteLine($"Id: {actor.ActorId}, First Name: {actor.LastName}, Last Name: {actor.FirstName}");
            }
        }

        private void showStoreNumeberByCountry()
        {
            Console.WriteLine("Insert the name of the Country");
            var countryName = Console.ReadLine();
            var stores = Logic.GetStoreNumberByCountry(countryName);
            Console.WriteLine(stores.Count());
        }

        private void ShowMoviesRentalNumber()
        {
            Console.WriteLine("Insert the id of the film");
            var moviesId = Console.ReadLine();
            var id = int.TryParse(moviesId, out var idMov) ? idMov : -1;
            var rental = Logic.MovieRentalNumber(id);
            Console.WriteLine(rental.Count());
        }

        private void ShowFilmByGenere()
        {
            var movies = Logic.ShowMoviesByGenere();
            foreach (var film in movies)
            {
                Console.WriteLine($"Id: {film.Film.FilmId}, Title: {film.Film.Title}, Release Year: {film.Film.ReleaseYear}, Category: {film.Category.Name}");
            }
        }

        private void ShowAllMoviesByActor()
        {
            var films = Logic.GetAllMoviesByActor();
            foreach (var film in films)
            {
                Console.WriteLine($"Id: {film.FilmId}, Title: {film.Title}, Release Year: {film.ReleaseYear}");
            }
        }

        private void ShowAllCategories()
        {
            Logic.getAllCategories();
            foreach (var category in Logic.Context.Categories)
            {
                Console.WriteLine($"Category: {category.Name}");
            }
        }

        private void ShowAllActors()
        {
            Logic.GetAllActors()
                .ForEach(actor => Console.WriteLine($"Actor: {actor.FirstName} {actor.LastName}"));
        }

        private void ShowActorsMovies()
        {
            //Console.WriteLine("Insert the actor ID:");
            //var idString = Console.ReadLine();
            //var actorId = int.TryParse(idString, out var id) ? id : -1;
            //var movies = Logic.GetMoviesByActorId(actorId);
            //foreach (var movie in movies)
            //{
            //    Console.WriteLine($"{movie.FilmId} - {movie.Title}");
            //}

            var movies = Logic.GetAllFilms();
            var actors = Logic.GetAllActors();

            foreach (var movie in movies)
            {
                Console.WriteLine($"Movie: {movie.Title}");
                var actorsIds = movie.FilmActors.Select(fa => fa.ActorId).ToList();
                var movieActors = actors.Where(a => actorsIds.Contains(a.ActorId)).ToList();
                foreach (var actor in movieActors)
                {
                    Console.WriteLine($"  Actor: {actor.FirstName} {actor.LastName}");
                }
            }
        }
    }
}
