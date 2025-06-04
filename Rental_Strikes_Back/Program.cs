using Microsoft.EntityFrameworkCore;
using Rental_Strikes_Back;

namespace Rental_Strikes_Back
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var context = new ClanDvdRentalContext();
            var logic = new BusinessLogic(context);
            var tui = new Tui(logic);
            tui.Run();
        }
    }
}
