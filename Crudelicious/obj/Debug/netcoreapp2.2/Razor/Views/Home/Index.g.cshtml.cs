#pragma checksum "/Users/nickhuang/Documents/c_sharp/Crudelicious/Views/Home/Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "c85b27d7a8832e2ed33aec3cf1d4f3305909f2f6"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Home_Index), @"mvc.1.0.view", @"/Views/Home/Index.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/Home/Index.cshtml", typeof(AspNetCore.Views_Home_Index))]
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
#line 1 "/Users/nickhuang/Documents/c_sharp/Crudelicious/Views/_ViewImports.cshtml"
using Crudelicious;

#line default
#line hidden
#line 2 "/Users/nickhuang/Documents/c_sharp/Crudelicious/Views/_ViewImports.cshtml"
using Crudelicious.Models;

#line default
#line hidden
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"c85b27d7a8832e2ed33aec3cf1d4f3305909f2f6", @"/Views/Home/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"64c0db40c4c91a29aacfb134c187d6cf7f912d39", @"/Views/_ViewImports.cshtml")]
    public class Views_Home_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#line 1 "/Users/nickhuang/Documents/c_sharp/Crudelicious/Views/Home/Index.cshtml"
  
    ViewData["Title"] = "CRUDelicious | Home";

#line default
#line hidden
            BeginContext(55, 223, true);
            WriteLiteral("<br>\r\n<br>\r\n<div class=\"contaner text-center\">\r\n    <h3>Welcome to CRUDelicious!</h3>\r\n    <br>\r\n\r\n     <div class=\"row\">\r\n         <div class=\"col\">\r\n             <h4>Check out some recent dishes!</h4>\r\n             <hr>\r\n");
            EndContext();
#line 14 "/Users/nickhuang/Documents/c_sharp/Crudelicious/Views/Home/Index.cshtml"
              foreach(var dish in ViewBag.Dishes)
             {

#line default
#line hidden
            BeginContext(345, 42, true);
            WriteLiteral("                <p>\r\n                   <a");
            EndContext();
            BeginWriteAttribute("href", " href=\"", 387, "\"", 411, 2);
            WriteAttributeValue("", 394, "view/", 394, 5, true);
#line 17 "/Users/nickhuang/Documents/c_sharp/Crudelicious/Views/Home/Index.cshtml"
WriteAttributeValue("", 399, dish.DishId, 399, 12, false);

#line default
#line hidden
            EndWriteAttribute();
            BeginContext(412, 1, true);
            WriteLiteral(">");
            EndContext();
            BeginContext(414, 9, false);
#line 17 "/Users/nickhuang/Documents/c_sharp/Crudelicious/Views/Home/Index.cshtml"
                                          Write(dish.Name);

#line default
#line hidden
            EndContext();
            BeginContext(423, 9, true);
            WriteLiteral(" </a> by ");
            EndContext();
            BeginContext(433, 9, false);
#line 17 "/Users/nickhuang/Documents/c_sharp/Crudelicious/Views/Home/Index.cshtml"
                                                             Write(dish.Chef);

#line default
#line hidden
            EndContext();
            BeginContext(442, 26, true);
            WriteLiteral(" \r\n                </p> \r\n");
            EndContext();
#line 19 "/Users/nickhuang/Documents/c_sharp/Crudelicious/Views/Home/Index.cshtml"
             }

#line default
#line hidden
            BeginContext(484, 126, true);
            WriteLiteral("         </div>\r\n         <div class=\"col\">\r\n             <a href=\"new\">Add a Dish</a>\r\n         </div>\r\n     </div>\r\n\r\n</div>");
            EndContext();
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