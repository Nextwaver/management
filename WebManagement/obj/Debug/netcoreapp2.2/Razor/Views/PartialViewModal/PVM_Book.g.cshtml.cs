#pragma checksum "D:\ProjectWeb\WebNetCore\WebManagement\WebManagement\Views\PartialViewModal\PVM_Book.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "78f34b59582e5b2b278e993c7b1cc1e6306126bf"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_PartialViewModal_PVM_Book), @"mvc.1.0.view", @"/Views/PartialViewModal/PVM_Book.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/PartialViewModal/PVM_Book.cshtml", typeof(AspNetCore.Views_PartialViewModal_PVM_Book))]
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
#line 1 "D:\ProjectWeb\WebNetCore\WebManagement\WebManagement\Views\_ViewImports.cshtml"
using WebManagement;

#line default
#line hidden
#line 2 "D:\ProjectWeb\WebNetCore\WebManagement\WebManagement\Views\_ViewImports.cshtml"
using WebManagement.Models;

#line default
#line hidden
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"78f34b59582e5b2b278e993c7b1cc1e6306126bf", @"/Views/PartialViewModal/PVM_Book.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"b5bec0fbef87e7889213c13e4888e9ab541fb33d", @"/Views/_ViewImports.cshtml")]
    public class Views_PartialViewModal_PVM_Book : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<Book>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            BeginContext(13, 75, true);
            WriteLiteral("\r\n<style>\r\n    ._BlankRow {\r\n        min-height: 1rem;\r\n    }\r\n</style>\r\n\r\n");
            EndContext();
#line 9 "D:\ProjectWeb\WebNetCore\WebManagement\WebManagement\Views\PartialViewModal\PVM_Book.cshtml"
 using (Html.BeginForm(FormMethod.Post, new { @id = "CNform" }))
{
    

#line default
#line hidden
            BeginContext(162, 52, false);
#line 11 "D:\ProjectWeb\WebNetCore\WebManagement\WebManagement\Views\PartialViewModal\PVM_Book.cshtml"
Write(Html.HiddenFor(model => model.ID, new { id = "ID" }));

#line default
#line hidden
            EndContext();
            BeginContext(216, 116, true);
            WriteLiteral("    <div class=\"row\">\r\n        <div class=\"col-12 col-md-6\">\r\n            <label>เลขที่หนังสือ</label>\r\n            ");
            EndContext();
            BeginContext(333, 121, false);
#line 15 "D:\ProjectWeb\WebNetCore\WebManagement\WebManagement\Views\PartialViewModal\PVM_Book.cshtml"
       Write(Html.TextBoxFor(model => model.BookNo, new { @class = "form-control", id = "txb_BookNo", placeholder = "เลขที่หนังสือ" }));

#line default
#line hidden
            EndContext();
            BeginContext(454, 121, true);
            WriteLiteral("\r\n        </div>\r\n\r\n        <div class=\"col-12 col-md-6\">\r\n            <label for=\"form-field-8\">ปี</label>\r\n            ");
            EndContext();
            BeginContext(576, 121, false);
#line 20 "D:\ProjectWeb\WebNetCore\WebManagement\WebManagement\Views\PartialViewModal\PVM_Book.cshtml"
       Write(Html.TextBoxFor(model => model.BookYear, new { @class = "form-control", id = "txb_BookYear", placeholder = "ปี (พ.ศ.)" }));

#line default
#line hidden
            EndContext();
            BeginContext(697, 72, true);
            WriteLiteral("\r\n        </div>\r\n    </div>\r\n    <div class=\"_BlankRow col-12\"></div>\r\n");
            EndContext();
            BeginContext(771, 120, true);
            WriteLiteral("    <div class=\"row\">\r\n        <div class=\"col-12 col-md-6\">\r\n            <label>คำนำหน้าเลขทะบียน</label>\r\n            ");
            EndContext();
            BeginContext(892, 141, false);
#line 28 "D:\ProjectWeb\WebNetCore\WebManagement\WebManagement\Views\PartialViewModal\PVM_Book.cshtml"
       Write(Html.TextBoxFor(model => model.GunRegIDPrefix, new { @class = "form-control", id = "txb_GunRegIDPrefix", placeholder = "คำนำหน้าเลขทะบียน" }));

#line default
#line hidden
            EndContext();
            BeginContext(1033, 129, true);
            WriteLiteral("\r\n        </div>\r\n\r\n        <div class=\"col-12 col-md-6\">\r\n        </div>\r\n    </div>\r\n    <div class=\"_BlankRow col-12\"></div>\r\n");
            EndContext();
            BeginContext(1164, 121, true);
            WriteLiteral("    <div class=\"row\">\r\n        <div class=\"col-12 col-md-6\">\r\n            <label>เลขทะเบียนเริ่มต้น</label>\r\n            ");
            EndContext();
            BeginContext(1286, 140, false);
#line 39 "D:\ProjectWeb\WebNetCore\WebManagement\WebManagement\Views\PartialViewModal\PVM_Book.cshtml"
       Write(Html.TextBoxFor(model => model.GunRegIDStart, new { @class = "form-control", id = "txb_GunRegIDStart", placeholder = "เลขทะเบียนเริ่มต้น" }));

#line default
#line hidden
            EndContext();
            BeginContext(1426, 117, true);
            WriteLiteral("\r\n        </div>\r\n\r\n        <div class=\"col-12 col-md-6\">\r\n            <label>เลขทะเบียนสิ้นสุด</label>\r\n            ");
            EndContext();
            BeginContext(1544, 135, false);
#line 44 "D:\ProjectWeb\WebNetCore\WebManagement\WebManagement\Views\PartialViewModal\PVM_Book.cshtml"
       Write(Html.TextBoxFor(model => model.GunRegIDEnd, new { @class = "form-control", id = "txb_GunRegIDEnd", placeholder = "เลขทะเบียนสิ้นสุด" }));

#line default
#line hidden
            EndContext();
            BeginContext(1679, 72, true);
            WriteLiteral("\r\n        </div>\r\n    </div>\r\n    <div class=\"_BlankRow col-12\"></div>\r\n");
            EndContext();
            BeginContext(1753, 127, true);
            WriteLiteral("    <div class=\"row\">\r\n        <div class=\"col-12 col-md-6\">\r\n            <label>ประเภทอาวุธปืน(สั้น/ยาว)</label>\r\n            ");
            EndContext();
            BeginContext(1881, 136, false);
#line 52 "D:\ProjectWeb\WebNetCore\WebManagement\WebManagement\Views\PartialViewModal\PVM_Book.cshtml"
       Write(Html.TextBoxFor(model => model.GroupGun, new { @class = "form-control", id = "txb_GroupGun", placeholder = "ประเภทอาวุธปืน(สั้น/ยาว)" }));

#line default
#line hidden
            EndContext();
            BeginContext(2017, 116, true);
            WriteLiteral("\r\n        </div>\r\n\r\n        <div class=\"col-12 col-md-6\">\r\n            <label>จำนวนหน้าทั้งหมด</label>\r\n            ");
            EndContext();
            BeginContext(2134, 130, false);
#line 57 "D:\ProjectWeb\WebNetCore\WebManagement\WebManagement\Views\PartialViewModal\PVM_Book.cshtml"
       Write(Html.TextBoxFor(model => model.PageTotal, new { @class = "form-control", id = "txb_PageTotal", placeholder = "จำนวนหน้าทั้งหมด" }));

#line default
#line hidden
            EndContext();
            BeginContext(2264, 30, true);
            WriteLiteral("\r\n        </div>\r\n    </div>\r\n");
            EndContext();
#line 60 "D:\ProjectWeb\WebNetCore\WebManagement\WebManagement\Views\PartialViewModal\PVM_Book.cshtml"
}

#line default
#line hidden
            BeginContext(2297, 2109, true);
            WriteLiteral(@"
<script type=""text/javascript"">
    var ID;

    function StartPratialView(_url) {
        url = _url;
        ID = getParamValue(_url, ""ID"");
        $(""#ID"").val(ID);
        if (ID != null) fnLoadDataBook(ID);
    }

    function fnLoadDataBook(ID) {
        $.ajax({
            type: 'GET',
            cache: false,
            url: '/GunRegistration/LoadDataBook',
            data: ""ID="" + ID,
            success: function (data, textStatus, jqXHR) {
                if (data._ErrorMessageModel.code == ""OK"") {
                    $(""#txb_BookNo"").val(data.bookNo);
                    $(""#txb_BookYear"").val(data.bookYear);
                    $(""#txb_GunRegIDPrefix"").val(data.gunRegIDPrefix);
                    $(""#txb_GunRegIDStart"").val(data.gunRegIDStart);
                    $(""#txb_GunRegIDEnd"").val(data.gunRegIDEnd);
                    $(""#txb_GroupGun"").val(data.groupGun);
                    $(""#txb_PageTotal"").val(data.pageTotal);
                }
                els");
            WriteLiteral(@"e {
                    showmessage(data._ErrorMessageModel.message);
                }
            },
            error: function (jqXHR, textStatus, errorThrown) {
                showmessage(jqXHR, textStatus, errorThrown);
            }
        });
    }
    function SaveBook() {
        var ERROR = document.getElementById('ERROR');
        ERROR.innerHTML = """";

        var data = $('#CNform').serialize();
        fnLoadingModal();
        $.ajax({
            type: 'POST',
            cache: false,
            url: '/GunRegistration/SaveBook',
            data: data,
            success: function (data, textStatus, jqXHR) {
                if (data._ErrorMessageModel.code == ""OK"")
                    showmessage(data._ErrorMessageModel.message, refreshAllData);
                else {
                    ERROR.innerHTML = data._ErrorMessageModel.message;
                    fnUnLoadingModal();
                }
            },
            error: function (jqXHR, textStatus, err");
            WriteLiteral("orThrown) {\r\n\r\n            }\r\n        });\r\n    }\r\n</script>\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<Book> Html { get; private set; }
    }
}
#pragma warning restore 1591
