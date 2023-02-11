#pragma checksum "C:\Ayaz Practice\TP_API\TP_UI2\Views\Home\ManageUsers.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "64130c8a6f6ecc707009269ae7c28de3d63ccfe3"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Home_ManageUsers), @"mvc.1.0.view", @"/Views/Home/ManageUsers.cshtml")]
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
#line 1 "C:\Ayaz Practice\TP_API\TP_UI2\Views\_ViewImports.cshtml"
using Microsoft.AspNetCore.Http;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Ayaz Practice\TP_API\TP_UI2\Views\_ViewImports.cshtml"
using Microsoft.Extensions.Configuration;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "C:\Ayaz Practice\TP_API\TP_UI2\Views\_ViewImports.cshtml"
using TP_UI2;

#line default
#line hidden
#nullable disable
#nullable restore
#line 4 "C:\Ayaz Practice\TP_API\TP_UI2\Views\_ViewImports.cshtml"
using TP_UI2.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"64130c8a6f6ecc707009269ae7c28de3d63ccfe3", @"/Views/Home/ManageUsers.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"cfaebe5931482682b7539322bf968f42a3a626d6", @"/Views/_ViewImports.cshtml")]
    #nullable restore
    public class Views_Home_ManageUsers : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    #nullable disable
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("action", new global::Microsoft.AspNetCore.Html.HtmlString("/action_page.php modal"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
            WriteLiteral(@"<style>
    .fa-square-check {
        color: green;
    }

    .fa-circle-xmark {
        background-color: green;
    }
</style>
<div class=""card"">
    <div class=""card-body"">
        <div class=""row"">
            <div class=""col-md-10""></div>
            <div class=""col-md-2"">
                <button id=""btnUser"" class=""btn btn-primary"" data-toggle=""modal"" data-target=""#myModal"">Add User</button>
            </div>
        </div>
    </div>
</div>
<div class=""card"">
    <div class=""card-body"">
        <div class=""row"">
            <div class=""col-md-12"">
                <table id=""tblUser"" class=""table table-striped table-bordered"">
                    <thead>
                        <tr>
                            <th>Name</th>
                            <th>Email Id</th>
                            <th>Role</th>
                            <th>Active</th>
                        </tr>
                    </thead>
                    <tbody></tbody>
                </tab");
            WriteLiteral(@"le>
            </div>
        </div>
    </div>
</div>

<div class=""modal"" id=""myModal"">
        <div class=""modal-dialog"">
            <div class=""modal-content"">
                <div class=""modal-header"">
                    <h3>User Details</h3>
                    <button type=""button"" class=""close"" data-dismiss=""modal"">&times;</button>
                </div>
                <div class=""modal-body"">
                    ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "64130c8a6f6ecc707009269ae7c28de3d63ccfe35467", async() => {
                WriteLiteral(@"
                        <div class=""form-group"">
                            <label for=""name"">User Name</label>
                            <input type=""text"" class=""form-control"" id=""txtUserName"" placeholder=""Enter Name"" name=""name"" required>
                        </div>
                        <div class=""form-group"">
                            <label for=""email"">Email:</label>
                            <input type=""email"" class=""form-control"" id=""txtEmail"" placeholder=""Enter email"" name=""email"" required>
                        </div>
                        <div class=""form-group"">
                            <label for=""pwd"">Password:</label>
                            <input type=""password"" class=""form-control"" id=""txtPwd"" placeholder=""Enter password"" name=""pswd"" required>
                        </div>
                        <button type=""button"" class=""btn btn-primary"" onclick=""SaveUser()"">Submit</button>
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
            WriteLiteral("\r\n                </div>\r\n            </div>\r\n        </div>\r\n</div>\r\n");
            DefineSection("Scripts", async() => {
                WriteLiteral(@"
<script>
   $(document).ready(function(){
        GetAllUsers();
    })
    $(document).on('keyup','input[id^=txt]',function(){
        if($(this).val().trim()){
            $(this).removeClass('is-invalid');
        }else{
            $(this).addClass('is-invalid');
        }
    });
    function GetAllUsers(){
        $(""#tblUser"").dataTable({
            ""ajax"":{
                url: baseUrl + ""tp/GetAllUsers"",
                type:""GET"",
                dataType:""JSON"",
                contentType:""application/json"",
                async:false,
                dataSrc:""""
            },
            ""columns"":[
            {""data"":""name""},
            {""data"":""email""},
            {
                ""data"":null,
                ""render"":function(a,b,c){
                    if(c.role==1)
                    return 'Admin'
                    else
                    return 'Test Creater'
                }

            },
            {
                ""data"":null,
       ");
                WriteLiteral(@"         ""render"":function(a,b,c){
                    return c.isActive ? `<i class=""fa-solid fa-square-check""></i>`:`<i class=""fa-solid fa-circle-xmark""></i>`
                }
            }
            ]
        })
    }
    function SaveUser(){
        var isValid = true;
        if(!$('#txtUserName').val().trim()){
            $('#txtUserName').addClass('is-invalid');
            isValid=false;
        }
        if(!$('#txtEmail').val().trim()){
            $('#txtEmail').addClass('is-invalid');
            isValid=false;
        }
        if(!$('#txtPwd').val().trim()){
            $('#txtPwd').addClass('is-invalid');
            isValid=false;
        }
        if(!isValid){
            return;
        }
        var obj={
            name:$(""#txtUserName"").val(),
            email:$(""#txtEmail"").val(),
            password:$(""#txtPwd"").val()
        }
        $.ajax({
            url: baseUrl + ""tp/SaveUser"",
            type:""POST"",
            contentType:""application/");
                WriteLiteral(@"json"",
            async:false,
            data:JSON.stringify(obj),
            success:function(resp){
                Swal.fire('Saved','User Saved Sucessfuly','success');
                $(""#txtUserName"").val('');
                $(""#txtEmail"").val('');
                $(""#txtPwd"").val('');
                $(""#myModal"").modal('hide');
            },
            error:function(err){
                Swal.fire('OOPS','Something Went Wrong','error');
            }
        })
    }
</script>
");
            }
            );
            WriteLiteral("\r\n");
        }
        #pragma warning restore 1998
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public IHttpContextAccessor _hca { get; private set; } = default!;
        #nullable disable
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public IConfiguration _config { get; private set; } = default!;
        #nullable disable
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