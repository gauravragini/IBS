#pragma checksum "C:\Users\Ragini\Desktop\IBS\IBS\IBS.PresentationLayer\Views\Admin\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "95fc97584418f1758aa0b3a8f1175b41b5ac07be"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Admin_Index), @"mvc.1.0.view", @"/Views/Admin/Index.cshtml")]
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
#nullable restore
#line 1 "C:\Users\Ragini\Desktop\IBS\IBS\IBS.PresentationLayer\Views\_ViewImports.cshtml"
using IBS.PresentationLayer;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\Ragini\Desktop\IBS\IBS\IBS.PresentationLayer\Views\_ViewImports.cshtml"
using IBS.EntitiesLayer.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"95fc97584418f1758aa0b3a8f1175b41b5ac07be", @"/Views/Admin/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"f7b73252c3fc50cdf6a74240d91a548653a9dd55", @"/Views/_ViewImports.cshtml")]
    public class Views_Admin_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<ApplicationUser>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("src", new global::Microsoft.AspNetCore.Html.HtmlString("~/images/account2.jpg"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("style", new global::Microsoft.AspNetCore.Html.HtmlString("float:right; padding-left:70px; width:400px;height:400px"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        #line hidden
        #pragma warning disable 0649
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperExecutionContext __tagHelperExecutionContext;
        #pragma warning restore 0649
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner __tagHelperRunner = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner();
        #pragma warning disable 0169
        private string __tagHelperStringValueBuffer;
        #pragma warning restore 0169
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
        private global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 2 "C:\Users\Ragini\Desktop\IBS\IBS\IBS.PresentationLayer\Views\Admin\Index.cshtml"
  
    ViewData["Title"] = "Home";
    Layout = "~/Views/Admin/_LayoutAdmin.cshtml";

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n\r\n");
#nullable restore
#line 8 "C:\Users\Ragini\Desktop\IBS\IBS\IBS.PresentationLayer\Views\Admin\Index.cshtml"
 if (ViewData["passwordsuccess"] != null)
{

#line default
#line hidden
#nullable disable
            WriteLiteral("    <br />\r\n    <div class=\"alert alert-danger alert-dismissible\">\r\n        <button type=\"button\" class=\"close\" data-dismiss=\"alert\">&times;</button>\r\n        <strong>");
#nullable restore
#line 13 "C:\Users\Ragini\Desktop\IBS\IBS\IBS.PresentationLayer\Views\Admin\Index.cshtml"
           Write(ViewData["passwordsuccess"]);

#line default
#line hidden
#nullable disable
            WriteLiteral("</strong>\r\n    </div>\r\n");
#nullable restore
#line 15 "C:\Users\Ragini\Desktop\IBS\IBS\IBS.PresentationLayer\Views\Admin\Index.cshtml"
}

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n\r\n<hr />\r\n<h4><i>MY PROFILE</i></h4>\r\n<hr />\r\n\r\n<div id=\"profile\"  style=\"background-color:white\">\r\n    <table style=\"margin-left:170px;\">\r\n        <tr>\r\n            <td>First Name</td>\r\n            <td>");
#nullable restore
#line 26 "C:\Users\Ragini\Desktop\IBS\IBS\IBS.PresentationLayer\Views\Admin\Index.cshtml"
           Write(Model.FirstName);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n            <td rowspan=\"11\">\r\n                ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("img", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "95fc97584418f1758aa0b3a8f1175b41b5ac07be5519", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_1);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n            </td>\r\n        </tr>\r\n        <tr>\r\n            <td>Last Name </td>\r\n            <td>");
#nullable restore
#line 33 "C:\Users\Ragini\Desktop\IBS\IBS\IBS.PresentationLayer\Views\Admin\Index.cshtml"
           Write(Model.LastName);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n            <td rowspan=\"11\"></td>\r\n        </tr>\r\n        <tr>\r\n            <td>Email Id </td>\r\n            <td>");
#nullable restore
#line 38 "C:\Users\Ragini\Desktop\IBS\IBS\IBS.PresentationLayer\Views\Admin\Index.cshtml"
           Write(Model.UserName);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n            <td rowspan=\"11\"></td>\r\n        </tr>\r\n        <tr>\r\n            <td>Phone Number </td>\r\n            <td>");
#nullable restore
#line 43 "C:\Users\Ragini\Desktop\IBS\IBS\IBS.PresentationLayer\Views\Admin\Index.cshtml"
           Write(Model.PhoneNumber);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n            <td rowspan=\"11\"></td>\r\n        </tr>\r\n        <tr>\r\n            <td>Date Of Birth</td>\r\n            <td>");
#nullable restore
#line 48 "C:\Users\Ragini\Desktop\IBS\IBS\IBS.PresentationLayer\Views\Admin\Index.cshtml"
           Write(Model.Dob);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n            <td rowspan=\"11\"></td>\r\n        </tr>\r\n        <tr>\r\n            <td>Gender</td>\r\n            <td>");
#nullable restore
#line 53 "C:\Users\Ragini\Desktop\IBS\IBS\IBS.PresentationLayer\Views\Admin\Index.cshtml"
           Write(Model.Gender);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n            <td rowspan=\"11\"></td>\r\n        </tr>\r\n        <tr>\r\n            <td>Father\'s Name</td>\r\n            <td>");
#nullable restore
#line 58 "C:\Users\Ragini\Desktop\IBS\IBS\IBS.PresentationLayer\Views\Admin\Index.cshtml"
           Write(Model.FathersName);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n            <td rowspan=\"11\"></td>\r\n        </tr>\r\n        <tr>\r\n            <td>Mother\'s Name</td>\r\n            <td>");
#nullable restore
#line 63 "C:\Users\Ragini\Desktop\IBS\IBS\IBS.PresentationLayer\Views\Admin\Index.cshtml"
           Write(Model.MothersName);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n            <td rowspan=\"11\"></td>\r\n        </tr>\r\n        <tr>\r\n            <td>Address</td>\r\n            <td>");
#nullable restore
#line 68 "C:\Users\Ragini\Desktop\IBS\IBS\IBS.PresentationLayer\Views\Admin\Index.cshtml"
           Write(Model.Address);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n            <td rowspan=\"11\"></td>\r\n        </tr>\r\n        <tr>\r\n            <td>PinCode</td>\r\n            <td>");
#nullable restore
#line 73 "C:\Users\Ragini\Desktop\IBS\IBS\IBS.PresentationLayer\Views\Admin\Index.cshtml"
           Write(Model.Pincode);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n            <td rowspan=\"11\"></td>\r\n        </tr>\r\n\r\n    </table>\r\n</div>");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<ApplicationUser> Html { get; private set; }
    }
}
#pragma warning restore 1591
