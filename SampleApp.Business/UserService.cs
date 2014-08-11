using System;
using System.Collections.Generic;
using System.Linq;
using NHibernate;
using SampleApp.Common;
using SampleApp.Models;
using SampleApp.Repository;

namespace SampleApp.Business
{
    public interface IUserService
    {
        List<User> GetUsers(string q = null, string sort = null, bool desc = false, int? limit = null,
            int offset = 0);
        User GetUser(int id);
        bool UpdateUser(int id, User user);
        bool DeleteUser(int id);
        bool CreateUser(User user);
    }

    public class UserService : IUserService
    {
        private readonly UnitOfWork _unitOfWork;
        private readonly Repository<int, User> _repository;

        public UserService(ISessionProvider sessionProvider)
        {
            ISessionFactory sessionFactory = sessionProvider.GetSessionFactory();

            _unitOfWork = new UnitOfWork(sessionFactory);
            _repository = new Repository<int, User>(_unitOfWork.Session);
        }

        public List<User> GetUsers(string q = null, string sort = null, bool desc = false, int? limit = null,
            int offset = 0)
        {
            var list = _repository.All();

            var users = string.IsNullOrEmpty(sort)
                ? list.OrderByDescending(x => x.Name).ToList()
                : list.OrderByField(sort, !desc).ToList();


            if (!String.IsNullOrEmpty(q) && q != "undefined")
            {
                q = q.ToLower();
                users = users.Where(x => x.Name.ToLower().Contains(q)).ToList();
            }

            if (offset > 0)
                users = users.Skip(offset).ToList();

            if (limit.HasValue)
                users = users.Take(limit.Value).ToList();

            return users;
        }

        public User GetUser(int id)
        {
            return _repository.FindBy(id);
        }

        public bool UpdateUser(int id, User user)
        {
            try
            {
                _repository.Update(user);
                _unitOfWork.Commit();
                return true;
            }
            catch
            {
                _unitOfWork.Rollback();
                // log exception
                return false;
            }
        }

        public bool DeleteUser(int id)
        {
            try
            {
                User user = _repository.FindBy(id);
                if (user != null)
                    _repository.Delete(user);
                _unitOfWork.Commit();
                return true;
            }
            catch
            {
                _unitOfWork.Rollback();
                // log exception
                return false;
            }
        }

        public bool CreateUser(User user)
        {
            try
            {
                _repository.Add(user);
                _unitOfWork.Commit();
                return true;
            }
            catch
            {
                _unitOfWork.Rollback();
                // log exception
                return false;
            }
        }
    }
}
