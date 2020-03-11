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
    public class SeriesController : ApiController
    {
        /// <summary>
        /// Get Serie Details By Series ID
        /// </summary>
        /// <remarks>
        /// The API returns the list of Series 
        /// </remarks>
        /// <param name="SeriesID">Series ID</param>
        /// <returns>List of Series</returns>
        [HttpGet]
        [Route("Series/{SeriesId}")]
        [SwaggerResponse(HttpStatusCode.OK, "Successful", typeof(SeriesModel))]
        [SwaggerResponse(HttpStatusCode.NotFound, "NotFound", typeof(NotFoundResult))]
        [SwaggerResponse(HttpStatusCode.BadRequest, "BadRequest", typeof(BadRequestResult))]
        [SwaggerOperation(Tags = new string[] { "Series" })]
        public IHttpActionResult GetSeriesBySeriesId(int SeriesID)
        {
            var Series = new SeriesModel();
            if (SeriesID <= 0) return Ok(Series);

            var SerieModel = new SeriesDataModel();
            SerieModel.seriesId = SeriesID;
            Series = SerieModel.GetSeriesBySeriesId();
            return Ok(Series);
        }

        /// <summary>
        /// Get Serie Details By Serie Id
        /// </summary>
        /// <returns>Serie Details</returns>
        [HttpGet]
        [Route("Series")]
        [SwaggerResponse(HttpStatusCode.OK, "Successful", typeof(SeriesModel))]
        [SwaggerResponse(HttpStatusCode.NotFound, "NotFound", typeof(NotFoundResult))]
        [SwaggerResponse(HttpStatusCode.BadRequest, "BadRequest", typeof(BadRequestResult))]
        [SwaggerOperation(Tags = new string[] { "Series" })]
        public IHttpActionResult GetAllSeries()
        {
            List<SeriesModel> Series = new List<SeriesModel>();
            var SerieModel = new SeriesDataModel();
            Series = SerieModel.GetAllSeries();
            return Ok(Series);
        }

        /// <summary>
        /// Add Serie
        /// </summary>
        /// <param name="Serie"></param>
        /// <returns>Last inserted Serie details</returns>
        [HttpPost]
        [Route("Series/AddSeries")]
        [SwaggerResponse(HttpStatusCode.OK, "Successful", typeof(SeriesModel))]
        [SwaggerResponse(HttpStatusCode.NotFound, "NotFound", typeof(NotFoundResult))]
        [SwaggerResponse(HttpStatusCode.BadRequest, "BadRequest", typeof(BadRequestResult))]
        [SwaggerOperation(Tags = new string[] { "Series" })]
        public IHttpActionResult AddSerie([FromBody] SeriesModel Serie)
        {
            SeriesModel Series = new SeriesModel();
            var SerieModel = new SeriesDataModel();
            Series = SerieModel.AddSeries(Serie);
            return Ok(Series);
        }

        /// <summary>
        /// Update Serie
        /// </summary>
        /// <param name="Serie"></param>
        /// <returns>Last inserted Serie details</returns>
        [HttpPut]
        [Route("Series/UpdateSeries")]
        [SwaggerResponse(HttpStatusCode.OK, "Successful", typeof(SeriesModel))]
        [SwaggerResponse(HttpStatusCode.NotFound, "NotFound", typeof(NotFoundResult))]
        [SwaggerResponse(HttpStatusCode.BadRequest, "BadRequest", typeof(BadRequestResult))]
        [SwaggerOperation(Tags = new string[] { "Series" })]
        public IHttpActionResult UpdateSeries([FromBody] SeriesModel Serie)
        {
            SeriesModel series = new SeriesModel();
            var SerieModel = new SeriesDataModel();
            series = SerieModel.UpdateSeries(Serie);
            return Ok(series);
        }

        /// <summary>
        /// Get Serie Teams By Series ID
        /// </summary>
        /// <remarks>
        /// The API returns the list of teams participating in the series 
        /// </remarks>
        /// <param name="SeriesID">Series ID</param>
        /// <returns>List of Teams in the Series</returns>
        [HttpGet]
        [Route("Series/{SeriesId}/Teams")]
        [SwaggerResponse(HttpStatusCode.OK, "Successful", typeof(SeriesModel))]
        [SwaggerResponse(HttpStatusCode.NotFound, "NotFound", typeof(NotFoundResult))]
        [SwaggerResponse(HttpStatusCode.BadRequest, "BadRequest", typeof(BadRequestResult))]
        [SwaggerOperation(Tags = new string[] { "Series" })]
        public IHttpActionResult GetSeriesTeamsBySeriesID(int SeriesID)
        {
            List<SeriesTeamsModel> Series = new List<SeriesTeamsModel>();
            var SerieModel = new SeriesDataModel();
            SerieModel.seriesId = SeriesID;
            Series = SerieModel.GetSeriesTeamBySeriesId();
            return Ok(Series);
        }

        /// <summary>
        /// Get Serie Team Players By Series ID
        /// </summary>
        /// <remarks>
        /// The API returns the list of team players participating in the series 
        /// </remarks>
        /// <param name="SeriesID">Series ID</param>
        /// <returns>List of Team Players in the Series</returns>
        [HttpGet]
        [Route("Series/{SeriesId}/Players")]
        [SwaggerResponse(HttpStatusCode.OK, "Successful", typeof(SeriesModel))]
        [SwaggerResponse(HttpStatusCode.NotFound, "NotFound", typeof(NotFoundResult))]
        [SwaggerResponse(HttpStatusCode.BadRequest, "BadRequest", typeof(BadRequestResult))]
        [SwaggerOperation(Tags = new string[] { "Series" })]
        public IHttpActionResult GetSeriesTeamsPlayersBySeriesID(int SeriesID)
        {
            List<SeriesTeamPlayersModel> seriesTeamPlayersModels = new List<SeriesTeamPlayersModel>();
            var SerieModel = new SeriesDataModel();
            SerieModel.seriesId = SeriesID;
            seriesTeamPlayersModels = SerieModel.GetSeriesTeamPlayersBySeriesId();
            return Ok(seriesTeamPlayersModels);
        }
    }
}
