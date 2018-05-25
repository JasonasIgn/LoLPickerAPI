﻿using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.IO;
using System.Linq;
using System.Net;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Analysis.Application.main;
using Analysis.Application.main.generalData;
using Analysis.EF.entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;


namespace Analysis.Web.Controllers
{
    [Route("/[controller]")]
    public class GeneralDataController : Controller
    {
        protected readonly IGeneralDataService _generalDataService;
        public GeneralDataController(IGeneralDataService generalDataService)
        {
            _generalDataService = generalDataService;
        }


        [HttpGet("{id}")]
        public GeneralData Get(int id)
        {
            return _generalDataService.GetById(id);
        }

        [HttpPut]
        public IActionResult UpdateGeneralData([FromBody] GeneralData data)
        {
            try
            {
                _generalDataService.UpdateGeneralData(data);
                return Ok();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
            return BadRequest();
        }
    }
}