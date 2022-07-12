using BookStore1.Models.Models;
using BookStore1.Models.Model;
using BookStore1.Repository;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace BookStore1.Api.Controllers
{
    [Route("api/category")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        CategoryRepository _categoryRepository = new CategoryRepository();

        [Route("list")]
        [HttpGet]
        public IActionResult GetCatogires(int pageIndex = 1, int pageSize = 10, string keyword = "")
        {
            var categories = _categoryRepository.GetCategories(pageIndex, pageSize, keyword);
            ListResponse<CategoryModel> listResponse = new ListResponse<CategoryModel>()
            {
                Results = categories.Results.Select(c => new CategoryModel(c)),
                TotalRecords = categories.TotalRecords,
            };

            return Ok(listResponse);
        }

        [Route("{id}")]
        [HttpGet]
        public IActionResult GetCategory(int id)
        {
            var category = _categoryRepository.GetCategory(id);
            CategoryModel categoryModel = new CategoryModel(category);

            return Ok(categoryModel);
        }

        [Route("add")]
        [HttpPost]
        public IActionResult AddCategory(CategoryModel model)
        {
            Category category = new Category()
            {
                Id = model.Id,
                Name = model.Name
            };
            var response = _categoryRepository.AddCategory(category);
            CategoryModel categoryModel = new CategoryModel(response);

            return Ok(categoryModel);
        }

        [Route("update")]
        [HttpPut]
        public IActionResult UpdateCategory(CategoryModel model)
        {
            Category category = new Category()
            {
                Id = model.Id,
                Name = model.Name
            };
            var response = _categoryRepository.UpdateCategory(category);
            CategoryModel categoryModel = new CategoryModel(response);

            return Ok(categoryModel);
        }

        [Route("delete/{id}")]
        [HttpDelete]
        public IActionResult DeleteCategory(int id)
        {
            var response = _categoryRepository.DeleteCategory(id);
            return Ok(response);
        }
    }
}
