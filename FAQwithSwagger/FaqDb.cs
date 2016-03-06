using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Nettbutikk_FAQ.Models;
using System.Globalization;

namespace Nettbutikk_FAQ
{
    public class FaqDb : IFaqDb
    {
        public List<Faq> hentAlleFaq()
        {
            using(var db = new FaqContext())
            {
                try
                {
                    var liste = db.Faqs.Select(f => new Faq
                    {
                        id = f.Id,
                        sporsmal = f.Sporsmal,
                        svar = f.Svar,
                        kategori = f.Kategori.Navn
                    }).ToList();

                    return liste;
                }
                catch
                {
                    return null;
                }
            }
        }

        public List<Kategori> hentAlleKategorier()
        {
            using (var db = new FaqContext())
            {
                try
                {
                    var liste = db.Kategorier.Select(k => new Kategori
                    {
                        kategoriId = k.Id,
                        navn = k.Navn

                    }).ToList();

                    return liste;
                }
                catch (Exception feil)
                {
                    return null;
                }
            }
        }

        public List<Question> hentAlleSporsmal()
        {
            using (var db = new FaqContext())
            {
                try
                {
                    var temp = db.Questions.ToList();
                    var liste = new List<Question>();
                    foreach(var element in temp)
                    {
                        liste.Add(new Question {
                            id = element.Id,
                            dato = element.Dato.ToString("d/M/yyyy HH:mm:ss"),
                            kategori = element.Kategori.Navn,
                            sporsmal = element.Sporsmal,
                            epost = element.Epost
                        });
                    }

                    return liste;
                }
                catch (Exception feil)
                {
                    return null;
                }
            }
        }

        public Faq hentEnFaq(int id)
        {
            using (var db = new FaqContext())
            {
                try
                {
                    var utFaq = db.Faqs.Find(id);

                    return new Faq
                    {
                        id = utFaq.Id,
                        kategori = utFaq.Kategori.Navn,
                        sporsmal = utFaq.Sporsmal,
                        svar = utFaq.Svar
                    };
                }
                catch
                {
                    return null;
                }
            }
        }

        public Kategori hentEnKategori(int id)
        {
            using (var db = new FaqContext())
            {
                try
                {
                    var utKat = db.Kategorier.Find(id);

                    return new Kategori
                    {
                        kategoriId = utKat.Id,
                        navn = utKat.Navn
                    };
                }
                catch
                {
                    return null;
                }
            }
        }

        public Question hentEttSporsmal(int id)
        {
            using (var db = new FaqContext())
            {
                try
                {
                    var utQuestion = db.Questions.Find(id);

                    return new Question
                    {
                        id = utQuestion.Id,
                        dato = utQuestion.Dato.ToString("d/M/yyyy HH:mm:ss"),
                        epost = utQuestion.Epost,
                        kategori = utQuestion.Kategori.Navn,
                        sporsmal = utQuestion.Sporsmal
                    };
                }
                catch
                {
                    return null;
                }
            }
        }

        public bool lagreEttSporsmal(Question innSporsmal)
        {
            using (var db = new FaqContext())
            {
                try
                {
                    db.Questions.Add(new Questions
                    {
                        Epost = innSporsmal.epost,
                        Dato = DateTime.Now,
                        Kategori = db.Kategorier.Where(k => k.Navn == innSporsmal.kategori).SingleOrDefault(),
                        Sporsmal = innSporsmal.sporsmal
                    });
                    db.SaveChanges();
                    return true;
                }
                catch
                {
                    return false;
                }
            }
        }
    }
}