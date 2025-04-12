using System.Text.Json;
using System.Text.Json.Serialization;
using CompareUsers.Managers;
using Microsoft.AspNetCore.Authorization.Infrastructure;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using CompareUsers.Types;

namespace CompareUsers.Pages;

public class IndexModel : PageModel
{
    [BindProperty]
    public string ExistingUserContent { get; set; } = string.Empty;
    [BindProperty]
    public string InsertUpdateUserContent { get; set; } = string.Empty;

    public List<User> NewUsers { get; set; } = [];
    public List<User> UpdatedUsers { get; set; } = [];

    public void OnGet()
    {
        // Read json file in /data directory to pre-populate the json for the UI.
        ExistingUserContent = System.IO.File.ReadAllText("Data/users.json");
        InsertUpdateUserContent = System.IO.File.ReadAllText("Data/updates.json");
    }

    public IActionResult OnPost()
    {
        if (ModelState.IsValid)
        {
            try
            {
                // Load users from JSON strings.
                var users = UserManager.GetUsers(ExistingUserContent);
                var updatedUsers = UserManager.GetUsers(InsertUpdateUserContent);

                // Compare users and generate the result.
                var result = UserManager.GetInsertedUpdatedUsers(users, updatedUsers);
                NewUsers = result.Item1;
                UpdatedUsers = result.Item2;
            }
            catch (Exception excep)
            {
                ModelState.AddModelError(string.Empty, $"Error processing the request: {excep.Message}");
            }
        }

        return Page();
    }
}
