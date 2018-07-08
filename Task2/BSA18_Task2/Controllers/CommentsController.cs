using BSA18_Task2.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BSA18_Task2.Controllers
{
    public class CommentsController : Controller
    {
        private readonly UserDataService userDataService;

        public CommentsController()
        {
            userDataService = UserDataService.Instance;
        }

        // GET: Comments/
        public ActionResult Index()
        {
            return View();
        }

        // POST: Comments/GetShortCommentsList/
        [HttpPost]
        public ActionResult GetShortCommentsList(int userId)
        {
            var comments = userDataService.GetCommentsList(userId);
            return View(comments);
        }

        // POST: Comments/GetUserCommentsList/
        [HttpPost]
        public ActionResult GetUserCommentsList(int userId)
        {
            var comments = userDataService.GetUserCommentsList(userId);
            return View(comments);
        }

        // POST: Comments/GetCommentsCount/
        [HttpPost]
        public ActionResult GetCommentsCount(int userId)
        {
            var comments = userDataService.GetCommentsCount(userId);
            return View(comments);
        }
    }
}