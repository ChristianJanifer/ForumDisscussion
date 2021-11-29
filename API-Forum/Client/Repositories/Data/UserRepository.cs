using API_Forum.Models;
using API_Forum.ViewModel;
using Client.Base.Urls;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Client.Repositories.Data
{
    public class UserRepository : GeneralRepository<User, int>
    {
        private readonly Address address;
        private readonly string request;
        private readonly HttpClient httpClient;

        public UserRepository(Address address, string request = "Users/") : base(address, request)
        {
            this.address = address;
            this.request = request;
            httpClient = new HttpClient
            {
                BaseAddress = new Uri(address.link)
            };
        }

        public async Task<List<ProfileVM>> GetProfile()
        {
            List<ProfileVM> entities = new List<ProfileVM>();

            using (var response = await httpClient.GetAsync(request + "Profile/"))
            {
                string apiResponse = await response.Content.ReadAsStringAsync();
                entities = JsonConvert.DeserializeObject<List<ProfileVM>>(apiResponse);
            }
            return entities;
        }

        public async Task<ProfileVM> Profile(int id)
        {
            ProfileVM entity = null;

            using (var response = await httpClient.GetAsync(request + "Profile/" + id))
            {
                string apiResponse = await response.Content.ReadAsStringAsync();
                entity = JsonConvert.DeserializeObject<ProfileVM>(apiResponse);
            }
            return entity;
        }


        public async Task<List<ProfileVM>> GetAllMember()
        {
            List<ProfileVM> entities = new List<ProfileVM>();

            using (var response = await httpClient.GetAsync(request + "GetAllMember/"))
            {
                string apiResponse = await response.Content.ReadAsStringAsync();
                entities = JsonConvert.DeserializeObject<List<ProfileVM>>(apiResponse);
            }
            return entities;
        }

        public HttpStatusCode DeleteUser(int id)
        {
            var result = httpClient.DeleteAsync(address.link + request + "Delete/" + id).Result;
            return result.StatusCode;
        }

        public async Task<List<DiscussionVM>> GetLanding()
        {
            List<DiscussionVM> entities = new List<DiscussionVM>();

            using (var response = await httpClient.GetAsync(request + "GetDiscussion/"))
            {
                string apiResponse = await response.Content.ReadAsStringAsync();
                entities = JsonConvert.DeserializeObject<List<DiscussionVM>>(apiResponse);
            }
            return entities;
        }

        public async Task<List<DiscussionVM>> GetDiscussionbyId(int id)
        {
            List<DiscussionVM> entities = new List<DiscussionVM>();

            using (var response = await httpClient.GetAsync(request + "GetDiscussionId/" + id))
            {
                string apiResponse = await response.Content.ReadAsStringAsync();
                entities = JsonConvert.DeserializeObject<List<DiscussionVM>>(apiResponse);
            }
            return entities;
        }

        public async Task<List<CommentVM>> GetReplybyId(int id)
        {
            List<CommentVM> entities = new List<CommentVM>();

            using (var response = await httpClient.GetAsync(request + "GetComment/" + id))
            {
                string apiResponse = await response.Content.ReadAsStringAsync();
                entities = JsonConvert.DeserializeObject<List<CommentVM>>(apiResponse);
            }
            return entities;
        }

        public async Task<List<DiscussionVM>> GetDiscussionByCat(int id)
        {
            List<DiscussionVM> entities = new List<DiscussionVM>();

            using (var response = await httpClient.GetAsync(request + "GetDiscussionByCat/" + id))
            {
                string apiResponse = await response.Content.ReadAsStringAsync();
                entities = JsonConvert.DeserializeObject<List<DiscussionVM>>(apiResponse);
            }
            return entities;
        }

        public async Task<List<DiscussionVM>> GetDiscussionByUser(int id)
        {
            List<DiscussionVM> entities = new List<DiscussionVM>();

            using (var response = await httpClient.GetAsync(request + "GetDiscussionByUser/" + id))
            {
                string apiResponse = await response.Content.ReadAsStringAsync();
                entities = JsonConvert.DeserializeObject<List<DiscussionVM>>(apiResponse);
            }
            return entities;
        }
    }
}