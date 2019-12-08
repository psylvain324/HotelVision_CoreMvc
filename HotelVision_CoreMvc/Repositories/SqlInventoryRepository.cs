using System;
using System.Collections.Generic;
using System.Linq;
using HotelVision_CoreMvc.Data;
using HotelVision_CoreMvc.Models;
using HotelVision_CoreMvc.Services.Interfaces;
using Microsoft.Extensions.Logging;

namespace HotelVision_CoreMvc.Repositories
{
    public class SqlInventoryRepository : IRepository<InventoryItem>
    {
        private DatabaseContext databaseContext;
        private readonly ILogger logger;

        public SqlInventoryRepository(DatabaseContext databaseContext, ILogger<SqlInventoryRepository> logger)
        {
            this.databaseContext = databaseContext;
            this.logger = logger;
        }

        public bool Add(InventoryItem item)
        {
            try
            {
                databaseContext.InventoryItems.Add(item);
                databaseContext.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                logger.LogError("Failed to add Employee item to the database: " + ex.Message);
                return false;
            }
        }

        public bool Delete(InventoryItem Item)
        {
            try
            {
                InventoryItem item = Get(Item.Id);
                if (item != null)
                {
                    databaseContext.InventoryItems.Remove(Item);
                    databaseContext.SaveChanges();
                    return true;
                }
                return false;
            }
            catch (Exception ex)
            {
                logger.LogError("Unable to delete Inventory Item: " + ex.Message);
                return false;
            }
        }

        public bool Edit(InventoryItem item)
        {
            try
            {
                databaseContext.InventoryItems.Update(item);
                databaseContext.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                logger.LogError("Unable to save Inventory Item: " + ex.Message);
            }
            return false;
        }

        public InventoryItem Get(int id)
        {
            if (databaseContext.InventoryItems.Count(x => x.Id == id) > 0)
            {
                return databaseContext.InventoryItems.First(x => x.Id == id);
            }
            return null;
        }

        public InventoryItem Get(int? id)
        {
            if (id == null)
            {
                throw new ArgumentNullException();
            }
            if (databaseContext.InventoryItems.Count(x => x.Id == id) > 0)
            {
                return databaseContext.InventoryItems.FirstOrDefault(x => x.Id == id);
            }
            return null;
        }

        public IEnumerable<InventoryItem> GetAll()
        {
            return databaseContext.InventoryItems;
        }

        public bool Exists(int id)
        {
            return databaseContext.InventoryItems.SingleOrDefault(e => e.Id == id) != null;
        }
    }
}
