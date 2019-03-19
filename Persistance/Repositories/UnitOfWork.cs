using System.Threading.Tasks;
using SuperMarket.Domain.Repositories;
using SuperMarket.Persistence.Contexts;

namespace SuperMarket.Persistence.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly AppDbContext _context;

        public UnitOfWork(AppDbContext context)
        {
            _context = context;
        }

        public async Task CompleteAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}

/*
Separating the persistence logic from business rules gives 
many advantages in terms of code reusability and maintenance. 
If we use EF Core directly, we’ll end up having more complex 
classes that won’t be so easy to change.

But this Unit of work Pattern and the Respository Pattern 
both are implemented behind the scenes by EF core. still its good 
programming prcatice to devide the business logic and persistence.


 */
