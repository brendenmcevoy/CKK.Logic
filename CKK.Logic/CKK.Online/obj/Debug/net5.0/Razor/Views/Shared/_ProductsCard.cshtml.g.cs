#pragma checksum "C:\Users\beanwater\Source\Repos\brendenmcevoy\CKK.Logic\CKK.Logic\CKK.Online\Views\Shared\_ProductsCard.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "84d8d688557355905f1631268e18c0e745667d74"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Shared__ProductsCard), @"mvc.1.0.view", @"/Views/Shared/_ProductsCard.cshtml")]
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
#line 1 "C:\Users\beanwater\Source\Repos\brendenmcevoy\CKK.Logic\CKK.Logic\CKK.Online\Views\_ViewImports.cshtml"
using CKK.Online;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\beanwater\Source\Repos\brendenmcevoy\CKK.Logic\CKK.Logic\CKK.Online\Views\_ViewImports.cshtml"
using CKK.Online.Models;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "C:\Users\beanwater\Source\Repos\brendenmcevoy\CKK.Logic\CKK.Logic\CKK.Online\Views\_ViewImports.cshtml"
using CKK.Logic.Models;

#line default
#line hidden
#nullable disable
#nullable restore
#line 4 "C:\Users\beanwater\Source\Repos\brendenmcevoy\CKK.Logic\CKK.Logic\CKK.Online\Views\_ViewImports.cshtml"
using CKK.DB.Repository;

#line default
#line hidden
#nullable disable
#nullable restore
#line 5 "C:\Users\beanwater\Source\Repos\brendenmcevoy\CKK.Logic\CKK.Logic\CKK.Online\Views\_ViewImports.cshtml"
using CKK.DB.Interfaces;

#line default
#line hidden
#nullable disable
#nullable restore
#line 6 "C:\Users\beanwater\Source\Repos\brendenmcevoy\CKK.Logic\CKK.Logic\CKK.Online\Views\_ViewImports.cshtml"
using CKK.DB.UOW;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"84d8d688557355905f1631268e18c0e745667d74", @"/Views/Shared/_ProductsCard.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"2191cae952594633bfe722b36a1ab682521c9beb", @"/Views/_ViewImports.cshtml")]
    #nullable restore
    public class Views_Shared__ProductsCard : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<Product>
    #nullable disable
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("<div class=\"card\" style\"width: 18 rem; padding: 5px;\">\r\n    <div class=\"card-body\">\r\n        <h5 class=\"card-title text-center\">");
#nullable restore
#line 4 "C:\Users\beanwater\Source\Repos\brendenmcevoy\CKK.Logic\CKK.Logic\CKK.Online\Views\Shared\_ProductsCard.cshtml"
                                      Write(Model.Name);

#line default
#line hidden
#nullable disable
            WriteLiteral("</h5>\r\n        <p class=\"card-text\">");
#nullable restore
#line 5 "C:\Users\beanwater\Source\Repos\brendenmcevoy\CKK.Logic\CKK.Logic\CKK.Online\Views\Shared\_ProductsCard.cshtml"
                        Write(Model.Price.ToString("c"));

#line default
#line hidden
#nullable disable
            WriteLiteral("</p>\r\n        <p class=\"card-text\">Quantity Avalible: ");
#nullable restore
#line 6 "C:\Users\beanwater\Source\Repos\brendenmcevoy\CKK.Logic\CKK.Logic\CKK.Online\Views\Shared\_ProductsCard.cshtml"
                                           Write(Model.Quantity);

#line default
#line hidden
#nullable disable
            WriteLiteral("</p>\r\n        <br />\r\n    </div>\r\n</div>\r\n<div class=\"card-footer\">\r\n    <input class=\"num-spinner\"");
            BeginWriteAttribute("id", " id=\"", 385, "\"", 407, 2);
            WriteAttributeValue("", 390, "spinner-", 390, 8, true);
#nullable restore
#line 11 "C:\Users\beanwater\Source\Repos\brendenmcevoy\CKK.Logic\CKK.Logic\CKK.Online\Views\Shared\_ProductsCard.cshtml"
WriteAttributeValue("", 398, Model.Id, 398, 9, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" style=\"padding: 10px; width: 75%;\"\r\n    type=\"number\" value=\"0\" min=\"0\"");
            BeginWriteAttribute("max", " max=\"", 480, "\"", 501, 1);
#nullable restore
#line 12 "C:\Users\beanwater\Source\Repos\brendenmcevoy\CKK.Logic\CKK.Logic\CKK.Online\Views\Shared\_ProductsCard.cshtml"
WriteAttributeValue("", 486, Model.Quantity, 486, 15, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" step=\"1\"/>\r\n</div>");
        }
        #pragma warning restore 1998
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.IModelExpressionProvider ModelExpressionProvider { get; private set; } = default!;
        #nullable disable
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IUrlHelper Url { get; private set; } = default!;
        #nullable disable
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IViewComponentHelper Component { get; private set; } = default!;
        #nullable disable
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IJsonHelper Json { get; private set; } = default!;
        #nullable disable
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<Product> Html { get; private set; } = default!;
        #nullable disable
    }
}
#pragma warning restore 1591
