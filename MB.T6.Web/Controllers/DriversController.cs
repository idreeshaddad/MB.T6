using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MB.T6.Entities;
using MB.T6.Web.Data;
using MB.T6.Web.Models.Drivers;
using AutoMapper;

namespace MB.T6.Web.Controllers
{
    public class DriversController : Controller
    {
        #region Data and Const

        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;

        public DriversController(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        #endregion

        #region Actions

        [HttpGet]
        public async Task<IActionResult> List()
        {
            var drivers = await _context
                                    .Drivers
                                    .ToListAsync();

            var driversVM = _mapper.Map<List<Driver>, List<DriverListViewModel>>(drivers);

            return View(driversVM);
        }

        [HttpGet]
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Drivers == null)
            {
                return NotFound();
            }

            var driver = await _context
                                    .Drivers
                                    .Include(driver => driver.Cars)
                                    .FirstOrDefaultAsync(driver => driver.Id == id);

            if (driver == null)
            {
                return NotFound();
            }

            var driverVM = _mapper.Map<Driver, DriverDetailsViewModel>(driver);

            return View(driverVM);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(DriverViewModel driverVM)
        {
            if (ModelState.IsValid)
            {
                var driver = _mapper.Map<DriverViewModel, Driver>(driverVM);

                _context.Add(driver);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(List));
            }
            return View(driverVM);
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Drivers == null)
            {
                return NotFound();
            }

            var driver = await _context.Drivers.FindAsync(id);
            if (driver == null)
            {
                return NotFound();
            }

            var driverVM = _mapper.Map<Driver, DriverViewModel>(driver);

            return View(driverVM);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, DriverViewModel driverVM)
        {
            if (id != driverVM.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                var driver = _mapper.Map<DriverViewModel, Driver>(driverVM);

                try
                {
                    
                    _context.Update(driver);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DriverExists(driver.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        // TODO log the error to log file to be reviewed later
                        throw;
                    }
                }
                return RedirectToAction(nameof(List));
            }

            return View(driverVM);
        }

        [HttpGet]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Drivers == null)
            {
                return NotFound();
            }

            var driver = await _context
                                    .Drivers
                                    .FirstOrDefaultAsync(m => m.Id == id);

            if (driver == null)
            {
                return NotFound();
            }

            var driverVM = _mapper.Map<Driver, DriverViewModel>(driver);

            return View(driverVM);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Drivers == null)
            {
                return Problem("Entity set 'ApplicationDbContext.Drivers'  is null.");
            }
            var driver = await _context.Drivers.FindAsync(id);
            if (driver != null)
            {
                _context.Drivers.Remove(driver);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(List));
        }


        [HttpGet]
        public IActionResult Search()
        {
            var drivers = new List<DriverListViewModel>(); 
            return View(drivers);
        }


        [HttpPost]
        public async Task<IActionResult> Search(string keyword)
        {
            var drivers = await _context
                                .Drivers
                                .Where(driver => 
                                        driver.FirstName.Contains(keyword)
                                        ||
                                        driver.LastName.Contains(keyword)
                                        ||
                                        driver.PhoneNumber.Contains(keyword)
                                )
                                .ToListAsync();

            var driverVMs = _mapper.Map<List<Driver>, List<DriverListViewModel>>(drivers);

            return View(driverVMs);
        }

        #endregion

        #region Private

        private bool DriverExists(int id)
        {
            return (_context.Drivers?.Any(e => e.Id == id)).GetValueOrDefault();
        } 

        #endregion
    }
}
