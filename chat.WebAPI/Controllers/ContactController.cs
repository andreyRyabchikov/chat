using AutoMapper;
using chat.Services.Abstract;
using chat.Services.Models;
using chat.WebAPI.Models;
using Microsoft.AspNetCore.Mvc;

namespace chat.WebAPI.Controllers
{
    /// <summary>
    /// Contact endpoints
    /// </summary>
    [ProducesResponseType(200)]
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiController]
    public class ContactController : ControllerBase
    {
        private readonly IContactService ContactService;
        private readonly IMapper mapper;

        /// <summary>
        /// Doctors controller
        /// </summary>
        public ContactController(IContactService ContactService, IMapper mapper)
        {
            this.ContactService = ContactService;
            this.mapper = mapper;
        }

        /// <summary>
        /// Get Contacts by pages
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IActionResult GetContacts([FromQuery] int limit = 20, [FromQuery] int offset = 0)
        {
            var pageModel = ContactService.GetContacts(limit, offset);
            return Ok(mapper.Map<PageResponse<ContactResponse>>(pageModel));
        }

        /// <summary>
        /// Update Contact
        /// </summary>
        [HttpPut]
        [Route("{id}")]
        public IActionResult UpdateContact([FromRoute] Guid id, [FromBody] ContactResponse model)
        {
            var validationResult = model.Validate();
            if (!validationResult.IsValid)
            {
                return BadRequest(validationResult.Errors);
            }
            try
            {
                var resultModel = ContactService.UpdateContact(id, mapper.Map<ContactModel>(model));

                return Ok(mapper.Map<ContactResponse>(resultModel));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }

        /// <summary>
        /// Delete Contact
        /// </summary>
        [HttpDelete]
        [Route("{id}")]
        public IActionResult DeleteContact([FromRoute] Guid id)
        {
            try
            {
                ContactService.DeleteContact(id);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }

        /// <summary>
        /// Get Contact
        /// </summary>
        [HttpGet]
        [Route("{id}")]
        public IActionResult GetContact([FromRoute] Guid id)
        {
            try
            {
                var ContactModel = ContactService.GetContact(id);
                return Ok(mapper.Map<ContactResponse>(ContactModel));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }
        /// <summary>
        /// Add Contact
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public IActionResult AddContact([FromBody] ContactModel Contact)
        {
            var response = ContactService.AddContact(Contact);
            return Ok(response);
        }
    }
}