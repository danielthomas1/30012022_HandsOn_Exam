using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using BookRecomendationBusinessLayer;
using BookRecomendationDTO;
using BookRecomendationWebApp.Models;
using Newtonsoft.Json;

namespace BookRecomendationWebApp.Controllers
{
    //DO NOT MODIFY THE METHOD NAMES : Adding of parameters / changing the return types of the given methods may be required.
    public class RecomendBookController : Controller
    {
        // GET: RecomendBook

        BookRecomendationBL blObj;
        public ActionResult Index()
        {
            return View();
        }


        
        public void AddReviews()
        {

        }

        public ActionResult DisplayResultsUsingWebAPI()
        {
            try
            {
                List<BookDTO> lstBook = blObj.GetAllBookNames();
                foreach (var book in lstBook)
                {
                    bookViewModel newObj = new ProductViewModel();
                    newObj.BookName = book.BookName;
                    newObj.bookRating = book.BookRating;
                    newObj.ProductColor = book.BookReview;
                    lstbookModel.Add(newObj);
                }
                return View(lstbookModel);
            }
            catch (Exception)
            {
                return View("Error");
            }
        }
    }
}