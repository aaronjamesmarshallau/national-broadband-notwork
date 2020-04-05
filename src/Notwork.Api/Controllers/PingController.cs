using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Notwork.Api.Contexts;
using Notwork.Api.Contexts.Models;

namespace Notwork.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PingController : Controller
    {
        private readonly NotworkContext _context;
        
        public PingController(NotworkContext ctx)
        {
            _context = ctx;
        }
        
        [HttpPost]
        public async Task Ping()
        {
            await _context.Pings.AddAsync(new Ping());
            await _context.SaveChangesAsync();
            
            Console.WriteLine($"Ping received at {DateTime.Now}");
        }
    }
}