using BSA18_Task2.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BSA18_Task2.Controllers
{
    public class PostsController : Controller
    {
        private readonly UserDataService userDataService;

        public PostsController()
        {
            userDataService = UserDataService.Instance;
        }

        // GET: Posts/
        public ActionResult Index()
        {
            return View();
        }

        // POST: Posts/GetPostInfo/
        [HttpPost]
        public ActionResult GetPostInfo(int postId)
        {
            var postInfo = userDataService.GetPostInfo(postId);
            return View(postInfo);
        }

        // POST: Posts/GetUserPostsList/
        [HttpPost]
        public ActionResult GetUserPostsList(int userId)
        {
            var post = userDataService.GetUserPostsList(userId);
            return View(post);
        }
    }
}