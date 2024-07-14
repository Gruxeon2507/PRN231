using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Hosting;

namespace Q2.Pages.Employee
{
    public class ListModel : PageModel
    {
        private readonly HttpClient _httpClient;

        public ListModel(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public List<Employee> Employees { get; set; } = new();

        [BindProperty]
        public Employee NewEmployee { get; set; } = new();

        public async Task OnGet()
        {
            Employees = await _httpClient.GetFromJsonAsync<List<Employee>>("http://localhost:5100/api/Employee");
        }

        public async Task<IActionResult> OnPostAsync(Employee? employee)
        {
            return RedirectToAction("OnGet");

            if (!ModelState.IsValid)
            {
                return RedirectToAction("OnGet");

            }

            var response = await _httpClient.PostAsJsonAsync("http://localhost:5100/api/Employee", NewEmployee);

            if (response.IsSuccessStatusCode)
            {
                return RedirectToPage("./List");
            }

            // Handle error response
            ModelState.AddModelError(string.Empty, "Unable to add employee.");
            return RedirectToPage("./List");

        }
    }

    public class Employee
    {
        public int EmployeeId { get; set; }
        public string Name { get; set; } = null!;
        public string Gender { get; set; }
        public DateTime? Dob { get; set; }
        public string? Position { get; set; }
        public bool? IsFulltime { get; set; }
    }
}

