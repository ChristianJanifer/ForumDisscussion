#pragma checksum "C:\Users\Buala Hulu\Documents\GitHub\ForumDisscussion\API-Forum\Client\Views\Discussions\LihatDiskusi.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "74a5a91c703584396d0d4ceaa00031144b0a4622"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Discussions_LihatDiskusi), @"mvc.1.0.view", @"/Views/Discussions/LihatDiskusi.cshtml")]
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
#line 4 "C:\Users\Buala Hulu\Documents\GitHub\ForumDisscussion\API-Forum\Client\Views\Discussions\LihatDiskusi.cshtml"
using Microsoft.AspNetCore.Http;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"74a5a91c703584396d0d4ceaa00031144b0a4622", @"/Views/Discussions/LihatDiskusi.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"3332004e6f18ccbec22253d7e177fe1fd5f40969", @"/Views/_ViewImports.cshtml")]
    public class Views_Discussions_LihatDiskusi : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("id", new global::Microsoft.AspNetCore.Html.HtmlString("formComment"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
#nullable restore
#line 7 "C:\Users\Buala Hulu\Documents\GitHub\ForumDisscussion\API-Forum\Client\Views\Discussions\LihatDiskusi.cshtml"
  
    Layout = "_LayoutMember";

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
<section class=""my-5"">
    <div class=""container bg-white p-4"">
        <h6 class=""hid""></h6>
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
                    <div c");
            WriteLiteral(@"lass=""dropdown-menu py-3 mt-0"" aria-labelledby=""dropdownMenuButton"">
                        <div class=""row"">
                            <div class=""col-2"">
                                <ul class=""list-group"">
                                    <li class=""list-item""><span class=""badge badge-danger""><i class=""fas fa-burn"">HOT!</i><button class=""btn"" onclick=""getTrend()"">Hot Tread!</button></span></li>
                                    <li class=""list-item""><span class=""badge badge-info""><i class=""fas fa-bullhorn"">NEW!</i><button class=""btn"" onclick=""getNewThread()"">New Thread!</button></span></li>
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

                    <div class=""co");
            WriteLiteral(@"llapse"" id=""postKomen"">
                        <section class=""new-topic my-5"">
                            <div class=""container bg-white p-4"">
                                <div class=""row d-flex justify-content-between p-3"">
                                    <div");
            BeginWriteAttribute("class", " class=\"", 2571, "\"", 2579, 0);
            EndWriteAttribute();
            WriteLiteral(@">
                                        <img src=""/page/img/message_icon2.png"" class=""img-fluid"">
                                        <span class=""pl-2 text-body font-weight-bold"">Create Comment</span>
                                    </div>
                                </div>
                                <div class=""form py-3"">
                                    ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "74a5a91c703584396d0d4ceaa00031144b0a46227167", async() => {
                WriteLiteral(@"
                                        <div class=""form-group"">
                                            <label for=""formInputContentComment"">Content Comment</label>
                                            <input type=""text"" class=""form-control"" id=""contentComment"" name=""contentComment"" placeholder=""Content Comment"">
                                        </div>
                                        <div class=""form-row"">
                                            <div class=""form-group col-md-6"">
                                                <label for=""formInputDateComment"">Date Comment</label>
                                                <input type=""date"" class=""form-control"" id=""dateCom"" name=""dateCom"" placeholder=""DateCom"">
                                            </div>
                                            <div class=""form-group col-md-6"">
                                                <label for=""formInputUserId"">Name User</label>
                              ");
                WriteLiteral("                  <input type=\"text\" class=\"form-control\" id=\"user\" name=\"user\" placeholder=\"UserId\"");
                BeginWriteAttribute("value", " value=\"", 4115, "\"", 4182, 1);
#nullable restore
#line 77 "C:\Users\Buala Hulu\Documents\GitHub\ForumDisscussion\API-Forum\Client\Views\Discussions\LihatDiskusi.cshtml"
WriteAttributeValue("", 4123, HttpContextAccessor.HttpContext.Session.GetInt32("UserId"), 4123, 59, false);

#line default
#line hidden
#nullable disable
                EndWriteAttribute();
                WriteLiteral(@" disabled>
                                            </div>
                                        </div>
                                        <div class=""form-row"">
                                            <div class=""form-group col-md-4"">
                                                <label for=""formInputDiscussionId"">Content Discussion</label>
                                                <input type=""text"" class=""form-control"" id=""dis"" name=""dis"" placeholder=""DisId"" disabled>
                                            </div>
                                        </div>
                                        <div class=""row d-flex justify-content-end mt-4 px-3"">
                                            <button type=""button"" class=""btn btn-warning"" onclick=""validComment()"">Add Comment</button>
                                            <button type=""button"" class=""btn btn-danger"" onclick=window.location.reload();>Close</button>
                                        </div>");
                WriteLiteral("\n                                    ");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral(@"
                                </div>
                            </div>
                        </section>
                    </div>
                    <div class=""container"" id=""tampilKomen"">

                    </div>
                </div>
            </div>
        </div> 
    </div>
</section>");
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
