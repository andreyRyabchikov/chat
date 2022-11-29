using AutoMapper;
using chat.Services.Abstract;
using chat.Services.Models;
using chat.WebAPI.Models;
using Microsoft.AspNetCore.Mvc;

namespace chat.WebAPI.Controllers
{
    /// <summary>
    /// BlackList endpoints
    /// </summary>
    [ProducesResponseType(200)]
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiController]
    public class BlackListController : ControllerBase
    {
        private readonly IBlackListService BlackListService;
        private readonly IMapper mapper;

        /// <summary>
        /// Doctors controller
        /// </summary>
        public BlackListController(IBlackListService BlackListService, IMapper mapper)
        {
            this.BlackListService = BlackListService;
            this.mapper = mapper;
        }

        /// <summary>
        /// Get BlackLists by pages
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IActionResult GetBlackLists([FromQuery] int limit = 20, [FromQuery] int offset = 0)
        {
            var pageModel = BlackListService.GetBlackLists(limit, offset);
            return Ok(mapper.Map<PageResponse<BlackListResponse>>(pageModel));
        }

        /// <summary>
        /// Update BlackList
        /// </summary>
        [HttpPut]
        [Route("{id}")]
        public IActionResult UpdateBlackList([FromRoute] Guid id, [FromBody] BlackListResponse model)
        {
            var validationResult = model.Validate();
            if (!validationResult.IsValid)
            {
                return BadRequest(validationResult.Errors);
            }
            try
            {
                var resultModel = BlackListService.UpdateBlackList(id, mapper.Map<BlackListModel>(model));

                return Ok(mapper.Map<BlackListResponse>(resultModel));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }

        /// <summary>
        /// Delete BlackList
        /// </summary>
        [HttpDelete]
        [Route("{id}")]
        public IActionResult DeleteBlackList([FromRoute] Guid id)
        {
            try
            {
                BlackListService.DeleteBlackList(id);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }

        /// <summary>
        /// Get BlackList
        /// </summary>
        [HttpGet]
        [Route("{id}")]
        public IActionResult GetBlackList([FromRoute] Guid id)
        {
            try
            {
                var BlackListModel = BlackListService.GetBlackList(id);
                return Ok(mapper.Map<BlackListResponse>(BlackListModel));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }
        /// <summary>
        /// Add BlackList
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public IActionResult AddBlackList([FromBody] BlackListModel BlackList)
        {
            var response = BlackListService.AddBlackList(BlackList);
            return Ok(response);
        }
    }
}