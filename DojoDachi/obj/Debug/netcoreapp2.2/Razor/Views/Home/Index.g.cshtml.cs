#pragma checksum "/Users/nickhuang/Documents/c_sharp/DojoDachi/Views/Home/Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "82de25991ca6e9bbc90a3e341941a77786cfb741"
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
#line 1 "/Users/nickhuang/Documents/c_sharp/DojoDachi/Views/_ViewImports.cshtml"
using DojoDachi;

#line default
#line hidden
#line 2 "/Users/nickhuang/Documents/c_sharp/DojoDachi/Views/_ViewImports.cshtml"
using DojoDachi.Models;

#line default
#line hidden
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"82de25991ca6e9bbc90a3e341941a77786cfb741", @"/Views/Home/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"9bce70f5dafba3f05b5d94a87a662fc8c5511826", @"/Views/_ViewImports.cshtml")]
    public class Views_Home_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            BeginContext(0, 110, true);
            WriteLiteral("<div class=\"container text-center\">\r\n    <div class=\"text-center\">\r\n       <h4 class=\"text-warning\">Fullness: ");
            EndContext();
            BeginContext(111, 16, false);
#line 3 "/Users/nickhuang/Documents/c_sharp/DojoDachi/Views/Home/Index.cshtml"
                                     Write(ViewBag.Fullness);

#line default
#line hidden
            EndContext();
            BeginContext(127, 14, true);
            WriteLiteral(" | Happiness: ");
            EndContext();
            BeginContext(142, 17, false);
#line 3 "/Users/nickhuang/Documents/c_sharp/DojoDachi/Views/Home/Index.cshtml"
                                                                    Write(ViewBag.Happiness);

#line default
#line hidden
            EndContext();
            BeginContext(159, 10, true);
            WriteLiteral(" | Meals: ");
            EndContext();
            BeginContext(170, 13, false);
#line 3 "/Users/nickhuang/Documents/c_sharp/DojoDachi/Views/Home/Index.cshtml"
                                                                                                Write(ViewBag.Meals);

#line default
#line hidden
            EndContext();
            BeginContext(183, 11, true);
            WriteLiteral(" | Energy: ");
            EndContext();
            BeginContext(195, 14, false);
#line 3 "/Users/nickhuang/Documents/c_sharp/DojoDachi/Views/Home/Index.cshtml"
                                                                                                                         Write(ViewBag.Energy);

#line default
#line hidden
            EndContext();
            BeginContext(209, 348, true);
            WriteLiteral(@"</h4> 
    </div>
    <div class=""col"">
        <img class=""img-thumbnail"" src=""https://media1.popsugar-assets.com/files/thumbor/A_VYzA4mzM8ejer76bRVFXqoX_4/fit-in/2048xorig/filters:format_auto-!!-:strip_icc-!!-/2019/05/19/206/n/44498184/tmp_bZsd3X_b6d3c64c3bff43e3_Courtesy_of_HBO_6_.jpg"" alt=""Dragon Image""> 
        <h4 class=""text-warning"">");
            EndContext();
            BeginContext(558, 15, false);
#line 7 "/Users/nickhuang/Documents/c_sharp/DojoDachi/Views/Home/Index.cshtml"
                            Write(ViewBag.Message);

#line default
#line hidden
            EndContext();
            BeginContext(573, 373, true);
            WriteLiteral(@"</h4>
    </div>
    <div>
        <h5><a href=""feed""><button class=""btn btn-outline-warning"">Feed</button></a> | <a href=""play""><button class=""btn btn-outline-warning"">Play</button></a> | <a href=""work""><button class=""btn btn-outline-warning"">Work</button></a> | <a href=""sleep""><button class=""btn btn-outline-warning"">Sleep</button></a> </h5>
    </div>
    
</div>");
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
