using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Q2.Pages
{
    public class ProjectModel : PageModel
    {
        private readonly HttpClient _httpClient;

        public ProjectModel(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public List<Project> Projects { get; set; } = new();

        [BindProperty]
        public Project NewProject { get; set; } = new();

        public async Task OnGet()
        {
            Projects = await _httpClient.GetFromJsonAsync<List<Project>>("http://localhost:5100/api/Project");
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            var response = await _httpClient.PostAsJsonAsync("http://localhost:5100/api/Project", NewProject);

            if (response.IsSuccessStatusCode)
            {
                return RedirectToPage();
            }

            // Handle error response
            ModelState.AddModelError(string.Empty, "Unable to add project.");
            return Page();
        }
    }

    public class Project
    {
        public int ProjectId { get; set; }
        public string ProjectName { get; set; } = null!;
        public string ProjectDescription { get; set; } = null!;
        public DateTime StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public bool IsActive { get; set; }
    }
}
