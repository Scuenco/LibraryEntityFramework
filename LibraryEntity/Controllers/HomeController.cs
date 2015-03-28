using LibraryEntity.Model;
using LibraryEntity.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LibraryEntity.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            List<Book> model;
            using (ApplicationDbContext db = new ApplicationDbContext())
            {
                model = db.Books.Where(x => x.IsDeleted == false).ToList();//convert back to List
            }
            return View(model);
        }
        public ActionResult Details(int id)
        {
            Book model;
            using (ApplicationDbContext db = new ApplicationDbContext())
            {
                model = db.Books.Where(x => x.BookID == id).FirstOrDefault();
            }
            return View(model);
        }

        public ActionResult DeleteBook(int id)
        {
            using (ApplicationDbContext db = new ApplicationDbContext())
            {
               Book model = db.Books.FirstOrDefault(x => x.BookID == id);
                if (model != null)
                { 
                    model.IsDeleted = true;
                    db.SaveChanges();
                }
            }
            return RedirectToAction("Index");
        }
        public ActionResult EditBook(int id)
        {
            Book model;
            using (ApplicationDbContext db = new ApplicationDbContext()) 
            {
                model = db.Books.FirstOrDefault(x => x.BookID == id);
            }
            return View(model);
        }
        [HttpPost]
        public ActionResult EditBook(Book book)
        {
            using (ApplicationDbContext db = new ApplicationDbContext())
            {
                /* 
                It generates an Inner Exception Error:
            {"There is already an open DataReader associated with this Command which must be closed first."}*/
                /*
                foreach (Book b in db.Books)
                {
                    if (b.BookID == book.BookID)
                    {
                        b.Title = book.Title;
                        b.Author = book.Author;
                        b.Genre = book.Genre;
                        db.SaveChanges();
                    }
                }
                */
                
                Book b = db.Books.FirstOrDefault(x => x.BookID == book.BookID);
                if (b != null)
                {
                    b.Title = book.Title;
                    b.Author = book.Author;
                    b.Genre = book.Genre;
                    db.SaveChanges();
                }
                
            }
            return RedirectToAction("Details", new {id = book.BookID });
        }
        public ActionResult AddBook()
        {
            return View(new Book());
        }
        [HttpPost]
        public ActionResult AddBook(Book newBook)
        {
            using (ApplicationDbContext db = new ApplicationDbContext())
            {
                db.Books.Add(newBook);
                db.SaveChanges();
            }
            return RedirectToAction("Index");
        }
        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}