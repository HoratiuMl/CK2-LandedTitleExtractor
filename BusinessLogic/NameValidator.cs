using System.Collections.Generic;
using System.Linq;

namespace CK2LandedTitlesManager.BusinessLogic  
{
    public sealed class NameValidator : INameValidator
    {
        public bool IsNameValid(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                return false;
            }

            if (!name.All(c => AllowedCharacters.Contains(c)))
            {
                System.Console.WriteLine($"Invalid name \"{name}\"");
                return false;
            }

            return true;
        }

        public bool IsNameValid(string name, string cultureId)
        {
            if (!IsNameValid(name))
            {
                return false;
            }

            if (DisallowedCharactersPerCulture.ContainsKey(cultureId))
            {
                return name.ToLower().All(c => !DisallowedCharactersPerCulture[cultureId].Contains(c));
            }

            return true;
        }
        
        readonly string AllowedCharacters =
            "\",'‘’“”`÷×- " +
            "ßÞþð" +
            "AÁÀÂÅÄÃÆBCÇDÐEÉÈÊËFGHIÍÌÎÏJKLMNÑOÓÒÔÖÕØŒPQRSŠTUÚÙÛÜVWXYÝŸZŽ" +
            "aáàâåäãæbcçdeéèêëfghiíìîïjklmnñoóòôöõøœpqrsštuúùûüvwxyýÿzž";
        
        readonly IDictionary<string, string> DisallowedCharactersPerCulture = new Dictionary<string, string>()
        {
            { "romanian", "üåæçðžøœšñßžÞýþçší" },
            { "bosnian", "üåæíñßþçã" },
            { "bulgarian", "üåæíñßþçã" },
            { "carantanian", "üåæíñßþçã" },
            { "croatian", "üåæíñßþçã" },
            { "italian", "üåæçðžøœšñßžÞýþçãš" },
            { "serbian", "üåæíñßþçã" },
            { "swedish", "ížšñçã" },
        };
    }
}