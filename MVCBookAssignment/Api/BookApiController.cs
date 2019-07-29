using MVCBookAssignment.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace MVCBookAssignment.Api
{
    public class BookApiController : ApiController
    {
        private ApplicationDbContext _context;

        public BookApiController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        [HttpGet]
        public IEnumerable<Book> GetBooks()
        {
            return _context.Books.ToList();
        }

        //Get /api/Customer/id
        public  Book GetCustomerById(int? id)
        {
            return _context.Books.SingleOrDefault(c => c.Id == id);
        }

        [HttpPost]
        public IHttpActionResult CreateBook(Book book)
        {
            if (!ModelState.IsValid)
                // throw new HttpResponseException(HttpStatusCode.BadRequest);
                BadRequest();

            _context.Books.Add(book);
            _context.SaveChanges();
            // return book;
            return Ok(book);
        }

        [HttpPut]
        public void UpdateBook(int id, Book book)
        {
            if (!ModelState.IsValid)
                throw new HttpResponseException(HttpStatusCode.BadRequest);

            var booksInDb = _context.Books.SingleOrDefault(c => c.Id == id);
            if (booksInDb == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);
            booksInDb.BookName = book.BookName;
            
            _context.SaveChanges();

        }

        public void DeleteBook(int id)
        {
            var bookInDb = _context.Books.SingleOrDefault(p => p.Id == id);
            if (bookInDb == null)
                throw new HttpResponseException(HttpStatusCode.BadRequest);
            _context.SaveChanges();
        }
    }
}
