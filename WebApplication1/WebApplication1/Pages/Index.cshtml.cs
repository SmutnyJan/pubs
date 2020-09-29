using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using WebApplication1.Models;
using WebApplication1.Services;

namespace WebApplication1.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        private readonly AppDbContext _db;
        private readonly PubsManager pm;
        [BindProperty]
        public int idToDelete { get; set; }
        public List<Pub> Pubs { get; set; }
        public IndexModel(ILogger<IndexModel> logger, AppDbContext db)
        {
            _logger = logger;
            _db = db;
            pm = new PubsManager(db);
            Pubs = _db.Pubs.ToList();
        }

        public void OnGet()
        {
        }
        public void OnPost()
        {
            pm.Delete(idToDelete);
            Pubs = _db.Pubs.ToList();
        }
    }
    //_db.Pubs(new Pub {Name = "", Municipality = ""});
    //_db.SaveChanges();
    /*
    //var pub = _db.Pubs.Find(id);
    //var pub = _db.Pubs.Where(p => p.Municapility == "Liberec").ToList()
    //var pub = _db.Pubs.Where(p => p.Municipality == "Liberec").FirstOfDefault()
    var pub = _db.Pubs.SingleOfDefault(p => p.Name == "U tupé vydry");
    if(pub != null){
        
    }
    pub.Name = "U Chytrého Morodce";
    _db.SaveChanges();

    pub.Remove()
    _db.SaveChanges();
     */
}
