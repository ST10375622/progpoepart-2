﻿using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using St10375622Part2.Models;

namespace St10375622Part2.Data
{
	public class ApplicationDbContext : IdentityDbContext
	{
		public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
			: base(options)
		{
		}

		public DbSet<FileDocument> File { get; set; }

		public DbSet<Lecturer> Lecturers { get; set; }
	}
}
