using Mico.DAL;
using Mico.Models;
using Microsoft.AspNetCore.Mvc;


namespace Mico.Areas.Admin.Controllers
{
    [Area(nameof(Admin))]
    public class DoctorController : Controller
    {
        private readonly AppDbContext _context;
        private readonly IWebHostEnvironment _env;
        public DoctorController(AppDbContext context, IWebHostEnvironment env)
        {
            _context = context;
            _env = env;
        }

        public IActionResult Index()
        {
            var Doctors = _context.Doctors.ToList();
            return View(Doctors);
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(Doctor doctor, IFormFile file )
        {
            
            if (!ModelState.IsValid)
            {

                return View();
            }
            string filename = Guid.NewGuid() + file.FileName;
            var path = Path.Combine(_env.WebRootPath, "Upload", filename);
            using FileStream fileStream = new FileStream(path, FileMode.Create);

            await file.CopyToAsync(fileStream);

            doctor.PhotoUrl = "/Upload/" + filename;
            await _context.AddAsync(doctor);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }
        public IActionResult Update(int id)
        {
            var doctor = _context.Doctors.FirstOrDefault(x=>x.Id==id);
            return View(doctor);
        }
        [HttpPost]
        public async Task<IActionResult> Update(Doctor doctor, IFormFile file,int id)
        {
            if (!ModelState.IsValid)
            {

                return View();
            }
            var oldDoctor = _context.Doctors.FirstOrDefault(x => x.Id == id);
            oldDoctor.Title = doctor.Title;
            oldDoctor.Duty = doctor.Duty;
            oldDoctor.Name = doctor.Name;
            string filename = Guid.NewGuid() + file.FileName;
            var path = Path.Combine(_env.WebRootPath, "Upload", filename);
            using FileStream fileStream = new FileStream(path, FileMode.Create);

            await file.CopyToAsync(fileStream);

            doctor.PhotoUrl = "/Upload/" + filename;
            oldDoctor.PhotoUrl = doctor.PhotoUrl;
            await _context.SaveChangesAsync();

            return RedirectToAction("Index");
        }
        public IActionResult Delete(int id)
        {
            _context.Remove(_context.Doctors.FirstOrDefault(x => x.Id == id));
            _context.SaveChanges();
            return RedirectToAction("Index");

        }

    }
}
