using API_Forum.Models;
using API_Forum.ViewModel;
using Client.Base.Urls;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
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

        public async Task<List<LandingVM>> GetLanding()
        {
            List<LandingVM> entities = new List<LandingVM>();

            using (var response = await httpClient.GetAsync(request + "Landing/"))
            {
                string apiResponse = await response.Content.ReadAsStringAsync();
                entities = JsonConvert.DeserializeObject<List<LandingVM>>(apiResponse);
            }
            return entities;
        }

        public async Task<List<ReplyVM>> GetReply()
        {
            List<ReplyVM> entities = new List<ReplyVM>();

            using (var response = await httpClient.GetAsync(request + "Reply/"))
            {
                string apiResponse = await response.Content.ReadAsStringAsync();
                entities = JsonConvert.DeserializeObject<List<ReplyVM>>(apiResponse);
            }
            return entities;
        }

        public async Task<List<ReplyVM>> GetReplybyId(int id)
        {
            List<ReplyVM> entities = new List<ReplyVM>();

            using (var response = await httpClient.GetAsync(request + "Reply/" + id))
            {
                string apiResponse = await response.Content.ReadAsStringAsync();
                entities = JsonConvert.DeserializeObject<List<ReplyVM>>(apiResponse);
            }
            return entities;
        }
        /*public async Task<ProfileVM> Profile(string id)
        {
            ProfileVM entity = null;

            using (var response = await httpClient.GetAsync(request + "Profile/" + id))
            {
                string apiResponse = await response.Content.ReadAsStringAsync();
                entity = JsonConvert.DeserializeObject<ProfileVM>(apiResponse);
            }
            return entity;
        }*/

        /*public HttpStatusCode Register(RegisterVM entity)
        {
            StringContent content = new StringContent(JsonConvert.SerializeObject(entity), Encoding.UTF8, "application/json");
            var result = httpClient.PostAsync(address.link + request + "Register/", content).Result;
            return result.StatusCode;
        }*/

        /*public async Task<JWTokenVM> Login(LoginVM loginVM)
        {
            JWTokenVM token = null;

            StringContent content = new StringContent(JsonConvert.SerializeObject(loginVM), Encoding.UTF8, "application/json");
            var result = await httpClient.PostAsync(request + "Login/", content);

            string apiResponse = await result.Content.ReadAsStringAsync();
            token = JsonConvert.DeserializeObject<JWTokenVM>(apiResponse);

            return token;
        }*/

    }
}
