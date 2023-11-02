using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using PulseNex.ActionFilters;
using PulseNex.Helpers;
using PulseNex.Model;
using System.Linq;
using System.Net;

namespace PulseNex.Controller
{
    [FullAuthorization]
    public class FileController : BaseController
    {
        public FileController()
        {

        }

        [HttpPost]
        [Route("File/PostFile")]
        public async Task<ActionResult> PostFile([FromForm] IFormFile objFile)
        {
            try
            {
                if (objFile.FileName == null || objFile.FileName.Length == 0)
                {
                    return Ok(new APIResponse(APIResponse.ResponseCode.ERROR, "File not found", null));
                }
                var NewFileName = Guid.NewGuid().ToString() + objFile.FileName;
                var path = CommonHelper.GetFileFolderLocation() + NewFileName;

                bool exists = System.IO.Directory.Exists(CommonHelper.GetFileFolderLocation());

                if (!exists)
                    System.IO.Directory.CreateDirectory(CommonHelper.GetFileFolderLocation());

                using (FileStream stream = new FileStream(path, FileMode.Create))
                {
                    await objFile.CopyToAsync(stream);
                    stream.Close();
                }

                return Ok(new APIResponse(APIResponse.ResponseCode.SUCCESS, "File Uploaded", NewFileName));
            }
            catch (Exception ex)
            {
                return Ok(new APIResponse(APIResponse.ResponseCode.ERROR, ex.Message, null));
            }
        }
    }
}
