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

        public HttpStatusCode DeleteUser(int id)
        {
            var result = httpClient.DeleteAsync(address.link + request + "Delete/"+ id).Result;
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

        /*public HttpStatusCode PostCategory(CategoryVM entity)
        {
            StringContent content = new StringContent(JsonConvert.SerializeObject(entity), Encoding.UTF8, "application/json");
            var result = httpClient.PostAsync(address.link + request + "PostCategory/", content).Result;
            return result.StatusCode;
        }

        public async Task<List<CategoryVM>> GetCategoryAll()
        {
            List<CategoryVM> entities = new List<CategoryVM>();

            using (var response = await httpClient.GetAsync(request + "GetCategoryAll/"))
            {
                string apiResponse = await response.Content.ReadAsStringAsync();
                entities = JsonConvert.DeserializeObject<List<CategoryVM>>(apiResponse);
            }
            return entities;
        }

        public async Task<List<CategoryVM>> GetCategorybyId(int id)
        {
            List<CategoryVM> entities = new List<CategoryVM>();

            using (var response = await httpClient.GetAsync(request + "GetCategory/" + id))
            {
                string apiResponse = await response.Content.ReadAsStringAsync();
                entities = JsonConvert.DeserializeObject<List<CategoryVM>>(apiResponse);
            }
            return entities;
        }*/
    }
}
