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
                    ViewFilms();
                }
                else if (input == "2")
                {
                    ViewActors();
                }
                else if (input == "3")
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

        private void ViewActors()
        {
            throw new NotImplementedException();
        }

        private void ViewFilms()
        {
            var Films = Logic.GetAllFilms();
            foreach (var film in Films)
            {
                Console.WriteLine($"Title: {film.Title}, Release Year: {film.ReleaseYear}");
            }
        }
    }
}
