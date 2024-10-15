using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using St10375622Part2.Data;
using St10375622Part2.Models;

namespace St10375622Part2.Controllers
{
	public class FileController : Controller
	{
		private readonly ApplicationDbContext _context;

		public FileController(ApplicationDbContext context)
		{
			_context = context;
		}
		public IActionResult Index()
		{

			// Fetch the list of lecturers
			var lecturers = _context.Lecturers
				.Select(l => new { l.LecturerId, l.Name })
				.ToList();

			// Populate ViewBag.Lecturer with the list of lecturers for the dropdown
			ViewBag.Lecturer = lecturers;
			//retrieve data from the database
			var files = _context.File.ToList();
					return View(files);
			
		}


		public async Task<IActionResult> UploadFile(FileDocument model)
		{
			//populate the dropdown list
			var lecturers = _context.Lecturers
				.Select(l => new { l.LecturerId, l.Name })
				.ToList();
			ViewBag.Lecturer = new SelectList(lecturers, "LecturerId", "Name");

			if (model.fileUpload != null && model.fileUpload.Length > 0)
			{
				//validate the file extension to only accept pdf, docx
				if (model.fileUpload.ContentType == "application/pdf" || 
					model.fileUpload.ContentType == "application/vnd.openxmlformats-officedocument.wordprocessingml.document" ||
					model.fileUpload.ContentType == "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet")
				{
					//get the file extension
					var fileExtension = Path.GetExtension(model.fileUpload.FileName);
					//get the file size
					var fileSize = model.fileUpload.Length;
					//get the file name
					var fileName = Path.GetFileName(model.fileUpload.FileName);
					//get the file path
					var filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "uploads", model.fileUpload.FileName);
					//copy the file to the server
					using (var stream = new FileStream(filePath, FileMode.Create))
					{
						await model.fileUpload.CopyToAsync(stream);
					}

					//retrieve the lecturer name based on the selected lecturer id
					var lecturer = _context.Lecturers.FirstOrDefault(l => l.LecturerId == model.LecturerId);
					if (lecturer != null)
					{
                        model.LecturerName = lecturer.Name;
                    }
                    else
					{
                        model.LecturerName = "Unknown";
                    }
					//save the file details to the database
					model.FileName = fileName;
					model.FileExtension = fileExtension;
					model.FileSize = fileSize;
					model.FilePath = filePath;
					_context.Add(model);
					await _context.SaveChangesAsync();
					return RedirectToAction("Index");
				}
				else
				{
					ModelState.AddModelError("fileUpload", "Invalid file type. Only pdf and docx files are allowed");
					return View("Index");
				}
			}
			
			return View();
		}

		//delete the file from the server and the database
		public async Task<IActionResult> DeleteFile(int id)
		{
            var file = _context.File.FirstOrDefault(f => f.FileId == id);
            if (file != null)
			{
                //delete the file from the server
                if (System.IO.File.Exists(file.FilePath))
				{
                    System.IO.File.Delete(file.FilePath);
                }
                //delete the file from the database
                _context.Remove(file);
                await _context.SaveChangesAsync();
            }
            return RedirectToAction("Index");
        }


	}
}

