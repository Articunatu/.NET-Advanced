﻿using _04___API.Models;
using _04___API.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace _04___API_WebConnect.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InterestController : ControllerBase
    {
        private IRepository<Interest> _repo2;

        public InterestController(IRepository<Interest> repo2)
        {
            _repo2 = repo2;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> ReadPersonsInterests(int id)
        {
            //try
            //{
                return Ok(await _repo2.SearchByPerson(id));
            //}
            //catch (Exception)
            //{
            //    return StatusCode(StatusCodes.Status500InternalServerError,
            //        "Error to retrieve this person's interests from database.....");
            //}
        }

        [HttpPost("{pId}")]
        public async Task<ActionResult<Interest>> ConnectInterestToPerson(Interest interest, int pId, int iId)
        {
            //try
            //{
                var foundInterest = await _repo2.ConnectToPerson(interest, pId, iId);
                if (foundInterest != null)
                {
                    return Created("", foundInterest);
                }
                return NotFound($"Could not find person with id: {pId} in database!");
            //}
            //catch (Exception)
            //{
            //    return StatusCode(StatusCodes.Status500InternalServerError, "Error connecting to database");
            //}
        }
    }
}