using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API_Forum.ViewModel
{
    public class DiscussionVM
    {
        public string Title { get; set; }

        public string Content { get; set; }

        public DateTime DateDis { get; set; }

        [JsonConverter(typeof(StringEnumConverter))]
        public GenericUriParserOptions StatusComt { get; set; }
        public int UserId { get; set; }
        public int CategoryId { get; set; }
        public int TypeId { get; set; }
        public int CommentId { get; set; }
    }
}
