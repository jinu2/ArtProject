using ArtProject.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Text.Json;

namespace ArtProject.Pages
{
    public class LogInModel : PageModel
    {
        [BindProperty]
        public string Username { get; set; }
        [BindProperty]
        public string Password { get; set; }


        public IActionResult OnPostLoginRequest()
        {
            string path = @"UserData.json";

            var existingData = new List<UserModel>();

            if (System.IO.File.Exists(path))
            {
                var json = System.IO.File.ReadAllText(path);
                existingData = JsonSerializer.Deserialize<List<UserModel>>(json);
            }


            List<string> usernames = existingData.Select(person => person.Username).ToList();

            List<string> passwords = existingData.Select(person => person.Password).ToList();


            if (usernames.Contains(Username))
            {
                if (passwords.Contains(Password))
                {
                    string valueToSend = Username;
                    Console.WriteLine($"login successful");
                    TempData["MyValue"] = valueToSend;
                    return RedirectToPage("Profile");
                }
            }

            else
            {
                return RedirectToPage("Login");
            }

            return RedirectToPage("Index");
        }
    }
}
