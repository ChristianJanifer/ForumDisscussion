﻿using API_Forum.Models;
using Client.Base.Urls;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace Client.Repositories.Data
{
    public class CommentRepository : GeneralRepository<Comment, int>
    {
        private readonly Address address;
        private readonly string request;
        private readonly HttpClient httpClient;

        public CommentRepository(Address address, string request = "Comments/") : base(address, request)
        {
            this.address = address;
            this.request = request;
            httpClient = new HttpClient
            {
                BaseAddress = new Uri(address.link)
            };
        }

        public async Task<List<Comment>> GetComments()
        {
            List<Comment> entities = new List<Comment>();

            using (var response = await httpClient.GetAsync(request + "GetAll/"))
            {
                string apiResponse = await response.Content.ReadAsStringAsync();
                entities = JsonConvert.DeserializeObject<List<Comment>>(apiResponse);
            }
            return entities;
        }
    }
}