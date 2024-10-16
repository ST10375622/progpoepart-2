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
		public string FileName { get; set; }
		public string FileExtension { get; set; }
		//the file limit is set to 10mb
		[Range(1, 10 * 1024 * 1024, ErrorMessage = "File size exceeds the 10 MB limit.")]
		public long FileSize { get; set; }
		public string FilePath { get; set; }
		//the document is linked to the lecturer
		public Lecturer Lecturer { get; set; }
	}
}
