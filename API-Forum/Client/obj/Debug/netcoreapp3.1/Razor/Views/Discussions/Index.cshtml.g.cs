#pragma checksum "C:\Users\Buala Hulu\Documents\GitHub\ForumDisscussion\API-Forum\Client\Views\Discussions\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "deaf45efe8f8d34813415596bdb72deb8c2b0ecf"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Discussions_Index), @"mvc.1.0.view", @"/Views/Discussions/Index.cshtml")]
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
#line 1 "C:\Users\Buala Hulu\Documents\GitHub\ForumDisscussion\API-Forum\Client\Views\_ViewImports.cshtml"
using Client;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\Buala Hulu\Documents\GitHub\ForumDisscussion\API-Forum\Client\Views\_ViewImports.cshtml"
using Client.Models;

#line default
#line hidden
#nullable disable
#nullable restore
#line 4 "C:\Users\Buala Hulu\Documents\GitHub\ForumDisscussion\API-Forum\Client\Views\Discussions\Index.cshtml"
using Microsoft.AspNetCore.Http;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"deaf45efe8f8d34813415596bdb72deb8c2b0ecf", @"/Views/Discussions/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"3332004e6f18ccbec22253d7e177fe1fd5f40969", @"/Views/_ViewImports.cshtml")]
    public class Views_Discussions_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
#nullable restore
#line 7 "C:\Users\Buala Hulu\Documents\GitHub\ForumDisscussion\API-Forum\Client\Views\Discussions\Index.cshtml"
  
    Layout = "_LayoutMember";

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n<section class=\"my-5\">\r\n    <div class=\"container bg-white p-4\">\r\n        <div class=\"row d-flex justify-content-between p-3\">\r\n            <div class=\"pl-2 text-body font-weight-bold\">\r\n                <h6 class=\"text-hide\" id=\"userId\">");
#nullable restore
#line 15 "C:\Users\Buala Hulu\Documents\GitHub\ForumDisscussion\API-Forum\Client\Views\Discussions\Index.cshtml"
                                             Write(HttpContextAccessor.HttpContext.Session.GetInt32("UserId"));

#line default
#line hidden
#nullable disable
            WriteLiteral(@"</h6>
                <h4>List Diskusi User</h4>
            </div>
        </div>
        <div class=""container"" id=""diskusi1"">
        </div>
        <div class=""container"">
            <div class=""container"" id=""jumlahKomen1"">

            </div>
            <div class=""container"" id=""tampilKomen1"">

            </div>
        </div>
    </div>
</section>


");
        }
        #pragma warning restore 1998
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public IHttpContextAccessor HttpContextAccessor { get; private set; }
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
