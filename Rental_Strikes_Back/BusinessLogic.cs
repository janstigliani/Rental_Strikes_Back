using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Rental_Strikes_Back.Model;

namespace Rental_Strikes_Back
{
    internal class BusinessLogic
    {
        public ClanDvdRentalContext Context { get; set; } = new ClanDvdRentalContext();
        public BusinessLogic(ClanDvdRentalContext context)
        {
            Context = context;
        }
        internal List<Film> GetAllFilms()
        {
            var List = Context.Films.ToList();
            return List;
        }

        internal List<Actor> GetAllActors()
        {
            var list = Context.Actors.ToList();
            return list;
        }
        internal List<Category> getAllCategories()
        {
           var list = Context.Categories.ToList();
            return list;
        }
    }
}
