using Store.Data.Infrastructure;
using Store.Model.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Data.Repositories
{
    public class PositionsRepository : RepositoryBase<Positions>, IPositionsRepository
    {
        public PositionsRepository(IDbFactory dbFactory)
            : base(dbFactory) { }

        public Positions GetPositionByTitle(string Title)
        {
            var Position = this.DbContext.Positions.Where(c => c.PositionTitle == Title).FirstOrDefault();

            return Position;
        }


        public override void Update(Positions entity)
        {
            entity.ChangeDate = DateTime.Now;
            base.Update(entity);
        }
    }

    public interface IPositionsRepository : IRepository<Positions>
    {
        Positions GetPositionByTitle(string Title);
    }
}

