using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using BertoniMiniproyecto.Models;
using BertoniMiniproyecto.Data;
using Newtonsoft.Json;

namespace BertoniMiniproyecto.Data
{
    public static class PicturesProvider
    {
        private const string APIAddress = "https://jsonplaceholder.typicode.com";

        public static async Task<IEnumerable<Album>> GetAlbumsAsync()
        {
            return await HttpDataProvider.GetAsync<Album>($"{APIAddress}/albums");
        }

        public static async Task<IEnumerable<Comment>> GetCommentsAsync()
        {
            return await HttpDataProvider.GetAsync<Comment>($"{APIAddress}/comments");
        }

        public static async Task<IEnumerable<Photo>> GetPhotosAsync()
        {
            return await HttpDataProvider.GetAsync<Photo>($"{APIAddress}/photos");
        }
    }
}
