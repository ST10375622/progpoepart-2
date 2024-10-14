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
				if (model.fileUpload.ContentType == "application/pdf" || model.fileUpload.ContentType == "application/vnd.openxmlformats-officedocument.wordprocessingml.document")
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


	}
}

