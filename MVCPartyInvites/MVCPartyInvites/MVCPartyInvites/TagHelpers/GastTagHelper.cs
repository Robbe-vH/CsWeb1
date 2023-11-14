using Microsoft.AspNetCore.Razor.Runtime.TagHelpers;
using Microsoft.AspNetCore.Razor.TagHelpers;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using MVCPartyInvites.Models;
using System.Text;

namespace MVCPartyInvites.TagHelpers
{
    // You may need to install the Microsoft.AspNetCore.Razor.Runtime package into your project
    [HtmlTargetElement("gast", Attributes = "title, gasten")]
    public class GastTagHelper : TagHelper
    {
        public string Title { get; set; }
        public IEnumerable<Gast> Gasten { get; set; }
        public override void Process(TagHelperContext context, TagHelperOutput output)
        {

            output.Content.SetHtmlContent(GetHtmlText());
        }
        
           
        private string GetHtmlText()
        {
            StringBuilder html = new StringBuilder();
            html.Append("<table class='table table-bordered'>");
            html.Append("<tr>");
            html.Append($"<th colspan='2' class='font-weight-bold'>{Title}</th>");
            html.Append("</tr>");
            html.Append("<tr>");
            html.Append("<th class='font-weight-bold'>Naam</th>");
            html.Append("<th class='font-weight-bold'>Email</th>");
            html.Append("</tr>");
            if (Gasten != null)
            {
                foreach (Gast gast in Gasten)
                {
                    html.Append($"<tr><td>{gast.Naam}</td><td>{gast.Email}</td></tr>");
                }
            }
            html.Append("</table>");
            return html.ToString();
        }
    }
}
