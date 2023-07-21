using Store.Data.Infrastructure;
using Store.Model;
using Store.Model.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Data.Repositories
{
    public class AuthorRepository : RepositoryBase<Authors>, IAuthorRepository
    {
        public AuthorRepository(IDbFactory dbFactory)
            : base(dbFactory) { }

        public Authors GetAuthorByName(string AuthorName)
        {
            var Author = this.DbContext.Authors.Where(c => c.FirstName == AuthorName).FirstOrDefault();

            return Author;
        }
        public Authors GetAuthorByLastName(string AuthorLastName)
        {
            var Author = this.DbContext.Authors.Where(c => c.LastName == AuthorLastName).FirstOrDefault();

            return Author;
        }

        public override void Update(Authors entity)
        {
            entity.ChangeDate = DateTime.Now;
            base.Update(entity);
        }
    }

    public interface IAuthorRepository : IRepository<Authors>
    {
        Authors GetAuthorByName(string AuthorName);
        Authors GetAuthorByLastName(string AuthorLastName);
    }
}
