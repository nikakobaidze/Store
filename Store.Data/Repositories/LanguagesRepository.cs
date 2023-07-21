using Store.Data.Infrastructure;
using Store.Model.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Data.Repositories
{
    public class LanguagesRepository : RepositoryBase<Languages>, ILanguagesRepository
    {
        public LanguagesRepository(IDbFactory dbFactory)
            : base(dbFactory) { }
        public Languages GetBookByLanguage(string Language)
        {
            var Languages = this.DbContext.Languages.Where(x => x.Language == Language).FirstOrDefault();
            return Languages;
        }
    }

    public interface ILanguagesRepository : IRepository<Languages>
    {
        Languages GetBookByLanguage(string Language);

    }
}
