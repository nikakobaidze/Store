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
    public interface IPublisherService
    {
        IEnumerable<Publishers> GetPublisher(string name = null);
        //IEnumerable<Users> GetUserName(string name );
        Publishers GetPublisher(int id);
        //Publishers GetPublisher(string name);
        void SavePublisher();
        void CreatePublisher(Publishers publisher);
        void UpdatePublisher(Publishers publishers);
        void DeletePublisher(Publishers publishers);   
    }

    public class PublisherService : IPublisherService
    {
        private readonly IPublishersRepository PublishersRepository;
        private readonly IUnitOfWork unitOfWork;

        public PublisherService(IPublishersRepository PublishersRepository, IUnitOfWork unitOfWork)
        {
            this.PublishersRepository = PublishersRepository;
            this.unitOfWork = unitOfWork;
        }

        #region ICategoryService Members

        public IEnumerable<Publishers> GetPublisher(string name = null)
        {
            if (string.IsNullOrEmpty(name))
                return PublishersRepository.GetAll();
            else
                return PublishersRepository.GetAll().Where(c => c.Name == name);
        }
        //public IEnumerable<Users> GetUserName(string name)
        //{
        //    var User = UsersRepository.GetUserByUserName(name);

        //    return User;
        //}

        public Publishers GetPublisher(int id)
        {
            var Publisher = PublishersRepository.GetById(id);
            return Publisher;
        }

        public void CreatePublisher(Publishers Publisher)
        {
            PublishersRepository.Add(Publisher);
        }
        public void UpdatePublisher(Publishers Publisher)
        {
            PublishersRepository.Update(Publisher);
        }
        public void DeletePublisher(Publishers Publisher)
        {
            PublishersRepository.Delete(Publisher);
        }
        public void SavePublisher()
        {
            unitOfWork.Commit();
        }

        
    }
    #endregion

}