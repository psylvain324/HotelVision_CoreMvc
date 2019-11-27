using HotelVision_CoreMvc.Data;
using HotelVision_CoreMvc.Models;
using HotelVision_CoreMvc.Services.Interfaces;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;

namespace HotelVision_CoreMvc.Services
{
    public class SqlEmployeeRepository : IRepository<Employee>
	{
        private DatabaseContext databaseContext;
        private readonly ILogger logger;

        public SqlEmployeeRepository(DatabaseContext databaseContext, ILogger<SqlEmployeeRepository> logger)
		{
			this.databaseContext = databaseContext;
			this.logger = logger;
		}

		public bool Add(Employee item)
		{
			try
			{
				databaseContext.Employees.Add(item);
				databaseContext.SaveChanges();
				return true;
			}
			catch (Exception ex)
			{
				logger.LogError("Failed to add Employee item to the database: " + ex.Message);
				return false;
			}
		}

		public bool Delete(Employee Item)
		{
			try
			{
				Employee employee = Get(Item.Id);
				if (employee != null)
				{
					databaseContext.Employees.Remove(Item);
					databaseContext.SaveChanges();
					return true;
				}
				return false;
			}
			catch (Exception ex)
			{
				logger.LogError("Unable to delete employee: " + ex.Message);
				return false;
			}
		}

		public bool Edit(Employee item)
		{
			try
			{
				databaseContext.Employees.Update(item);
				databaseContext.SaveChanges();
				return true;
			}
			catch (Exception ex)
			{
				logger.LogError("Unable to save employee: " + ex.Message);
			}
			return false;
		}

		public Employee Get(int id)
		{
			if (databaseContext.Employees.Count(x => x.Id == id) > 0)
			{
				return databaseContext.Employees.First(x => x.Id == id);
			}
			return null;
		}

        public Employee Get(int? id)
        {
            if(id == null)
            {
                throw new ArgumentNullException();
            }
            if (databaseContext.Employees.Count(x => x.Id == id) > 0)
            {
                return databaseContext.Employees.FirstOrDefault(x => x.Id == id);
            }
            return null;
        }

        public IEnumerable<Employee> GetAll()
        {
            return databaseContext.Employees;
        }

        public bool Exists(int id)
        {
            return databaseContext.Employees.SingleOrDefault(e => e.Id == id) != null;
        }
    }
}
