using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;

namespace MVCVoertuig.ModelValidatations;

public class BouwjaarValidation : Attribute, IModelValidator
{
    public IEnumerable<ModelValidationResult> Validate(ModelValidationContext context)
    {
        const int bouwjaarMinValue = 1900;
        int bouwjaar = 0;
        var list = new List<ModelValidationResult>();
        if (int.TryParse(context.Model.ToString(), out bouwjaar))
        {
            if (bouwjaar < bouwjaarMinValue || bouwjaar > DateTime.Now.Year)
            {
                list.Add(new ModelValidationResult("", $"Bouwjaar moet liggen tussen {bouwjaarMinValue} en {DateTime.Now.Year}!"));
            }
        }            
        else
        {
            list.Add(new ModelValidationResult("", "Geen geldig bouwjaar!"));
        }            
        return list;

    }
}