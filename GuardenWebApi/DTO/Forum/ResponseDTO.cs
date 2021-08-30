using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GuardenWebApi.DTO.Forum
{
    public class ResponseDTO
    {
        public int Response_ID { get; set; }
        public string Response_Content { get; set; }

        public Nullable<System.DateTime> Time { get; set; }

        public Nullable<int> User_ID { get; set; }

        public string Name { get; set; }

        public string ProfileImg { get; set; }
    }
}