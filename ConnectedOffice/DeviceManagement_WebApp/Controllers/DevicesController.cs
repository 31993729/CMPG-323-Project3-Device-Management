using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using DeviceManagement_WebApp.Data;
using DeviceManagement_WebApp.Models;
using DeviceManagement_WebApp.Repository;
using Microsoft.AspNetCore.Authorization;

namespace DeviceManagement_WebApp.Controllers
{
    public class DevicesController : Controller
    {

        private readonly IDeviceRepository _DeviceRepository;
        private readonly ICategoryRepository _CategoryRepository;
        private readonly IZoneRepository _ZoneRepository;
        public DevicesController(IDeviceRepository DeviceRepository, ICategoryRepository categoryRepository, IZoneRepository zoneRepository)
        {

            _DeviceRepository = DeviceRepository;
            _CategoryRepository = categoryRepository;
            _ZoneRepository = zoneRepository;
        }

        // GET: Devices
        public async Task<IActionResult> Index()
        {
            
            return View(_DeviceRepository.GetAll());
        }

        // GET: Devices/Details/5
        public async Task<IActionResult> Details(Guid id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var device =  _DeviceRepository.GetById(id);
            if (device == null)
            {
                return NotFound();
            }

            return View(device);
        }

        // GET: Devices/Create
        public IActionResult Create()
        {
            ViewData["CategoryId"] = new SelectList(_CategoryRepository.GetAll(), "CategoryId", "CategoryName");
            ViewData["ZoneId"] = new SelectList(_ZoneRepository.GetAll(), "ZoneId", "ZoneName");
            return View();
        }

        // POST: Devices/Create
        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("DeviceId,DeviceName,CategoryId,ZoneId,Status,IsActive,DateCreated")] Device device)
        {
            device.DeviceId = Guid.NewGuid();
            _DeviceRepository.Add(device);
            _DeviceRepository.Save();
            return RedirectToAction(nameof(Index));


        }

        // GET: Devices/Edit/5
        public async Task<IActionResult> Edit(Guid id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var device =  _DeviceRepository.GetById(id);
            if (device == null)
            {
                return NotFound();
            }
            ViewData["CategoryId"] = new SelectList(_CategoryRepository.GetAll(), "CategoryId", "CategoryName", device.CategoryId);
            ViewData["ZoneId"] = new SelectList(_ZoneRepository.GetAll(), "ZoneId", "ZoneName", device.ZoneId);
            return View(device);
        }

        // POST: Devices/Edit/5
        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("DeviceId,DeviceName,CategoryId,ZoneId,Status,IsActive,DateCreated")] Device device)
        {
            if (id != device.DeviceId)
            {
                return NotFound();
            }
            try
            {
                _DeviceRepository.Update(device);
                _DeviceRepository.Save();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DeviceExists(device.DeviceId))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }
            return RedirectToAction(nameof(Index));

        }

        // GET: Devices/Delete/5
        public async Task<IActionResult> Delete(Guid id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var device = _DeviceRepository.GetById(id);
            if (device == null)
            {
                return NotFound();
            }

            return View(device);
        }

        // POST: Devices/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var device =  _DeviceRepository.GetById(id);
            _DeviceRepository.Remove(device);
            _DeviceRepository.Save();
            return RedirectToAction(nameof(Index));
        }

        private bool DeviceExists(Guid id)
        {
            Device device = _DeviceRepository.GetById(id);
            if (device == null)
            { 
                return false;
            }
            else
            {
                return true;
            }
                

        }

    }
}
