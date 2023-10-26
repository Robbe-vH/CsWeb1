using Microsoft.AspNetCore.Razor.Runtime.TagHelpers;
using Microsoft.AspNetCore.Razor.TagHelpers;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using MVCVoertuig.Data;
using System.Text;

namespace MVCVoertuig.TagHelpers
{
    // You may need to install the Microsoft.AspNetCore.Razor.Runtime package into your project
    [HtmlTargetElement("car-info")]
    public class CarInfoTagHelper : TagHelper
    {
        VoertuigDbContext _context;

        [HtmlAttributeName("merk")]
        public string Merk { get; set; }

        public CarInfoTagHelper(VoertuigDbContext context)
        {
            _context = context;
        }

        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            output.Content.SetHtmlContent(GetHTMLText());
        }

        private string GetHTMLText()
        {
            StringBuilder html = new StringBuilder();
            html.Append("<button type='button' class='btn border-primary m-2'>");
            html.Append("Aantal voertuigen ");
            html.Append("<span class='badge bg-primary'>");
            html.Append($"{GetCarCount()}");
            html.Append("</span>");
            html.Append("</button>");
            return html.ToString();
        }

        private int GetCarCount()
        {
            int carCount = 0;

            if (string.IsNullOrEmpty(Merk))
            {
                carCount = _context.Voertuigen.Count();
            }
            else
            {
                carCount = _context.Voertuigen
                    .Where(v => v.Merk == Merk)
                    .Count();
            }
            return carCount;
        }
    }
}
