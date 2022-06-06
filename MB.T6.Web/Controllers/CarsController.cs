using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MB.T6.Entities;
using MB.T6.Web.Data;
using AutoMapper;
using MB.T6.Web.Models.Cars;

namespace MB.T6.Web.Controllers
{
    public class CarsController : Controller
    {
        #region Data and Const

        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;

        public CarsController(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        #endregion

        #region Actions

        public async Task<IActionResult> Index()
        {
            var cars = await _context
                                .Cars
                                .Include(car => car.Driver)
                                .ToListAsync();

            var carsVM = _mapper.Map<List<Car>, List<CarListViewModel>>(cars);

            return View(carsVM);
        }

        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Cars == null)
            {
                return NotFound();
            }

            var car = await _context
                                .Cars
                                .Include(car => car.Driver)
                                .FirstOrDefaultAsync(m => m.Id == id);

            if (car == null)
            {
                return NotFound();
            }

            var carVM = _mapper.Map<Car, CarViewModel>(car);

            return View(carVM);
        }

        public IActionResult Create()
        {
            ViewData["driversSource"] = new SelectList(_context.Drivers, "Id", "FullName");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CarViewModel carVM)
        {
            if (ModelState.IsValid)
            {
                var car = _mapper.Map<CarViewModel, Car>(carVM);

                _context.Add(car);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            ViewData["DriverId"] = new SelectList(_context.Drivers, "Id", "FullName", carVM.DriverId);
            return View(carVM);
        }

        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Cars == null)
            {
                return NotFound();
            }

            var car = await _context.Cars.FindAsync(id);

            if (car == null)
            {
                return NotFound();
            }

            ViewData["driversSource"] = new SelectList(_context.Drivers, "Id", "FullName", car.DriverId);

            var carVM = _mapper.Map<Car, CarViewModel>(car);

            return View(carVM);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, CarViewModel carVM)
        {
            if (id != carVM.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                var car = _mapper.Map<CarViewModel, Car>(carVM);

                _context.Update(car);
                await _context.SaveChangesAsync();

                return RedirectToAction(nameof(Index));
            }

            ViewData["DriverId"] = new SelectList(_context.Drivers, "Id", "FirstName", carVM.DriverId);
            return View(carVM);
        }

        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Cars == null)
            {
                return NotFound();
            }

            var car = await _context
                                .Cars
                                .Include(car => car.Driver)
                                .FirstOrDefaultAsync(m => m.Id == id);

            if (car == null)
            {
                return NotFound();
            }

            var carVM = _mapper.Map<Car, CarViewModel>(car);

            return View(carVM);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Cars == null)
            {
                return Problem("Entity set 'ApplicationDbContext.Cars'  is null.");
            }
            var car = await _context.Cars.FindAsync(id);
            if (car != null)
            {
                _context.Cars.Remove(car);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public IActionResult AdvancedSearch()
        {
            var VM = new CarSearchViewModel();
            return View(VM);
        }

        [HttpPost]
        public async Task<IActionResult> AdvancedSearch(CarSearchViewModel viewModel)
        {
            var cars = await _context
                            .Cars
                            .Include(car => car.Driver)
                            .Where(car => car.Manufacturer == viewModel.Manufacturer)
                            .ToListAsync();

            var carVMs = _mapper.Map<List<Car>, List<CarListViewModel>>(cars);

            viewModel.Results = carVMs;

            return View(viewModel);
        }

        #endregion

        #region Private Methods

        private bool CarExists(int id)
        {
            return (_context.Cars?.Any(e => e.Id == id)).GetValueOrDefault();
        }

        #endregion
    }
}
