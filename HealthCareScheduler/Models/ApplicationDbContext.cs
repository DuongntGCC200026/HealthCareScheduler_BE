using HealthCareScheduler.Constraints;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage;

namespace HealthCareScheduler.Models
{
	public class ApplicationDbContext : DbContext
	{
		public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
		{
			try
			{
				if (Database.GetService<IDatabaseCreator>() is RelationalDatabaseCreator databaseCreator)
				{
					if (!databaseCreator.CanConnect())
					{
						Console.WriteLine("Create Db");

						databaseCreator.Create();
					}
				}
			}
			catch (Exception ex)
			{
				Console.WriteLine(ex.Message);
			}
		}

		public ApplicationDbContext()
		{
		}

		public DbSet<Appointment> Appointments { get; set; }
		public DbSet<Branch> Branches { get; set; }
		public DbSet<Feedback> Feedbacks { get; set; }
		public DbSet<MedicalRecord> MedicalRecords { get; set; }
		public DbSet<Role> Roles { get; set; }
		public DbSet<Service> Services { get; set; }
		public DbSet<User> Users { get; set; }

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			base.OnModelCreating(modelBuilder);

			modelBuilder.Entity<User>()
				.HasMany(u => u.PatientApppointments)
				.WithOne(u => u.Patient)
				.HasForeignKey(u => u.PatientId)
				.HasPrincipalKey(u => u.UserId)
				.OnDelete(DeleteBehavior.Restrict);

			modelBuilder.Entity<User>()
				.HasMany(u => u.DoctorApppointments)
				.WithOne(u => u.Doctor)
				.HasForeignKey(u => u.DoctorId)
				.HasPrincipalKey(u => u.UserId)
				.OnDelete(DeleteBehavior.Restrict);

			// Seed Roles
			modelBuilder.Entity<Role>().HasData(
				new Role { RoleId = new Guid("F0C0879E-9FF3-4A24-A0E7-0FF51EAB20DF"), Name = ERole.Administrator.ToString() },
				new Role { RoleId = new Guid("E4EF916D-6074-4DA9-AB77-4AD8D4240E8B"), Name = ERole.BranchManagement.ToString() },
				new Role { RoleId = new Guid("6426DA65-82BB-4BB0-B3BC-B0B85B285BFA"), Name = ERole.Doctor.ToString() },
				new Role { RoleId = new Guid("257043FF-6A57-4CC0-AD16-629F631296D9"), Name = ERole.Patient.ToString() }
			);

			string adminPassword = "12345678";
			PasswordHasher<string> passwordHasher = new();
			string password = passwordHasher.HashPassword(null, adminPassword);

			// Seed Users
			modelBuilder.Entity<User>().HasData(
				new User
				{
					UserId = new Guid("53724A55-7FC2-4819-88F1-6291D5DB64EA"),
					Email = "admin@gmail.com",
					Password = password,
					FirstName = "Admin",
					LastName = "Admin",
					DateOfBirth = new DateTime(2002, 3, 15),
					Address = "Admin Address",
					Specialization = "Admin",
					PhoneNumber = "1234567890",
					RoleId = new Guid("F0C0879E-9FF3-4A24-A0E7-0FF51EAB20DF")
				}
			);
		}
	}
}
