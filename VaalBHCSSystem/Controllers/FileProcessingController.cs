using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using VaalBeachClub.Common;
using VaalBeachClub.Models.Domain.Files;
using VaalBeachClub.Models.Domain.Members;
using VaalBeachClub.Models.ViewModels.Files;
using VaalBeachClub.Services.Authentication;

namespace VaalBreachClub.Web.Controllers
{
    public class FileProcessingController : Controller
    {
        #region Fields
        private readonly IUserService _userService;

        #endregion

        #region Cstor
        public FileProcessingController(IUserService userService)
        {
            _userService = userService;
        }
        #endregion
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult UploadUserProfileImage([FromBody] UserProfileImageUploadRequest request)
        {
            bool Success = false;
            string sMessage = "";
            BeachClubFile BeachClubFileToAddOrUpdate = null;
            try
            {
                byte[] NewImage = Convert.FromBase64String(request.ImageData);
                BeachClubFileToAddOrUpdate = new BeachClubFile()
                {
                    Id = request.Id,
                    ContentType = request.FileType,
                    DateCreated = DateTime.Now,
                    FileSize = NewImage.Length,
                    FileExtension = Path.GetExtension(request.FileName).Replace(".", ""),
                    FileName = Path.GetFileNameWithoutExtension(request.FileName),
                    FileBlob = new FileBlob()
                    {
                        BlobData = NewImage
                    },
                    MemberProfileImage = new MemberProfileImage()
                    {
                        BeachClubMemberID = _userService.GetUserID(),
                        DateLastUpdated = DateTime.Now
                    }
                };

                _userService.AddUserProfilePicture(BeachClubFileToAddOrUpdate);

                Success = true;
                sMessage = "Added/Updated Profile Image Succesfully";
            }
            catch (VaalBeachClubException e)
            {
                Success = false;
                sMessage = "Failed To Add/Update Profile Image Succesfully - Error: " + e.Message;
            }


            return new JsonResult(new retrunObject()
            {
                Message = sMessage,
                Success = Success,
                RtnID = BeachClubFileToAddOrUpdate.Id
            });
        }
    }

    public class retrunObject
    {
        public bool Success { get; set; }
        public string Message { get; set; }
        public int RtnID { get; set; }
    }
}