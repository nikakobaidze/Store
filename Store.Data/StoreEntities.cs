using Store.Data.Configuration;
using Store.Model;
using Store.Model.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;




namespace Store.Data
{
    public class StoreEntities : DbContext
    {
        public StoreEntities() : base(@"Data Source=DESKTOP-LNFCMVA\SQLEXPRESS;Initial Catalog=Library2;Integrated Security=True") { }

        public DbSet<Authors> Authors { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Gadget> Gadgets { get; set; }
        public DbSet<BookAuthors> BookAuthors { get; set; }
        public DbSet<BookGenres>  BookGenres { get; set; }
        public DbSet<BookLanguages> BookLanguages { get; set; }
        public DbSet<BookPublishers> BookPublishers { get; set; }
        public DbSet<Books> Books { get; set; }
        public DbSet<BookShalves> BookShalves { get; set; }
        public DbSet<EmployeePositions> EmployeePositions { get; set; }
        public DbSet<Employees> Employees { get; set; }
        public DbSet<Genres> Genres { get; set; }
        public DbSet<Languages> Languages { get; set; }
        public DbSet<Loans> Loans { get; set; }
        public DbSet<Members> Members { get; set; }
        public DbSet<Penalties> Penalties { get; set; }
        public DbSet<Positions> Positions { get; set; }
        public DbSet<Publishers> Publishers { get; set; }
        public DbSet<Reservations> Reservations { get; set; }
        public DbSet<Shalves> Shalves { get; set; }
        public DbSet<UserRoles> UserRoles { get; set; }
        public DbSet<Users> Users { get; set; }
        public DbSet<Roles> Roles { get;set; }
        public DbSet<RoleMenu> RoleMenu { get; set; }
        public DbSet<Menu> menus { get; set; }

        public virtual void Commit()
        {
            base.SaveChanges();
        }
        
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Configurations.Add(new GadgetConfiguration());
            modelBuilder.Configurations.Add(new CategoryConfiguration());
        }

        //public System.Data.Entity.DbSet<Store.Web.ViewModels.ShalvesViewModel> ShalvesViewModels { get; set; }

        //public System.Data.Entity.DbSet<Store.Web.ViewModels.ShalvesViewModel> ShalvesViewModels { get; set; }

        //public System.Data.Entity.DbSet<Store.Web.ViewModels.PossitionViewModel> PossitionViewModels { get; set; }

        //public System.Data.Entity.DbSet<Store.Web.ViewModels.LanguageViewModel> LanguageViewModels { get; set; }

        //public System.Data.Entity.DbSet<Store.Web.ViewModels.GenreViewModel> GenreViewModels { get; set; }

        // public System.Data.Entity.DbSet<Store.Web.ViewModels.GenreViewModel> GenreViewModels { get; set; }

        //public System.Data.Entity.DbSet<Store.Web.ViewModels.BookViewModel> BookViewModels { get; set; }

        //public System.Data.Entity.DbSet<Store.Web.ViewModels.BookViewModel> BookViewModels { get; set; }

        //public System.Data.Entity.DbSet<Store.Web.ViewModels.BookViewModel> BookViewModels { get; set; }

        //public System.Data.Entity.DbSet<Store.Web.ViewModels.AuthorViewModel> AuthorViewModels { get; set; }

        // public System.Data.Entity.DbSet<Store.Web.ViewModels.AuthorViewModel> AuthorViewModels { get; set; }

        //public System.Data.Entity.DbSet<Store.Web.ViewModels.AuthorViewModel> AuthorViewModels { get; set; }

        //public System.Data.Entity.DbSet<Store.Web.ViewModels.AuthorViewModel> AuthorViewModels { get; set; }

        //public System.Data.Entity.DbSet<Store.Web.ViewModels.PublisherViewModel> PublisherViewModels { get; set; }

        // public System.Data.Entity.DbSet<Store.Web.ViewModels.AuthorViewModel> AuthorViewModels { get; set; }

        //public System.Data.Entity.DbSet<Store.Web.ViewModels.AuthorViewModel> AuthorViewModels { get; set; }

        // public System.Data.Entity.DbSet<Store.Data.ViewModels.AuthorViewModel> AuthorViewModels { get; set; }

        //
        //public System.Data.Entity.DbSet<Store.Web.ViewModels.PublisherViewModel> PublisherViewModels { get; set; }

        //public System.Data.Entity.DbSet<Store.Web.ViewModels.PublisherViewModel> PublisherViewModels { get; set; }

        //public System.Data.Entity.DbSet<Store.Web.ViewModels.AuthorViewModel> AuthorViewModels { get; set; }

        //public System.Data.Entity.DbSet<Store.Web.ViewModels.AuthorViewModel> AuthorViewModels { get; set; }
    }
}

