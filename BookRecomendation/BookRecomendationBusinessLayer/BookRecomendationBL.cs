using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookRecomendationDataAccessLayer;
using BookRecomendationDTO;

namespace BookRecomendationBusinessLayer
{
    //DO NOT MODIFY THE METHOD NAMES : Adding of parameters / changing the return types of the given methods may be required. 
    public class BookRecomendationBL
    {
        BookRecomendationBL dalObj;

        public int ConnectToDB()
        {
            try
            {
                BookRecommodationBL dalObj = new BookRecomendationBL();
                return dalObj.ConnectionToDB();
            }
            catch (Exception)
            {
                return -89;
            }
        }
        public void ShowReviewsForBook()
        {
            BookRecomendationDAL dalObj = new BookRecomendationDAL();
            dalObj.FetchAllBooks();
        }


        public void AddReviewForBook()
        {
            BookRecomendationDAL dalObj = new BookRecomendationDAL();
            return dalObj.Insertreviewforbook(newbookobj, out newbookId);
        }
      
    }
}
