using Microsoft.AspNetCore.Razor.Runtime.TagHelpers;
using Microsoft.AspNetCore.Razor.TagHelpers;
using PXLHotel_12200496.Models;
using System.Text;

namespace PXLHotel_12200496.TagHelpers
{
    [HtmlTargetElement("hotel-card")]
    public class HotelTagHelper : TagHelper
    {
        public string HotelName { get; set; }
        public string HotelCountry { get; set; }
        public List<HotelRoom> HotelRooms { get; set; }

        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            // Create the HTML structure using a StringBuilder
            var html = new StringBuilder();
            html.AppendLine("<div class=\"card m-2 p-2\" style=\"width: 18rem;\">");
            html.AppendLine("  <div class=\"card-body\">");
            html.AppendLine($"    <h5 class=\"card-title\"> {HotelName} </h5>");
            html.AppendLine($"    <h6 class=\"card-subtitle mb-2 text-muted\"> Country: {HotelCountry} </h6>");

            foreach (var room in HotelRooms)
            {
                html.AppendLine("    <p class=\"card-text\">");
                html.AppendLine($"      {room.HotelRoomNumber} - {room.HotelRoomName}");
                html.AppendLine("    </p>");
            }

            html.AppendLine("  </div>");
            html.AppendLine("</div>");

            // Set the HTML content to the output
            output.TagName = null;  // Remove the original tag
            output.Content.SetHtmlContent(html.ToString());
        }
    }
}
