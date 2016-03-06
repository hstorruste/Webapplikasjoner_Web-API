using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Nettbutikk_FAQ.Models;

namespace Nettbutikk_FAQ
{
    interface IFaqDb
    {
        List<Faq> hentAlleFaq();
        Faq hentEnFaq(int id);
        List<Kategori> hentAlleKategorier();
        Kategori hentEnKategori(int id);
        List<Question> hentAlleSporsmal();
        Question hentEttSporsmal(int id);
        bool lagreEttSporsmal(Question innSporsmal);
    }
}
