#pragma checksum "C:\Users\Ragini\Desktop\IBS\IBS\IBS.PresentationLayer\Views\Customer\ViewTransactions.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "fc1b3f0101823c6aef4f544e0d1436fdd0377130"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Customer_ViewTransactions), @"mvc.1.0.view", @"/Views/Customer/ViewTransactions.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"fc1b3f0101823c6aef4f544e0d1436fdd0377130", @"/Views/Customer/ViewTransactions.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"f7b73252c3fc50cdf6a74240d91a548653a9dd55", @"/Views/_ViewImports.cshtml")]
    public class Views_Customer_ViewTransactions : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IEnumerable<IBS.EntitiesLayer.Models.Transaction>>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
#nullable restore
#line 3 "C:\Users\Ragini\Desktop\IBS\IBS\IBS.PresentationLayer\Views\Customer\ViewTransactions.cshtml"
  
    ViewData["Title"] = "Transactions";
    Layout = "~/Views/Customer/_LayoutCustomer.cshtml";

#line default
#line hidden
#nullable disable
            WriteLiteral("<hr />\r\n<h4><i>MY TRANSACTIONS</i></h4>\r\n<hr />\r\n<table id=\"myTable\" class=\"table table-striped table-responsive gridtable\" width=\"100%\">\r\n    <thead>\r\n        <tr>\r\n            <th class=\"th-sm\" width=\"10%\">\r\n                ");
#nullable restore
#line 14 "C:\Users\Ragini\Desktop\IBS\IBS\IBS.PresentationLayer\Views\Customer\ViewTransactions.cshtml"
           Write(Html.DisplayNameFor(model => model.TransactionId));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </th>\r\n            <th class=\"th-sm\" width=\"20%\">\r\n                ");
#nullable restore
#line 17 "C:\Users\Ragini\Desktop\IBS\IBS\IBS.PresentationLayer\Views\Customer\ViewTransactions.cshtml"
           Write(Html.DisplayNameFor(model => model.TransactionDateTime));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </th>\r\n            <th class=\"th-sm\" width=\"20%\">\r\n                ");
#nullable restore
#line 20 "C:\Users\Ragini\Desktop\IBS\IBS\IBS.PresentationLayer\Views\Customer\ViewTransactions.cshtml"
           Write(Html.DisplayNameFor(model => model.TransactionFrom));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </th>\r\n            <th class=\"th-sm\" width=\"20%\">\r\n                ");
#nullable restore
#line 23 "C:\Users\Ragini\Desktop\IBS\IBS\IBS.PresentationLayer\Views\Customer\ViewTransactions.cshtml"
           Write(Html.DisplayNameFor(model => model.TransactionTo));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </th>\r\n            <th class=\"th-sm\" width=\"10%\">\r\n                ");
#nullable restore
#line 26 "C:\Users\Ragini\Desktop\IBS\IBS\IBS.PresentationLayer\Views\Customer\ViewTransactions.cshtml"
           Write(Html.DisplayNameFor(model => model.Amount));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </th>\r\n            <th class=\"th-sm\" width=\"20%\">\r\n                ");
#nullable restore
#line 29 "C:\Users\Ragini\Desktop\IBS\IBS\IBS.PresentationLayer\Views\Customer\ViewTransactions.cshtml"
           Write(Html.DisplayNameFor(model => model.Status));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </th>\r\n\r\n        </tr>\r\n    </thead>\r\n    <tbody>\r\n");
#nullable restore
#line 35 "C:\Users\Ragini\Desktop\IBS\IBS\IBS.PresentationLayer\Views\Customer\ViewTransactions.cshtml"
         foreach (var item in Model)
        {

#line default
#line hidden
#nullable disable
            WriteLiteral("            <tr>\r\n                <td>\r\n                    ");
#nullable restore
#line 39 "C:\Users\Ragini\Desktop\IBS\IBS\IBS.PresentationLayer\Views\Customer\ViewTransactions.cshtml"
               Write(Html.DisplayFor(modelItem => item.TransactionId));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                </td>\r\n                <td>\r\n                    ( ");
#nullable restore
#line 42 "C:\Users\Ragini\Desktop\IBS\IBS\IBS.PresentationLayer\Views\Customer\ViewTransactions.cshtml"
                 Write(Html.DisplayFor(modelItem => item.TransactionDateTime));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                </td>\r\n                <td>\r\n                    ");
#nullable restore
#line 45 "C:\Users\Ragini\Desktop\IBS\IBS\IBS.PresentationLayer\Views\Customer\ViewTransactions.cshtml"
               Write(Html.DisplayFor(modelItem => item.TransactionFrom));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                </td>\r\n                <td>\r\n                    ");
#nullable restore
#line 48 "C:\Users\Ragini\Desktop\IBS\IBS\IBS.PresentationLayer\Views\Customer\ViewTransactions.cshtml"
               Write(Html.DisplayFor(modelItem => item.TransactionTo));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                </td>\r\n                <td>\r\n                    ");
#nullable restore
#line 51 "C:\Users\Ragini\Desktop\IBS\IBS\IBS.PresentationLayer\Views\Customer\ViewTransactions.cshtml"
               Write(Html.DisplayFor(modelItem => item.Amount));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                </td>\r\n                <td>\r\n                    ");
#nullable restore
#line 54 "C:\Users\Ragini\Desktop\IBS\IBS\IBS.PresentationLayer\Views\Customer\ViewTransactions.cshtml"
               Write(Html.DisplayFor(modelItem => item.Status));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                </td>\r\n            </tr>\r\n");
#nullable restore
#line 57 "C:\Users\Ragini\Desktop\IBS\IBS\IBS.PresentationLayer\Views\Customer\ViewTransactions.cshtml"
        }

#line default
#line hidden
#nullable disable
            WriteLiteral("    </tbody>\r\n</table>\r\n<br />\r\n\r\n<script>\r\n    $(document).ready(function () {\r\n        $(\'#myTable\').dataTable();\r\n    });\r\n</script>");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IEnumerable<IBS.EntitiesLayer.Models.Transaction>> Html { get; private set; }
    }
}
#pragma warning restore 1591
