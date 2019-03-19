using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SuperMarket.Domain.Models;
using SuperMarket.Domain.Services.Communication;

namespace SuperMarket.Domain.Services
{
    public interface ICategoryService
    {
        //Task class encapsulates the returned value in order to make preserve the asynchronous behaviour
        Task<IEnumerable<Category>> ListAsync();

        Task<CategoryResponse> SaveAsync(Category category);
        Task<CategoryResponse> UpdateAsync(int id, Category category);

        Task<CategoryResponse> DeleteAsync(int id);

    }
}