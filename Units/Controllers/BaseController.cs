using System;
using System.Data.Entity;
using System.Net;
using System.Threading.Tasks;
using System.Web.Mvc;
using Units.Data;

namespace Units.Controllers
{
    public abstract class BaseController<T, TDTO> : Controller
    {
        public readonly IRepository<T> _repo;

        protected BaseController(IRepository<T> repo)
        {
            _repo = repo;
        }

        protected virtual async Task SetViewBag()
        {
            
        }

        public virtual async Task<ActionResult> Index()
        {
            var rv =  (await _repo.Where().ToListAsync()).Map<TDTO>();

            return View(rv);
        }

        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var obj = await _repo.Find(id ?? 0);
            if (obj == null)
            {
                return HttpNotFound();
            }
            return View(obj.Map<TDTO>());
        }

        public async Task<ActionResult> Create()
        {
            await SetViewBag();
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(TDTO obj)
        {
            if (ModelState.IsValid)
            {
                _repo.Upsert(obj.Map<T>());
                await _repo.Save();
                return RedirectToAction("Index");
            }
            await SetViewBag();
            return View(obj);
        }

        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var obj = await _repo.Find(id ?? 0);
            if (obj == null)
            {
                return HttpNotFound();
            }
            await SetViewBag();
            return View(obj.Map<TDTO>());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(TDTO obj)
        {
            if (ModelState.IsValid)
            {
                _repo.Upsert(obj.Map<T>());
                await _repo.Save();
                return RedirectToAction("Index");
            }
            await SetViewBag();
            return View(obj);
        }

        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var obj = await _repo.Find(id ?? 0);
            if (obj == null)
            {
                return HttpNotFound();
            }
            return View(obj.Map<TDTO>());
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            await _repo.Delete(id);
            await _repo.Save();
            return RedirectToAction("Index");
        }
    }
}
