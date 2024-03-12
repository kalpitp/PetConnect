using Microsoft.AspNetCore.Mvc;
using PetConnect.MVC.Models;
using System.Diagnostics;
using System.Text.Json;

namespace PetConnect.MVC.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly HttpClient _httpClient;

        public HomeController(ILogger<HomeController> logger, HttpClient httpClient)
        {
            _logger = logger;
            _httpClient = httpClient;
            _httpClient.BaseAddress = new Uri("http://localhost:5159/api");
        }

        public async Task<IActionResult> Index()
        {
            try
            {
                var response = await _httpClient.GetAsync("/pet");

                response.EnsureSuccessStatusCode();

                var json = await response.Content.ReadAsStringAsync();
                var pets = JsonSerializer.Deserialize<List<Pet>>(json);

                return View(pets); 
            }
            catch (HttpRequestException ex)
            {
                return StatusCode(500);
            }
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
