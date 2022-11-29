using AutoMapper;
using chat.Services.Abstract;
using chat.Services.Models;
using chat.WebAPI.Models;
using Microsoft.AspNetCore.Mvc;

namespace chat.WebAPI.Controllers
{
    /// <summary>
    /// Message endpoints
    /// </summary>
    [ProducesResponseType(200)]
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiController]
    public class MessagesController : ControllerBase
    {
        private readonly IMessageService MessageService;
        private readonly IMapper mapper;

        /// <summary>
        /// Doctors controller
        /// </summary>
        public MessagesController(IMessageService MessageService, IMapper mapper)
        {
            this.MessageService = MessageService;
            this.mapper = mapper;
        }

        /// <summary>
        /// Get Messages by pages
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IActionResult GetMessages([FromQuery] int limit = 20, [FromQuery] int offset = 0)
        {
            var pageModel = MessageService.GetMessages(limit, offset);
            return Ok(mapper.Map<PageResponse<MessageResponse>>(pageModel));
        }

        /// <summary>
        /// Update Message
        /// </summary>
        [HttpPut]
        [Route("{id}")]
        public IActionResult UpdateMessage([FromRoute] Guid id, [FromBody] UpdateMessageRequest model)
        {
            var validationResult = model.Validate();
            if (!validationResult.IsValid)
            {
                return BadRequest(validationResult.Errors);
            }
            try
            {
                var resultModel = MessageService.UpdateMessage(id, mapper.Map<UpdateMessageModel>(model));

                return Ok(mapper.Map<MessageResponse>(resultModel));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }

        /// <summary>
        /// Delete Message
        /// </summary>
        [HttpDelete]
        [Route("{id}")]
        public IActionResult DeleteMessage([FromRoute] Guid id)
        {
            try
            {
                MessageService.DeleteMessage(id);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }

        /// <summary>
        /// Get Message
        /// </summary>
        [HttpGet]
        [Route("{id}")]
        public IActionResult GetMessage([FromRoute] Guid id)
        {
            try
            {
                var MessageModel = MessageService.GetMessage(id);
                return Ok(mapper.Map<MessageResponse>(MessageModel));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }
        /// <summary>
        /// Add Message
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public IActionResult AddMessage([FromBody] MessageModel Message)
        {
            var response = MessageService.AddMessage(Message);
            return Ok(response);
        }
    }
}