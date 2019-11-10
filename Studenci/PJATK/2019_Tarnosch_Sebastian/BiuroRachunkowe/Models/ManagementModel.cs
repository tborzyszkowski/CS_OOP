namespace BiuroRachunkowe.Models
{
	using System;
	using System.Data.Entity;
	using System.ComponentModel.DataAnnotations.Schema;
	using System.Linq;
	using System.ComponentModel.DataAnnotations;
	using System.Collections.Generic;

	public partial class ManagementModel : DbContext
	{
		public ManagementModel()
			: base("name=DefaultConnection")
		{
		}

		public virtual DbSet<AspNetRoles> AspNetRoles { get; set; }
		public virtual DbSet<AspNetUsers> AspNetUsers { get; set; }
		public virtual DbSet<AspNetUserRoles> AspNetUserRoles { get; set; }

		//protected override void OnModelCreating(DbModelBuilder modelBuilder)
		//{
		//	modelBuilder.Entity<AspNetRoles>()
		//		.HasMany(e => e.AspNetUsers)
		//		.WithMany(e => e.AspNetRoles)
		//		.Map(m => m.ToTable("AspNetUserRoles").MapLeftKey("RoleId").MapRightKey("UserId"));
		//}


	}
	[Table("AspNetUsers")]
	public partial class AspNetUsers
	{
		//[System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
		//public AspNetUsers()
		//{
		//	AspNetRoles = new HashSet<AspNetRoles>();
		//}

		public string Id { get; set; }

		[StringLength(256)]
		public string Email { get; set; }

		public bool EmailConfirmed { get; set; }

		public string PasswordHash { get; set; }

		public string SecurityStamp { get; set; }

		public string PhoneNumber { get; set; }

		public bool PhoneNumberConfirmed { get; set; }

		public bool TwoFactorEnabled { get; set; }

		public DateTime? LockoutEndDateUtc { get; set; }

		public bool LockoutEnabled { get; set; }

		public int AccessFailedCount { get; set; }

		[Required]
		[StringLength(256)]
		public string UserName { get; set; }

		//[System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
		//public virtual ICollection<AspNetRoles> AspNetRoles { get; set; }
	}
	[Table("AspNetUserRoles")]
	public partial class AspNetUserRoles
	{
		[Key]
		[Column(Order = 0)]
		public string UserId { get; set; }

		[Key]
		[Column(Order = 1)]
		public string RoleId { get; set; }
	}
	[Table("AspNetRoles")]
	public partial class AspNetRoles
	{
		//[System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
		//public AspNetRoles()
		//{
		//	AspNetUsers = new HashSet<AspNetUsers>();
		//}

		public string Id { get; set; }

		[Required]
		[StringLength(256)]
		[Display(Name="Nazwa")]
		public string Name { get; set; }

		//[System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
		//public virtual ICollection<AspNetUsers> AspNetUsers { get; set; }
	}

	public class UserListViewModel
		{
		public string Id { get; set; }
		[Display(Name ="Rola")]
		public string Role { get; set; }
		public string Login { get; set; }
	
		}
	public class UserEditViewModel
	{
		public string Id { get; set; }
		public string UserName { get; set; }
		public List<string> roles{get;set;}
	}
}
