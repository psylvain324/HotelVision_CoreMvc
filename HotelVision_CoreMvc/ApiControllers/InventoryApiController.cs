using System;
using System.Collections.Generic;
using HotelVision_CoreMvc.Models;
using HotelVision_CoreMvc.Services.Interfaces;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace HotelVision_CoreMvc.ApiControllers
{
    /// <summary>
    /// Inventory Api Controller
    /// </summary>
    [Produces("application/json")]
    [ApiController]
    [Route("Api/Inventory")]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class InventoryApiController : Controller
    {
        private readonly IRepository<InventoryItem> inventoryRepository;
        private readonly ILogger<InventoryApiController> logger;

        public InventoryApiController(IRepository<InventoryItem> inventoryRepository, ILogger<InventoryApiController> logger)
        {
            this.inventoryRepository = inventoryRepository;
            this.logger = logger;
        }

        /// <summary>
        /// This returns all the Inventory Items.
        /// </summary>
        /// <returns>IEnumerable of Inventory Items</returns>
        [HttpGet]
        [ProducesResponseType(200)]
        [ProducesResponseType(404)]
        public ActionResult<IEnumerable<InventoryItem>> Get()
        {
            try
            {
                return Ok(inventoryRepository.GetAll());
            }
            catch (Exception ex)
            {
                logger.LogError("Something went wrong:" + ex.Message);
                return NotFound();
            }
        }

        // GET: Api/Inventory/{id}
        /// <summary>
        /// This method returns one employee
        /// </summary>
        /// <param name="id">Id of the Inventory Item.</param>
        /// <returns>Inventory Item</returns>
        [HttpGet]
        public ActionResult<InventoryItem> Get(int id)
        {
            return Ok(inventoryRepository.Get(id));
        }

        // POST: Api/Inventory
        /// <summary>
        /// The post method for adding an Inventory Item
        /// </summary>
        /// <param name="item">Type of Invetory Item</param>
        /// <returns>Created on success or appropriate code otherwise.</returns>
        [HttpPost]
        public IActionResult Create([FromBody]InventoryItem item)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    logger.LogError("Invalid model state.");
                    return BadRequest();
                }
                else
                {
                    inventoryRepository.Add(item);
                    return Created($"/Api/Inventory/{item.Id}", item);
                }
            }
            catch (Exception ex)
            {
                logger.LogError("Exception adding new Inventory Item: " + ex.Message);
                return BadRequest();
            }
        }

        // PUT: Api/Inventory/{id}
        /// <summary>
        /// Put method to edit an existing employee.
        /// </summary>
        /// <param name="item">Recieves Invetory Item.</param>
        /// <returns>Appropriate Http code.</returns>
        [HttpPut]
        public IActionResult Put([FromBody]InventoryItem item)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    logger.LogError("Invalid model state.");
                    return BadRequest();
                }
                else
                {
                    inventoryRepository.Edit(item);
                    return Ok(item);
                }
            }
            catch (Exception ex)
            {
                logger.LogError("Exception adding new Inventory Item: " + ex.Message);
                return BadRequest();
            }
        }

        // DELETE: Api/Invetory/{id}
        /// <summary>
        /// Deletes an existing Inventory Item.
        /// </summary>
        /// <param name="id">Id of the Inventory Item to be deleted.</param>
        /// <returns>Appropriate HTTP code.</returns>
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                var item = inventoryRepository.Get(id);
                if (item != null)
                {
                    inventoryRepository.Delete(item);
                    return Ok("Invetory Item deleted");
                }
                return BadRequest("Could not delete Invetory Item.");
            }
            catch (Exception ex)
            {
                logger.LogError("Exception deleting the Inventory Item: " + ex.Message);
                return BadRequest();
            }
        }
    }
}
