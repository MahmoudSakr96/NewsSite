using Microsoft.AspNetCore.Mvc;
using Business;
using Business.Dto;
using UI.Models;
using System.Diagnostics;
using System;
using System.Collections.Generic;
using System.Linq;
using Business.Contracts.Persistence;
using Domain.Entities;
using Infrastructure;
using AutoMapper;
using Business.Contracts.Feature;
using Microsoft.EntityFrameworkCore;
using System.Net;
using Microsoft.AspNetCore.Authorization;
using System.Globalization;
using Business.Helper;
using Business.Dto;

namespace UI.Controllers
{
    [Authorize]
    public class CategoryController : Controller
    {
        private readonly ILogger<CategoryController> _logger;
        private readonly ICategoryAppService _categoryAppService;
        public CategoryController(ILogger<CategoryController> logger, ICategoryAppService categoryAppService)
        {
            _logger = logger;
            _categoryAppService = categoryAppService;
        }

        [Authorize]
        public async Task<ActionResult> Index()
        {
            var viewModel = await _categoryAppService.GetAllAsync();
            return View(viewModel);
        }

        [Authorize]
        public ActionResult Create()
        {
            return View("CategoryForm",new CategoryDto { });
        }

        [Authorize]
        [HttpPost]
        public async Task<ActionResult> SaveAsync(CategoryDto model)
        {
            if (ModelState.IsValid)
            {
                if(model.Id == 0)
                {
                    await _categoryAppService.AddAsync(model);
                } 
                else {
                    await _categoryAppService.UpdateAsync(model);
                }
                TempData["Message"] = "Saved successfully";
                return RedirectToAction("Index");
            }
            return View(model);
        }

        [Authorize]
        public async Task<ActionResult> EditAsync(int id)
        {
            var viewModel = await _categoryAppService.GetByIdAsync(id);
            return View("CategoryForm", viewModel);
        }

        [Authorize]
        [HttpPost]
        public async Task<ActionResult> EditAsync(CategoryDto model)
        {
            if (ModelState.IsValid)
            {
                await _categoryAppService.UpdateAsync(model);
                return RedirectToAction("Index");
            }

            return View(model);
        }

        [Authorize]
        public async Task<ActionResult> DetailAsync(int id)
        {

            var viewModel = await _categoryAppService.GetByIdAsync(id);
            return View(viewModel);
        }
    }
}