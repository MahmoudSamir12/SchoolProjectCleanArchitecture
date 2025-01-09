using System.Globalization;

namespace SchoolProject.Data.Commons
{
    public class GeneralLocalizableEntity
    {
        public string Localize(string textAr, string textEn)
        {
            CultureInfo culture = Thread.CurrentThread.CurrentCulture;

            var localizedValue = culture.TwoLetterISOLanguageName.Equals("ar",
                StringComparison.InvariantCultureIgnoreCase) ?
                textAr :
                textEn;

            return localizedValue ?? throw new InvalidOperationException("Both localized names are null.");
        }
    }
}
