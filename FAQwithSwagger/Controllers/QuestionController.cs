using Nettbutikk_FAQ.Models;
using Swashbuckle.Swagger.Annotations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Web.Http;
using System.Web.Script.Serialization;

namespace Nettbutikk_FAQ.Controllers
{
    public class QuestionController : ApiController
    {
        FaqDb _faqDb;

        public QuestionController()
        {
            _faqDb = new FaqDb();
        }

        // GET api/Question
        /// <summary>
        /// Get all questions
        /// </summary>
        /// <remarks>Get a array of all questions</remarks>
        /// <returns></returns>
        [SwaggerResponse(HttpStatusCode.OK, Type = typeof(List<Question>))]
        [SwaggerResponse(HttpStatusCode.NotFound)]
        public HttpResponseMessage Get()
        {
            List<Question> liste = _faqDb.hentAlleSporsmal();

            if (liste != null)
            {
                var Json = new JavaScriptSerializer();
                string jsonString = Json.Serialize(liste);

                return new HttpResponseMessage()
                {
                    Content = new StringContent(jsonString, Encoding.UTF8, "application/json"),
                    StatusCode = HttpStatusCode.OK
                };
            }
            return new HttpResponseMessage()
            {
                Content = new StringContent("Fant ikke spørsmål i Db"),
                StatusCode = HttpStatusCode.NotFound
            };
        }

        // GET api/Question/3
        /// <summary>
        /// Get question
        /// </summary>
        /// <param name="id">Unique id</param>
        /// <remarks>Get single question by providing id</remarks>
        /// <returns></returns>
        [SwaggerResponse(HttpStatusCode.OK, Type = typeof(Question))]
        [SwaggerResponse(HttpStatusCode.NotFound)]
        public HttpResponseMessage Get(int id)
        {
            Question sporsmal = _faqDb.hentEttSporsmal(id);

            if (sporsmal != null)
            {
                var Json = new JavaScriptSerializer();
                string jsonString = Json.Serialize(sporsmal);

                return new HttpResponseMessage()
                {
                    Content = new StringContent(jsonString, Encoding.UTF8, "application/json"),
                    StatusCode = HttpStatusCode.OK
                };
            }
            return new HttpResponseMessage()
            {
                Content = new StringContent("Fant ikke spørsmål i Db"),
                StatusCode = HttpStatusCode.NotFound
            };
        }

        // GET api/Question/katId=5/ ( Hente ut alle questions på kategorinummer. Hente ut alle faq på kategorinummer. Hvordan gjøre det?)

        // POST api/Question
        /// <summary>
        /// Add new question
        /// </summary>
        /// <param name="innSporsmal"></param>
        /// <remarks>Insert new question</remarks>
        /// <returns></returns>
        /// 
        [SwaggerResponse(HttpStatusCode.OK)]
        [SwaggerResponse(HttpStatusCode.NotFound)]
        public HttpResponseMessage Post(Question innSporsmal)
        {
            if (ModelState.IsValid)
            {
                bool ok = _faqDb.lagreEttSporsmal(innSporsmal);
                if (ok)
                {
                    return new HttpResponseMessage
                    {
                        StatusCode = HttpStatusCode.OK
                    };
                }
            }
            return new HttpResponseMessage
            {
                Content = new StringContent("Kunne ikke sette inn spørsmål i Db"),
                StatusCode = HttpStatusCode.NotFound
            };
        }
    }
}
