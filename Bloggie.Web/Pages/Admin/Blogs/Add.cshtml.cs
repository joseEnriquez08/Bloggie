using Bloggie.Web.Data;
using Bloggie.Web.Models.Domain;
using Bloggie.Web.Models.ViewModels;
using Bloggie.Web.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Text.Json;

namespace Bloggie.Web.Pages.Admin.Blogs
{
    [Authorize(Roles = "Admin")]
    public class AddModel : PageModel
    {
        
        private readonly IBlogPostRepository blogPostRepository;

        //this creates a two way binding between a variable and a form component. The
        //for componenet must have the attribute: asp-for="variable name"
        //this method should not be used, too cluttered 
        /*[BindProperty]
        public string heading { get; set; }

        [BindProperty]
        public string pageTitle { get; set; }*/

        //better to encapsulate all those varibale in an object
        [BindProperty]
        public AddBlogPost AddBlogPostRequest { get; set; }

        [BindProperty]
        public IFormFile FeaturedImage { get; set; }

        [BindProperty]
        public string Tags { get; set; }


        public AddModel(IBlogPostRepository blogPostRepository)
        {
            //this.bloggieDbContext = bloggieDbContext;
            this.blogPostRepository = blogPostRepository;
        }
        public void OnGet()
        {
        }

        public async Task<IActionResult> OnPost()
        {
            //maps request to a blogPost object
            var blogPost = new BlogPost()
            {
                Heading = AddBlogPostRequest.Heading,
                PageTitle = AddBlogPostRequest.PageTitle,
                Content = AddBlogPostRequest.Content,
                ShortDescription = AddBlogPostRequest.ShortDescription,
                FeaturedImageUrl = AddBlogPostRequest.FeaturedImageUrl,
                UrlHandle = AddBlogPostRequest.UrlHandle,
                PublishedDate = AddBlogPostRequest.PublishedDate,
                Author = AddBlogPostRequest.Author,
                Visible = AddBlogPostRequest.Visible,
                Tags = new List<Tag>(Tags.Split(',').Select(x => new Tag() { Name = x.Trim()}))
            };
           /* //when adding to the database, the GUID from the mapping will automatically be assigned
            await bloggieDbContext.BlogPosts.AddAsync(blogPost);
            await bloggieDbContext.SaveChangesAsync();*/

            await blogPostRepository.AddAsync(blogPost);

            var notification = new Notification
            {
                Type = Enums.NotificationType.Success,
                Message = "New blog created!"

            };
            TempData["Notification"] = JsonSerializer.Serialize(notification);


            //sends to another page
            return RedirectToPage("/Admin/Blogs/List");
        }
    }
}
