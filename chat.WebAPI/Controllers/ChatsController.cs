using AutoMapper;
using chat.Services.Abstract;
using chat.Services.Models;
using chat.WebAPI.Models;
using Microsoft.AspNetCore.Mvc;

namespace chat.WebAPI.Controllers
{
    /// <summary>
    /// Chat endpoints
    /// </summary>
    [ProducesResponseType(200)]
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiController]
    public class ChatsController : ControllerBase
    {
        private readonly IChatService ChatService;
        private readonly IMapper mapper;

        /// <summary>
        /// Doctors controller
        /// </summary>
        public ChatsController(IChatService ChatService, IMapper mapper)
        {
            this.ChatService = ChatService;
            this.mapper = mapper;
        }

        /// <summary>
        /// Get Chats by pages
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IActionResult GetChats([FromQuery] int limit = 20, [FromQuery] int offset = 0)
        {
            var pageModel = ChatService.GetChats(limit, offset);
            return Ok(mapper.Map<PageResponse<ChatResponse>>(pageModel));
        }

        /// <summary>
        /// Update Chat
        /// </summary>
        [HttpPut]
        [Route("{id}")]
        public IActionResult UpdateChat([FromRoute] Guid id, [FromBody] UpdateChatRequest model)
        {
            var validationResult = model.Validate();
            if (!validationResult.IsValid)
            {
                return BadRequest(validationResult.Errors);
            }
            try
            {
                var resultModel = ChatService.UpdateChat(id, mapper.Map<UpdateChatModel>(model));

                return Ok(mapper.Map<ChatResponse>(resultModel));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }

        /// <summary>
        /// Delete Chat
        /// </summary>
        [HttpDelete]
        [Route("{id}")]
        public IActionResult DeleteChat([FromRoute] Guid id)
        {
            try
            {
                ChatService.DeleteChat(id);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }

        /// <summary>
        /// Get Chat
        /// </summary>
        [HttpGet]
        [Route("{id}")]
        public IActionResult GetChat([FromRoute] Guid id)
        {
            try
            {
                var ChatModel = ChatService.GetChat(id);
                return Ok(mapper.Map<ChatResponse>(ChatModel));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }
        /// <summary>
        /// Add Chat
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public IActionResult AddChat([FromBody] ChatModel Chat)
        {
            var response = ChatService.AddChat(Chat);
            return Ok(response);
            
        }
    }
}