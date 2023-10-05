using Store.Data.Infrastructure;
using Store.Data.Repositories;
using Store.Model;
using Store.Model.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Service
{
    // operations you want to expose
    public interface IPositionService
    {
        IEnumerable<Positions> GetPosition(string name = null);
        Positions GetPosition(int id);
        void SavePosition();
        void CreatePosition(Positions Position);
        void UpdatePosition(Positions Position);
        void DeletePosition(Positions Position);
    }

    public class PositionService : IPositionService
    {
        private readonly IPositionsRepository PositionsRepository;
        private readonly IUnitOfWork unitOfWork;

        public PositionService(IPositionsRepository PositionsRepository, IUnitOfWork unitOfWork)
        {
            this.PositionsRepository = PositionsRepository;
            this.unitOfWork = unitOfWork;
        }


        public IEnumerable<Positions> GetPosition(string name = null)
        {
            if (string.IsNullOrEmpty(name))
                return PositionsRepository.GetAll();
            else
                return PositionsRepository.GetAll().Where(c => c.PositionTitle == name);
        }
        //public IEnumerable<Users> GetUserName(string name)
        //{
        //    var User = UsersRepository.GetUserByUserName(name);

        //    return User;
        //}

        public Positions GetPosition(int id)
        {
            var Position = PositionsRepository.GetById(id);
            return Position;
        }

        public void CreatePosition(Positions Publisher)
        {
            PositionsRepository.Add(Publisher);
        }
        public void UpdatePosition(Positions Publisher)
        {
            PositionsRepository.Update(Publisher);
        }
        public void DeletePosition(Positions Publisher)
        {
            PositionsRepository.Delete(Publisher);
        }
        public void SavePosition()
        {
            unitOfWork.Commit();
        }



    }
}