using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace LanguagesAssembly
{
    public class Translator
    {
        public static List<Language> LanguageIndex = new List<Language>
        {
            new Language
            {
                LanguageName = "English",
                LanguageCultureName = "en-US"
            },

            new Language
            {
                LanguageName = "Romana",
                LanguageCultureName = "ro-RO"
            },

            new Language
            {
                LanguageName = "Deutsch",
                LanguageCultureName = "de-DE"
            },

            new Language
            {
                LanguageName = "Lëtzebuergesch",
                LanguageCultureName = "lg-LU"
            },

            new Language
            {
                LanguageName = "Magyar",
                LanguageCultureName = "hu-HU"
            }
        };

        public static bool IsLanguageAvailable(string lang)
        {
            return LanguageIndex.Where(a =>
            a.LanguageCultureName.Equals(lang)).FirstOrDefault() != null ? true : false;
        }

        public static string GetDefaultLanguage()
        {
            return LanguageIndex[0].LanguageCultureName;
        }
    }


    public class Language
    {
        public string LanguageName { get; set; }
        public string LanguageCultureName { get; set; }
    }
}
