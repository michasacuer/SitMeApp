﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using DataAccessLibrary.Models;
using DataAccessLibrary.Repositories.Generic;
using DataAccessLibrary.Repositories.RestaurantRepo;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SitMe.Models;

namespace SitMe.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IRepository<User> _userRepository;
        private readonly IRepository<Restaurant> _restaurantRepository;

        private readonly IRestaurantRepository _restaurantRepositoryConcrete;

        public HomeController(  ILogger<HomeController> logger,
                                IRepository<User> userRepository,
                                IRepository<Restaurant> restaurantRepository,
                                IRestaurantRepository restaurantRepositoryConcrete)
        {
            _logger = logger;
            _userRepository = userRepository;
            _restaurantRepository = restaurantRepository;
            _restaurantRepositoryConcrete = restaurantRepositoryConcrete;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult RestaurantProfile() {
            return View();
        }

        public async Task<IActionResult> RestaurantList() {
            // many to many query
            var restaurants = await _restaurantRepositoryConcrete.GetRstaurantsWithTags();
            return View(restaurants);
        }


        public IActionResult CreateReservation() {
            return View();
        }

        public IActionResult UserProfile() {
            return View();
        }

        public IActionResult ThankYou() {
            return View();
        }

        public IActionResult Privacy()
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
