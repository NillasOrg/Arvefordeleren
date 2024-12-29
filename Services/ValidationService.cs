using System.ComponentModel.DataAnnotations;

namespace Arvefordeleren.Services;

public class ValidationService
{

    public bool IsAllFieldsValid<T>(List<T> list) // Validerer om alting på alle items i en liste er opfyldte
    {
        if (list == null || list.Count == 0)
            return false;
        
        foreach (var item in list)
        {
            var context = new ValidationContext(item, null, null);
            var results = new List<ValidationResult>();
            if (!Validator.TryValidateObject(item, context, results, true))
            {
                return false;
            }
        }

        return list.Count != 0;
    }

    public bool IsAllFieldsValid<T>(T item) // Validerer om alting på 1 enkelt item er opfyldte
    {
        if (item == null)
            return false;
        
        var context = new ValidationContext(item, null, null);
        var results = new List<ValidationResult>();
        if (!Validator.TryValidateObject(item, context, results, true))
        {
            return false;
        }

        return true;
    }
    
}