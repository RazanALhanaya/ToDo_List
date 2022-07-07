using Microsoft.AspNetCore.Mvc;
using todoList.Models;

namespace todoList.Controllers
{
    public enum SortDirection
    {
        Ascending,
        Descending
    }
    public class ListController : Controller
    {
        HRDB dbContext = new HRDB(); //instance
        public IActionResult Index(string sortField , string CurrentSortField , SortDirection SortDirection1 , string SearchByName)
        {
            var Lists = GetTask();
            if (!string.IsNullOrEmpty(SearchByName))
                Lists = Lists.Where(e => e.Task.ToLower().Contains(SearchByName.ToLower())).ToList();

            return View(this.SortList(Lists, sortField, CurrentSortField, SortDirection1));

        }
        // fun. to send list to index as list 
        private List<List> GetTask()
        {

            // ctreate list then return it
            // List<List> Lists = dbContext.Lists.ToList();
            var Lists = (from List in dbContext.Lists
                         select new List
                         {
                             ListId = List.ListId,
                             Task = List.Task,
                             DateOfTask = List.DateOfTask,
                             TimeOfTask = List.TimeOfTask,
                         }).ToList();
            return Lists;

        }
        public IActionResult Create()
        {
            
            return View();
        }

        [HttpPost]
     public IActionResult Create(List model)
        {
            ModelState.Remove("ListId");
            if (ModelState.IsValid)
            {  // check
               dbContext.Lists.Add(model);
               dbContext.SaveChanges();
                return RedirectToAction("Index");
            }
            return View();
        }
        public IActionResult Edit( int ID)
        {
            List data = this.dbContext.Lists.Where(e=>e.ListId ==ID).FirstOrDefault();
            return View("Create", data);
        }


        [HttpPost]
        public IActionResult Edit(List model)
        {
            ModelState.Remove("ListId");
            if (ModelState.IsValid)
            {  // check
                dbContext.Lists.Update(model);
                dbContext.SaveChanges();
                return RedirectToAction("Index");
            }
            return View("Create",model);
        }

        
        public IActionResult Delete(int ID)
        {
           List data = this.dbContext.Lists.Where(e => e.ListId == ID).FirstOrDefault();
            if (data != null)
            {
                dbContext.Lists.Remove(data);
                dbContext.SaveChanges();
            }
            return RedirectToAction("Index");

        }

        private List<List> SortList(List<List> lists, string sortField, string currentSortField, SortDirection sortDirection) // sortDirection : Des or Asc
        {
            if (string.IsNullOrEmpty(sortField))
            {
                ViewBag.SortField = "ListId";
                ViewBag.SortDirection = SortDirection.Ascending;
            }
            else
            {
                if (currentSortField == sortField)
                    ViewBag.SortDirection = sortDirection == SortDirection.Ascending? SortDirection.Descending: SortDirection.Ascending; 
                else
                    ViewBag.SortDirection = SortDirection.Ascending;
                ViewBag.SortField = sortField;
            }

            var propertyInfo = typeof(List).GetProperty(ViewBag.SortField); // Reflation type
            if (ViewBag.SortDirection == SortDirection.Ascending)
                lists = lists.OrderBy(e => propertyInfo.GetValue(e, null)).ToList(); // e=> is lamda exp.
            else
                lists = lists.OrderByDescending(e => propertyInfo.GetValue(e, null)).ToList(); 
            return lists;
        }
    }
}
