using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ProfileMVCApplication.Models;
using ProfileMVCApplication.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProfileMVCApplication.Controllers
{
    public class ProfileController : Controller
    {
        private IRepo<Profile> _Repo;
        private ILogger<ProfileController> _Logger;

        public ProfileController(IRepo<Profile> repo, ILogger<ProfileController> logger)
        {
            _Repo = repo;
            _Logger = logger;
        }

        // GET: ProfileController
        public ActionResult Index()
        {
            List<Profile> p = _Repo.GetAll().ToList();
            return View(p);
        }

        // GET: ProfileController/Details/5
        public ActionResult Details(int id)
        {
            Profile p = _Repo.Get(id);
            return View(p);
        }

        // GET: ProfileController/Create
        public ActionResult Create()
        {

            return View();
        }

        // POST: ProfileController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Profile p)
        {
            try
            {
                _Repo.Add(p);
            }
            catch(Exception e)
            {
                _Logger.LogDebug(e.Message);
            }
            return RedirectToAction(nameof(Index));
        }

        // GET: ProfileController/Edit/5
        public ActionResult Edit(int id)
        {
            Profile p = _Repo.Get(id);
            return View(p);
        }

        // POST: ProfileController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, Profile p)
        {
            _Repo.Update(id, p);
            return RedirectToAction("Index");
        }

        // GET: ProfileController/Delete/5
        public ActionResult Delete(int id)
        {
            Profile p = _Repo.Get(id);
            return View(p);
        }

        // POST: ProfileController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete( Profile p)
        {
            try
            {
                _Repo.Delete(p);
                
            }
            catch(Exception e)
            {
                _Logger.LogDebug(e.Message);
            }
            return RedirectToAction("Index");
        }
    }
}
