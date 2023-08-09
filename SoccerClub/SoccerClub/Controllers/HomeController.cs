﻿using Microsoft.AspNetCore.Mvc;
using SoccerClub.Models;
using System.Diagnostics;

namespace SoccerClub.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Matches()
        {
            return View();
        }

        public IActionResult MatchesDetail()
        {
            return View();
        }

        public IActionResult Shop()
        {
            return View();
        }

        public IActionResult Schedule()
        {
            return View();
        }

        public IActionResult Blog()
        {
            return View();
        }

        public IActionResult Players()
        {
            return View();
        }

        public IActionResult PlayersDetail()
        {
            return View();
        }

        public IActionResult Contact()
        {
            return View();
        }

        public IActionResult Cart()
        {
            return View();
        }

        public IActionResult Login()
        {
            return View();
        }

        public IActionResult Signup()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}