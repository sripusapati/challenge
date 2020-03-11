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
    public class MemberController : ApiController
    {
        /// <summary>
        /// Add Member
        /// </summary>
        /// <param name="member"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("Members/AddMember")]
        [SwaggerResponse(HttpStatusCode.OK, "Successful", typeof(MemberModel))]
        [SwaggerResponse(HttpStatusCode.NotFound, "NotFound", typeof(NotFoundResult))]
        [SwaggerResponse(HttpStatusCode.BadRequest, "BadRequest", typeof(BadRequestResult))]
        [SwaggerOperation(Tags = new string[] { "Members" })]
        public IHttpActionResult AddMember([FromBody] MemberModel member)
        {
            MemberModel memberDetail = new MemberModel();
            var memberModel = new MemberDataModel();
            memberDetail = memberModel.AddMember(member);
            return Ok(memberDetail);
        }
    }
}
