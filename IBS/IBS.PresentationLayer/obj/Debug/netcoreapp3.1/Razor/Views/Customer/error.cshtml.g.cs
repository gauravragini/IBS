#pragma checksum "C:\Users\Ragini\Desktop\IBS\IBS\IBS.PresentationLayer\Views\Customer\error.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "088fae67ae69cb45b2ff1c6a6bae18b7d024a805"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Customer_error), @"mvc.1.0.view", @"/Views/Customer/error.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"088fae67ae69cb45b2ff1c6a6bae18b7d024a805", @"/Views/Customer/error.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"f7b73252c3fc50cdf6a74240d91a548653a9dd55", @"/Views/_ViewImports.cshtml")]
    public class Views_Customer_error : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
#nullable restore
#line 2 "C:\Users\Ragini\Desktop\IBS\IBS\IBS.PresentationLayer\Views\Customer\error.cshtml"
  
    ViewData["Title"] = "error";
    Layout = "~/Views/Customer/_LayoutCustomer.cshtml";

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n<br>\r\n<div class=\"fail\">\r\n    <h4>OOPS !!! Transaction Failed</h4>\r\n    <br />\r\n    <p style=\"color:darkblue;font-weight:bolder\">Please try to fix the error and try again Later</p>\r\n    ");
#nullable restore
#line 12 "C:\Users\Ragini\Desktop\IBS\IBS\IBS.PresentationLayer\Views\Customer\error.cshtml"
Write(ViewData["error"]);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n</div>\r\n\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<dynamic> Html { get; private set; }
    }
}
#pragma warning restore 1591
