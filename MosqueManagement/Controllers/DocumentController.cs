﻿using Microsoft.AspNetCore.Mvc;

namespace MosqueManagement.Controllers
{
    public class DocumentController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
