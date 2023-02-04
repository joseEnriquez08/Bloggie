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
    public class EditModel : PageModel
    {
        //private readonly BloggieDbContext bloggieDbContext;
        private readonly IBlogPostRepository blogPostRepository;

        [BindProperty]
        public BlogPost BlogPost { get; set; }

        [BindProperty]
        public IFormFile FeaturedImage { get; set; }

        [BindProperty]
        public string Tags { get; set; }

        public EditModel(IBlogPostRepository blogPostRepository)
        {
            //this.bloggieDbContext = bloggieDbContext;
            this.blogPostRepository = blogPostRepository;
        }


        //when sending data from one page to another, the parameter name here has to match
        //the routing paramet name in the cshtml file.
        public async Task OnGet(Guid id)
        {
            BlogPost = await blogPostRepository.GetAsync(id);
            if (BlogPost != null && BlogPost.Tags != null)
            {
                Tags = String.Join(',', BlogPost.Tags.Select(x => x.Name));
            }

        }

        public async Task<IActionResult> OnPostEdit()
        {
            try
            {

                BlogPost.Tags = new List<Tag>(Tags.Split(',').Select(x => new Tag() { Name = x.Trim() }));
                //throw new Exception();

                await blogPostRepository.UpdateAsync(BlogPost);
                //ViewData["test"] = "hi";

                //Bad method since ther could be multiple different types of messages.
                //Better to make a generic notification type
                //ViewData["MessageDescription"] = "Record was sussessfully saved!";

                ViewData["Notification"] = new Notification
                {
                    Message = "Record updated successfully!",
                    Type = Enums.NotificationType.Success
                };
            }
            catch (Exception ex)
            {
                ViewData["Notification"] = new Notification
                {
                    Message = "Something went wrong!",
                    Type = Enums.NotificationType.Error
                };
               // throw;
            }

            return Page();

        }

        //using "OnPost" tells .net that its a post method.
        //otherwise you can use the [HttpPost] annotation attribute
        public async Task<IActionResult> OnPostDelete()
        {
            var deleted = await blogPostRepository.DeleteAsync(BlogPost.Id);
            if (deleted)
            {
                var notification = new Notification
                {
                    Type = Enums.NotificationType.Success,
                    Message = "Blog was deleted successfully!"

                };
                TempData["Notification"] = JsonSerializer.Serialize(notification);
                return RedirectToPage("/Admin/Blogs/List");
            }
            
            
            //returns current page
            return Page();

            
        }
    }
}
