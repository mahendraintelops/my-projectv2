using MediatR;
using Microsoft.AspNetCore.Mvc;
using Application.Commands.MyResourceService;
using Application.Queries.MyResourceService;
using Application.Responses;
using System.Net;


namespace Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MyResourceServiceController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly ILogger<MyResourceServiceController> _logger;
        public MyResourceServiceController(IMediator mediator, ILogger<MyResourceServiceController> logger)
        {
            _mediator = mediator;
            _logger = logger;
        }

        
        [HttpPost(Name = "CreateMyResource")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        public async Task<ActionResult<int>> CreateMyResource([FromBody] CreateMyResourceCommand command)
        {
            var result = await _mediator.Send(command);
            return Ok(result);
        }
        

        
        [HttpGet(Name = "GetAllMyResources")]
        [ProducesResponseType(typeof(IEnumerable<List<MyResourceResponse>>), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<List<MyResourceResponse>>> GetAllMyResources(CancellationToken cancellationToken)
        {
            var response = await _mediator.Send(new GetAllMyResourcesQuery(), cancellationToken);
            return Ok(response);
        }
        

        
        [HttpGet("{id}", Name = "GetMyResourceById")]
        [ProducesResponseType(typeof(MyResourceResponse), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        public async Task<ActionResult<MyResourceResponse>> GetMyResourceById(int id, CancellationToken cancellationToken)
        {
            _logger.LogInformation("MyResource GET request received for ID {id}", id);
            var response = await _mediator.Send(new GetMyResourceByIdQuery(id), cancellationToken);
            return Ok(response);
        }
        

        
        [HttpPut(Name = "UpdateMyResource")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult> UpdateMyResource([FromBody] UpdateMyResourceCommand command)
        {
            await _mediator.Send(command);
            return NoContent();
        }
        

        
        [HttpDelete("{id}", Name = "DeleteMyResource")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult> DeleteMyResource(int id)
        {
            _logger.LogInformation("MyResource DELETE request received for ID {id}", id);
            var cmd = new DeleteMyResourceCommand() { Id = id };
            await _mediator.Send(cmd);
            return NoContent();
        }
        
    }
}
