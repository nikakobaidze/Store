using Store.Model.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Store.Web.ViewModels
{
    public class PossitionViewModel
    {
        public int ID { get; set; }
        public string PositionTitle { get; set; }
        public virtual List<EmployeePositions> EmployeePositions { get; set; }

    }
}