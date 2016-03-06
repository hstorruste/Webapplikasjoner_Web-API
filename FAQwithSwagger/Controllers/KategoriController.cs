using Nettbutikk_FAQ.Models;
using Swashbuckle.Swagger.Annotations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Web.Http;
using System.Web.Http.Description;
using System.Web.Script.Serialization;

namespace Nettbutikk_FAQ.Controllers
{
    public class KategoriController : ApiController
    {
        FaqDb _faqDb;

        public KategoriController()
        {
            _faqDb = new FaqDb();
        }

        // GET api/Kategori
        /// <summary>
        /// Get all kategories
        /// </summary>
        /// <remarks>Get a array of all kategories</remarks>
        [SwaggerResponse(HttpStatusCode.OK, Type = typeof(List<Kategori>))]
        [SwaggerResponse(HttpStatusCode.NotFound)]
        [ResponseType(typeof(List<Kategori>))]
        public HttpResponseMessage Get()
        {
            List<Kategori> liste = _faqDb.hentAlleKategorier();

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
                Content = new StringContent("Fant ikke kategori i Db"),
                StatusCode = HttpStatusCode.NotFound
            };
        }

        // GET api/Kategori/3
        /// <summary>
        /// Get kategori
        /// </summary>
        /// <param name="id">Unique id</param>
        /// <remarks>Get single kategori by providing id</remarks>
        /// <returns></returns>
        [SwaggerResponse(HttpStatusCode.OK, Type = typeof(Kategori))]
        [SwaggerResponse(HttpStatusCode.NotFound)]
        public HttpResponseMessage Get(int id)
        {
            Kategori kategori = _faqDb.hentEnKategori(id);

            if (kategori != null)
            {
                var Json = new JavaScriptSerializer();
                string jsonString = Json.Serialize(kategori);

                return new HttpResponseMessage()
                {
                    Content = new StringContent(jsonString, Encoding.UTF8, "application/json"),
                    StatusCode = HttpStatusCode.OK
                };
            }
            return new HttpResponseMessage()
            {
                Content = new StringContent("Fant ikke kategori i Db"),
                StatusCode = HttpStatusCode.NotFound
            };
        }


        // GET api/Kategori/ ( Hente ut alle questions på kategorinummer. Hente ut alle faq på kategorinummer. Hvordan gjøre det?)
    }
}
