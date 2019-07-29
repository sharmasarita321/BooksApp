using MVCBookAssignment.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;

namespace MVCBookAssignment.Controllers
{
    public class HomeController : Controller
    {
        ApplicationDbContext _context;

        public HomeController()
        {
            _context = new ApplicationDbContext();
        }


        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            var book = _context.Books.ToList();

            return View(book);
        }

        /// <summary>
        /// the code used below is for consuming the webapi that hasbeen written created to perform the 
        /// operation at the client side itself.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        //  public ActionResult About() 
        //{
        //    IEnumerable<Book> books = null;
        //    using (var client = new HttpClient())
        //    {
        //        client.BaseAddress = new Uri("http://localhost:59205/api/");
        //        var responseTask = client.GetAsync("books");
        //        responseTask.Wait();
        //        var result = responseTask.Result;
        //        if(result.IsSuccessStatusCode)
        //        {
        //            var readTask = result.Content.ReadAsAsync<IEnumerable<Book>>();
        //            readTask.Wait();
        //            books = readTask.Result;
        //        }

        //        else
        //        {
        //            books = Enumerable.Empty<Book>();
        //            ModelState.AddModelError(string.Empty, "Server Error");
        //        }

        //    }
        //    return View();
        //}

        public ActionResult Details(int? id)
        {
            var book = _context.Books.SingleOrDefault(c => c.Id == id);
            if (book == null)
                return HttpNotFound();

            return View(book);
        }


        public ActionResult CreateNew()
        {
            return View();
        }

        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult create(Book book)
        //{
        //    return View("New", ViewModel);
        //}


        public ActionResult Edit(int? id)
        {
            var book = _context.Books.SingleOrDefault(c => c.Id == id);

            if (book == null)
                return HttpNotFound();
            else
            {
                var booksInDb = _context.Books.Single(c => c.Id == book.Id);
                booksInDb.BookName = book.BookName;
            }
            _context.SaveChanges();

            return View("CreateNew", book);
        }

        //public ActionResult Delete(int ? id)
        //{
        //    var book = _context.Books.Find(id);
        //    _context.Books.Remove(book);
        //    _context.SaveChanges();
        //    return RedirectToAction("About");
        //}

    }

    //other way of doing the the script thing by using functions.
//    <script>
//        $(()=>{
        
//        $('#btndelete').on('click' , () =>{
//        alert('Delete button clicked')
//    })
//})
}