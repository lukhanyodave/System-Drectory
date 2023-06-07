using DirFileLocation.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.IO;

namespace DirFileLocation.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class DirectoryListingController : ControllerBase
    {
        private readonly IDirFileService dirFileService;
        public DirectoryListingController(IDirFileService _dirFileService) 
        {
            dirFileService = _dirFileService;
        }

        //search a given path  & display the contents of the searched directory.
        // Users should also be able to sort the current directory contents ===> Ui sort 
        [HttpGet("{path}")]
        public  IActionResult SearchPath(string path)
        {
            try
            {
               var res=  dirFileService.GetDirFile(path);
               return Ok(res);
            }
            catch (DirectoryNotFoundException)
            {
               return NotFound();
            }
            catch (UnauthorizedAccessException)
            {
               return Forbid();
            }
        }
      
    }
}
