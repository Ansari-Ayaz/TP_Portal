#pragma checksum "C:\Ayaz Practice\TP_API\TP_UI2\Views\Home\CreateSchedule.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "0ec1e8f074b24911abbd44b2e0284351f986f24d"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Home_CreateSchedule), @"mvc.1.0.view", @"/Views/Home/CreateSchedule.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"0ec1e8f074b24911abbd44b2e0284351f986f24d", @"/Views/Home/CreateSchedule.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"cfaebe5931482682b7539322bf968f42a3a626d6", @"/Views/_ViewImports.cshtml")]
    #nullable restore
    public class Views_Home_CreateSchedule : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    #nullable disable
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral(@"<style>
    .rowBr {
        margin-bottom: 10px;
    }
</style>
<div class=""card"">
    <div class=""card-body"">
        <div class=""row"">
            <div class=""col-md-3"">
                <label>Test Name</label>
                <input id=""txtTestName"" class=""form-control"" disabled />
            </div>
            <div class=""col-md-3"">
                <label>Start Time</label>
                <input id=""txtStartTime"" class=""form-control"" placeholder=""Enter Start Time"" type=""date"" />
            </div>
            <div class=""col-md-3"">
                <label>End Time</label>
                <input id=""txtEndTime"" class=""form-control"" placeholder=""Enter Stop Time"" type=""date"" />
            </div>
            <div class=""col-md-3"">
                <button id=""btnSave"" type=""button"" class=""btn btn-primary"" style=""margin-top:1.9rem"" onclick=""SaveSchCand()"">Submit</button>
            </div>
        </div>
    </div>
</div>
<div>
    <div class=""card"">
        <div id=""divMain"" clas");
            WriteLiteral(@"s=""card-body"">
            <div class=""row"">
                <div class=""col-md-8"">
                    <table id=""tblCand"" class=""table table-striped"">
                        <thead>
                            <tr>
                                <th>Email</th>
                                <th>Name</th>
                            </tr>
                        </thead>
                        <tbody>
                        </tbody>
                    </table>
                </div>
            </div>
        </div>
    </div>
</div>
<template id=""tmplMain"">
    <tr>
        <td>
            <input type=""text"" placeholder=""Enter Email"" class=""form-control email"" />
        </td>
        <td>
            <input type=""text"" placeholder=""Enter Name"" class=""form-control name"" />
        </td>
        <td class=""tdAdd""><button class=""btn btn-primary btnAdd"">Add</button></td>
        <td id=""tdRmv""><button class=""btn btn-danger btnRmv"">Remove</button></td>
    </tr>
</template>
");
            WriteLiteral("\r\n<template id=\"tmplAdd\">\r\n    <button class=\"btn btn-primary btnAdd\">Add</button>\r\n</template>\r\n\r\n<template id=\"tmplRmv\">\r\n    <button class=\"btn btn-danger btnRmv\">Remove</button>\r\n</template>\r\n\r\n");
            DefineSection("Scripts", async() => {
                WriteLiteral(@"
<script>
    var params = new URLSearchParams(window.location.search)
    var id = params.get('Id')
    var testName = params.get('TestName')
    $(document).ready(function(){
        $(""tbody"").append($(""#tmplMain"").html());
        $(""#divMain tbody .btnRmv "").remove();
        $(""#txtTestName"").val(testName)
    })

    function SaveSchCand(){
        var obj={
            testId:parseInt(id),
            testName:testName,
            userId:user.UserId,
            startTime:$('#txtStartTime').val(),
            endTime:$('#txtEndTime').val(),
            candidates:[]
            }
            $('tbody tr').each(function(){
                var cand = {
                    email:$(this).find($('.email')).val(),
                    name:$(this).find($('.name')).val()
                }
              obj.candidates.push(cand);
            })

        $.ajax({
            url:baseUrl + ""tp/SaveSchCandDetail"",
            type:""POST"",
            contentType:""application/json"",");
                WriteLiteral(@"
            async:false,
            data:JSON.stringify(obj),
            success:function(resp){
                Swal.fire('Done','Saved Successfully','success');
            },
            error:function(err){
                Swal.fire('OOPS','Failed To Saved','error');
            }

        })
    }

    $(document).on('click','.btnAdd',function(){
        var y = $(this).closest($('tbody')).find($('.btnRmv')).length
        console.log(y)
        if(y<1){
            $(this).closest($('tbody')).find($('td')).last().prepend($('#tmplRmv').html())
        }
        $(""tbody"").append($(""#tmplMain"").html());
        $(this).remove();

    })
    $(document).on('click','.btnRmv',function(){

        $(this).closest($('tr')).remove();
        var z = $('#divInput .col-md-4').last().find('.btnAdd').length
        console.log(z);
        if($('tbody tr').last().find($('.btnAdd')).length<1){
            $(""tbody tr"").last().find($('.tdAdd')).append($('#tmplAdd').html())
        }
 ");
                WriteLiteral("       if($(\'tbody tr\').length==1){\r\n            $(\"tbody tr td\").last().find($(\'.btnRmv\')).remove();\r\n        }\r\n    })\r\n</script>\r\n");
            }
            );
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
