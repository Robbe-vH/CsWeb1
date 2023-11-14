using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;

namespace PXLHotel_12200496.ModelValidations
{
    public class Country : Attribute, IModelValidator
    {

        public IEnumerable<ModelValidationResult> Validate(ModelValidationContext context)
        {
            List<string> toegelatenWaardes = new List<string> { "BE", "NL" };
            var list = new List<ModelValidationResult>();

            if (!toegelatenWaardes.Contains(context.ToString()))
                list.Add(new ModelValidationResult("", "Enkel BE en NL zijn toegelaten."));

            return list;
        }
    }
}
