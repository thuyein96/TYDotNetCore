using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Data;
using System.Data.SqlClient;
using TYDotNetCore.RestApi.Models;
using TYDotNetCore.RestApi.Services;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;
using TYDotNetCore.Shared;

namespace TYDotNetCore.RestApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BlogAdoDotNet2Controller : ControllerBase
    {
        private readonly AdoDotNetService _adoDotNetService = new AdoDotNetService(ConnectionStrings.SqlConnectionStringBuilder.ConnectionString);

        [HttpGet]
        public IActionResult GetBlogs()
        {
            string query = "select * from tbl_blog";
            var lst = _adoDotNetService.Query<BlogModel>(query);

            return Ok(lst);
        }

        [HttpGet("{id}")]
        public IActionResult GetBlog(int id)
        {
            string query = "select * from tbl_blog where BlogId = @BlogId";

            //AdoDotNetParameter[] parameters = new AdoDotNetParameter[1];
            //parameters[0] = new AdoDotNetParameter("@BlogId", id);
            //var lst = _adoDotNetService.Query<BlogModel>(query, parameters);

            var item = _adoDotNetService.FirstOrDefaultQuery<BlogModel>(query, new AdoDotNetParameter("@BlogId", id));
            

            if (item is null)
            {
                return NotFound("No Data Found.");
            }

            return Ok(item);
        }

        [HttpPost]
        public IActionResult CreateBlog(BlogModel blog)
        {
            string query = @"INSERT INTO [dbo].[Tbl_Blog]
           ([BlogTitle]
           ,[BlogAuthor]
           ,[BlogContent])
     VALUES
           (@BlogTitle
           ,@BlogAuthor
           ,@BlogContent)";

            int result = _adoDotNetService.Execute(query,
                new AdoDotNetParameter("@BlogTitle", blog.BlogTitle),
                new AdoDotNetParameter("@BlogAuthor", blog.BlogAuthor),
                new AdoDotNetParameter("@BlogContent", blog.BlogContent));

            string message = result > 0 ? "Saving Successful." : "Saving Failed.";
            return Ok(message);
        }

        [HttpPut("{id}")]
        public IActionResult UpdateBlog(int id, BlogModel blog)
        {
            string query = @"UPDATE [dbo].[Tbl_Blog]
   SET [BlogTitle] = @BlogTitle
      ,[BlogAuthor] = @BlogAuthor
      ,[BlogContent] = @BlogContent
 WHERE BlogId = @BlogId";

            int result = _adoDotNetService.Execute(query,
                new AdoDotNetParameter("@BlogId", id),
                new AdoDotNetParameter("@BlogTitle", blog.BlogTitle),
                new AdoDotNetParameter("@BlogAuthor", blog.BlogAuthor),
                new AdoDotNetParameter("@BlogContent", blog.BlogContent));

            string message = result > 0 ? "Updating Successful." : "Updating Failed.";
            return Ok(message);
        }

        [HttpPatch("{id}")]
        public IActionResult PatchBlog(int id, BlogModel blog) 
        {
            string conditions = string.Empty;

            if (!string.IsNullOrEmpty(blog.BlogTitle))
            {
                conditions += "[BlogTitle] = @BlogTitle, ";               
            }
            if (!string.IsNullOrEmpty(blog.BlogAuthor)) 
            {
                conditions += "[BlogAuthor] = @BlogAuthor, ";
            }
            if (!string.IsNullOrEmpty(blog.BlogContent))
            {
                conditions += "[BlogContent] = @BlogContent, ";
            }
            if(conditions.Length == 0)
            {
                return NotFound("No data found.");
            }
            conditions = conditions.Substring(0, conditions.Length - 2);

            string query = $@"UPDATE [dbo].[Tbl_Blog]
                           SET {conditions} 
                         WHERE BlogId = @BlogId";

            List<AdoDotNetParameter> parameters = new List<AdoDotNetParameter>();
            parameters.Add(new AdoDotNetParameter("@BlogId", id));
            if(!string.IsNullOrEmpty(blog.BlogTitle))
            {
                parameters.Add(new AdoDotNetParameter("@BlogTitle", blog.BlogTitle));
            }
            if (!string.IsNullOrEmpty(blog.BlogAuthor))
            {
                parameters.Add(new AdoDotNetParameter("@BlogAuthor", blog.BlogAuthor));
            }
            if (!string.IsNullOrEmpty(blog.BlogContent))
            {
                parameters.Add(new AdoDotNetParameter("@BlogContent", blog.BlogContent));
            }

            int result = _adoDotNetService.Execute(query, parameters.ToArray());

            string message = result > 0 ? "Updating Successful." : "Updating Failed.";


            return Ok(message);
        } 

        [HttpDelete("{id}")]
        public IActionResult DeleteBlog(int id)
        {
            string query = @"delete from Tbl_Blog where BlogId = @BlogId";
            int result = _adoDotNetService.Execute(query, new AdoDotNetParameter("@BlogId", id));

            string message = result > 0 ? "Delete Successful." : "Delete Failed.";
            return Ok(message);
        }
    }
}
