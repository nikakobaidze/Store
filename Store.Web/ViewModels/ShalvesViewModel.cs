using Store.Model.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Store.Web.ViewModels
{
    public class ShalvesViewModel
    {
        public int ID { get; set; }
        public int Floor { get; set; }
        public int Room { get; set; }
        public string Shelf { get; set; }
        public string Section { get; set; }
        public string Row { get; set; }

        public virtual List<BookShalves> BookShalves { get; set; }
    }
}