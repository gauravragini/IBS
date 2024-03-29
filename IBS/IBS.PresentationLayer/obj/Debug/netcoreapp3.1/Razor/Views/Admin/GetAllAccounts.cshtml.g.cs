#pragma checksum "C:\Users\Ragini\Desktop\IBS\IBS\IBS.PresentationLayer\Views\Admin\GetAllAccounts.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "d3d100993da33b88c28075eb7fb443c24601b9aa"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Admin_GetAllAccounts), @"mvc.1.0.view", @"/Views/Admin/GetAllAccounts.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"d3d100993da33b88c28075eb7fb443c24601b9aa", @"/Views/Admin/GetAllAccounts.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"f7b73252c3fc50cdf6a74240d91a548653a9dd55", @"/Views/_ViewImports.cshtml")]
    public class Views_Admin_GetAllAccounts : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IEnumerable<IBS.EntitiesLayer.Models.Account>>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
#nullable restore
#line 3 "C:\Users\Ragini\Desktop\IBS\IBS\IBS.PresentationLayer\Views\Admin\GetAllAccounts.cshtml"
  
    ViewData["Title"] = "AllAccounts";
    Layout = "~/Views/Admin/_LayoutAdmin.cshtml";

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n\r\n<hr />\r\n<h4><i>List Of Account Holders</i></h4>\r\n<hr />\r\n\r\n<table id=\"myTable\"class=\"table table-striped table-responsive gridtable\" style=\"background-color:white\">\r\n    <thead>\r\n        <tr>\r\n            <th style=\"width:30%\">\r\n                ");
#nullable restore
#line 17 "C:\Users\Ragini\Desktop\IBS\IBS\IBS.PresentationLayer\Views\Admin\GetAllAccounts.cshtml"
           Write(Html.DisplayNameFor(model => model.AccountNumber));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </th>\r\n            <th style=\"width:10%\">\r\n                ");
#nullable restore
#line 20 "C:\Users\Ragini\Desktop\IBS\IBS\IBS.PresentationLayer\Views\Admin\GetAllAccounts.cshtml"
           Write(Html.DisplayNameFor(model => model.AccountType));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </th>\r\n            <th style=\"width:10%\">\r\n                ");
#nullable restore
#line 23 "C:\Users\Ragini\Desktop\IBS\IBS\IBS.PresentationLayer\Views\Admin\GetAllAccounts.cshtml"
           Write(Html.DisplayNameFor(model => model.AvailableBalance));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </th>\r\n            <th style=\"width:10%\">\r\n                ");
#nullable restore
#line 26 "C:\Users\Ragini\Desktop\IBS\IBS\IBS.PresentationLayer\Views\Admin\GetAllAccounts.cshtml"
           Write(Html.DisplayNameFor(model => model.InterestAmount));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </th>\r\n            <th style=\"width:30%\">\r\n                ");
#nullable restore
#line 29 "C:\Users\Ragini\Desktop\IBS\IBS\IBS.PresentationLayer\Views\Admin\GetAllAccounts.cshtml"
           Write(Html.DisplayNameFor(model => model.AccountCreationTime));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </th>\r\n            <th style=\"width:10%\">Status</th>\r\n        </tr>\r\n    </thead>\r\n    <tbody>\r\n");
#nullable restore
#line 35 "C:\Users\Ragini\Desktop\IBS\IBS\IBS.PresentationLayer\Views\Admin\GetAllAccounts.cshtml"
         foreach (var item in Model)
        {

#line default
#line hidden
#nullable disable
            WriteLiteral("            <tr>\r\n                <td>\r\n                    ");
#nullable restore
#line 39 "C:\Users\Ragini\Desktop\IBS\IBS\IBS.PresentationLayer\Views\Admin\GetAllAccounts.cshtml"
               Write(Html.DisplayFor(modelItem => item.AccountNumber));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                </td>\r\n                <td>\r\n                    ");
#nullable restore
#line 42 "C:\Users\Ragini\Desktop\IBS\IBS\IBS.PresentationLayer\Views\Admin\GetAllAccounts.cshtml"
               Write(Html.DisplayFor(modelItem => item.AccountType));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                </td>\r\n                <td>\r\n                    ");
#nullable restore
#line 45 "C:\Users\Ragini\Desktop\IBS\IBS\IBS.PresentationLayer\Views\Admin\GetAllAccounts.cshtml"
               Write(Html.DisplayFor(modelItem => item.AvailableBalance));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                </td>\r\n                <td>\r\n                    ");
#nullable restore
#line 48 "C:\Users\Ragini\Desktop\IBS\IBS\IBS.PresentationLayer\Views\Admin\GetAllAccounts.cshtml"
               Write(Html.DisplayFor(modelItem => item.InterestAmount));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                </td>\r\n                <td>    \r\n                    ");
#nullable restore
#line 51 "C:\Users\Ragini\Desktop\IBS\IBS\IBS.PresentationLayer\Views\Admin\GetAllAccounts.cshtml"
               Write(Html.DisplayFor(modelItem => item.AccountCreationTime));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                </td>\r\n");
#nullable restore
#line 53 "C:\Users\Ragini\Desktop\IBS\IBS\IBS.PresentationLayer\Views\Admin\GetAllAccounts.cshtml"
                 if(item.AvailableBalance == 0)
                {

#line default
#line hidden
#nullable disable
            WriteLiteral("                <td>\r\n                    NOT OPEN\r\n                </td>\r\n");
#nullable restore
#line 58 "C:\Users\Ragini\Desktop\IBS\IBS\IBS.PresentationLayer\Views\Admin\GetAllAccounts.cshtml"
                }
                else
                {

#line default
#line hidden
#nullable disable
            WriteLiteral("                    <td>OPEN</td>\r\n");
#nullable restore
#line 62 "C:\Users\Ragini\Desktop\IBS\IBS\IBS.PresentationLayer\Views\Admin\GetAllAccounts.cshtml"
                }

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </tr>\r\n");
#nullable restore
#line 65 "C:\Users\Ragini\Desktop\IBS\IBS\IBS.PresentationLayer\Views\Admin\GetAllAccounts.cshtml"
        }

#line default
#line hidden
#nullable disable
            WriteLiteral("    </tbody>\r\n</table>\r\n<p class=\"text-muted\">**open Account = Customer has deposited the minimum of 1000.</p>\r\n<script>\r\n    $(document).ready(function () {\r\n        $(\'#myTable\').dataTable();\r\n    });\r\n</script>\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IEnumerable<IBS.EntitiesLayer.Models.Account>> Html { get; private set; }
    }
}
#pragma warning restore 1591
