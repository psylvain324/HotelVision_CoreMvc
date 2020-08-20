using System;
using System.Linq;
using System.Threading.Tasks;
using HotelVision_CoreMvc.Data;
using HotelVision_CoreMvc.Models;
using HotelVision_CoreMvc.Models.ViewModels;
using HotelVision_CoreMvc.Repositories;
using Microsoft.AspNetCore.Hosting.Server;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace HotelVision_CoreMvc.Controllers
{
    public class InventoryController : Controller
    {
        private readonly SqlInventoryRepository inventoryRepository;
        private readonly DatabaseContext databaseContext;
        private readonly ILogger<InventoryController> logger;
        private readonly IServer server;

        public InventoryController(SqlInventoryRepository inventoryRepository, DatabaseContext databaseContext,
            ILogger<InventoryController> logger, IServer server)
        {
            this.inventoryRepository = inventoryRepository;
            this.databaseContext = databaseContext;
            this.logger = logger;
        }

        // GET: InventoryIndex
        public async Task<IActionResult> InventoryIndex(int? pageNumber)
        {
            var inventoryItems = from i in databaseContext.InventoryItems select i;
            return View(await PaginatedList<InventoryItem>.CreateAsync(inventoryItems.AsNoTracking(), pageNumber ?? 1, 10));
        }

        // GET: Inventory/InventoryDetails
        public IActionResult InventoryDetails(int? id)
        {
            if (id == null)
            {
                return BadRequest();
            }

            var inventoryItem = inventoryRepository.GetAll().FirstOrDefault(m => m.Id == id);
            if (inventoryItem == null)
            {
                return NotFound();
            }
            return View(inventoryItem);
        }

        // GET: Inventory/InventoryCreate
        public IActionResult InventoryCreate()
        {
            return View();
        }

        // POST: Inventory/InventoryCreate
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult InventoryDelete([Bind("Id,ItemName,Category,CurrentStock,Capacity,UnitCost,RestockScheduled,RestockScheduleDate,")] InventoryItem inventoryItem)
        {
            if (ModelState.IsValid)
            {
                inventoryRepository.Add(inventoryItem);
                return RedirectToAction(nameof(Index));
            }
            return View(inventoryItem);
        }

        // GET: Inventory/InventoryEdit
        [HttpGet]
        public IActionResult InventoryEdit(int? id)
        {
            if (id == null)
            {
                return BadRequest();
            }

            var inventoryItem = inventoryRepository.Get((int)id);
            if (inventoryItem == null)
            {
                return NotFound();
            }
            return View(inventoryItem);
        }

        // POST: Inventory/InventoryEdit
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult InventoryEdit(int id, [Bind("Id,ItemName,Category,CurrentStock,Capacity,UnitCost,RestockScheduled,RestockScheduleDate,")] InventoryItem inventoryItem)
        {
            if (id != inventoryItem.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    inventoryRepository.Edit(inventoryItem);
                }
                catch (Exception ex)
                {
                    if (!InventoryItemExists(inventoryItem.Id))
                    {
                        return NotFound();
                    }
                    logger.LogError(ex.Message);
                }
                return RedirectToAction("InventoryIndex", "Inventory");
            }
            return View(inventoryItem);
        }

        //GET: Inventory/InventoryDelete
        public IActionResult InventoryDelete(int? id)
        {
            if (id == null)
            {
                return BadRequest();
            }

            var inventoryItem = inventoryRepository.Get((int)id);
            if (inventoryItem == null)
            {
                return NotFound();
            }

            return View(inventoryItem);
        }

        //POST: Inventory/Delete
        [HttpPost, ActionName("InventoryDelete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            var inventoryItem = inventoryRepository.Get(id);
            inventoryRepository.Delete(inventoryItem);
            return RedirectToAction(nameof(InventoryIndex));
        }

        private bool InventoryItemExists(int id)
        {
            return inventoryRepository.Get(id) != null;
        }
    }
}
