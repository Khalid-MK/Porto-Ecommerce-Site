#pragma checksum "G:\CEI\Assignments\ASP Core\Project\Code\ITI.CEI.Core\ITI.CEI.Core.Porto\Views\Admin\ManageRoles.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "8d611d7e8e7c6161fb6bea4a7f8aceda55108b69"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Admin_ManageRoles), @"mvc.1.0.view", @"/Views/Admin/ManageRoles.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/Admin/ManageRoles.cshtml", typeof(AspNetCore.Views_Admin_ManageRoles))]
namespace AspNetCore
{
    #line hidden
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.Rendering;
    using Microsoft.AspNetCore.Mvc.ViewFeatures;
#line 1 "G:\CEI\Assignments\ASP Core\Project\Code\ITI.CEI.Core\ITI.CEI.Core.Porto\Views\_ViewImports.cshtml"
using ITI.CEI.Core.Porto;

#line default
#line hidden
#line 2 "G:\CEI\Assignments\ASP Core\Project\Code\ITI.CEI.Core\ITI.CEI.Core.Porto\Views\_ViewImports.cshtml"
using ITI.CEI.Core.Porto.Models;

#line default
#line hidden
#line 3 "G:\CEI\Assignments\ASP Core\Project\Code\ITI.CEI.Core\ITI.CEI.Core.Porto\Views\_ViewImports.cshtml"
using ITI.CEI.Core.Porto.Models.View_Models;

#line default
#line hidden
#line 4 "G:\CEI\Assignments\ASP Core\Project\Code\ITI.CEI.Core\ITI.CEI.Core.Porto\Views\_ViewImports.cshtml"
using Microsoft.AspNetCore.Identity;

#line default
#line hidden
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"8d611d7e8e7c6161fb6bea4a7f8aceda55108b69", @"/Views/Admin/ManageRoles.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"cd3a80bf086abb787a7e6e6e979a3891bffa2824", @"/Views/_ViewImports.cshtml")]
    public class Views_Admin_ManageRoles : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<AdminViewModel>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("type", "text", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("form-control"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("id", new global::Microsoft.AspNetCore.Html.HtmlString("request-title"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("onsubmit", new global::Microsoft.AspNetCore.Html.HtmlString("MapValue()"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_4 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "AddRole", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_5 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("method", "post", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        #line hidden
        #pragma warning disable 0169
        private string __tagHelperStringValueBuffer;
        #pragma warning restore 0169
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperExecutionContext __tagHelperExecutionContext;
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner __tagHelperRunner = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner();
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager __backed__tagHelperScopeManager = null;
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager __tagHelperScopeManager
        {
            get
            {
                if (__backed__tagHelperScopeManager == null)
                {
                    __backed__tagHelperScopeManager = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager(StartTagHelperWritingScope, EndTagHelperWritingScope);
                }
                return __backed__tagHelperScopeManager;
            }
        }
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.InputTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#line 2 "G:\CEI\Assignments\ASP Core\Project\Code\ITI.CEI.Core\ITI.CEI.Core.Porto\Views\Admin\ManageRoles.cshtml"
  
    ViewData["Title"] = "Roles";

#line default
#line hidden
            BeginContext(64, 136, true);
            WriteLiteral("\r\n\r\n\r\n<div class=\" login\" style=\"width:30%;\">\r\n\r\n\r\n    <a class=\"btn btn-info mb-3\" style=\"width:auto\" id=\"btnclick\" >Add new role</a>\r\n");
            EndContext();
#line 12 "G:\CEI\Assignments\ASP Core\Project\Code\ITI.CEI.Core\ITI.CEI.Core.Porto\Views\Admin\ManageRoles.cshtml"
      
        foreach (var role in Model.Roles)
        {

#line default
#line hidden
            BeginContext(262, 110, true);
            WriteLiteral("            <div class=\"card mb-3\">\r\n                <div class=\"card-header\">\r\n                    Role Id : ");
            EndContext();
            BeginContext(373, 7, false);
#line 17 "G:\CEI\Assignments\ASP Core\Project\Code\ITI.CEI.Core\ITI.CEI.Core.Porto\Views\Admin\ManageRoles.cshtml"
                         Write(role.Id);

#line default
#line hidden
            EndContext();
            BeginContext(380, 110, true);
            WriteLiteral("\r\n                </div>\r\n                <div class=\"card-body\">\r\n                    <h3 class=\"card-title\">");
            EndContext();
            BeginContext(491, 9, false);
#line 20 "G:\CEI\Assignments\ASP Core\Project\Code\ITI.CEI.Core\ITI.CEI.Core.Porto\Views\Admin\ManageRoles.cshtml"
                                      Write(role.Name);

#line default
#line hidden
            EndContext();
            BeginContext(500, 74, true);
            WriteLiteral("</h3>\r\n                </div>\r\n                <div class=\"card-footer\">\r\n");
            EndContext();
#line 23 "G:\CEI\Assignments\ASP Core\Project\Code\ITI.CEI.Core\ITI.CEI.Core.Porto\Views\Admin\ManageRoles.cshtml"
                      
                        if (role.Name == "Admin" || role.Name == "Shop_Owner")
                        {

#line default
#line hidden
            BeginContext(705, 129, true);
            WriteLiteral("                            <a data-confirm=\"Are you sure?\" style=\"width:auto\"  class=\"btn btn-danger mb-3 disabled\">Delete</a>\r\n");
            EndContext();
#line 27 "G:\CEI\Assignments\ASP Core\Project\Code\ITI.CEI.Core\ITI.CEI.Core.Porto\Views\Admin\ManageRoles.cshtml"
                        }
                        else
                        {

#line default
#line hidden
            BeginContext(918, 59, true);
            WriteLiteral("                            <a data-confirm=\"Are you sure?\"");
            EndContext();
            BeginWriteAttribute("href", " href=\"", 977, "\"", 1003, 2);
            WriteAttributeValue("", 984, "DeleteRole/", 984, 11, true);
#line 30 "G:\CEI\Assignments\ASP Core\Project\Code\ITI.CEI.Core\ITI.CEI.Core.Porto\Views\Admin\ManageRoles.cshtml"
WriteAttributeValue("", 995, role.Id, 995, 8, false);

#line default
#line hidden
            EndWriteAttribute();
            BeginContext(1004, 60, true);
            WriteLiteral(" style=\"width:auto\" class=\"btn btn-danger mb-3\">Delete</a>\r\n");
            EndContext();
#line 31 "G:\CEI\Assignments\ASP Core\Project\Code\ITI.CEI.Core\ITI.CEI.Core.Porto\Views\Admin\ManageRoles.cshtml"
                        }
                    

#line default
#line hidden
            BeginContext(1114, 46, true);
            WriteLiteral("\r\n                </div>\r\n            </div>\r\n");
            EndContext();
#line 36 "G:\CEI\Assignments\ASP Core\Project\Code\ITI.CEI.Core\ITI.CEI.Core.Porto\Views\Admin\ManageRoles.cshtml"
        }
    

#line default
#line hidden
            BeginContext(1178, 601, true);
            WriteLiteral(@"
</div>


<div class=""modal fade "" id=""requestModal"" tabindex=""-1"" role=""dialog"" aria-labelledby=""exampleModalLabel"" aria-hidden=""true"">
    <div class=""modal-dialog"" role=""document"">
        <div class=""modal-content"">
            <div class=""modal-header"">
                <h2 class=""modal-title"" id=""exampleModalLabel"">New Role</h2>
                <button type=""button"" class=""close"" data-dismiss=""modal"" aria-label=""Close"">
                    <span aria-hidden=""true"">&times;</span>
                </button>
            </div>
            <div class=""modal-body"">
                ");
            EndContext();
            BeginContext(1779, 643, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "8d611d7e8e7c6161fb6bea4a7f8aceda55108b6910304", async() => {
                BeginContext(1843, 166, true);
                WriteLiteral("\r\n                    <div class=\"form-group\">\r\n                        <label for=\"request-title\" class=\"col-form-label\">Role title</label>\r\n                        ");
                EndContext();
                BeginContext(2009, 79, false);
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("input", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagOnly, "8d611d7e8e7c6161fb6bea4a7f8aceda55108b6910864", async() => {
                }
                );
                __Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.InputTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper);
#line 55 "G:\CEI\Assignments\ASP Core\Project\Code\ITI.CEI.Core\ITI.CEI.Core.Porto\Views\Admin\ManageRoles.cshtml"
__Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper.For = ModelExpressionProvider.CreateModelExpression(ViewData, __model => __model.Role.Name);

#line default
#line hidden
                __tagHelperExecutionContext.AddTagHelperAttribute("asp-for", __Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper.For, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
                __Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper.InputTypeName = (string)__tagHelperAttribute_0.Value;
                __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_1);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_2);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                EndContext();
                BeginContext(2088, 327, true);
                WriteLiteral(@"
                    </div>
                    <div class=""modal-footer"">
                        <button type=""button"" id=""btnHideModal"" class=""btn btn--gray"">Close</button>
                        <button type=""submit"" id=""btnHideModal"" class=""btn btn--primary"">Add</button>
                    </div>
                ");
                EndContext();
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_3);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Action = (string)__tagHelperAttribute_4.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_4);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Method = (string)__tagHelperAttribute_5.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_5);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(2422, 60, true);
            WriteLiteral("\r\n            </div>\r\n        </div>\r\n    </div>\r\n</div>\r\n\r\n");
            EndContext();
            DefineSection("Scripts", async() => {
                BeginContext(2499, 428, true);
                WriteLiteral(@"

    <script>

        
        // to show pop up form
        $(""#btnclick"").click(function () {
            $(""#requestModal"").modal('show');
        });

        // to hide pop up form
        $(""#btnHideModal"").click(function () {
            var value = $('#request-title').val();
            $('#requestTitle').val(value);
            $(""#requestModal"").modal('hide');
        });

    </script>



 ");
                EndContext();
            }
            );
        }
        #pragma warning restore 1998
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.IModelExpressionProvider ModelExpressionProvider { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IUrlHelper Url { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IViewComponentHelper Component { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IJsonHelper Json { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<AdminViewModel> Html { get; private set; }
    }
}
#pragma warning restore 1591
