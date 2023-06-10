using ArtProject.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Text.Json;

namespace ArtProject.Pages
{
    public class SignUpModel : PageModel
    {
        [BindProperty]
        public List<UserModel> Users { get; set; }

        [BindProperty]
        public string Name { get; set; }

        [BindProperty]
        public int Age { get; set; }

        [BindProperty]
        public string Email { get; set; }

        [BindProperty]
        public string Username { get; set; }

        [BindProperty]
        public string Password { get; set; }



        public IActionResult OnPostUserRequest()
        {
            string path = @"UserData.json";

            var newData = new UserModel(Name, Age, Email, Username, Password);


            var existingData = new List<UserModel>();

            if (System.IO.File.Exists(path))
            {
                var json = System.IO.File.ReadAllText(path);
                existingData = JsonSerializer.Deserialize<List<UserModel>>(json);
            }


            existingData.Add(newData);


            var updatedJson = JsonSerializer.Serialize(existingData);
            Console.WriteLine(updatedJson);
            //System.IO.File.WriteAllText(jsonData, updatedJson);



            using (var tw = new StreamWriter(path, false))
            {
                tw.WriteLine(updatedJson.ToString());
                tw.Close();
            }


            return RedirectToPage("Index");
        }
        public void OnGet()
        {
        }
    }
}
