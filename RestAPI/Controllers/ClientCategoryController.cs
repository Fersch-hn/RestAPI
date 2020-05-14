using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using RestAPI.Models;
using RestAPI.Models.DTO;
using RestAPI.Repository;
using RestAPI.Utils;

namespace RestAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class ClientCategoryController : ControllerBase
    {
        ICRMRepository _CRMRepository;

        public ClientCategoryController(ICRMRepository cRMRepository)
        {
            _CRMRepository = cRMRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetCategories()
        {
            var validation = new Validations();
            var categoriesList = new List<CategoriesDTO>();

            var categories = await _CRMRepository.GetClientCategories();
            if (validation.ValidationDataCount(categories.Count))
            {
                foreach (var category in categories)
                {
                    var categoryDTO = new CategoriesDTO(category);
                    categoriesList.Add(categoryDTO);
                }
            }
            return Ok(categoriesList);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetCategory(int id)
        {
            var validation = new Validations();
            var categoryFromDatabase = await _CRMRepository.GetClientCategory(id);
            if (validation.IsNotNull(categoryFromDatabase))
            {
                var categoryDTO = new CategoriesDTO(categoryFromDatabase);
                return Ok(categoryDTO);
            }
            return NotFound();
        }

        [HttpPost]
        public async Task<IActionResult> PostCategory(ClientCategory clientCategory)
        {
            var validation = new Validations();
            var categoryFromDatabase = await _CRMRepository.PostClientCategory(clientCategory);
            if (validation.IsNotNull(categoryFromDatabase))
            {
                var categoryDTO = new CategoriesDTO(categoryFromDatabase);
                return Ok(categoryDTO);
            }
            return BadRequest();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCategory(int id)
        {
            var validation = new Validations();
            var categoryFromDatabase = await _CRMRepository.GetClientCategory(id);
            if (validation.IsNotNull(categoryFromDatabase))
            {
                var result = await _CRMRepository.DeleteClientCategory(categoryFromDatabase);
                if (result)
                {
                    return Ok();
                }
                else
                {
                    return BadRequest();
                }
               
            }
            return NotFound();
        }
    }
}