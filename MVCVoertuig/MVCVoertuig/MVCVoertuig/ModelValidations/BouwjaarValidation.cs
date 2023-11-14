using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;

namespace MVCVoertuig.ModelValidations
{
    public class BouwjaarValidation : Attribute, IModelValidator
    {
        public IEnumerable<ModelValidationResult> Validate(ModelValidationContext context)
        {
            var list = new List<ModelValidationResult>();
            const int bouwjaarMinValue = 1900;
            int bouwjaar = 0;
            string error = $"Bouwjaar moet liggen tussen {bouwjaarMinValue} en {DateTime.Now.Year}";
            if(int.TryParse(context.Model.ToString(), out bouwjaar))
            {
                if(bouwjaar<bouwjaarMinValue || bouwjaar > DateTime.Now.Year) 
                {
                    list.Add(new ModelValidationResult("", error));
                }
            }
            else 
            {
                list.Add(new ModelValidationResult("", error));
            }
            return list;
        }
    }
}
