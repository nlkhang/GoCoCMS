using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.AspNetCore.Razor.TagHelpers;

namespace GoCoCMS.Web.Infrastructure.TagHelpers
{
    [HtmlTargetElement("goco-label", Attributes = ForAttributeName, TagStructure = TagStructure.WithoutEndTag)]
    public class GoCoLabelTagHelper : TagHelper
    {
        #region Fields

        private const string ForAttributeName = "asp-for";
        private const string RequiredAttributeName = "asp-required";

        #endregion

        #region Properties

        [HtmlAttributeName(ForAttributeName)]
        public ModelExpression For { get; set; }

        [HtmlAttributeName(RequiredAttributeName)]
        public string IsRequired { set; get; }

        #endregion

        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            output.TagName = "label";
            output.TagMode = TagMode.StartTagAndEndTag;

            // required
            bool.TryParse(IsRequired, out var required);
            if (required)
            {
                output.Content.SetHtmlContent("<span class='required'>*</span>");
            }

            output.PostContent.SetContent(!string.IsNullOrEmpty(For.Metadata.DisplayName)
                ? For.Metadata.DisplayName
                : For.Name);
        }
    }
}
