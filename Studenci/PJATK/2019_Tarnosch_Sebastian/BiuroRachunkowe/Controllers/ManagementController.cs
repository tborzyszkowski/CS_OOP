using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using BiuroRachunkowe.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace BiuroRachunkowe.Controllers
{
    public class ManagementController : Controller
    {
        private ManagementModel db = new ManagementModel();

		// GET: Management
		public ActionResult UserList()
        {
			if (User.Identity.IsAuthenticated)
			{
				var uM = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(new ApplicationDbContext()));

				List<UserListViewModel> model = new List<UserListViewModel>();
				foreach (var user in db.AspNetUsers.ToList())
				{
					UserListViewModel userView = new UserListViewModel();

					userView.Id = user.Id;
					userView.Login = user.UserName;
					List<String> listRole = uM.GetRoles(user.Id).ToList();
					userView.Role = string.Join(",", listRole);
					model.Add(userView);
				}

				return View(model);
			}
			else
				return RedirectToAction("Login","Account");
        }
		public ActionResult EditUser(string id)
		{
			if (User.Identity.IsAuthenticated)
			{
				UserEditViewModel model = new UserEditViewModel();
				var uM = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(new ApplicationDbContext()));

				ViewBag.RoleId = new SelectList(db.AspNetRoles, "Name", "Name");
				model.roles = uM.GetRoles(id).ToList();
				model.Id = id;
				model.UserName = db.AspNetUsers.FirstOrDefault(x => x.Id == id).UserName;
				return View(model);
			}
			else
				return RedirectToAction("Login", "Account");
		}
		[HttpPost]
		[Authorize(Roles = "Admin")]
		[ValidateAntiForgeryToken]
		public ActionResult EditUser(UserEditViewModel model, string[] selectedRoles)
		{
			var uM = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(new ApplicationDbContext()));

			if (User.Identity.IsAuthenticated) // if the user is already logged in
			{

				try
				{

					

					var UserToUpdate = db.AspNetUsers.Find(model.Id);


					

					var roles =  uM.GetRoles(model.Id).ToArray();
					uM.RemoveFromRoles(model.Id, roles);
					uM.AddToRoles(model.Id, selectedRoles);

					return RedirectToAction("UserList");
				}
				catch (RetryLimitExceededException /* dex */)
				{
					ModelState.AddModelError("", "Unable to save changes. Try again, and if the problem persists, see your system administrator.");
				}
			}
			else
			{
				return RedirectToAction("Login", "Account");
			}


			// If we got this far, something failed, redisplay form
			return View(model);
		}
		// GET: Management/Delete/5
		public ActionResult DeleteUser(string id)
        {
			if (User.Identity.IsAuthenticated)
			{
				if (id == null)
				{
					return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
				}
				AspNetUsers aspNetUsers = db.AspNetUsers.Find(id);
				if (aspNetUsers == null)
				{
					return HttpNotFound();
				}
				return View(aspNetUsers);
			}
			else
				return RedirectToAction("Login", "Account");

		}

		// POST: Management/Delete/5
		[HttpPost, ActionName("Delete")]
		[Authorize(Roles = "Admin")]
		[ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            AspNetUsers aspNetUsers = db.AspNetUsers.Find(id);

			foreach (var role in db.AspNetUserRoles.Where(x => x.UserId == id))
				db.AspNetUserRoles.Remove(role);
            db.AspNetUsers.Remove(aspNetUsers);
            db.SaveChanges();
            return RedirectToAction("UserList");
        }

		public ActionResult RoleList()
		{
			if (User.Identity.IsAuthenticated)
			{
				return View(db.AspNetRoles.OrderBy(x => x.Id).ToList());
			}
			else
				return RedirectToAction("Login", "Account");

		}

		// GET: AspNetRoles/Create
		public ActionResult CreateRole()
		{
			if (User.Identity.IsAuthenticated)
			{
				return View();
			}
			else
				return RedirectToAction("Login", "Account");

		}

		// POST: AspNetRoles/Create
		// To protect from overposting attacks, please enable the specific properties you want to bind to, for 
		// more details see https://go.microsoft.com/fwlink/?LinkId=317598.
		[HttpPost]
		[Authorize(Roles = "Admin")]
		[ValidateAntiForgeryToken]
		public ActionResult CreateRole([Bind(Include = "Id,Name")] AspNetRoles aspNetRoles)
		{
			if (!String.IsNullOrEmpty(aspNetRoles.Name))
			{
				aspNetRoles.Id=(Convert.ToInt32(db.AspNetRoles.OrderByDescending(x => x.Id).First().Id) + 1).ToString();
				db.AspNetRoles.Add(aspNetRoles);
				db.SaveChanges();
				return RedirectToAction("RoleList");
			}
			

			return View(aspNetRoles);
		}

		// GET: AspNetRoles/Edit/5
		public ActionResult EditRole(string id)
		{
			if (User.Identity.IsAuthenticated)
			{
				if (id == null)
				{
					return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
				}
				AspNetRoles aspNetRoles = db.AspNetRoles.Find(id);
				if (aspNetRoles == null)
				{
					return HttpNotFound();
				}
				return View(aspNetRoles);
			}
			else
				return RedirectToAction("Login", "Account");

		}

		// POST: AspNetRoles/Edit/5
		// To protect from overposting attacks, please enable the specific properties you want to bind to, for 
		// more details see https://go.microsoft.com/fwlink/?LinkId=317598.
		[HttpPost]
		[ValidateAntiForgeryToken]
		[Authorize(Roles = "Admin")]
		public ActionResult EditRole([Bind(Include = "Id,Name")] AspNetRoles aspNetRoles)
		{
			if (ModelState.IsValid)
			{
				db.Entry(aspNetRoles).State = EntityState.Modified;
				db.SaveChanges();
				return RedirectToAction("RoleList");
			}
			return View(aspNetRoles);
		}

		// GET: AspNetRoles/Delete/5
		public ActionResult DeleteRole(string id)
		{
			if (User.Identity.IsAuthenticated)
			{
				if (id == null)
				{
					return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
				}
				AspNetRoles aspNetRoles = db.AspNetRoles.Find(id);
				if (aspNetRoles == null)
				{
					return HttpNotFound();
				}
				return View(aspNetRoles);
			}
			else
				return RedirectToAction("Login", "Account");

		}

		// POST: AspNetRoles/Delete/5
		[HttpPost, ActionName("DeleteRole")]
		[ValidateAntiForgeryToken]
		[Authorize(Roles = "Admin")]
		public ActionResult DeleteRoleConfirmed(string id)
		{
			AspNetRoles aspNetRoles = db.AspNetRoles.Find(id);
			db.AspNetRoles.Remove(aspNetRoles);
			db.SaveChanges();
			return RedirectToAction("RoleList");
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
