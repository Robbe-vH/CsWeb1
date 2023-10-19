using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Razor.Runtime.TagHelpers;
using Microsoft.AspNetCore.Razor.TagHelpers;
using MVCSportsStore.ViewModels;

namespace MVCSportsStore.TagHelpers
{
    // You may need to install the Microsoft.AspNetCore.Razor.Runtime package into your project
    [HtmlTargetElement("page-link", Attributes = "paging-info")]
    public class PageLinkTagHelper : TagHelper
    {
        public PagingInfo PagingInfo { get; set; }

        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            output.TagName = "div";
            output.Content.AppendHtml(getPaginationLinks(PagingInfo));
        }

        private TagBuilder getPaginationLinks(PagingInfo pagingInfo)
        {
            var ul = new TagBuilder("ul");
            ul.Attributes["class"] = "pagination";
            for (int page = 1; page < pagingInfo.TotalPages + 1; page++)
            {
                ul.InnerHtml.AppendHtml(getPaginationLink(page, page == pagingInfo.CurrentPage));
            }

            return ul;
        }

        private TagBuilder getPaginationLink(int page, bool active)
        {
            string pageLinkActive = "btn border btn-border-primary";
            string pageLink = "btn border btn-border-secondary";

            TagBuilder li = new TagBuilder("li");
            li.Attributes["class"] = "page-item";
            TagBuilder a = new TagBuilder("a");
            a.Attributes["class"] = active ? pageLinkActive : pageLink;
            a.Attributes["href"] = $"/Home/Index/{page}";
            a.Attributes["title"] = $"Go to page {page}";
            a.InnerHtml.Append(page.ToString());
            li.InnerHtml.AppendHtml(a);

            return li;
        }
    }
}
