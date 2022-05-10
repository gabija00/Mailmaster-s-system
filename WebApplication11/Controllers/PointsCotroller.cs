using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication11.Controllers
{
    public class PointsCotroller : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
