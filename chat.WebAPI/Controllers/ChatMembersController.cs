using AutoMapper;
using chat.Services.Abstract;
using chat.Services.Models;
using chat.WebAPI.Models;
using Microsoft.AspNetCore.Mvc;

namespace chat.WebAPI.Controllers
{
    /// <summary>
    /// Doctors endpoints
    /// </summary>
    [ProducesResponseType(200)]
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiController]
    public class ChatMembersController : ControllerBase
    {
        private readonly IChatMemberService ChatMemberService;
        private readonly IMapper mapper;

        /// <summary>
        /// Doctors controller
        /// </summary>
        public ChatMembersController(IChatMemberService ChatMemberService, IMapper mapper)
        {
            this.ChatMemberService = ChatMemberService;
            this.mapper = mapper;
        }

        /// <summary>
        /// Get ChatMembers by pages
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IActionResult GetChatMembers([FromQuery] int limit = 20, [FromQuery] int offset = 0)
        {
            var pageModel = ChatMemberService.GetChatMembers(limit, offset);
            return Ok(mapper.Map<PageResponse<ChatMemberResponse>>(pageModel));
        }

        /// <summary>
        /// Update ChatMember
        /// </summary>
        [HttpPut]
        [Route("{id}")]
        public IActionResult UpdateChatMember([FromRoute] Guid id, [FromBody] ChatMemberResponse model)
        {
            try
            {
                var resultModel = ChatMemberService.UpdateChatMember(id, mapper.Map<ChatMemberModel>(model));

                return Ok(mapper.Map<ChatMemberResponse>(resultModel));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }

        /// <summary>
        /// Delete ChatMember
        /// </summary>
        [HttpDelete]
        [Route("{id}")]
        public IActionResult DeleteChatMember([FromRoute] Guid id)
        {
            try
            {
                ChatMemberService.DeleteChatMember(id);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }

        /// <summary>
        /// Get ChatMember
        /// </summary>
        [HttpGet]
        [Route("{id}")]
        public IActionResult GetChatMember([FromRoute] Guid id)
        {
            try
            {
                var ChatMemberModel = ChatMemberService.GetChatMember(id);
                return Ok(mapper.Map<ChatMemberResponse>(ChatMemberModel));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }
    }
}