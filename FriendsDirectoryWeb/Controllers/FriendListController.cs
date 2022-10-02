using FriendsDirectoryWeb.Data;
using FriendsDirectoryWeb.Models;
using Microsoft.AspNetCore.Mvc;

namespace FriendsDirectoryWeb.Controllers
{
    public class FriendListController : Controller
    {
        private readonly ApplicationDbContext _db;

        public FriendListController(ApplicationDbContext db)
        {
            _db = db;
        }

        public IActionResult Index()
        {
            IEnumerable<FriendList> objFriendList = _db.friendLists;
            return View(objFriendList);
        }
        //GET
        public IActionResult Create()
        {
            return View();
        }
        //POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(FriendList obj)
        {
            if (obj.FirstName == obj.LastName.ToString())
            {
                ModelState.AddModelError("FirstName", "The First Name and Last Name cannot exactly match the Name.");
            }
            if (ModelState.IsValid)
            {
                _db.friendLists.Add(obj);
                _db.SaveChanges();
                TempData["success"] = "Friend created successfully";
                return RedirectToAction("Index");
            }
            return View(obj);
        }
        //GET
        public IActionResult Edit(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            var friendListFromDb = _db.friendLists.Find(id);
            

            if (friendListFromDb == null)
            {
                return NotFound();
            }

            return View(friendListFromDb);
        }
        //POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(FriendList obj)
        {
            if (obj.FirstName == obj.LastName.ToString())
            {
                ModelState.AddModelError("name", "The First Name & Last Name cannot exactly match the Name.");
            }
            if (ModelState.IsValid)
            {
                _db.friendLists.Update(obj);
                _db.SaveChanges();
                TempData["success"] = "Friend updated successfully";
                return RedirectToAction("Index");
            }
            return View(obj);
        }
        public IActionResult Delete(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            var friendListFromDb = _db.friendLists.Find(id);
            

            if (friendListFromDb == null)
            {
                return NotFound();
            }

            return View(friendListFromDb);
        }
        //POST
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeletePOST(int? id)
        {
            var obj = _db.friendLists.Find(id);
            if (obj == null)
            {
                return NotFound();
            }
            _db.friendLists.Remove(obj);
            _db.SaveChanges();
            TempData["success"] = "Friend deleted successfully";
            return RedirectToAction("Index");
        }
    }
}
