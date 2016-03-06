using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Nettbutikk_FAQ;
using Nettbutikk_FAQ.Models;
using System.Web.Script.Serialization;
using System.Text;
using Swashbuckle.Swagger.Annotations;

namespace Nettbutikk_FAQ.Controllers
{
    public class FaqController : ApiController
    {
        FaqDb _faqDb;

        public FaqController()
        {
            _faqDb = new FaqDb();
        }

        // GET api/Faq
        /// <summary>
        /// Get all FAQ's
        /// </summary>
        /// <remarks>Get a array of all FAQ's</remarks>
        [SwaggerResponse(HttpStatusCode.OK, Type = typeof(List<Faq>))]
        [SwaggerResponse(HttpStatusCode.NotFound)]
        public HttpResponseMessage Get()
        {
            List<Faq> liste = _faqDb.hentAlleFaq();

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
                Content = new StringContent("Fant ikke FAQ i Db"),
                StatusCode = HttpStatusCode.NotFound
            };
        }

        // GET api/Faq/3
        /// <summary>
        /// Get FAQ
        /// </summary>
        /// <param name="id">Unique id</param>
        /// <remarks>Get single FAQ by providing id</remarks>
        /// <returns></returns>
        [SwaggerResponse(HttpStatusCode.OK, Type = typeof(Faq))]
        [SwaggerResponse(HttpStatusCode.NotFound)]
        public HttpResponseMessage Get(int id)
        {
            Faq faq = _faqDb.hentEnFaq(id);

            if (faq != null)
            {
                var Json = new JavaScriptSerializer();
                string jsonString = Json.Serialize(faq);

                return new HttpResponseMessage()
                {
                    Content = new StringContent(jsonString, Encoding.UTF8, "application/json"),
                    StatusCode = HttpStatusCode.OK
                };
            }
            return new HttpResponseMessage()
            {
                Content = new StringContent("Fant ikke FAQ i Db"),
                StatusCode = HttpStatusCode.NotFound
            };
        }

        /* GET api/Faq/katId=5/ ( Hente ut alle questions på kategorinummer. Hente ut alle faq på kategorinummer. Hvordan gjøre det? 
        Trenger strengt tatt ikke gjøre det, men hadde kanskje vært fint å fått til for innsendt spørsmål(Questions). Men tror kanskje jeg dropper det.)*/
    }
}
