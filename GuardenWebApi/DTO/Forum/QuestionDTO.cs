using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GuardenWebApi.DTO.Forum
{
    public class QuestionDTO
    {
        public int Question_ID { get; set; }
        public string Question_Content { get; set; }
        public Nullable<int> Question_Votes { get; set; }
        public string Question_Photo { get; set; }

        public Nullable<System.DateTime> Time { get; set; }

        public Nullable<int> User_ID { get; set; }

        public string Name { get; set; }

        public string ProfileImg { get; set; }

        public List<AnswerDTO> answers { get; set; }




    }
}