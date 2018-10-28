using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.AspNetCore.Razor.TagHelpers;

namespace GoCoCMS.Web.Infrastructure.TagHelpers
{
    [HtmlTargetElement("goco-datetime-picker", Attributes = ForAttributeName, TagStructure = TagStructure.WithoutEndTag)]
    public class GoCoDateTimePickerTagHelper : TagHelper
    {
        #region Fields

        private const string ForAttributeName = "asp-for";

        #endregion

        #region Properties

        [HtmlAttributeName(ForAttributeName)]
        public ModelExpression For { get; set; }

        #endregion

        #region Methods

        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            output.TagName = "div";
            output.TagMode = TagMode.StartTagAndEndTag;

            output.Attributes.SetAttribute("class", "input-group date");
            output.Content.SetHtmlContent($@"<input type='text' class='form-control' name='{For.Name}' value='{For.Model}'/>
                    <span class='input-group-addon'><span class='fa fa-calendar'></span></span>");
        }

        #endregion
    }
}
