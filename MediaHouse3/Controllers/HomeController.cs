using MediaHouse3.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.UI;

namespace MediaHouse3.Controllers
{
    public class HomeController : Controller 
    {
        UsersContext uc = new UsersContext();
        ArticlesContext ac = new ArticlesContext();

        private SqlConnection conn = new SqlConnection("Data Source=LUKE-PC\\SQLEXPRESS;Initial Catalog=EnterpriseAssignment;Integrated Security=True");

        public ActionResult Index()
        {
            //ViewBag.Message = "Modify this template to jump-start your ASP.NET MVC application.";
            var model = GetLatestFiveArticles();
            return View(model);
        }

        //Get the latest five articles for the slider
        public List<Article> GetLatestFiveArticles()
        {
            List<Article> latestArticles = new List<Article>();
            //get all the national articles and put them in a data table    
            DataTable latestDt = new DataTable();
            SqlDataAdapter adapter = new SqlDataAdapter("SELECT TOP 5 * FROM [dbo].[Article] ORDER BY dateCreated DESC", conn);
            adapter.Fill(latestDt);

            //add the rows in the datatable to the article list
            foreach (DataRow dr in latestDt.Rows)
            {
                Article a = new Article();
                a.articleTitle = dr["articleTitle"].ToString();
                a.subHeader = dr["subHeader"].ToString();
                a.dateCreated = (DateTime)dr["dateCreated"];
                a.UserId = (int)dr["UserId"];
                a.categoryId = (int)dr["categoryId"];
                latestArticles.Add(a);
            }

            return latestArticles;
        }

        public ActionResult Articles()
        {
            var model = ac.Articles.ToList();
            model.OrderByDescending(x => x.dateCreated).ToList();
            return View(model);
        }

        public ActionResult GetNational()
        {
            var model = GetNationalArticles();
            return View(model);
        }

        public List<Article> GetNationalArticles()
        {
            //create a list for national articles
            List<Article> nationalArticles = new List<Article>();
            //get all the national articles and put them in a data table    
            DataTable nationalDt = new DataTable();
            SqlDataAdapter adapter = new SqlDataAdapter("SELECT * FROM [dbo].[Article] WHERE categoryId = '1' ORDER BY dateCreated DESC", conn);
            adapter.Fill(nationalDt);

            //add the rows in the datatable to the article list
            foreach (DataRow dr in nationalDt.Rows)
            {
                Article a = new Article();
                a.articleTitle = dr["articleTitle"].ToString();
                a.subHeader = dr["subHeader"].ToString();
                a.dateCreated = (DateTime)dr["dateCreated"];
                a.UserId = (int)dr["UserId"];
                a.categoryId = (int)dr["categoryId"];
                nationalArticles.Add(a);
            }

            //return the list
            return nationalArticles;
        }

        public ActionResult GetOverseas()
        {
            var model = GetOverseasArticles();
            if (model.Count == 0)
            {
                return View();
            }
            return View(model);
        }

        public List<Article> GetOverseasArticles()
        {
            //create a list for overseas articles
            List<Article> overseasArticles = new List<Article>();
            //get all the overseas articles and put them in a data table    
            DataTable overseasDt = new DataTable();
            SqlDataAdapter adapter = new SqlDataAdapter("SELECT * FROM [dbo].[Article] WHERE categoryId = '2' ORDER BY dateCreated DESC", conn);
            adapter.Fill(overseasDt);

            //add the rows in the datatable to the article list
            foreach (DataRow dr in overseasDt.Rows)
            {
                Article a = new Article();
                a.articleTitle = dr["articleTitle"].ToString();
                a.subHeader = dr["subHeader"].ToString();
                a.dateCreated = (DateTime)dr["dateCreated"];
                a.UserId = (int)dr["UserId"];
                a.categoryId = (int)dr["categoryId"];
                overseasArticles.Add(a);
            }

            //return the list
            return overseasArticles;
        }

        public ActionResult GetSports()
        {
            var model = GetSportsArticles();
            return View(model);
        }

        public List<Article> GetSportsArticles()
        {
            //create a list for sports articles
            List<Article> sportsArticles = new List<Article>();
            //get all the sports articles and put them in a data table    
            DataTable sportsDt = new DataTable();
            SqlDataAdapter adapter = new SqlDataAdapter("SELECT * FROM [dbo].[Article] WHERE categoryId = '3' ORDER BY dateCreated DESC", conn);
            adapter.Fill(sportsDt);

            //add the rows in the datatable to the article list
            foreach (DataRow dr in sportsDt.Rows)
            {
                Article a = new Article();
                a.articleTitle = dr["articleTitle"].ToString();
                a.subHeader = dr["subHeader"].ToString();
                a.dateCreated = (DateTime)dr["dateCreated"];
                a.UserId = (int)dr["UserId"];
                a.categoryId = (int)dr["categoryId"];
                sportsArticles.Add(a);
            }

            //return the list
            return sportsArticles;
        }

        public ActionResult GetOpinion()
        {
            var model = GetOpinionArticles();
            return View(model);
        }

        public List<Article> GetOpinionArticles()
        {
            //create a list for opinion articles
            List<Article> opinionArticles = new List<Article>();
            //get all the sports articles and put them in a data table    
            DataTable opinionDt = new DataTable();
            SqlDataAdapter adapter = new SqlDataAdapter("SELECT * FROM [dbo].[Article] WHERE categoryId = '4' ORDER BY dateCreated DESC", conn);
            adapter.Fill(opinionDt);

            //add the rows in the datatable to the article list
            foreach (DataRow dr in opinionDt.Rows)
            {
                Article a = new Article();
                a.articleTitle = dr["articleTitle"].ToString();
                a.subHeader = dr["subHeader"].ToString();
                a.dateCreated = (DateTime)dr["dateCreated"];
                a.UserId = (int)dr["UserId"];
                a.categoryId = (int)dr["categoryId"];
                opinionArticles.Add(a);
            }

            //return the list
            return opinionArticles;
        }

        public ActionResult GetTravel()
        {
            var model = GetTravelArticles();
            return View(model);
        }

        public List<Article> GetTravelArticles()
        {
            //create a list for opinion articles
            List<Article> travelArticles = new List<Article>();
            //get all the sports articles and put them in a data table    
            DataTable travelDt = new DataTable();
            SqlDataAdapter adapter = new SqlDataAdapter("SELECT * FROM [dbo].[Article] WHERE categoryId = '5' ORDER BY dateCreated DESC", conn);
            adapter.Fill(travelDt);

            //add the rows in the datatable to the article list
            foreach (DataRow dr in travelDt.Rows)
            {
                Article a = new Article();
                a.articleTitle = dr["articleTitle"].ToString();
                a.subHeader = dr["subHeader"].ToString();
                a.dateCreated = (DateTime)dr["dateCreated"];
                a.UserId = (int)dr["UserId"];
                a.categoryId = (int)dr["categoryId"];
                travelArticles.Add(a);
            }

            //return the list
            return travelArticles;
        }

        public ActionResult GetOdd()
        {
            var model = GetOddArticles();
            return View(model);
        }

        public List<Article> GetOddArticles()
        {
            //create a list for opinion articles
            List<Article> oddArticles = new List<Article>();
            //get all the sports articles and put them in a data table    
            DataTable oddDt = new DataTable();
            SqlDataAdapter adapter = new SqlDataAdapter("SELECT * FROM [dbo].[Article] WHERE categoryId = '6' ORDER BY dateCreated DESC", conn);
            adapter.Fill(oddDt);

            //add the rows in the datatable to the article list
            foreach (DataRow dr in oddDt.Rows)
            {
                Article a = new Article();
                a.articleTitle = dr["articleTitle"].ToString();
                a.subHeader = dr["subHeader"].ToString();
                a.dateCreated = (DateTime)dr["dateCreated"];
                a.UserId = (int)dr["UserId"];
                a.categoryId = (int)dr["categoryId"];
                oddArticles.Add(a);
            }

            //return the list
            return oddArticles;
        }

        [Authorize]
        public ActionResult CreateArticle()
        {
            return View();
        }

        public ActionResult ViewArticle(string title)
        {
            Article a = new Article();
            a = GetArticle(title);
            return View(a);
        }

        public ActionResult ViewAuthor(string username)
        {
            UserProfile up = new UserProfile();
            up = GetUser(username);
            int userId = up.UserId;
            List<Article> articlesOfUser = GetArticlesForAuthor(userId);
            return View(up);
        }

        [Authorize]
        public ActionResult EditArticle(string title)
        {
            Article a = new Article();
            //ArticleModel am = new ArticleModel();
            a = GetArticle(title);
            //am = GetArticle(title);
            return View(a);
            //return View(am);
        }

        //Show all users on the users page
        public ActionResult Users() 
        {
            var model = uc.UserProfiles.ToList();
            return View(model);
        }

        //Get particular user
        public UserProfile GetUser(string username)
        {
            var model = uc.UserProfiles.ToList();
            return model.SingleOrDefault(x => x.UserName == username);
        }

        //Get particular article
        public Article GetArticle(string articleTitle)
        {
            var model = ac.Articles.ToList();
            return model.SingleOrDefault(x => x.articleTitle == articleTitle);
        }

        public Article GetArticleId(int articleId)
        {
            var model = ac.Articles.ToList();
            return model.SingleOrDefault(x => x.articleId == articleId);
        }

        //Get user to edit
        [Authorize]
        public ActionResult EditUser(string username)
        {
            UserProfile up = new UserProfile();
            up = GetUser(username);
            return View(up);
        }

        //Add new article
        [HttpPost]
        [Authorize]
        public ActionResult CreateArticle(string username, string categories, string articleTitle, string subHeader, string articleContent, string imageArticle, bool isBreaking)
        {
            try
            {
                conn.Open();
                //to get the user id
                UserProfile up = new UserProfile();
                up = GetUser(username);
                int userId = up.UserId;

                //byte[] image = ImageToByte(Image.FromFile(imageArticle));

                //to get the category id
                //Category cat = new Category();
                // TODO
                //int catId = cat.categoryId;

                int isBreakingDb = 0;
                if (isBreaking == true)
                {
                    isBreakingDb = 1;
                }

                SqlCommand cmd = new SqlCommand("INSERT INTO [dbo].[Article] (articleTitle, subHeader, articleContent, dateCreated, imageArticle, isBreaking, UserId, categoryId) VALUES (@articleTitle, @subHeader, @articleContent, @dateCreated, @imageArticle, @isBreaking, @UserId, @categoryId)", conn);
                cmd.Parameters.AddWithValue("@articleTitle", articleTitle);
                cmd.Parameters.AddWithValue("@subHeader", subHeader);
                cmd.Parameters.AddWithValue("@articleContent", articleContent);
                cmd.Parameters.AddWithValue("@dateCreated", DateTime.Now); //get current date/time of upload
                cmd.Parameters.AddWithValue("@imageArticle", imageArticle);
                cmd.Parameters.AddWithValue("@isBreaking", isBreakingDb); //use the int (bit) value to be inputted into the db
                cmd.Parameters.AddWithValue("@UserId", userId);
                cmd.Parameters.AddWithValue("@categoryId", categories);
                cmd.ExecuteNonQuery();
                conn.Close();
            }

            catch
            {
                TempData["Message"] = "Error occurred";
            }
            return RedirectToAction("Articles");
        }

        //Convert image to byte
        public byte[] ImageToByte(System.Drawing.Image image)
        {
            MemoryStream ms = new MemoryStream();
            image.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);
            return ms.ToArray();
        }

        //Convert byte to image
        public Image ByteToImage(byte[] byteArray)
        {
            MemoryStream ms = new MemoryStream(byteArray);
            Image returnImg = Image.FromStream(ms);
            return returnImg;
        }

        //Save changes to user
        [HttpPost]
        [Authorize]
        public ActionResult EditUser(string username, string firstName, string lastName, string email, string profileDesc)
        {
            try
            {
                conn.Open();
                UserProfile up = new UserProfile();
                up = GetUser(username);
                int userId = up.UserId;

                SqlCommand cmd = new SqlCommand("UPDATE [dbo].[UserProfile] SET firstName = @newName, lastName = @newSurname, profileDesc = @newDesc, email = @newEmail WHERE UserId = @userid", conn);
                cmd.Parameters.AddWithValue("@newName", firstName);
                cmd.Parameters.AddWithValue("@newSurname", lastName);
                cmd.Parameters.AddWithValue("@newDesc", profileDesc);
                cmd.Parameters.AddWithValue("@newEmail", email);
                cmd.Parameters.AddWithValue("@userid", userId);
                cmd.ExecuteNonQuery();
                conn.Close();

                //ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('User edited successfully!')", true);
                
            }

            catch
            {
                TempData["Message"] = "Error occurred";
            }

            return RedirectToAction("Users");
        }

        //Delete user
        [Authorize]
        public ActionResult DeleteUser(string username)
        {
            try
            {
                //connectToDb();
                //open connection
                conn.Open();
                //get the user profile to delete
                UserProfile up = new UserProfile();
                up = GetUser(username);
                int userId = up.UserId;
                //delete from the database
                SqlCommand cmd = new SqlCommand("DELETE FROM [dbo].[UserProfile] WHERE UserId = @userid", conn);
                cmd.Parameters.AddWithValue("@userid", userId);
                cmd.ExecuteNonQuery();
                //close connection
                conn.Close();
            }

            catch
            {
                TempData["Message"] = "Error occurred";
            }

            return RedirectToAction("Users");        
        
        }

        //Edit an article
        [HttpPost]
        [Authorize]
        public ActionResult EditArticle(string title, string subHeader, string articleContent, int categoryId, bool isBreaking)
        {
            try
            {
                conn.Open();
                Article a = new Article();
                a = GetArticle(title);
                int articleId = a.articleId;
                //a = GetArticleId(articleId);

                int isBreakingDb = 0;
                if (isBreaking == true)
                {
                    isBreakingDb = 1;
                }

                SqlCommand cmd = new SqlCommand("UPDATE [dbo].[Article] SET articleTitle = @articleTitle, subHeader = @subHeader, articleContent = @articleContent, isBreaking = @isBreaking, categoryId = @categoryId WHERE articleId = @articleId", conn);
                cmd.Parameters.AddWithValue("@articleTitle", title);
                cmd.Parameters.AddWithValue("@subHeader", subHeader);
                cmd.Parameters.AddWithValue("@articleContent", articleContent);
                cmd.Parameters.AddWithValue("@isBreaking", isBreakingDb);
                cmd.Parameters.AddWithValue("@articleId", articleId);
                cmd.Parameters.AddWithValue("@categoryId", categoryId);
                cmd.ExecuteNonQuery();
            }
            catch
            {
                TempData["Message"] = "Error occurred";
            }
            return RedirectToAction("Articles");
        }

        //Delete article
        [Authorize]
        public ActionResult DeleteArticle(string title)
        {
            try
            {
                conn.Open();
                Article a = new Article();
                a = GetArticle(title);
                int articleId = a.articleId;
                SqlCommand cmd = new SqlCommand("DELETE FROM [dbo].[Article] WHERE articleId = @articleId", conn);
                cmd.Parameters.AddWithValue("@articleId", articleId);
                cmd.ExecuteNonQuery();
                conn.Close();
            }

            catch
            {
                TempData["Message"] = "Error occurred";
            }
            return RedirectToAction("Articles");
        }

        //Get all the articles related to the author
        public List<Article> GetArticlesForAuthor(int userId)
        {
            List<Article> authorArticles = new List<Article>();
            DataTable articlesDt = new DataTable();
            string sqlCommand = "SELECT * FROM [dbo].[Article] WHERE UserId = " + userId;
            SqlDataAdapter adapter = new SqlDataAdapter(sqlCommand, conn);
            adapter.Fill(articlesDt);

            foreach (DataRow dr in articlesDt.Rows)
            {
                Article a = new Article();
                a.articleTitle = dr["articleTitle"].ToString();
                a.subHeader = dr["subHeader"].ToString();
                a.dateCreated = (DateTime)dr["dateCreated"];
                a.UserId = (int)dr["UserId"];
                a.categoryId = (int)dr["categoryId"];
                authorArticles.Add(a);
            }

            return authorArticles;
        }
    }
}
