using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Nettbutikk_FAQ.Models
{
    //Domene- og viewmodell
    /// <summary>
    /// Kategori Model
    /// </summary>
    public class Kategori
    {
        /// <summary>
        /// Kategori id
        /// </summary>
        public int kategoriId { get; set; }
        /// <summary>
        /// Navn
        /// </summary>
        public string navn { get; set; }
    }
}