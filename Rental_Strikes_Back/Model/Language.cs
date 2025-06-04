using System;
using System.Collections.Generic;

namespace Rental_Strikes_Back.Model;

public partial class Language
{
    public int LanguageId { get; set; }

    public string Name { get; set; } = null!;

    public DateTime LastUpdate { get; set; }

    public virtual ICollection<Film> Films { get; set; } = new List<Film>();
}
