using DataLib;
using ModelLib;
using Swashbuckle.Swagger.Annotations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Results;

namespace Challenge.Controllers
{
    public class MatchController : ApiController
    {
        /// <summary>
        /// Add Match
        /// </summary>
        /// <param name="match"></param>
        /// <returns>Last inserted match details</returns>
        [HttpPost]
        [Route("Match/AddMatch")]
        [SwaggerResponse(HttpStatusCode.OK, "Successful", typeof(PlayersModel))]
        [SwaggerResponse(HttpStatusCode.NotFound, "NotFound", typeof(NotFoundResult))]
        [SwaggerResponse(HttpStatusCode.BadRequest, "BadRequest", typeof(BadRequestResult))]
        [SwaggerOperation(Tags = new string[] { "Match" })]
        public IHttpActionResult AddPlayer([FromBody] MatchModel match)
        {
            MatchModel matchModel = new MatchModel();
            var matchDataModel = new MatchDataModel();
            matchModel = matchDataModel.AddMatch(match);
            return Ok(matchModel);
        }

        /// <summary>
        /// Update Match
        /// </summary>
        /// <param name="match"></param>
        /// <returns>Last inserted match details</returns>
        [HttpPut]
        [Route("Match/UpdateMatch")]
        [SwaggerResponse(HttpStatusCode.OK, "Successful", typeof(PlayersModel))]
        [SwaggerResponse(HttpStatusCode.NotFound, "NotFound", typeof(NotFoundResult))]
        [SwaggerResponse(HttpStatusCode.BadRequest, "BadRequest", typeof(BadRequestResult))]
        [SwaggerOperation(Tags = new string[] { "Match" })]
        public IHttpActionResult UpdatePlayer([FromBody] MatchModel match)
        {
            MatchModel matchModel = new MatchModel();
            var matchDataModel = new MatchDataModel();
            matchModel = matchDataModel.UpdateMatch(match);
            return Ok(matchModel);
        }
    }
}
