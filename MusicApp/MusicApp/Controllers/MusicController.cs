using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;

namespace MusicApp.Controllers
{
    public class MusicController : ApiController
    {
        /// <summary>
        /// Function to get default playlist songs
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public HttpResponseMessage GetDefaultPlaylistSong()
        {
            HttpResponseMessage message;
            try
            {
                // By default gets all the songs from db.
                message = Request.CreateResponse(HttpStatusCode.OK, Music.GetAll());
            }
            catch
            {
                message = Request.CreateResponse("Error While retrieving songs");
            }
            return message;
        }
        //-------------------------------------------------------------------------------------
        /// <summary>
        /// Function to delete songs from db based on value
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("api/music/Remove")]
        public HttpResponseMessage Remove([FromBody]string value)
        {
            HttpResponseMessage message;
            try
            {
                // By default gets all the songs from db.
                Music.DeleteById(value);
                message = Request.CreateResponse(HttpStatusCode.OK, Music.GetAll());
            }
            catch
            {
                message = Request.CreateResponse("Error while removing");
            }
            return message;
        }
        //-------------------------------------------------------------------------------------
        /// <summary>
        /// Function to delete songs from db based on value
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("api/music/Add")]
        public HttpResponseMessage Add([FromBody]string value)
        {
            HttpResponseMessage message;
            try
            {
                // Check whether the song to be deleted is default song or not. if its default songs, then it is not deleted.
                Music.AddBySongName(value);
                message = Request.CreateResponse(HttpStatusCode.OK, Music.GetAll());
            }
            catch
            {
                message = Request.CreateResponse("Error while adding song to db");
            }
            return message;
        }
    }
}