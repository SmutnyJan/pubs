using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WebApplication1.Models;

namespace WebApplication1.Pages
{
    public class DetailModel : PageModel
    {
        private readonly AppDbContext _db;
        public Pub Pub { get; set; }

        public DetailModel(AppDbContext db)
        {
            _db = db;
        }
        public void OnGet(int? id = null)
        {
            Pub = _db.Pubs.SingleOrDefault(p => p.Id == id);
        }
    }
}
