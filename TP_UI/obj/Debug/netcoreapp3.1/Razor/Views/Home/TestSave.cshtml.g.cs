#pragma checksum "C:\Ayaz Practice\TP_API\TP_UI\Views\Home\TestSave.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "7674b7f7cba4b81f718caf23c3e472ebd90dbb08"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Home_TestSave), @"mvc.1.0.view", @"/Views/Home/TestSave.cshtml")]
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
#line 1 "C:\Ayaz Practice\TP_API\TP_UI\Views\_ViewImports.cshtml"
using TP_UI;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Ayaz Practice\TP_API\TP_UI\Views\_ViewImports.cshtml"
using TP_UI.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"7674b7f7cba4b81f718caf23c3e472ebd90dbb08", @"/Views/Home/TestSave.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"b901fa9842bf59f10cf13dab24895051185057f3", @"/Views/_ViewImports.cshtml")]
    #nullable restore
    public class Views_Home_TestSave : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    #nullable disable
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("for"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "7674b7f7cba4b81f718caf23c3e472ebd90dbb083498", async() => {
                WriteLiteral(@"
    <div class=""row"">
        <div class=""col-md-12"">
            <label ><b>No.of Question</b></label>
            <input id=""txtTestName"" class=""form-control"" type=""text""/>
        </div>
    </div><br>
    <div class=""row"">
        <div class=""col-md-4"">
            <label ><b>No.of Question</b></label>
            <input id=""txtNoOfQues"" type=""text"" class=""form-control""/>
        </div>
        <div class=""col-md-4"">
            <label ><b>Points per Question</b></label>
            <input id=""txtPoPerQues"" type=""number"" class=""form-control""/>
        </div>
        <div class=""col-md-4"">
            <label ><b>Time Per Question</b></label>
            <input id=""txtTmPerQues"" type=""number"" class=""form-control""/>
        </div>
    </div><br>
    <div class=""row"">
        <div class=""col-md-2"">
            <button id=""btnTestSave"" class=""btn btn-primary"" type=""button"" onclick=""SaveTicket()"">Save</button>
        </div>
    </div>
    
");
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
            WriteLiteral("\r\n");
            DefineSection("Scripts", async() => {
                WriteLiteral(@"
    <script>
        $(document).ready(function(){

        })
        function SaveTicket(){
            var obj = {
                testName:$(""#txtTestName"").val(),
                no_Of_Q:parseInt($(""#txtNoOfQues"").val()),
                perQ_Point:parseInt($(""#txtPoPerQues"").val()),
                perQ_Time_Min:parseInt($(""#txtTmPerQues"").val()),
                }
                $.ajax({
                    url:""https://localhost:44327/api/TP/SaveTest"",
                    type:""POST"",
                    contentType:""application/json"",
                    data:JSON.stringify(obj),
                    async:false,
                    success:function(resp){
                        SwitchToQuestionScreen(resp.respObj);
                    },
                    error:function(err){
                       swal(""Something Went Wrong!"",""Test Not Save"",""error"")
                    }
                })
        }
        function SwitchToQuestionScreen(Id){
            window.loca");
                WriteLiteral("tion.href = window.location.origin + \"/Home/QuesOptSave/?Id=\"+Id;\r\n        }\r\n        \r\n        \r\n    </script>\r\n");
            }
            );
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<dynamic> Html { get; private set; } = default!;
        #nullable disable
    }
}
#pragma warning restore 1591
