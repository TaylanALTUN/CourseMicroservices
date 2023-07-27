﻿using FreeCourse.Shared.ControllerBases;
using FreeCourse.Shared.Dtos;
using FreeeCourse.Services.PhotoStock.Dtos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FreeeCourse.Services.PhotoStock.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class PhotosController : CustomBaseController
    {
        public async Task<IActionResult> PhotoSave(IFormFile photo, CancellationToken cancellationToken)
        {
            if (photo != null && photo.Length > 0)
            {
                var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/photos", photo.FileName);

                using var stream = new FileStream(path, FileMode.Create);

                await photo.CopyToAsync(stream, cancellationToken);

                var returnPath = $"photos/{photo.FileName}";

                PhotoDto photoDto= new PhotoDto();
                photoDto.Url = returnPath;

                return CreateActionResultInstance(Response<PhotoDto>.Success(photoDto,StatusCodes.Status200OK));

            }

            return CreateActionResultInstance(Response<PhotoDto>.Fail("Photo is emty",StatusCodes.Status404NotFound));
        }

        public IActionResult PhotoDelete(string photoUrl, CancellationToken cancellationToken)
        {
            var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/photos", photoUrl);

            if (System.IO.File.Exists(path)) return CreateActionResultInstance(Response<NoContent>.Fail("photo not found", StatusCodes.Status404NotFound));

            System.IO.File.Delete(path);

            return CreateActionResultInstance(Response<NoContent>.Success(StatusCodes.Status204NoContent));
        }
    }
}
