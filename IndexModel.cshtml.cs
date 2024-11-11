// Pages/Index.cshtml.cs
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using YourNamespace.Models;

namespace YourNamespace.Pages
{
    public class IndexModel : PageModel
    {
        public List<TestModel> Tests { get; set; } = new List<TestModel>();

        public async Task OnGetAsync()
        {
            using (var client = new HttpClient())
            {
                var response = await client.GetAsync("https://localhost:5001/api/tests");
                if (response.IsSuccessStatusCode)
                {
                    Tests = await response.Content.ReadAsAsync<List<TestModel>>();
                }
            }
        }
    }
}