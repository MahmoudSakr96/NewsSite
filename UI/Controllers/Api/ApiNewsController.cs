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
    public class ApiNewsController : Controller
    {
        private readonly ILogger<ApiNewsController> _logger;
        private readonly INewsAppService _newsAppService;
        public ApiNewsController(ILogger<ApiNewsController> logger, INewsAppService newsAppService)
        {
            _logger = logger;
            _newsAppService = newsAppService;
        }

        [Authorize]
        [HttpPost]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            await _newsAppService.DeleteByIdAsync(id);
            return Ok();
        }

    }
}
