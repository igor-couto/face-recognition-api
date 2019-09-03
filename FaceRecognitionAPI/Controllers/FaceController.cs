using System;
using System.Drawing;
using FaceRecognitionApplication.Domain.Model.Classifiers;
using FaceRecognitionApplication.Domain.Model.Recognizers;
using Microsoft.AspNetCore.Mvc;

namespace FaceRecognitionAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FaceController : ControllerBase
    {
        private readonly IClassifier _classifier;
        private readonly IRecognizer _recognizer;

        public FaceController(IClassifier classifier, IRecognizer recognizer)
        {
            _classifier = classifier;
            _recognizer = recognizer;
        }

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