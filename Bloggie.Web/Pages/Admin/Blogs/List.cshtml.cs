using Bloggie.Web.Data;
using Bloggie.Web.Models.Domain;
using Bloggie.Web.Models.ViewModels;
using Bloggie.Web.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using System.Text.Json;

namespace Bloggie.Web.Pages.Admin.Blogs
{
    [Authorize(Roles = "Admin")]
    public class ListModel : PageModel
    {
        //private readonly BloggieDbContext bloggieDbContext;
        private readonly IBlogPostRepository blogPostRepository;

        public List<BlogPost> BlogPosts { get; set; }

        public ListModel(IBlogPostRepository blogPostRepository)
        {
            //this.bloggieDbContext = bloggieDbContext;
            this.blogPostRepository = blogPostRepository;
        }


        //this method is called when the Listr page loads
        public async Task OnGet()
        {
            //Was reading the ungeneric notification
            /*var messageDescription = (string)TempData["MessageDescription"];

            if (!string.IsNullOrWhiteSpace(messageDescription))
            {
                ViewData["MessageDescription"] = messageDescription;
            }*/

            /*
             * In add.cshtml.cs, temp data cannot work with complex datatypes such as "Notification",
             * so i am jsonSerializing the notif object. Here, i am retrieving that json object, storing
             * it as a string in notificationJson. Then, i am deserializing it or converting it back to a
             * notif object and storing it in the ViewData wich passes the notif to the view
             */
            var notificationJson = (string)TempData["Notification"];
            if(notificationJson != null)
            {
                ViewData["Notification"] = JsonSerializer.Deserialize<Notification>(notificationJson);

            }
            BlogPosts = (await blogPostRepository.GetAllAsync())?.ToList();
        }
    }
}
