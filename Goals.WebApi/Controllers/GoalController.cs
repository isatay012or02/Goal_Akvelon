using AutoMapper;
using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Goals.Application.Goals.Queries.GetGoalList;
using Goals.Application.Goals.Queries.GetGoalDetails;
using Goals.Application.Goals.Commands.CreateGoal;
using Goals.Application.Goals.Commands.UpdateGoal;
using Goals.Application.Goals.Commands.DeleteCommand;
using Goals.WebApi.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;

namespace Goals.WebApi.Controllers
{

    [ApiVersion("1.0")]
    [ApiVersion("2.0")]
    [Produces("application/json")]
    [Route("api/[controller]")]
    [Route("api/{version:apiVersion}/[controller]")]
    public class GoalController : BaseController
    {

        private readonly IMapper _mapper;

        public GoalController(IMapper mapper) => _mapper = mapper;

        /// <summary>
        /// Gets the list of goals
        /// </summary>
        /// <remarks>
        /// Sample request:
        /// GET /goal
        /// </remarks>
        /// <returns>Returns GoalListVm</returns>
        /// <response code="200">Success</response>
        /// <response code="401">If the user is unauthorized</response>
        [HttpGet]
        [Authorize]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<ActionResult<GoalListVm>> GetAll()
        {
            var query = new GetGoalListQuery
            {
                UserId = UserId
            };
            var vm = await Mediator.Send(query);
            return Ok(vm);
        }

        /// <summary>
        /// Gets the goal by id
        /// </summary>
        /// <remarks>
        /// Sample request:
        /// GET /goal/D34D349E-43B8-429E-BCA4-793C932FD580
        /// </remarks>
        /// <param name="id">Goal id (guid)</param>
        /// <returns>Returns GoalDetailsVm</returns>
        /// <response code="200">Success</response>
        /// <response code="401">If the user in unauthorized</response>
        [HttpGet("{id}")]
        [Authorize]
        public async Task<ActionResult<GoalDetailsVm>> Get(Guid id)
        {
            var query = new GetGoalDetailsQuery
            {
                UserId = UserId,
                Id = id
            };
            var vm = await Mediator.Send(query);
            return Ok(vm);
        }

        /// <summary>
        /// Creates the goal
        /// </summary>
        /// <remarks>
        /// Sample request:
        /// POST /goal
        /// {
        ///     title: "goal title",
        ///     details: "goal details"
        /// }
        /// </remarks>
        /// <param name="createGoalDto">CreateGoalDto object</param>
        /// <returns>Returns id (guid)</returns>
        /// <response code="201">Success</response>
        /// <response code="401">If the user is unauthorized</response>
        [HttpPost]
        [Authorize]
        public async Task<ActionResult<Guid>> Create([FromBody] CreateGoalDto createGoalDto)
        {
            var command = _mapper.Map<CreateGoalCommand>(createGoalDto);
            command.UserId = UserId;
            var goalId = await Mediator.Send(command);
            return Ok(goalId);
        }

        /// <summary>
        /// Updates the goal
        /// </summary>
        /// <remarks>
        /// Sample request:
        /// PUT /goal
        /// {
        ///     title: "updated goal title"
        /// }
        /// </remarks>
        /// <param name="updateGoalDto">UpdateGoalDto object</param>
        /// <returns>Returns NoContent</returns>
        /// <response code="204">Success</response>
        /// <response code="401">If the user is unauthorized</response>
        [HttpPut]
        [Authorize]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<ActionResult> Update([FromBody] UpdateGoalDto updateGoalDto)
        {
            var command = _mapper.Map<UpdateGoalCommand>(updateGoalDto);
            command.UserId = UserId;
            await Mediator.Send(command);
            return NoContent();
        }

        /// <summary>
        /// Deletes the goal by id
        /// </summary>
        /// <remarks>
        /// Sample request:
        /// DELETE /goal/88DEB432-062F-43DE-8DCD-8B6EF79073D3
        /// </remarks>
        /// <param name="id">Id of the goal (guid)</param>
        /// <returns>Returns NoContent</returns>
        /// <response code="204">Success</response>
        /// <response code="401">If the user is unauthorized</response>
        [HttpDelete("{id}")]
        [Authorize]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<IActionResult> Delete(Guid id)
        {
            var command = new DeleteGoalCommand
            {
                Id = id,
                UserId = UserId
            };
            await Mediator.Send(command);
            return NoContent();
        }
    }
}
