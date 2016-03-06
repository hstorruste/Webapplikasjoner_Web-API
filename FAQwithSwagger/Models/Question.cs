using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Nettbutikk_FAQ.Models
{
    //Domene- og viewmodell
    /// <summary>
    /// Question Model
    /// </summary>
    public class Question
    {
        /// <summary>
        /// Id
        /// </summary>
        public int id { get; set; }
        /// <summary>
        /// Dato
        /// </summary>
        public string dato { get; set; }
        /// <summary>
        /// Epost
        /// </summary>
        [Required]
        [RegularExpression(@"[A-Za-z0-9._%+-]+@[A-Za-z0-9.-]+\.[A-Za-z]{2,4}")]
        public string epost { get; set; }
        /// <summary>
        /// Spørsmål
        /// </summary>
        [Required]
        public string sporsmal { get; set; }
        /// <summary>
        /// Kategori
        /// </summary>
        [Required]
        public string kategori { get; set; }
    }
}