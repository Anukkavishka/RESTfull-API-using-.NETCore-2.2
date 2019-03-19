using SuperMarket.Persistence.Contexts;

namespace Supermarket.Persistence.Repositories
{
    public abstract class BaseRepository
    {
        protected readonly AppDbContext _context;

        public BaseRepository(AppDbContext context)
        {
            _context = context; //this will give all the methods that lets you to access the Db.
        }
    }
}

/* 
this class is defined as abstract and that is because we can use this base class to inherit this behaviours ,properties
in every Model class by just extending this to the Modeltype that we want to create the repository.
Also look in the base repository class we have also injected the AppDbContext interface also.

*/
