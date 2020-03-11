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
    public class PlayersController : ApiController
    {
        /// <summary>
        /// Get Player Details By Nation ID
        /// </summary>
        /// <remarks>
        /// The API returns the list of players 
        /// </remarks>
        /// <param name="NationID">Nation ID</param>
        /// <returns>List of Players</returns>
        [HttpGet]
        [Route("Players/{NationId}")]
        [SwaggerResponse(HttpStatusCode.OK, "Successful", typeof(PlayersModel))]
        [SwaggerResponse(HttpStatusCode.NotFound, "NotFound", typeof(NotFoundResult))]
        [SwaggerResponse(HttpStatusCode.BadRequest, "BadRequest", typeof(BadRequestResult))]
        [SwaggerOperation(Tags = new string[] { "Players" })]
        public IHttpActionResult GetPlayersByNationId(int NationID)
        {
            var players = new List<PlayersModel>();
            if (NationID <= 0) return Ok(players); 
            
            var playerModel = new PlayersDataModel();
            playerModel.nationId = NationID;
            players = playerModel.GetPlayerByNationId();
            return Ok(players);
        }

        /// <summary>
        /// Get Player Details By Player Id
        /// </summary>
        /// <param name="PlayerId"></param>
        /// <returns>Player Details</returns>
        [HttpGet]
        [Route("Player/{PlayerId}")]
        [SwaggerResponse(HttpStatusCode.OK, "Successful", typeof(PlayersModel))]
        [SwaggerResponse(HttpStatusCode.NotFound, "NotFound", typeof(NotFoundResult))]
        [SwaggerResponse(HttpStatusCode.BadRequest, "BadRequest", typeof(BadRequestResult))]
        [SwaggerOperation(Tags = new string[] { "Players" })]
        public IHttpActionResult GetPlayerDetails(int PlayerId)
        {
            PlayersModel players = new PlayersModel();
            var playerModel = new PlayersDataModel();
            players = playerModel.GetPlayerById(PlayerId);
            return Ok(players);
        }

        /// <summary>
        /// Add Player
        /// </summary>
        /// <param name="player"></param>
        /// <returns>Last inserted player details</returns>
        [HttpPost]
        [Route("Players/AddPlayer")]
        [SwaggerResponse(HttpStatusCode.OK, "Successful", typeof(PlayersModel))]
        [SwaggerResponse(HttpStatusCode.NotFound, "NotFound", typeof(NotFoundResult))]
        [SwaggerResponse(HttpStatusCode.BadRequest, "BadRequest", typeof(BadRequestResult))]
        [SwaggerOperation(Tags = new string[] { "Players" })]
        public IHttpActionResult AddPlayer([FromBody] PlayersModel player)
        {
            PlayersModel players = new PlayersModel();
            var playerModel = new PlayersDataModel();
            players = playerModel.AddPlayer(player);
            return Ok(players);
        }

        /// <summary>
        /// Update Player
        /// </summary>
        /// <param name="player"></param>
        /// <returns>Last inserted player details</returns>
        [HttpPut]
        [Route("Players/UpdatePlayer")]
        [SwaggerResponse(HttpStatusCode.OK, "Successful", typeof(PlayersModel))]
        [SwaggerResponse(HttpStatusCode.NotFound, "NotFound", typeof(NotFoundResult))]
        [SwaggerResponse(HttpStatusCode.BadRequest, "BadRequest", typeof(BadRequestResult))]
        [SwaggerOperation(Tags = new string[] { "Players" })]
        public IHttpActionResult UpdatePlayer([FromBody] PlayersModel player)
        {
            PlayersModel players = new PlayersModel();
            var playerModel = new PlayersDataModel();
            players = playerModel.UpdatePlayer(player);
            return Ok(players);
        }        
    }
}
