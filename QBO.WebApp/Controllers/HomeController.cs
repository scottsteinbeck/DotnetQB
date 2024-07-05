using Intuit.Ipp.OAuth2PlatformClient;
using Microsoft.AspNetCore.Mvc;
using QBO.Shared;
using QBO.WebApp.Models;
using System.Text.Json;
using System.Threading.Tasks;
using System.Diagnostics;

namespace QBO.WebApp.Controllers
{
    public class HomeController : Controller
    {
        public async Task<IActionResult> GetCustomers()
        {
            try
            {
                string customersJson = await QboHelper.GetAllCustomersAsync();
                var customerResponse = JsonSerializer.Deserialize<CustomerResponse>(customersJson, new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true
                });
                return View(customerResponse);
            }
            catch (Exception ex)
            {
                return Content($"An error occurred: {ex.Message}");
            }
        }

        public IActionResult Index()
        {
            // Use the shared helper library (QBO.Shared)
            // to load the token json data (Local.Tokens)
            // and initialize the OAuth2
            // client (Local.Client).
            QboLocal.Initialize(".//QBTokens.json");

            // redirect the local host to
            // a generated authorization URL.
            String authURL = QboHelper.GetAuthorizationURL(OidcScopes.Accounting);
            if(authURL != "") return Redirect(authURL);

            Console.WriteLine($"{QboLocal.Tokens?.AccessToken ?? "DefaultToken"}");

            // If the authorization URL is empty,
            
            return  View(new HomeViewModel("Success!"));
        }

        #region ASP.NET Default Code

        private readonly ILogger<HomeController> _logger;
        public HomeController(ILogger<HomeController> logger) => _logger = logger;

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error() => View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });

        #endregion
    }
}