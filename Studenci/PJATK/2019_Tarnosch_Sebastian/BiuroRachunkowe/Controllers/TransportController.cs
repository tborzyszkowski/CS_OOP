using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Text;
using System.Web;
using System.Web.Mvc;
using BiuroRachunkowe.Models;

namespace BiuroRachunkowe.Controllers
{
	public class TransportController : Controller
	{
		private OfficeModel db = new OfficeModel();

		// GET: Transport
		public ActionResult SADList(long? id, string sort, string SearchString)
		{
			if (User.Identity.IsAuthenticated)
			{
				ViewBag.idd = sort == "Id" ? "Id desc" : "Id";
				ViewBag.nr = sort == "Nr" ? "Nr desc" : "Nr";
				ViewBag.date = sort == "Date" ? "Date desc" : "Date";

				List<SAD> all = SADSearch(id, SearchString, sort);
				if (Session["SelectedIdIS"] != null)
					id = Convert.ToInt32(Session["SelectedIdIS"]);
				if (all.Any())
					ViewBag.Details = db.SAD.Where(x => x.Id == id).ToList();



				return View(all.ToList());
			}
			else
				return RedirectToAction("Login", "Account");


		}

		// GET: Transport/Details/5
		public ActionResult SADDetails(long? id)
		{
			if (User.Identity.IsAuthenticated)
			{
				if (id == null)
				{
					return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
				}
				SAD sAD = db.SAD.Find(id);
				if (sAD == null)
				{
					return HttpNotFound();
				}
				return View(sAD);
			}
			else
				return RedirectToAction("Login", "Account");
		}

		[Authorize(Roles = "User,Admin")]
		public ActionResult SADCreate()
		{
			if (User.Identity.IsAuthenticated)
			{
				return View();
			}
			else
				return RedirectToAction("Login", "Account");
		}

		[Authorize(Roles = "User,Admin")]
		[HttpPost]
		[ValidateAntiForgeryToken]
		public ActionResult SADCreate([Bind(Include = "Id,SadNumber,SadDate,Currency,ExchangeRate,SadStatus,Paid,PaidDate,Remarks")] SAD sAD)
		{
			if (ModelState.IsValid)
			{
				if (sAD.SadNumber.Contains("/"))
					sAD.SadNumber = sAD.SadNumber.Replace("/", String.Empty);
				db.SAD.Add(sAD);
				db.SaveChanges();
				return RedirectToAction("SADList", new { id = sAD.Id });
			}

			return View(sAD);
		}

		[Authorize(Roles = "User,Admin")]
		public ActionResult SADEdit(long? id)
		{
			if (User.Identity.IsAuthenticated)
			{
				if (id == null)
				{
					return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
				}
				SAD sAD = db.SAD.Find(id);
				if (sAD == null)
				{
					return HttpNotFound();
				}
				return View(sAD);
			}
			else
				return RedirectToAction("Login", "Account");
		}


		[HttpPost]
		[Authorize(Roles = "User,Admin")]
		[ValidateAntiForgeryToken]
		public ActionResult SADEdit([Bind(Include = "Id,SadNumber,SadDate,Currency,ExchangeRate,SadStatus,Paid,PaidDate,Remarks")] SAD sAD)
		{
			if (ModelState.IsValid)
			{
				if (sAD.SadNumber.Contains("/"))
					sAD.SadNumber = sAD.SadNumber.Replace("/", String.Empty);
				db.Entry(sAD).State = EntityState.Modified;
				db.SaveChanges();
				return RedirectToAction("SADList", new { id = sAD.Id });
			}
			return View(sAD);
		}




		[HttpPost]
		[Authorize(Roles = "User,Admin")]
		[ValidateAntiForgeryToken]
		public ActionResult SADDelete(long id)
		{
			SAD sAD = db.SAD.Find(id);
			db.SAD.Remove(sAD);
			db.SaveChanges();
			return RedirectToAction("SADList");
		}

		public ActionResult SADInvoice(long? id, string SearchString, string sort)
		{
			if (User.Identity.IsAuthenticated)
			{
				ViewBag.idd = sort == "Id" ? "Id desc" : "Id";
				ViewBag.nr = sort == "Nr" ? "Nr desc" : "Nr";
				ViewBag.date = sort == "Date" ? "Date desc" : "Date";

				List<SAD> all = SADSearch(id, SearchString, sort);
				if (Session["SelectedIdIS"] != null)
					id = Convert.ToInt32(Session["SelectedIdIS"]);
				if (all.Any())
				{
					SAD sad = db.SAD.FirstOrDefault(x => x.Id == id);
					ViewBag.InvoiceToAdd = GetInvoiceToAdd(sad.Currency);
					ViewBag.InvoiceToDelete = GetInvoiceToDelete(sad.Id);

				}


				return View(all.ToList());
			}
			else
				return RedirectToAction("Login", "Account");
		}

		public List<InvoiceHeader> GetInvoiceToAdd(string curr)
		{
			List<InvoiceHeader> invoiceToAdd = new List<InvoiceHeader>();


			foreach (InvoiceHeader invoice in db.InvoiceHeader.Where(x => x.Currency == curr).ToList())
			{
				if (!db.SAD_Invoice.Any(x => x.ID_INV == invoice.Id) && db.InvoicePosition.Any(x => x.InvoiceId == invoice.Id)) //jezeli nie jest w tabeli łączącej i posiada pozycje to dodaj do kolekcji wys faktur
					invoiceToAdd.Add(invoice);
			}
			return invoiceToAdd.Distinct().ToList();
		}

		public List<InvoiceHeader> GetInvoiceToDelete(long id)
		{
			List<InvoiceHeader> invoiceToDelete = new List<InvoiceHeader>();
			List<long> ids = db.SAD_Invoice.Where(x => x.ID_SAD == id).Select(x => x.ID_INV).ToList();
			foreach (long l in ids)
			{
				if (db.InvoiceHeader.Where(x => x.Id == l) != null)
				{

					invoiceToDelete.AddRange(db.InvoiceHeader.Where(x => x.Id == l));

				}
			}
			return invoiceToDelete.Distinct().ToList();

		}


		public List<SAD> SADSearch(long? id, string SearchString, string sort)
		{
			var all = db.SAD.AsQueryable();




			switch (sort)
			{
				case "Id":
					all = all.OrderBy(x => x.Id);
					break;
				case "Nr":
					all = all.OrderBy(x => x.SadNumber);
					break;
				case "Nr desc":
					all = all.OrderByDescending(x => x.SadNumber);
					break;
				case "Date":
					all = all.OrderBy(x => x.SadDate);
					break;
				case "Id desc":
					all = all.OrderByDescending(x => x.Id);
					break;
				case "Date desc":
					all = all.OrderByDescending(x => x.SadDate);
					break;
				default:
					all = all.OrderByDescending(x => x.SadDate);
					break;
			}


			if (SearchString == null)
			{
				if (Session["SearchSADIS"] != null)
					SearchString = Session["SearchSADIS"].ToString();
			}
			else if (SearchString == "")
			{
				if (Session["SearchSADIS"] != null)
				{
					if (Session["SearchSADIS"].ToString() != SearchString)
					{
						Session["SelectedIdIS"] = null;
						id = null;
					}
				}
				else
				{
					Session["SelectedIdIS"] = null;
					id = null;
				}
				Session["SearchSADIS"] = "";
			}

			if (!String.IsNullOrEmpty(SearchString))
			{

				if (Session["SearchSADIS"] != null)
				{
					if (Session["SearchSADIS"].ToString() != SearchString)
					{
						Session["SelectedIdIS"] = null;
						id = null;
					}
				}
				else
				{
					Session["SelectedIdIS"] = null;
					id = null;
				}
				Session["SearchSADIS"] = SearchString;
				string SearchString2 = SearchString;
				if (SearchString.Length > 20)
				{

					if (SearchString.Contains("/"))
					{
						SearchString2 = SearchString2.Replace("/", string.Empty);
					}
					else
					{

						SearchString2 = SearchString2.Insert(3, "/");
						SearchString2 = SearchString2.Insert(10, "/");
						SearchString2 = SearchString2.Insert(13, "/");
						SearchString2 = SearchString2.Insert(20, "/");
					}
				}
				all = all.Where(x => x.Id.ToString().Contains(SearchString.Trim()) || x.SadNumber.ToLower().Contains(SearchString.ToLower().Trim()) || x.SadNumber.ToLower().Contains(SearchString2.ToLower().Trim()) || x.SadDate.ToString().Contains(SearchString.Trim()));
			}

			if (Session["SelectedIdIS"] != null)
			{
				long jd = Convert.ToInt32(Session["SelectedIdIS"]);
				if (!all.Any(x => x.Id == jd))
				{
					Session["SelectedIdIS"] = null;
					id = null;
				}
			}
			if (!all.Any())
			{
				Session["SelectedIdIS"] = null;
				id = null;
			}
			if (id != null)
			{
				Session["SelectedIdIS"] = id;
			}
			else if (Session["SelectedIdIS"] != null)
			{
				id = Convert.ToInt32(Session["SelectedIdIS"]);
			}
			else
			{
				if (all.Any())
				{
					id = all.First().Id;
					Session["SelectedIdIS"] = id;
				}
			}

			return all.ToList();
		}

		[HttpPost]
		[Authorize(Roles = "User,Admin")]
		public ActionResult AddInvoice(long[] ids)
		{
			using (var office = new OfficeModel())
			{
				using (DbContextTransaction transaction = office.Database.BeginTransaction())
				{
					long sadID = Convert.ToInt32(Session["SelectedIdIS"]);
					var sad = office.SAD.FirstOrDefault(x => x.Id == sadID);
					StringBuilder sb = new StringBuilder();
					if (ids.Any())
					{
						foreach (var id in ids)
						{

							var positionlist = office.InvoicePosition.Where(x => x.InvoiceId == id);
							if (positionlist.Any())
							{
								foreach (var position in positionlist)
								{
									if (String.IsNullOrEmpty(position.HSCode))
									{
										transaction.Rollback();
										TempData["msg"] = "<script>alert('HS Code jest pusty');</script>";
										return RedirectToAction("SADInvoice", new { id = sadID });
									}
									else
									{

										if (office.SadPositions.Any(x => x.IdSad == sadID))//jezeli sad ma jakies pozycje to:
										{
											List<SadPositions> pos = office.SadPositions.Where(x => x.IdSad == sad.Id && x.HSCode == position.HSCode && x.CountryOfOrigin == position.CountryOfOrigin).ToList(); // sprobuj znaleźć podobne pozycje po kodzie hs i kodzie pochodzenia dla sadu

											if (pos.Any())
											{
												var SADposition = pos.First();
												position.TransportsCost = position.TransportsCost.HasValue ? position.TransportsCost.Value : 0;
												SADposition.PositionValue = SADposition.PositionValue + ((position.Price * position.Quantity * sad.ExchangeRate) + position.TransportsCost);
												SADposition.DutyValue = SADposition.DutyValue.HasValue ? SADposition.DutyValue.Value : 0;
												if (SADposition.Rate == 0) // jezeli stawka jest rozna od zera
													SADposition.DutyValue = 0;
												else
													SADposition.DutyValue = Math.Round(SADposition.PositionValue.Value * SADposition.Rate);//to oblicz wart celna na dstwaie stawki i wyliczonej wartosci pozycji
												if (!office.SAD_Invoice.Any(x => x.ID_SAD == sad.Id && x.ID_SAD_POS == SADposition.Id && x.ID_INV == position.InvoiceId && x.ID_INV_POS == position.Id))
												{
													SAD_Invoice pol = new SAD_Invoice();
													pol.ID_SAD = sad.Id;
													pol.ID_SAD_POS = SADposition.Id;
													pol.ID_INV = position.InvoiceId;
													pol.ID_INV_POS = position.Id;
													office.SAD_Invoice.Add(pol);
													office.SaveChanges();

												}

											}
											else//dodaj nowa pozycje jeesli nie znaleziono
											{
												var addPosition = new SadPositions();
												addPosition.IdSad = sad.Id;
												addPosition.HSCode = position.HSCode;
												addPosition.CountryOfOrigin = position.CountryOfOrigin;
												addPosition.Rate = 0;

												position.TransportsCost = position.TransportsCost.HasValue ? position.TransportsCost.Value : 0;
												addPosition.PositionValue = (position.Price * position.Quantity * sad.ExchangeRate) + position.TransportsCost;
												if (addPosition.Rate == 0) // jezeli stawka jest rozna od zera
													addPosition.DutyValue = 0;
												else
													addPosition.DutyValue = Math.Round(addPosition.PositionValue.Value * addPosition.Rate);//to oblicz wart celna na dstwaie stawki i wyliczonej wartosci pozycji


												office.SadPositions.Add(addPosition);

												office.SaveChanges();




												if (!office.SAD_Invoice.Any(x => x.ID_SAD == sad.Id && x.ID_SAD_POS == addPosition.Id && x.ID_INV == position.InvoiceId && x.ID_INV_POS == position.Id))
												{
													SAD_Invoice pol = new SAD_Invoice();
													pol.ID_SAD = sad.Id;
													pol.ID_SAD_POS = addPosition.Id;
													pol.ID_INV = position.InvoiceId;
													pol.ID_INV_POS = position.Id;
													office.SAD_Invoice.Add(pol);
													office.SaveChanges();
												}



											}
										}
										else //jezeli nie ma pozycji to dodaj nowa
										{
											var addPosition = new SadPositions();
											addPosition.IdSad = sad.Id;
											addPosition.HSCode = position.HSCode;
											addPosition.CountryOfOrigin = position.CountryOfOrigin;
											addPosition.Rate = 0;

											position.TransportsCost = position.TransportsCost.HasValue ? position.TransportsCost.Value : 0;
											addPosition.PositionValue = (position.Price * position.Quantity * sad.ExchangeRate) + position.TransportsCost;
											if (addPosition.Rate == 0) // jezeli stawka jest rozna od zera
												addPosition.DutyValue = 0;
											else
												addPosition.DutyValue = Math.Round(addPosition.PositionValue.Value * addPosition.Rate);//to oblicz wart celna na dstwaie stawki i wyliczonej wartosci pozycji


											office.SadPositions.Add(addPosition);

											office.SaveChanges();




											if (!office.SAD_Invoice.Any(x => x.ID_SAD == sad.Id && x.ID_SAD_POS == addPosition.Id && x.ID_INV == position.InvoiceId && x.ID_INV_POS == position.Id))
											{
												SAD_Invoice pol = new SAD_Invoice();
												pol.ID_SAD = sad.Id;
												pol.ID_SAD_POS = addPosition.Id;
												pol.ID_INV = position.InvoiceId;
												pol.ID_INV_POS = position.Id;
												office.SAD_Invoice.Add(pol);
												office.SaveChanges();

											}



										}
									}
								}
							}
							else
							{
								sb.AppendLine("Faktura o id:" + id + " nie posiada żadnych pozycji - pominięto fakture");
							}

						}
						if (!String.IsNullOrEmpty(sb.ToString()))
							TempData["msg"] = "<script>alert('  Dodanie Faktur zakończone sukcesem ! Ostrzeżenia:" + sb.ToString() + "');</script>";
						else
							TempData["msg"] = "<script>alert('  Dodanie Faktur zakończone sukcesem !');</script>";

						office.SaveChanges();
						transaction.Commit();

						return RedirectToAction("SADInvoice");
					}
					else
					{

						TempData["msg"] = "<script>alert('Wybierz fakturę do dodania  ');</script>";
						return RedirectToAction("SADInvoice");
					}

				}
			}

		}

		[HttpPost]
		[Authorize(Roles = "User,Admin")]
		public ActionResult DeleteInvoice(long[] ids)
		{

			using (var office = new OfficeModel())
			{
				using (DbContextTransaction transaction = office.Database.BeginTransaction())
				{
					if (ids != null)
					{

						long sadID = Convert.ToInt32(Session["SelectedIdIS"]);
						var sad = office.SAD.FirstOrDefault(x => x.Id == sadID);
						var positions = office.SadPositions.Where(x => x.IdSad == sadID);
						foreach (var id in ids)
						{
							List<SAD_Invoice> polList = office.SAD_Invoice.Where(x => x.ID_INV == id).ToList();
							if (!polList.Any())
							{
								TempData["msg"] = "<script>alert('Usunięcie faktury zakończone sukcesem');</script>";
								office.SaveChanges();
								return RedirectToAction("SADInvoice");
							}
							foreach (var pol in polList)
							{
								if (!office.InvoicePosition.Any(x => x.InvoiceId == pol.ID_INV))
								{
									TempData["msg"] = "<script>alert('Faktura nie zawiera pozycji ');</script>";
									return RedirectToAction("SADInvoice");
								}
								var positionInvoice = office.InvoicePosition.FirstOrDefault(x => x.Id == pol.ID_INV_POS);
								if (String.IsNullOrEmpty(positionInvoice.HSCode))
								{
									TempData["msg"] = "<script>alert(' HS Code jest puste');</script>";
									return RedirectToAction("SADInvoice");
								}


								if (office.SadPositions.Any(x => x.Id == pol.ID_SAD_POS))
								{
									var SADposList = office.SadPositions.Where(x => x.Id == pol.ID_SAD_POS);

									foreach (var pos in SADposList)
									{
										if (office.SAD_Invoice.Count(x => x.ID_SAD_POS == pos.Id) > 1)
										{
											try
											{
												if (pos.PositionValue - Math.Round((positionInvoice.Price * positionInvoice.Quantity * sad.ExchangeRate) + (positionInvoice.TransportsCost.HasValue ? positionInvoice.TransportsCost.Value : 0), 0) < 0)
													pos.PositionValue = 0;
												else
												{
													pos.PositionValue = pos.PositionValue - Math.Round((positionInvoice.Price * positionInvoice.Quantity * sad.ExchangeRate) + (positionInvoice.TransportsCost.HasValue ? positionInvoice.TransportsCost.Value : 0), 0);

												}
											}
											catch
											{
												pos.PositionValue = 0;

											}
										}
										else
											office.SadPositions.Remove(pos);
									}



								}





							}
							office.SAD_Invoice.RemoveRange(polList);
							office.SaveChanges();

						}
						office.SaveChanges();
						transaction.Commit();
						TempData["msg"] = "<script>alert('Usunięcie Faktur zakończone sukcesem !');</script>";
						return RedirectToAction("SADInvoice");
					}
					else
					{

						TempData["msg"] = "<script>alert('Wybierz fakturę do dodania  ');</script>";
						return RedirectToAction("SADInvoice");
					}
				}
			}

		}

		public ActionResult Positionslist(long? id, string sort, string SearchString, long? idpos)
		{
			if (User.Identity.IsAuthenticated)
			{
				ViewBag.idd = sort == "Id" ? "Id desc" : "Id";
				ViewBag.nr = sort == "Nr" ? "Nr desc" : "Nr";
				ViewBag.date = sort == "Date" ? "Date desc" : "Date";

				List<SAD> all = SADSearch(id, SearchString, sort);
				if (Session["SelectedIdIS"] != null)
					id = Convert.ToInt32(Session["SelectedIdIS"]);
				if (all.Any())
				{
					ViewBag.Details = db.SadPositions.Where(x => x.IdSad == id).OrderBy(x => x.Id).ToList();
					if (!idpos.HasValue)
					{
						if (Session["SelectedPosIS"] != null)
						{
							idpos = Convert.ToInt32(Session["SelectedPosIS"]);
						}
					}
					if (idpos.HasValue)
					{
						Session["SelectedPosIS"] = idpos;
						ViewBag.Details2 = db.SadPositions.Where(x => x.Id == idpos).ToList();
					}
				}
				return View(all);
			}
			else
				return RedirectToAction("Login", "Account");

		}

		[Authorize(Roles = "User,Admin")]
		public ActionResult PositionsEdit(long? id)
		{
			if (User.Identity.IsAuthenticated)
			{
				if (id == null)
				{
					return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
				}
				List<SelectListItem> CountryOfOrigin = new List<SelectListItem>()
			{
				new SelectListItem {Value="PL",Text="Polska" },
				new SelectListItem {Value="DE",Text="Niemcy" },
				new SelectListItem {Value="US",Text="USA" },
			};

				ViewBag.COODDL = new SelectList(CountryOfOrigin, "Value", "Text");

				List<SelectListItem> HSCode = new List<SelectListItem>()
			{
				new SelectListItem {Value="123",Text="Śrubka" },
				new SelectListItem {Value="343",Text="Układ Scalony" },
				new SelectListItem {Value="536",Text="Drut" },
			};

				ViewBag.HSDDL = new SelectList(HSCode, "Value", "Text");


				SadPositions position = db.SadPositions.Find(id);
				if (position == null)
				{
					return HttpNotFound();
				}
				return View(position);
			}
			else
				return RedirectToAction("Login", "Account");
		}


		[HttpPost]
		[Authorize(Roles = "User,Admin")]
		[ValidateAntiForgeryToken]
		public ActionResult PositionsEdit(SadPositions position)
		{

			if (ModelState.IsValid)
			{
				position.Rate /= 100;
				db.Entry(position).State = EntityState.Modified;
				db.SaveChanges();
				return RedirectToAction("Positionslist", new { id = position.IdSad, idpos = position.Id });
			}
			List<SelectListItem> CountryOfOrigin = new List<SelectListItem>()
			{
				new SelectListItem {Value="PL",Text="Polska" },
				new SelectListItem {Value="DE",Text="Niemcy" },
				new SelectListItem {Value="US",Text="USA" },
			};

			ViewBag.COODDL = new SelectList(CountryOfOrigin, "Value", "Text");

			List<SelectListItem> HSCode = new List<SelectListItem>()
			{
				new SelectListItem {Value="123",Text="Śrubka" },
				new SelectListItem {Value="343",Text="Układ Scalony" },
				new SelectListItem {Value="536",Text="Drut" },
			};

			ViewBag.HSDDL = new SelectList(HSCode, "Value", "Text");
			return View(position);

		}

		protected override void Dispose(bool disposing)
		{
			if (disposing)
			{
				db.Dispose();
			}
			base.Dispose(disposing);
		}
	}
}
