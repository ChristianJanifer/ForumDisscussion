#pragma checksum "C:\Users\Buala Hulu\Documents\GitHub\ForumDisscussion\API-Forum\Client\Views\Users\Dashboard.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "38e0cf174134fa46521e13397581077b7139a5da"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Users_Dashboard), @"mvc.1.0.view", @"/Views/Users/Dashboard.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"38e0cf174134fa46521e13397581077b7139a5da", @"/Views/Users/Dashboard.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"3332004e6f18ccbec22253d7e177fe1fd5f40969", @"/Views/_ViewImports.cshtml")]
    public class Views_Users_Dashboard : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 1 "C:\Users\Buala Hulu\Documents\GitHub\ForumDisscussion\API-Forum\Client\Views\Users\Dashboard.cshtml"
  
    Layout = "_LayoutAdmin";

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
        <div class=""row"">
            <div class=""col-3"">
                <div class=""container"" id=""Category"">
                    <h5>Category</h5>
                    <div class=""card"">
                        <div class=""card-body"" id=""category"">

                        </div>
                    </div>

                </div>
            </div>
            <div class=""col"">
                <div class=""dropdown mx-2"">
                    <button class=""btn"" type=""button"" data-toggle=""dropdown"" aria-haspopup=""true"" aria-expanded=""false"">
                        Choose Today!
                        <i class=""fas fa-chevron-down pl-2""></i>
                    </button>
                    <div class=""dropdown-menu py-3 mt-0"" ");
            WriteLiteral(@"aria-labelledby=""dropdownMenuButton"">
                        <div class=""row"">
                            <div class=""col-2"">
                                <ul class=""list-group"">
                                    <li class=""list-item""><button class=""btn"" onclick=""getTrend()"">Hot Tread!</button></li>
                                    <li class=""list-item""><button class=""btn"" onclick=""getNewThread()"">New Threa!</button></li>
                                </ul>
                            </div>
                        </div>
                    </div>
                </div>
                <div class=""container"" id=""diskusi"">
                </div>
                <div class=""container"">
                    <div class=""container"" id=""jumlahKomen"">

                    </div>
                    <div class=""container"" id=""tampilKomen"">

                    </div>
                </div>
            </div>
        </div>
    </div>
</section>
");
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
