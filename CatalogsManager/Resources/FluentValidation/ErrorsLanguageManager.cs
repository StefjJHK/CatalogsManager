using FluentValidation.Resources;

namespace CatalogManager.Resources.FluentValidation
{
    public class ErrorsLanguageManager : LanguageManager
    {
        public ErrorsLanguageManager()
        {
            AddTranslation("en", "NotEmptyValidator", "The field '{PropertyName}' is required.");
            AddTranslation("ru", "NotEmptyValidator", "Поле '{PropertyName}' обязательно.");
        }
    }
}
