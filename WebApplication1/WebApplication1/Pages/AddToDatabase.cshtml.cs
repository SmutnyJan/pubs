using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WebApplication1.Models;

namespace WebApplication1.Pages
{
    public class AddToDatabaseModel : PageModel
    {
        public int Difficulty { get; set; }
        [BindProperty]
        public string pubName { get; set; }
        [BindProperty]
        public string pubLocation { get; set; }

        private readonly AppDbContext _db;
        public List<Pub> Pubs { get; set; }
        public AddToDatabaseModel(AppDbContext db)
        {
            _db = db;
        }
        public void OnGet()
        {
            Pubs = _db.Pubs.ToList();
        }

        public ActionResult OnPost()
        {
            _db.Pubs.Add(new Pub {Name = pubName, Municipality = pubLocation});
            _db.SaveChanges();
            return RedirectToPage("./Index");
        }
    }
}
