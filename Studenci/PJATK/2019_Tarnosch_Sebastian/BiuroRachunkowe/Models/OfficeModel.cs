namespace BiuroRachunkowe.Models
{
	using System;
	using System.Data.Entity;
	using System.ComponentModel.DataAnnotations.Schema;
	using System.Linq;
	using System.ComponentModel.DataAnnotations;
	using System.Web.Mvc;
	using System.Collections.Generic;
	using BiuroRachunkowe.Validation;

	public partial class OfficeModel : DbContext
	{
		public OfficeModel()
			: base("name=DefaultConnection")
		{
		}

		public virtual DbSet<InvoiceHeader> InvoiceHeader { get; set; }
		public virtual DbSet<InvoicePosition> InvoicePosition { get; set; }
		public virtual DbSet<SAD> SAD { get; set; }
		public virtual DbSet<SadPositions> SadPositions { get; set; }
		public virtual DbSet<SAD_Invoice> SAD_Invoice { get; set; }

		protected override void OnModelCreating(DbModelBuilder modelBuilder)
		{
			modelBuilder.Entity<InvoiceHeader>()
				.Property(e => e.InvoiceNumber)
				.IsUnicode(false);



			modelBuilder.Entity<InvoiceHeader>()
				.Property(e => e.Voucher)
				.IsUnicode(false);

			modelBuilder.Entity<InvoiceHeader>()
				.Property(e => e.Remarks)
				.IsUnicode(false);

			modelBuilder.Entity<InvoiceHeader>()
				.Property(e => e.Currency)
				.IsUnicode(false);

			modelBuilder.Entity<InvoiceHeader>()
				.Property(e => e.ExchangeRate)
				.HasPrecision(10, 6);

			modelBuilder.Entity<InvoiceHeader>()
				.Property(e => e.InvoiceValue)
				.HasPrecision(14, 2);

			modelBuilder.Entity<InvoiceHeader>()
				.Property(e => e.TransportCost)
				.HasPrecision(14, 2);

			modelBuilder.Entity<InvoiceHeader>()
				.Property(e => e.AdditionalCost)
				.HasPrecision(14, 2);

			modelBuilder.Entity<InvoiceHeader>()
				.Property(e => e.Supplier)
				.IsUnicode(false);

			modelBuilder.Entity<InvoiceHeader>()
				.Property(e => e.ShipFrom)
				.IsUnicode(false);

			modelBuilder.Entity<InvoiceHeader>()
				.Property(e => e.TypeOfTranosport)
				.IsUnicode(false);

			modelBuilder.Entity<InvoicePosition>()
				.Property(e => e.Itemnumber)
				.IsUnicode(false);

			modelBuilder.Entity<InvoicePosition>()
				.Property(e => e.Quantity)
				.HasPrecision(14, 3);

			modelBuilder.Entity<InvoicePosition>()
				.Property(e => e.Price)
				.HasPrecision(14, 6);

			modelBuilder.Entity<InvoicePosition>()
				.Property(e => e.UnitOfMeasure)
				.IsUnicode(false);

			modelBuilder.Entity<InvoicePosition>()
				.Property(e => e.Weight)
				.HasPrecision(12, 3);

			modelBuilder.Entity<InvoicePosition>()
				.Property(e => e.HSCode)
				.IsUnicode(false);

			modelBuilder.Entity<InvoicePosition>()
				.Property(e => e.AdditionalCost)
				.HasPrecision(14, 6);

			modelBuilder.Entity<InvoicePosition>()
				.Property(e => e.TransportsCost)
				.HasPrecision(14, 6);

			modelBuilder.Entity<InvoicePosition>()
				.Property(e => e.CountryOfOrigin)
				.IsUnicode(false);

			modelBuilder.Entity<SAD>()
				.Property(e => e.SadNumber)
				.IsUnicode(false);

			modelBuilder.Entity<SAD>()
				.Property(e => e.Currency)
				.IsUnicode(false);

			modelBuilder.Entity<SAD>()
				.Property(e => e.ExchangeRate)
				.HasPrecision(10, 6);


			modelBuilder.Entity<SAD>()
				.Property(e => e.Paid)
				.IsFixedLength()
				.IsUnicode(false);

			modelBuilder.Entity<SAD>()
				.Property(e => e.Remarks)
				.IsUnicode(false);

			modelBuilder.Entity<SadPositions>()
				.Property(e => e.HSCode)
				.IsUnicode(false);

			modelBuilder.Entity<SadPositions>()
				.Property(e => e.CountryOfOrigin)
				.IsUnicode(false);

			modelBuilder.Entity<SadPositions>()
				.Property(e => e.Rate)
				.HasPrecision(7, 4);

			modelBuilder.Entity<SadPositions>()
				.Property(e => e.PositionValue)
				.HasPrecision(14, 2);

			modelBuilder.Entity<SadPositions>()
				.Property(e => e.DutyValue)
				.HasPrecision(14, 2);

			modelBuilder.Entity<SAD_Invoice>()
				.Property(e => e.CUSTOM_VALUE)
				.HasPrecision(14, 2);

			modelBuilder.Entity<SAD_Invoice>()
				.Property(e => e.DUTY_VALUE)
				.HasPrecision(14, 2);
		}

	}
	[Table("InvoiceHeader")]
	public partial class InvoiceHeader
	{
		public long Id { get; set; }

		[Required]
		[StringLength(50)]
		[Display(Name ="Numer Faktury")]
		public string InvoiceNumber { get; set; }

		[Column(TypeName = "date")]
		[DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
		[Display(Name = "Data Faktury")]
		public DateTime InvoiceDate { get; set; }

	

		[StringLength(30)]
		[Display(Name = "Voucher")]
		public string Voucher { get; set; }

		[StringLength(255)]
		[Display(Name = "Uwagi")]
		public string Remarks { get; set; }

		[Required]
		[StringLength(3)]
		[Display(Name = "Waluta")]
		public string Currency { get; set; }

		[Column(TypeName = "numeric")]
		[Display(Name = "Kurs Waluty")]
		public decimal ExchangeRate { get; set; }

		[Column(TypeName = "numeric")]
		[Display(Name = "Wartosc Faktury")]
		public decimal InvoiceValue { get; set; }

		[Column("TransportCost ", TypeName = "numeric")]
		[Display(Name = "Koszty Transportu")]
		public decimal? TransportCost { get; set; }

		[Column(TypeName = "numeric")]
		[Display(Name = "Dodatkowe Koszty")]
		public decimal? AdditionalCost { get; set; }

		[Required]
		[StringLength(11)]
		[Display(Name = "Dostawca")]
		public string Supplier { get; set; }

		[StringLength(11)]
		[Display(Name = "Pochodzenie")]
		public string ShipFrom { get; set; }

		[StringLength(15)]
		[Display(Name = "Typ Transportu")]
		public string TypeOfTranosport { get; set; }
	}
	public class InvoiceHeaderViewModel
	{
		public long Id { get; set; }

		[Required]
		[StringLength(50)]
		[Display(Name = "Numer Faktury")]
		public string InvoiceNumber { get; set; }

		[Column(TypeName = "date")]
		[DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
		[Display(Name = "Data Faktury")]
		public DateTime InvoiceDate { get; set; }

		

		[StringLength(30)]
		[Display(Name = "Voucher")]
		public string Voucher { get; set; }

		[StringLength(255)]
		[Display(Name = "Uwagi")]
		public string Remarks { get; set; }

		[Required]
		[StringLength(3)]
		[Display(Name = "Waluta")]
		public string Currency { get; set; }
		public IEnumerable<SelectListItem> CurrencyDDL
		{
			get
			{
				return new[]
				{
					new SelectListItem {Value="PLN",Text="Z£" },
					new SelectListItem {Value="USD",Text="USD" },
					new SelectListItem {Value="EUR",Text="EUR" },
				};
			}
		}

		[Column(TypeName = "numeric")]
		[Display(Name = "Kurs Waluty")]
		public decimal ExchangeRate { get; set; }

		[Column(TypeName = "numeric")]
		[Display(Name = "Wartosc Faktury")]
		public decimal InvoiceValue { get; set; }

		[Column("TransportCost ", TypeName = "numeric")]
		[Display(Name = "Koszty Transportu")]
		public decimal? TransportCost { get; set; }

		[Column(TypeName = "numeric")]
		[Display(Name = "Dodatkowe Koszty")]
		public decimal? AdditionalCost { get; set; }

		[Required]
		[StringLength(11)]
		[Display(Name = "Dostawca")]
		public string Supplier { get; set; }
		public IEnumerable<SelectListItem> SupplierDDL
		{
			get
			{
				return new[]
				{
					new SelectListItem {Value="DHL",Text="DHL" },
					new SelectListItem {Value="BC",Text="BC Company" },
				};
			}
		}

		[StringLength(11)]
		[Display(Name = "Pochodzenie")]
		public string ShipFrom { get; set; }
		public IEnumerable<SelectListItem> ShipFromDDL
		{
			get
			{
				return new[]
				{
					new SelectListItem {Value="PL",Text="Polska" },
					new SelectListItem {Value="DE",Text="Niemcy" },
					new SelectListItem {Value="US",Text="USA" },
				};
			}
		}

		[StringLength(15)]
		[Display(Name = "Typ Transportu")]
		public string TypeOfTranosport { get; set; }
		public IEnumerable<SelectListItem> TypeOfTransportDDL
		{
			get
			{
				return new[]
				{
					new SelectListItem {Value="Pociag",Text="Poci¹g" },
					new SelectListItem {Value="Samolot",Text="Samolot" },
					new SelectListItem {Value="Tir",Text="Tir" },
					new SelectListItem {Value="Statek",Text="Statek" },
				};
			}
		}
	}
	[Table("InvoicePosition")]
	public partial class InvoicePosition
	{
		public long InvoiceId { get; set; }

		public long Id { get; set; }

		[Display(Name = "Numer Pozycji")]
		public int? PositionNumber { get; set; }

		[Required]
		[StringLength(18)]
		[Display(Name = "Numer Komponentu")]
		public string Itemnumber { get; set; }

		[Column(TypeName = "numeric")]
		[Display(Name = "Iloœæ")]
		public decimal Quantity { get; set; }

		[Column(TypeName = "numeric")]
		[Display(Name = "Cena")]
		public decimal Price { get; set; }

		[Required]
		[StringLength(4)]
		[Display(Name = "Jednostka Miary")]
		public string UnitOfMeasure { get; set; }

		[Column(TypeName = "numeric")]
		[Display(Name = "Waga")]
		public decimal Weight { get; set; }

		[StringLength(13)]
		[Display(Name = "Kod HS")]
		public string HSCode { get; set; }

		[Column(TypeName = "numeric")]
		[Display(Name = "Dodatkowe Koszty")]
		public decimal? AdditionalCost { get; set; }

		[Column(TypeName = "numeric")]
		[Display(Name = "Koszty Transportu")]
		public decimal? TransportsCost { get; set; }

		[StringLength(50)]
		public string CountryOfOrigin { get; set; }

		[NotMapped]
		public decimal? value { get; set; } = 0;
	}

	public class InvoicePositionViewModel
	{
		public long InvoiceId { get; set; }

		public long Id { get; set; }

		[Display(Name = "Numer Pozycji")]
		public int? PositionNumber { get; set; }

		[Required]
		[StringLength(18)]
		[Display(Name = "Numer Komponentu")]
		public string Itemnumber { get; set; }
		public IEnumerable<SelectListItem> ItemnumberDDL
		{
			get
			{
				return new[]
				{
					new SelectListItem {Value="123",Text="Œrubka" },
					new SelectListItem {Value="343",Text="Uk³ad Scalony" },
					new SelectListItem {Value="536",Text="Drut" },
				};
			}
		}

		[Column(TypeName = "numeric")]
		[Display(Name = "Iloœæ")]
		public decimal Quantity { get; set; }

		[Column(TypeName = "numeric")]
		[Display(Name = "Cena")]
		public decimal Price { get; set; }

		[Required]
		[StringLength(4)]
		[Display(Name = "Jednostka Miary")]
		public string UnitOfMeasure { get; set; }
		public IEnumerable<SelectListItem> UnitOfMeasureDDL
		{
			get
			{
				return new[]
				{
					new SelectListItem {Value="szt",Text="Sztuka" },
					new SelectListItem {Value="m",Text="Metr" },
					new SelectListItem {Value="kg",Text="Kilogram" },
				};
			}
		}

		[Column(TypeName = "numeric")]
		[Display(Name = "Waga")]
		public decimal Weight { get; set; }

		[StringLength(13)]
		[Display(Name = "Kod HS")]
		public string HSCode { get; set; }

		[Column(TypeName = "numeric")]
		[Display(Name = "Dodatkowe Koszty")]
		public decimal? AdditionalCost { get; set; }

		[Column(TypeName = "numeric")]
		[Display(Name = "Koszty Transportu")]
		public decimal? TransportsCost { get; set; }

		[StringLength(50)]
		public string CountryOfOrigin { get; set; }
		public IEnumerable<SelectListItem> CountryOfOriginDDL
		{
			get
			{
				return new[]
				{
					new SelectListItem {Value="PL",Text="Polska" },
					new SelectListItem {Value="DE",Text="Niemcy" },
					new SelectListItem {Value="US",Text="USA" },
				};
			}
		}

		[NotMapped]
		public decimal? value { get; set; } = 0;
	}


	[Table("SAD")]
	public partial class SAD
	{
		public long Id { get; set; }

		[Required]
		[SADNumberValidation]
		[StringLength(25)]
		[Display(Name = "Numer SADu")]
		public string SadNumber { get; set; }

		[Column(TypeName = "date")]
		[DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
		[Display(Name = "Data SADu")]
		public DateTime SadDate { get; set; }

		[Required]
		[StringLength(3)]
		[Display(Name = "Waluta")]
		public string Currency { get; set; }

		[Column(TypeName = "numeric")]
		[Display(Name = "Kurs")]
		public decimal ExchangeRate { get; set; }

		

		[StringLength(1)]
		[Display(Name = "Zap³acono?")]
		public string Paid { get; set; }

		[Column(TypeName = "date")]
		[Display(Name = "Data zap³aty")]
		public DateTime? PaidDate { get; set; }

		[StringLength(255)]
		[Display(Name = "Uwagi")]
		public string Remarks { get; set; }
	}
	public partial class SAD_Invoice
	{
		[Key]
		[Column(Order = 0)]
		[DatabaseGenerated(DatabaseGeneratedOption.None)]
		public long ID_SAD { get; set; }

		[Key]
		[Column(Order = 1)]
		[DatabaseGenerated(DatabaseGeneratedOption.None)]
		public long ID_SAD_POS { get; set; }

		[Key]
		[Column(Order = 2)]
		[DatabaseGenerated(DatabaseGeneratedOption.None)]
		public long ID_INV { get; set; }

		[Key]
		[Column(Order = 3)]
		[DatabaseGenerated(DatabaseGeneratedOption.None)]
		public long ID_INV_POS { get; set; }

		[Column(TypeName = "numeric")]
		public decimal? CUSTOM_VALUE { get; set; }

		[Column(TypeName = "numeric")]
		public decimal? DUTY_VALUE { get; set; }
	}
	public partial class SadPositions
	{
		public long? IdSad { get; set; }

		public long Id { get; set; }

		[Required]
		[Display(Name = "Kod HS")]
		[StringLength(13)]
		public string HSCode { get; set; }

		[Required]
		[StringLength(3)]
		[Display(Name = "Kraj Pochodzenia")]
		public string CountryOfOrigin { get; set; }

		[Column(TypeName = "numeric")]
		[Display(Name = "Stawka")]
		public decimal Rate { get; set; }

		[Display(Name = "Wartoœæ pozycji")]
		[Column(TypeName = "numeric")]
		public decimal? PositionValue { get; set; }

		[Display(Name = "Wartoœæ C³a")]
		[Column(TypeName = "numeric")]
		public decimal? DutyValue { get; set; }
	}

	public class importInvoiceDate
	{
		[Display(Name = " Date From")]
		public DateTime from { get; set; }

		[Display(Name = "Date To")]
		public DateTime to { get; set; }

	}
}
