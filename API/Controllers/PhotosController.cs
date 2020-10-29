using API.Models;
using API.Services;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PhotosController : ControllerBase
    {
        private readonly PhotoService _photoService;

        public PhotosController(PhotoService photoService) => _photoService = photoService;

        [HttpGet]
        public ActionResult<List<Photo>> Get() =>
            _photoService.Get();

        [HttpGet("{label}", Name = "FilterPhotos")]
        public ActionResult<List<Photo>> Get(string label)
        {
            var Photo = _photoService.GetByLabel(label);

            if (Photo is null)
                return NotFound();

            return Photo;
        }

        [HttpPost]
        public ActionResult<Photo> Create(Photo Photo)
        {
            _photoService.Create(Photo);

            return CreatedAtRoute("GetPhoto", new { id = Photo.Id.ToString() }, Photo);
        }

        [HttpPut("{id:length(24)}")]
        public IActionResult Update(string id, Photo PhotoIn)
        {
            var Photo = _photoService.Get(id);

            if (Photo is null)
                return NotFound();


            _photoService.Update(id, PhotoIn);

            return NoContent();
        }

        [HttpDelete("{id:length(24)}")]
        public IActionResult Delete(string id)
        {
            var Photo = _photoService.Get(id);

            if (Photo is null)            
                return NotFound();            

            _photoService.Remove(Photo.Id);

            return NoContent();
        }
    }
}
