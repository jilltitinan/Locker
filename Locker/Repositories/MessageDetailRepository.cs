using Locker.DatabaseContext;
using Locker.DatabaseContext.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Locker.Repositories
{
    public class MessageDetailRepository
    {
        LockerDbContext _dbContext;

        public MessageDetailRepository(LockerDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public bool AddMessage(MessageDetail _message)
        {

            try
            {
                _dbContext.MessageDetails.Add(_message);
                _dbContext.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                Console.WriteLine("Exception error");
                return false;
            }
        }

        public bool DeleteMessage(int id)
        {
            try
            {
                _dbContext.MessageDetails.FirstOrDefault(x => x.Id_message == id).IsShow = false;
                _dbContext.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                Console.WriteLine("Exception error");
                return false;
            }
        }

        
        public List<Content> GetContent()
        {
            return _dbContext.Contents.ToList();
        }

        public List<Content> GetContent(int id)
        {

            return _dbContext.Contents.Where(x => x.Id_content == id).ToList();
        }


    }
}
