using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using Nettbutikk_FAQ.Models;

namespace Nettbutikk_FAQ
{
    public class Eksempeldata : CreateDatabaseIfNotExists<FaqContext>
    {
        protected override void Seed(FaqContext context)
        {
            var kategorier = new List<Kategorier>
            {
                new Kategorier { Navn = "Annet" },
                new Kategorier { Navn = "Brukerkonto" },
                new Kategorier { Navn = "Teknisk" },
                new Kategorier { Navn = "Personvern" },
                new Kategorier { Navn = "Frakt og levering" },
                new Kategorier { Navn = "Returnering og refusjon" },
                new Kategorier { Navn = "Betaling og priser" },
                new Kategorier { Navn = "Bestilling" },
            };

            kategorier.ForEach(k => context.Kategorier.Add(k));

            var faqs = new List<Faqs>
            {
               new Faqs { Kategori = kategorier.Single(k => k.Navn == "Bestilling"), Sporsmal = "Kan jeg ta bort produkter fra handlevognen?",
                        Svar = "Dette gjør du enkelt i Handlevognen. Der kan du 'Ta bort' artikkel. OBS! Endringer må gjøres før ordren sendes, det vil si før du har godkjent kjøpet."},
               new Faqs { Kategori = kategorier.Single(k => k.Navn == "Bestilling"), Sporsmal = "Kan jeg avbestille en ordre som er ferdig bestilt og betalt?",
                        Svar = "Du kan bare avbestille din ordre før den har blitt behandlet på vårt hovedlager. Kontakt kundesenteret vårt på tlf: 555 55 555 så raskt som mulig."},
               new Faqs { Kategori = kategorier.Single(k => k.Navn == "Betaling og priser"), Sporsmal = "Hvilke betalingsalternativer finnes på Skobutikken?",
                        Svar = "For tiden er det kunn mulig å betale med faktura. VISA og Mastercard kan bli aktuelt ved et senere tidspunkt."},
               new Faqs { Kategori = kategorier.Single(k => k.Navn == "Betaling og priser"), Sporsmal = "Er det noen ekstra transportkostnad som ikke er vist på nettsiden?",
                        Svar = "NEI! Alle varer sendes kostnadsfritt til kunden."},
               new Faqs { Kategori = kategorier.Single(k => k.Navn == "Betaling og priser"), Sporsmal ="Hvor lenge kan jeg vente med å betale for varen min?",
                        Svar = "Fra det øyeblikket du mottar bestillingen har du 15 dager på å fullføre betalingen. På den 16. dagen, vil det påløpe et purregebyr. Etter 3. purring vil kravet gå til inkasso."},
               new Faqs { Kategori = kategorier.Single(k => k.Navn == "Returnering og refusjon"), Sporsmal = "Kan jeg angre et kjøp på Skobutikken?",
                        Svar = "Angrerettloven gir deg 14 dagers angrefrist fra den dagen du har mottatt varen."},
               new Faqs { Kategori = kategorier.Single(k => k.Navn == "Returnering og refusjon"), Sporsmal = "Hvordan returnerer jeg en vare som er kjøpt på Skobutikken?",
                        Svar = "Ta kontakt med vårt kundesenter hvis du ønsker å returnere en vare. Når Skobutikken har mottatt varen og godkjent returen får du pengene tilbake. Etterbetalingen skjer normalt innen 10 arbeidsdager fra dagen Skobutikken har mottatt og godkjent returen."},
               new Faqs { Kategori = kategorier.Single(k => k.Navn == "Frakt og levering"), Sporsmal = "Leverer Skobutikken overalt i Norge?",
                        Svar = "Skobutikken samarbeider med PostPakker på leveringer i Norge. Varer bestilt på Skobutikken leveres over hele fastlands-Norge."},
               new Faqs { Kategori = kategorier.Single(k => k.Navn == "Frakt og levering"), Sporsmal = "Hvor raskt får jeg varene jeg har bestilt på Skobutikken?",
                        Svar = "Normal leveringstid er 2 til 5 arbeidsdager."},
               new Faqs { Kategori = kategorier.Single(k => k.Navn == "Frakt og levering"), Sporsmal = "Hva koster det å få levert en vare fra Skobutikken?",
                        Svar = "Levering er gratis i hele Norge." },
               new Faqs { Kategori = kategorier.Single(k => k.Navn == "Frakt og levering"), Sporsmal = "Hvilke land frakter dere til?",
                        Svar = "Varelevering skjer kunn i Norge."},
               new Faqs { Kategori = kategorier.Single(k => k.Navn == "Annet"), Sporsmal = "Har dere en katalog?",
                        Svar = "Så langt, har Skobutikken en 'virtuell' katalog. Hele produktutvalget er på nettet; vi har ingen fysisk katalog."},
               new Faqs { Kategori = kategorier.Single(k => k.Navn == "Annet"), Sporsmal = "Må jeg være myndig for å handle på Skobutikken?",
                        Svar = "Ja, du må være fylt 18 år."},
               new Faqs { Kategori = kategorier.Single(k => k.Navn == "Annet"), Sporsmal = "Er Skobutikken en ekte nettbutikk?",
                        Svar = "På ingen måte! Det er hverken nettbutikk eller noen annen form for butikk. Det hele er bare tull og tøys. Dette er kunn en skoleoppgave på ingeniørfag data ved HiOA."}
            };

            faqs.ForEach(f => context.Faqs.Add(f));

            context.SaveChanges();
        }

    }
}