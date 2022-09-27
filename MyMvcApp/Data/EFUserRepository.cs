
using MyMvcApp.Models;

namespace MyMvcApp.Data
{
    public class EFUserRepository : IUser<ConnectUser>
    {
        private readonly MyMvcAppContext _dbContext;

        public EFUserRepository(MyMvcAppContext dbContext)
        {
            _dbContext = dbContext;
        }
        public ConnectUser Add(ConnectUser model)
        {
            return _dbContext.ConnectUsers.Add(model).Entity;
        }

        public int Commit()
        {
            return _dbContext.SaveChanges();
        }

        public List<ConnectUser> GetAll()
        {
            return _dbContext.ConnectUsers.ToList();
        }

        public ConnectUser GetById(int id)
        {
            return _dbContext.ConnectUsers.Single(r => r.Id == id);
        }

        public ConnectUser GetByMail(string mail)
        {
            return _dbContext.ConnectUsers.Single(r => r.Email == mail);
        }

        public ConnectUser GetByFirstName(string firstName)
        {
            return _dbContext.ConnectUsers.Single(r => r.FirstName == firstName);
        }
    }
}