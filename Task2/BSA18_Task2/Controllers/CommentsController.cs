using BSA18_Task2.Services;
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

        // GET: Comment/GetComment/{id}
        public ActionResult GetComment(int id)
        {
            var comment = userDataService.GetComment(id);
            return View(comment);
        }

        // POST: Comments/GetShortCommentsList/
        [HttpPost]
        public ActionResult GetShortCommentsList(int Id)
        {
            if (Id < 1)
            {
                ModelState.AddModelError("Id", "Id value must be greater than zero");
                return View("Index");
            }
            var comments = userDataService.GetCommentsList(Id);
            return View(comments);
        }

        // POST: Comments/GetUserCommentsList/
        [HttpPost]
        public ActionResult GetUserCommentsList(int Id)
        {
            if (Id < 1)
            {
                ModelState.AddModelError("Id", "Id value must be greater than zero");
                return View("Index");
            }
            var comments = userDataService.GetUserCommentsList(Id);
            return View(comments);
        }

        // POST: Comments/GetCommentsCount/
        [HttpPost]
        public ActionResult GetCommentsCount(int Id)
        {
            if (Id < 1)
            {
                ModelState.AddModelError("Id", "Id value must be greater than zero");
                return View("Index");
            }
            var comments = userDataService.GetCommentsCount(Id);
            return View(comments);
        }
    }
}