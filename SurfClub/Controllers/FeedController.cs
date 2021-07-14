using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SurfClub.Helpers;
using SurfClub.Models;
using SurfClub.Models.DbModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SurfClub.Controllers
{
    public class FeedController : Controller
    {
        private readonly SurfClubDBContext dbContext;

        public FeedController(SurfClubDBContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public IActionResult Index()
        {
            var posts = dbContext.Posts.
                Include(c => c.Author).
                OrderBy(c => c.PublishDate).
                ToArray();
            ViewBag.Posts = posts;
            return View();
        }

        [HttpPost]
        public IActionResult AddPost(Post model, IFormFile imageData)
        {
            if (string.IsNullOrEmpty(model.Text) && imageData == null)
            {
                var posts1 = dbContext.Posts.
                Include(c => c.Author).
                OrderBy(c => c.PublishDate).
                ToArray();
                ViewBag.Posts = posts1;

                return View("Index", model);
            }
            if (imageData != null)
            {
                model.Photo = ImageHelper.UploadImage(imageData);
            }
            model.PublishDate = DateTime.Now;

            var userId = HttpContext.Session.GetInt32("UserId").Value; // maybe null

            var user = dbContext.Users.FirstOrDefault(c => c.Id == userId); // user or null

            model.Author = user;

            dbContext.Posts.Add(model);
            dbContext.SaveChanges();

            var posts = dbContext.Posts.
                Include(c =>c.Author).
                OrderBy(c => c.PublishDate).
                ToArray();
            ViewBag.Posts = posts;

            return View("Index");
        }
    }
}

