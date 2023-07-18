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
using GlobalApp.Demo.Application.Services;

namespace UI.Controllers
{
    //[Authorize]
    public class NewsController : Controller
    {
        private readonly ILogger<NewsController> _logger;
        private readonly INewsAppService _newsAppService;
        private readonly ICategoryAppService _categoryAppService;

        public NewsController(ILogger<NewsController> logger, INewsAppService newsAppService, ICategoryAppService categoryAppService)
        {
            _logger = logger;
            _newsAppService = newsAppService;
            _categoryAppService = categoryAppService;

        }

        public async Task<ActionResult> Index()
        {
            var viewModel = new NewsGrid
            {
                News = await _newsAppService.GetAllAsync(),
                Categories = await _categoryAppService.GetAllAsync()
            };
            return View(viewModel);
        }

        [HttpPost]
        public async Task<ActionResult> IndexAsync(int categoryId)
        {
            var viewModel = new NewsGrid
            {
                News = _newsAppService.GetAllByCategoryIdAsync(categoryId),
                Categories = await _categoryAppService.GetAllAsync(),
            };
            return View(viewModel);

        }

        [Authorize]
        public async Task<ActionResult> CreateAsync()
        {
            var viewModel = new NewsDto { Categories = await _categoryAppService.GetAllAsync() };
            return View("NewsForm", viewModel);
        }

        [Authorize]
        [HttpPost]
        public async Task<ActionResult> SaveAsync(NewsDto model)
        {

            if (ModelState.IsValid)
            {
                var file = Request.Form.Files["ImageData"];
                if(file != null)
                {
                    using (var memoryStream = new MemoryStream())
                    {
                        await file.CopyToAsync(memoryStream);
                        model.Image = memoryStream.ToArray();
                    }
                }
                if (model.Id == 0)
                {
                    await _newsAppService.AddAsync(model);
                } 
                else {
                    await _newsAppService.UpdateAsync(model);
                }
                TempData["Message"] = "Saved successfully";
                return RedirectToAction("Index");
            }
            model.Categories = await _categoryAppService.GetAllAsync();
            return View("NewsForm", model);
        }

        [Authorize]
        public async Task<ActionResult> EditAsync(int id)
        {
            var viewModel = await _newsAppService.GetByIdAsync(id);
            viewModel.Categories = await _categoryAppService.GetAllAsync();
            return View("NewsForm", viewModel);
        }

        [Authorize]
        [HttpPost]
        public async Task<ActionResult> EditAsync(NewsDto model)
        {
            if (ModelState.IsValid)
            {
                var viewModel = await _newsAppService.UpdateAsync(model);
                return RedirectToAction("Index");
            }

            return View(model);
        }

        public async Task<ActionResult> DetailsAsync(int id)
        {

            var viewModel = await _newsAppService.GetByIdAsync(id);
            viewModel.CategoryName = (await _categoryAppService.GetByIdAsync(viewModel.CategoryId)).Name;
            return View(viewModel);
        }

        [Authorize]
        public async Task<ActionResult> DeleteAsync(int id)
        {
            var viewModel = await _newsAppService.DeleteByIdAsync(id);
            return RedirectToAction("Index");
        }
    }
}