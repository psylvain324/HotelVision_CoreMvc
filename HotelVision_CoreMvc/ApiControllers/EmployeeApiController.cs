using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using HotelVision_CoreMvc.Services.Interfaces;
using HotelVision_CoreMvc.Models;

namespace HotelVision_CoreMvc.Controllers
{
    /// <summary>
    /// Employee Controller
    /// </summary>
    [Produces("application/json")]
	[ApiController]
    [Route("Api/Employee")]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class EmployeeApiController : Controller
    {
		private readonly IRepository<Employee> employeeRepository;
		private readonly ILogger<EmployeeController> logger;

		public EmployeeApiController(IRepository<Employee> employeeRepository, ILogger<EmployeeController> logger)
		{
			this.employeeRepository = employeeRepository;
			this.logger = logger;
		}

		/// <summary>
		/// This returns all the Employees.
		/// </summary>
		/// <returns>IEnumerable of Employees</returns>
		[HttpGet]
		[ProducesResponseType(200)]
		[ProducesResponseType(404)]
		public ActionResult<IEnumerable<Employee>> Get()
		{
			try
			{
				return Ok(employeeRepository.GetAll());
			}
			catch (Exception ex)
			{
				logger.LogError("Something went wrong:" + ex.Message);
				return NotFound();
			}
		}

		// GET: Api/Employee/{id}
		/// <summary>
		/// This method returns one employee
		/// </summary>
		/// <param name="id">Id of the employee.</param>
		/// <returns>Employee</returns>
		[HttpGet]
		public ActionResult<Employee> Get(int id)
		{
			return Ok(employeeRepository.Get(id));
		}

		// POST: Api/Employee
		/// <summary>
		/// The post method for adding a employee
		/// </summary>
		/// <returns>Created on success or appropriate code otherwise.</returns>
		[HttpPost]
        public IActionResult Create([FromBody]Employee employee)
        {
			try
			{
                if (!ModelState.IsValid)
                {
                    logger.LogError("Invalid model state.");
                    return BadRequest();
                }
                employeeRepository.Add(employee);
                return Created($"/Api/Employee/{employee.Id}", employee);
            }
			catch (Exception ex)
			{
				logger.LogError("Exception adding new employee: " + ex.Message);
				return BadRequest();
			}
        }
        
        // PUT: Api/Employee/{id}
		/// <summary>
		/// Put method to edit an existing employee.
		/// </summary>
		/// <param name="employee">Recieves Employee.</param>
		/// <returns>Appropriate Http code.</returns>
        [HttpPut]
        public IActionResult Put([FromBody]Employee employee)
        {
			try
			{
                if (!ModelState.IsValid)
                {
                    logger.LogError("Invalid model state.");
                    return BadRequest();
                }
                employeeRepository.Edit(employee);
                return Ok(employee);
            }
			catch (Exception ex)
			{
				logger.LogError("Exception adding new employee: " + ex.Message);
				return BadRequest();
			}
		}
        
        // DELETE: Api/Employee/{id}
		/// <summary>
		/// Deletes an existing employee.
		/// </summary>
		/// <param name="id">Id of the employee to be deleted.</param>
		/// <returns>Appropriate HTTP code.</returns>
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
			try
			{
				var employee = employeeRepository.Get(id);
				if (employee != null)
				{
					employeeRepository.Delete(employee);
					return Ok("Employee deleted");
				}
				return BadRequest("Could not delete employee.");
			}
			catch (Exception ex)
			{
				logger.LogError("Exception deleting the employee: " + ex.Message);
				return BadRequest();
			}
		}
    }
}
