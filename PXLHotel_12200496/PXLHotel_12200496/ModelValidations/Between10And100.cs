using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;

namespace PXLHotel_12200496.ModelValidations
{
    public class Between10And100 : Attribute, IModelValidator
    {
        public IEnumerable<ModelValidationResult> Validate(ModelValidationContext context)
        {
            var list = new List<ModelValidationResult>();
            bool isAnInt = int.TryParse(context.ToString(), out int result);
            if (isAnInt) 
            {
                if (result > 100 || result < 10) list.Add(new ModelValidationResult("", "Kamernummer moet tussen de 10 en 100 liggen."));
            }

            return list;
        }
    }
}
