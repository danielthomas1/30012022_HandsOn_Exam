using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookRecomendationDTO;

namespace BookRecomendationDataAccessLayer
{
    //DO NOT MODIFY THE METHOD NAMES : Adding of parameters / changing the return types of the given methods may be required.
    public class BookRecomendationDAL
    {

        SqlConnection conObj;
        SqlCommand cmdObj;
        public BookRecomendationDAL()
        {
            conObj = new SqlConnection(ConfigurationManager.ConnectionStrings["AdvWorksConnectionStr"].ConnectionString);
            //contextObj = new AdventureWorks2012Context();
        }

        public int ConnectionToDB()
        {
            try
            {
                BookRecomendationDAL dalObj = new BookRecomendationDAL();
                return dalObj.ConnectionToDB();
            }
            catch (Exception)
            {
                return -1;
            }


            public List<BookDTO> FetchReviewsForBook()
            {
                try
                {

                    SqlCommand conOb = new SqlCommand(@"select BookRating, BookName , BookReview from Production.Product where ListPrice>10", conObj);
                    conObj.Open();
                    SqlDataReader dept = conOb.ExecuteReader();
                    //while (dept.Read())
                    //{
                    //Console.WriteLine(dept["ProductId"] + "|" + dept["Name"]+ "|" + dept["ListPrice"]);
                    //}
                    List<BookDTO> ListProduct = new List<BookDTO>();
                    while (dept.Read())
                    {
                        BookDTO bkDTO = new BookDTO();
                        bkDTO.BookRating = Convert.ToInt32(dept["ProductID"]);
                        bkDTO.BookName = dept["Name"].ToString();
                        bkDTO.BookReview = Convert.ToString(dept["ListPrice"]);
                        ListProduct.Add(bkDTO);
                    }
                    return ListProduct;
                }
                catch (Exception ex)
                {
                    throw;
                }
            }

            public int SaveReviewForBookToDB(BookDTO, newbookobj)
            {
                try
            {
                    conObj = new SqlCommand();
                    conObj.CommandText = @"uspSaveReviewForBookToDB";
                    conObj.CommandType = System.Data.CommandType.StoredProcedure;
                    conObj.Connection = conObj;
                    conObj.Parameters.AddWithValue("@BookRating", newDeptObj.BookRating);
                    conObj.Parameters.AddWithValue("@BookName", newDeptObj.BookName);
                    conObj.Parameters.AddWithValue("@BookReview", newDeptObj.BookReview);
                    SqlParameter retvalue = new SqlParameter();
                    retvalue.Direction = ParameterDirection.ReturnValue;
                    retvalue.SqlDbType = SqlDbType.Int;
                    conObj.Parameters.Add(retvalue);
                    SqlParameter outValue = new SqlParameter();
                    outValue.Direction = ParameterDirection.Output;
                    outValue.SqlDbType = SqlDbType.Int;
                    outValue.ParameterName = "@BookName";
                    conObj.Parameters.Add(outValue);
                    conObj.Open();
                    conObj.ExecuteNonQuery();
                    newBookRating = Convert.ToInt32(outValue.Value);
                    return Convert.ToInt32(retvalue.Value);

                }
            catch (Exception ex)
                {
                    throw ex;
                }
                finally
                {
                    conObj.Close();
                }
            }
        }

        }
    }
