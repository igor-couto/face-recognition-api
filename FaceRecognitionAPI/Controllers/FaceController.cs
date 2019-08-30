using System;
using System.Drawing;
using Microsoft.AspNetCore.Mvc;

namespace FaceRecognitionAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FaceController : ControllerBase
    {
        /// <summary>
        /// Get person face by it name
        /// </summary>
        /// <param name="name">Person name</param>
        /// <returns></returns>
        [HttpGet]
        public ActionResult Get(string name)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Submit new face image from a person. If the person already exists, the system will be trained
        /// </summary>
        /// <param name="name">Person name</param>
        /// <param name="faceImage">Person face image</param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult Post(string name, Bitmap faceImage)
        {
            throw new NotImplementedException();
        }
    }
}