using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApi_NVV_Books.ActionResults;
using WebApi_NVV_Books.Data.Models;
using WebApi_NVV_Books.Data.Services;
using WebApi_NVV_Books.Data.ViewModels;
using WebApi_NVV_Books.Exception;

namespace WebApi_NVV_Books.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PublisherController : ControllerBase
    {
        private readonly PublishersService _publishersService;

        public PublisherController(PublishersService publishersService)
        {
            _publishersService = publishersService;
        }

        [HttpGet("get-all-publishers")]
        public IActionResult GetAllPublishers() 
        {
            try
            {
                var _result = _publishersService.GetAllPublishers();
                return Ok(_result);
            }
            catch (System.Exception)
            {

                return BadRequest("Sorry, we could not load the publishers");
            }
        }

        [HttpGet("get-all-sort-filtering-publishers")]
        public IActionResult GetAllPublishers(string sortBy, string searchStr, int pageNumber)
        {
            try
            {
                var _result = _publishersService.GetAllPublishers(sortBy, searchStr, pageNumber);
                return Ok(_result);
            }
            catch (System.Exception)
            {

                return BadRequest("Sorry, we could not load the publishers");
            }
        }


        [HttpPost("add-publisher")]
        public IActionResult AddPublisher([FromBody] PublisherVM publisher)
        {
            try
            {
                var newPublisher = _publishersService.AddPublisher(publisher);
                return Created(nameof(AddPublisher), newPublisher);
            }
            catch (System.Exception ex)
            {

                return BadRequest(ex.Message);
            }
           
        }

        [HttpGet("get-publisher-by-id/{id}")]
        public IActionResult GetPublisherById(int id)
        {
            //throw new System.Exception("This is an exception that will be handled by middleware");

            var _response = _publishersService.GetPublisherById(id);
            if(_response != null)
            {
                return Ok(_response);
            }
            else
            {
                return NotFound();
            }
        }

        //return type
        [HttpGet("get-publisher-type-by-id/{id}")]
        public Publisher GetPublisherTypeById(int id)
        {
            var _response = _publishersService.GetPublisherById(id);

            if (_response != null)
            {
                return _response;
            }
            else
            {
                return null;
            }
        }

        //return type
        [HttpGet("get-publisher-T-by-id/{id}")]
        public ActionResult<Publisher> GetPublisherTById(int id)
        {
            var _response = _publishersService.GetPublisherById(id);

            if (_response != null)
            {
                return _response;
            }
            else
            {
                return null;
            }
        }

        //custom
        [HttpGet("get-publisher-custom-result-id/{id}")]
        public CustomActionResult GetPublisherCustomResultById(int id)
        {
            var _response = _publishersService.GetPublisherById(id);

            if (_response != null)
            {
                var _responseObj = new CustomActionResultVM() { Publisher = _response };
                return new CustomActionResult(_responseObj);
            }
            else
            {
                var _responseObj = new CustomActionResultVM() { Exception=new System.Exception("This is coming from publishers controler") };
                return new CustomActionResult(_responseObj);
            }
        }

        [HttpGet("get-publisher-books-with-authors/{id}")]
        public IActionResult GetPublisherData(int id) 
        {
            var _response = _publishersService.GetPublisherData(id);
            return Ok(_response);
        }

        [HttpDelete("delete-publisher-by-id/{id}")]
        public IActionResult DeletePublisherById(int id)
        {
            
            try
            {
                _publishersService.DeletePublisherById(id);
                return Ok();
            }
            catch(PublisherNameException ex) 
            {
                return BadRequest($"{ex.Message}, Publisher name {ex.PublisherName}");
            }
            catch (System.Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }
    }
}
