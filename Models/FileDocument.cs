using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace St10375622Part2.Models
{
	public class FileDocument
	{
		[Key]
		public int FileId { get; set; }
		public int? LecturerId { get; set; }
		public string? LecturerName { get; set; }
		// File upload
		[NotMapped]
		public IFormFile fileUpload { get; set; }  // File for uploading (not stored in DB)

		//allowing only certain file types, pdf,docx
		//[RegularExpression(@"([a-zA-Z0-9\s_\\.\-\(\):])+(.pdf|.docx)$", ErrorMessage = "Only pdf, doc, docx, txt, jpg, jpeg, png files allowed.")]
		public string FileName { get; set; }
		public string FileExtension { get; set; }

		[Range(1, 10 * 1024 * 1024, ErrorMessage = "File size exceeds the 10 MB limit.")]
		public long FileSize { get; set; }
		public string FilePath { get; set; }

		public Lecturer Lecturer { get; set; }
	}
}
