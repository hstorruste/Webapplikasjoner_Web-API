using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Nettbutikk_FAQ.Models
{
    //Domene- og viewmodell
    /// <summary>
    /// FAQ Model
    /// </summary>
    public class Faq
    {
        /// <summary>
        /// Id
        /// </summary>
        public int id { get; set; }
        /// <summary>
        /// Spørsmål
        /// </summary>
        public string sporsmal { get; set; }
        /// <summary>
        /// Svar
        /// </summary>
        public string svar { get; set; }
        /// <summary>
        /// Kategori
        /// </summary>
        public string kategori { get; set; }
    }
}