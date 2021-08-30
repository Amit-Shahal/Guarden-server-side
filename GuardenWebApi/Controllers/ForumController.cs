using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using GuardenWebApi.DTO.Forum;
using GuardenClassLibrary.EF;


namespace GuardenWebApi.Controllers
{
    public class ForumController : ApiController
    {
        // GET api/<controller>
        public IHttpActionResult Get()
        {
            try
            {
                GuardenDB dB = new GuardenDB();

                List<QuestionDTO> questions = dB.tblQuestions.Select(q => new QuestionDTO() { 
                Question_ID= q.Question_ID,
                Question_Content = q.Question_Content,
                Question_Photo = q.Question_Photo,
                Question_Votes = q.Question_Votes,
                Time = q.Time,
                User_ID = q.User_ID,
                Name = dB.tblUsers.Where(u => u.ID == q.User_ID).Select(user => user.Name).FirstOrDefault(),
                ProfileImg = dB.tblUsers.Where(u => u.ID == q.User_ID).Select(user => user.ProfileImg).FirstOrDefault(),
                answers = dB.tblAnswers.Where(a=> a.Question_ID == q.Question_ID).Select(ans => new AnswerDTO()
                {
                    Answer_ID = ans.Answer_ID,
                    Answer_Content = ans.Answer_Content,
                    Answer_Photo =ans.Answer_Photo,
                    Answer_Votes = ans.Answer_Votes,
                    Time = ans.Time,
                    User_ID = ans.User_ID,
                    Name = dB.tblUsers.Where(u => u.ID == ans.User_ID).Select(user => user.Name).FirstOrDefault(),
                    ProfileImg = dB.tblUsers.Where(u => u.ID == ans.User_ID).Select(user => user.ProfileImg).FirstOrDefault(),
                    Responses = dB.tblResponses.Where(res => res.Answer_ID == ans.Answer_ID).Select(r=> new ResponseDTO()
                    {
                        Response_ID = r.Response_ID,
                        Response_Content = r.Response_Content,
                        Time = r.Time,
                        User_ID = r.User_ID,
                        Name = dB.tblUsers.Where(u => u.ID == r.User_ID).Select(user => user.Name).FirstOrDefault(),
                        ProfileImg = dB.tblUsers.Where(u => u.ID == r.User_ID).Select(user => user.ProfileImg).FirstOrDefault(),
                    }).ToList()
                }).ToList()
                
                }).ToList();
                questions.OrderBy(q => q.Time);
                foreach (QuestionDTO item in questions)
                {
                    item.answers.OrderBy(i => i.Time);
                    foreach (AnswerDTO ans in item.answers)
                    {
                        ans.Responses.OrderBy(r => r.Time);
                    }
                }
                return Ok(questions);
            }
            catch (Exception ex)
            {
                return Content(HttpStatusCode.BadRequest, ex);
            }
        }

        
    }
}