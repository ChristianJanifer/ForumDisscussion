#pragma checksum "D:\METRODATA CODING CAMP\GitHub\ForumDisscussion\API-Forum\Client\Views\Home\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "0767c5ea092da91dfabf33e2975fdf61835d4f14"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Home_Index), @"mvc.1.0.view", @"/Views/Home/Index.cshtml")]
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
#line 1 "D:\METRODATA CODING CAMP\GitHub\ForumDisscussion\API-Forum\Client\Views\_ViewImports.cshtml"
using Client;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "D:\METRODATA CODING CAMP\GitHub\ForumDisscussion\API-Forum\Client\Views\_ViewImports.cshtml"
using Client.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"0767c5ea092da91dfabf33e2975fdf61835d4f14", @"/Views/Home/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"3332004e6f18ccbec22253d7e177fe1fd5f40969", @"/Views/_ViewImports.cshtml")]
    public class Views_Home_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 1 "D:\METRODATA CODING CAMP\GitHub\ForumDisscussion\API-Forum\Client\Views\Home\Index.cshtml"
  
    ViewData["Title"] = "Home Page";
    Layout = "_LayoutLanding";

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
<section class=""my-5"">
    <div class=""container bg-white p-4"">
        <div class=""row d-flex justify-content-between p-3"">
            <div class=""pl-2 text-body font-weight-bold"">
                <h4>Forum Discussion</h4>
            </div>
        </div>
        <div class=""container"" id=""diskusi"">
        </div>
        <div class=""container"">
            <h6 class=""h5 font-weight-bold"">Comments</h6>
            <div class=""container"" id=""tampilKomen"">

            </div>
        </div>
    </div>
</section>");
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
