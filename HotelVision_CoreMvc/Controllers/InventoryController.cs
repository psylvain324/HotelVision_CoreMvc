﻿using System;
using System.Linq;
using HotelVision_CoreMvc.Models;
using HotelVision_CoreMvc.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace HotelVision_CoreMvc.Controllers
{
    public class InventoryController : Controller
    {
        private readonly IRepository<InventoryItem> inventoryRepository;
        private readonly ILogger<InventoryController> logger;

        public InventoryController(IRepository<InventoryItem> inventoryRepository, ILogger<InventoryController> logger)
        {
            this.inventoryRepository = inventoryRepository;
            this.logger = logger;
        }

        // GET: InventoryIndex
        public IActionResult InventoryIndex()
        {
            return View(inventoryRepository.GetAll());
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
                    else
                    {
                        logger.LogError(ex.Message);
                    }
                }
                return RedirectToAction("InventoryIndex", "Inventory");
            }
            return View(inventoryItem);
        }

        // GET: Inventory/InventoryDelete
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

        // POST: Invetory/Delete
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
