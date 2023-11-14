using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.Text.RegularExpressions;

namespace PXLHotel_12200496.ModelValidations
{
    public class NoNumeric : Attribute, IModelValidator
    {
        public IEnumerable<ModelValidationResult> Validate(ModelValidationContext context)
        {
            var list = new List<ModelValidationResult>();

            if (ContainsNumbers(context.ToString()))
                list.Add(new ModelValidationResult("", "De naam bevat een getal."));

            return list;
        }


        static bool ContainsNumbers(string ctx)
        {
            Regex regex = new Regex(@"\d");
            Match match = regex.Match(ctx);

            return match.Success;
        }
    }
}
