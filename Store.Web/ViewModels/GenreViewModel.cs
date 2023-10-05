using Store.Model.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Store.Web.ViewModels
{
    public class GenreViewModel
    {
        public int ID { get; set; }
        public string Name { get; set; }

        public virtual List<BookGenres> BookGenres { get; set; }

        public virtual List<BookLanguages> BookLanguages { get; set; }
    }
}