﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Aksheshkumar_C_C229.Models;

namespace Aksheshkumar_C_C229.Controllers
{
    public class HomeController : Controller
    {
        public ViewResult Index()
        {
            return View("HomePage");
        }

    }
}