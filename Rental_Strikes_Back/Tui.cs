using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

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
                else if (input == "8")
                {
                    ShowFilmByGenere();
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
            throw new NotImplementedException();
        }


        private void ShowFilmByGenere()
        {
            var movies = Logic.ShowMoviesByGenere();
            foreach (var film in movies)
            {
                Console.WriteLine($"Id: {film.FilmId}, Title: {film.Title}, Release Year: {film.ReleaseYear}, Genere: {film.CategoryId}");
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
            Console.WriteLine("Insert the actor ID:");
            var idString = Console.ReadLine();
            var actorId = int.TryParse(idString, out var id) ? id : -1;
            var movies = Logic.GetMoviesByActorId(actorId);
            foreach (var movie in movies)
            {
                Console.WriteLine($"{movie.FilmId} - {movie.Title}");
            }
        }
    }
}
