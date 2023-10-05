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
    public interface IShelveService
    {
        IEnumerable<Shalves> GetShelf(string name = null);
        //IEnumerable<Users> GetUserName(string name );
        Shalves GetShelf(int id);
        //Publishers GetPublisher(string name);
        void SaveShelf();
        void CreateShelf(Shalves shelf);
        void UpdateShelf(Shalves shelf);
        void DeleteShelf(Shalves shelf);
    }

    public class ShelveService : IShelveService
    {
        private readonly IShalvesRepository shalvesRepository;
        private readonly IUnitOfWork unitOfWork;

        public ShelveService(IShalvesRepository shalvesRepository, IUnitOfWork unitOfWork)
        {
            this.shalvesRepository = shalvesRepository;
            this.unitOfWork = unitOfWork;
        }

        #region ICategoryService Members

        public IEnumerable<Shalves> GetShelf(string name = null)
        {
            if (string.IsNullOrEmpty(name))
                return shalvesRepository.GetAll();
            else
                return shalvesRepository.GetAll().Where(c => c.Shelf == name);
        }
        //public IEnumerable<Users> GetUserName(string name)
        //{
        //    var User = UsersRepository.GetUserByUserName(name);

        //    return User;
        //}

        public Shalves GetShelf(int id)
        {
            var Author = shalvesRepository.GetById(id);
            return Author;
        }

        public void CreateShelf(Shalves shelf)
        {
            shalvesRepository.Add(shelf);
        }
        public void UpdateShelf(Shalves shelf)
        {
            shalvesRepository.Update(shelf);
        }
        public void DeleteShelf(Shalves shelf)
        {
            shalvesRepository.Delete(shelf);
        }
        public void SaveShelf()
        {
            unitOfWork.Commit();
        }


    }
    #endregion

}