using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using St10375622Part2.Data;
using St10375622Part2.Models;

namespace St10375622Part2.Controllers
{
    public class LecturerClaimController : Controller
    {
        private readonly ApplicationDbContext _context;

        public LecturerClaimController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
			var claims = _context.LecturerClaims.ToList();
			return View(claims);
        }

        public IActionResult Create()
        {
			return View();
        }

        [HttpPost]
        public IActionResult Create(LecturerClaim lecturerClaim)
        {

			if (ModelState.IsValid)
			{
				_context.LecturerClaims.Add(lecturerClaim);
				_context.SaveChanges();
				return RedirectToAction("Index");
			}
			return View(lecturerClaim);
		}

        public IActionResult Edit(int id)
        {
            var lecturerClaim = _context.LecturerClaims.Find(id);
            return View(lecturerClaim);
        }

        [HttpPost]
        public IActionResult Edit(LecturerClaim lecturerClaim)
        {
            if (ModelState.IsValid)
            {
                _context.LecturerClaims.Update(lecturerClaim);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(lecturerClaim);
        }

        public IActionResult Delete(int id)
        {
            var lecturerClaim = _context.LecturerClaims.Find(id);
            return View(lecturerClaim);
        }

        [HttpPost]
        public IActionResult Delete(LecturerClaim lecturerClaim)
        {
            _context.LecturerClaims.Remove(lecturerClaim);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

        public IActionResult Details(int id)
        {
            var lecturerClaim = _context.LecturerClaims.Find(id);
            return View(lecturerClaim);
        }

        //when the claim gets approved it will go here
        public IActionResult Approve(int id)
        {
            var lecturerClaim = _context.LecturerClaims.Find(id);
            //the status will be changed to approved
            lecturerClaim.Status = "Approved";
            _context.LecturerClaims.Update(lecturerClaim);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

        //when the claim gets rejected it will go here
        public IActionResult Reject(int id)
        {
            var lecturerClaim = _context.LecturerClaims.Find(id);
            //the status will change to rejected
            lecturerClaim.Status = "Rejected";
            _context.LecturerClaims.Update(lecturerClaim);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }


    }
}
