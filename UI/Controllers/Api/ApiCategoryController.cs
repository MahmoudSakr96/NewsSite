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
    public class ApiCategoryController : ControllerBase
    {
        private readonly ILogger<ApiCategoryController> _logger;
        private readonly ICategoryAppService _categoryAppService;
        public ApiCategoryController(ILogger<ApiCategoryController> logger, ICategoryAppService categoryAppService)
        {
            _logger = logger;
            _categoryAppService = categoryAppService;
        }

        [Authorize]
        [HttpPost]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            await _categoryAppService.DeleteByIdAsync(id);
            return Ok();
        }

    }
}
