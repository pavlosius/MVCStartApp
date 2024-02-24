using Microsoft.AspNetCore.Mvc;
using MVCStartApp.Models;
using MVCStartApp.Models.Db;
using MVCStartApp.Models.Repositories;
using System.Diagnostics;

namespace MVCStartApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IBlogRepository _repo;

        public HomeController(ILogger<HomeController> logger, IBlogRepository repo)
        {
            _logger = logger;
            _repo = repo;
        }

        public async Task <IActionResult> Index()
        {
            // Добавим создание нового пользователя
            var newUser = new User()
            {
                Id = Guid.NewGuid(),
                FirstName = "Andrey",
                LastName = "Petrov",
                JoinDate = DateTime.Now
            };

            // Добавим в базу
            await _repo.AddUser(newUser);

            // Выведем результат
            Console.WriteLine($"User with id {newUser.Id}, named {newUser.FirstName} was successfully added on {newUser.JoinDate}");

            return View();
        }

        public async Task<IActionResult> Authors()
        {
            var authors = await _repo.GetUsers();
            return View(authors);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
