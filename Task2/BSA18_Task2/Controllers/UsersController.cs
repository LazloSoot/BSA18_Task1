using BSA18_Task2.Services;
using System.Web.Mvc;

namespace BSA18_Task2.Controllers
{
    public class UsersController : Controller
    {
        private readonly UserDataService userDataService;

        public UsersController()
        {
            userDataService = UserDataService.Instance;
        }

        // GET: Users/
        public ActionResult Index()
        {
            return View();
        }

        // GET: Users/GetUser/{0}
        public ActionResult GetUser(int id)
        {
            var user = userDataService.GetUser(id);
            return View(user);
        }

        // GET: Users/GetAllUsers/
        public ActionResult GetAllUsers()
        {
            var users = userDataService.GetAllUsers();
            return View(users);
        }

        // GET: Users/GetOrderedUsersList
        public ActionResult GetOrderedUserList()
        {
            var users = userDataService.GetOrderedUserList();
            return View(users);
        }

        // POST: Users/GetUserInfo/
        [HttpPost]
        public ActionResult GetUserInfo(int Id)
        {
            if(Id < 1)
            {
                ModelState.AddModelError("Id", "Id value must be greater than zero");
                return View("Index");
            }
            var userInfo = userDataService.GetUserInfo(Id);
            return View(userInfo);
        }
    }
}