using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GuardenWebApi.DTO.Forum
{
    public class AnswerDTO
    {
        public int Answer_ID { get; set; }
        public string Answer_Content { get; set; }
        public Nullable<int> Answer_Votes { get; set; }
        public string Answer_Photo { get; set; }

        public Nullable<System.DateTime> Time { get; set; }

        public Nullable<int> User_ID { get; set; }

        public string Name { get; set; }

        public string ProfileImg { get; set; }
        public List<ResponseDTO> Responses { get; set; }

    }
}