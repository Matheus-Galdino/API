using API.Models;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Driver;
using System.Collections.Generic;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PhotosController : ControllerBase
    {
        MongoClient dbClient = new MongoClient("mongodb+srv://dbAdmin:dbAdminMaster@my-unsplash.f00v4.mongodb.net/photos?retryWrites=true&w=majority");

        [HttpGet]
        public IEnumerable<string> Get()
        {
            var dbList = dbClient.ListDatabaseNames().ToList();

            return dbList;
        }
    }
}
