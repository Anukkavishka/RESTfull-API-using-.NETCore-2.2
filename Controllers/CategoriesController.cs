using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SuperMarket.Domain.Models;
using SuperMarket.Domain.Services;
using SuperMarket.Resources;
using SuperMarket.Extensions;
using System;

namespace SuperMarket.Controllers
{
    [Route("/api/[controller]")]
    public class CategoriesController : Controller // path for the controller is given by the CategoriesControllers first letters before Contoller in lowercase
    {
        private readonly ICategoryService _categoryService;
        private readonly IMapper _mapper;
        public CategoriesController(ICategoryService categoryService, IMapper mapper) //dependency injection through contructor injection
        {
            _categoryService = categoryService;
            _mapper = mapper;
        }

        [HttpGet] //this tells that the below method will handle GET request for the endpoint '/api/categories'
        public async Task<IEnumerable<CategoryResource>> GetAllAsync() //async  key word tells the .NET core pipeline to use this method in async manner 
        //and the Task<IEnumerable<Category>> indicates how the response object should be and what it should contain.
        {
            //this is the declared method to get the category list in the service layer
            var categories = await _categoryService.ListAsync();//service response
            var resources = _mapper.Map<IEnumerable<Category>, IEnumerable<CategoryResource>>(categories); //mapped resource object

            return resources;
        }

        [HttpPost]
        public async Task<IActionResult> PostAsync([FromBody] SaveCategoryResource resource)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState.GetErrorMessages());


            var category = _mapper.Map<SaveCategoryResource, Category>(resource);
            var result = await _categoryService.SaveAsync(category);

            if (!result.Success)
                return BadRequest(result.Message);

            var categoryResource = _mapper.Map<Category, CategoryResource>(result.Category);
            return Ok(categoryResource);



        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutAsync(int id, [FromBody] SaveCategoryResource resource)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState.GetErrorMessages());

            var category = _mapper.Map<SaveCategoryResource, Category>(resource);
            var result = await _categoryService.UpdateAsync(id, category);

            if (!result.Success)
                return BadRequest(result.Message);

            var categoryResource = _mapper.Map<Category, CategoryResource>(result.Category);
            return Ok(categoryResource);
        }




        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            var result = await _categoryService.DeleteAsync(id);

            if (!result.Success)
                return BadRequest(result.Message);

            var categoryResource = _mapper.Map<Category, CategoryResource>(result.Category);
            return Ok(categoryResource);
        }

    }
}