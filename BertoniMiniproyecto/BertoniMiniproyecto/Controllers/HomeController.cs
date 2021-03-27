using BertoniMiniproyecto.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using BertoniMiniproyecto.Data;

namespace BertoniMiniproyecto.Controllers
{
    public class HomeController : Controller
    {
        public async Task<IActionResult> Index()
        {
            return View(await PicturesProvider.GetAlbumsAsync());
        }

        public async Task<IActionResult> Photos(int id)
        {
            var result = (await PicturesProvider.GetPhotosAsync())
                .Where(pic => pic.AlbumId == id);

            if (result.Count() == 0)
                return NotFound();

            return View(result);
        }

        public async Task<IActionResult> Comments(int id)
        {
            return Json((await PicturesProvider.GetCommentsAsync())
                .Where(c => c.PostId == id));
        }
    }
}
