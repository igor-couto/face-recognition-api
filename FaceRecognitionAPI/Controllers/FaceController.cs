using System;
using System.Drawing;
using Microsoft.AspNetCore.Mvc;

namespace FaceRecognitionAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FaceController : ControllerBase
    {
        [HttpGet("{id}")]
        public ActionResult<Bitmap> Get(int id)
        {
            //Bitmap face = getFaceById(id);
            //var byteArray = face.ConvertToByteArray();
            //return File(byteArray, "image/jpeg");

            throw new NotImplementedException();
        }
    }
}