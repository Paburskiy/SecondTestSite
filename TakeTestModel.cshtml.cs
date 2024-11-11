// Pages/TakeTest.cshtml.cs
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using YourNamespace.Models;

namespace YourNamespace.Pages
{
    public class TakeTestModel : PageModel
    {
        private readonly IHttpClientFactory _clientFactory;

        public TakeTestModel(IHttpClientFactory clientFactory)
        {
            _clientFactory = clientFactory;
        }

        [BindProperty(SupportsGet = true)]
        public string Id { get; set; }

        public TestModel Test { get; set; }

        [BindProperty]
        public List<int> Answers { get; set; }

        public int? Score { get; private set; }

        public async Task OnGetAsync()
        {
            var client = _clientFactory.CreateClient();
            var response = await client.GetAsync($"https://localhost:5001/api/tests/{Id}");
            if (response.IsSuccessStatusCode)
            {
                Test = await response.Content.ReadAsAsync<TestModel>();
            }
        }

        public async Task<IActionResult> OnPostAsync()
        {
            var client = _clientFactory.CreateClient();
            var response = await client.PostAsJsonAsync($"https://localhost:5001/api/tests/{Id}/check", Answers);

            if (response.IsSuccessStatusCode)
            {
                var result = await response.Content.ReadAsAsync<Dictionary<string, int>>();
                Score = result["score"];
                await OnGetAsync();
            }

            return Page();
        }
    }
}
