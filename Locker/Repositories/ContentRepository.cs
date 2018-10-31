using Locker.DatabaseContext;
using Locker.DatabaseContext.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Locker.Repositories
{
    public class ContentRepository
    {
        LockerDbContext _dbContext;

        public ContentRepository(LockerDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public bool AddContent(Content _content) {

            try
            {
                _dbContext.Contents.Add(_content);
                _dbContext.SaveChanges();
                return true;
            }
            catch(Exception)
            {
                Console.WriteLine("Exception error");
                return false;
            }
        }

        public bool DeleteContent (int id)
        {
            try
            {
                _dbContext.Contents.FirstOrDefault(x => x.Id_content == id).IsActive = false;
                _dbContext.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                Console.WriteLine("Exception error");
                return false;
            }
        }

        public bool UpdateActive (int id)
        {
            try {
                if (_dbContext.Contents.FirstOrDefault(x => x.Id_content == id) != null)
                {
                    _dbContext.Contents.FirstOrDefault(x => x.Id_content == id).IsActive = true;
                    _dbContext.SaveChanges();
                    return true;
                }
                return false;
            }
            catch(Exception)
            {
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
