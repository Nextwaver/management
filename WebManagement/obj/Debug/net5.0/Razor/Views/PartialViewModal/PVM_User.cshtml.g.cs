#pragma checksum "D:\dotnet_core\GITHUB\management\WebManagement\Views\PartialViewModal\PVM_User.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "6824d1d764ee29de9e37f9a65e240edcb14a5e7c"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_PartialViewModal_PVM_User), @"mvc.1.0.view", @"/Views/PartialViewModal/PVM_User.cshtml")]
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
#line 1 "D:\dotnet_core\GITHUB\management\WebManagement\Views\_ViewImports.cshtml"
using WebManagement;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "D:\dotnet_core\GITHUB\management\WebManagement\Views\_ViewImports.cshtml"
using WebManagement.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"6824d1d764ee29de9e37f9a65e240edcb14a5e7c", @"/Views/PartialViewModal/PVM_User.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"b5bec0fbef87e7889213c13e4888e9ab541fb33d", @"/Views/_ViewImports.cshtml")]
    #nullable restore
    public class Views_PartialViewModal_PVM_User : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<Account>
    #nullable disable
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("value", "", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("ng-value", new global::Microsoft.AspNetCore.Html.HtmlString("x.CODE"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("ng-repeat", new global::Microsoft.AspNetCore.Html.HtmlString("x in POSITION"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.OptionTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
#nullable restore
#line 3 "D:\dotnet_core\GITHUB\management\WebManagement\Views\PartialViewModal\PVM_User.cshtml"
 using (Html.BeginForm(FormMethod.Post, new { @id = "CNform" }))
{
    

#line default
#line hidden
#nullable disable
#nullable restore
#line 5 "D:\dotnet_core\GITHUB\management\WebManagement\Views\PartialViewModal\PVM_User.cshtml"
Write(Html.HiddenFor(model => model.ID, new { id = "ID" }));

#line default
#line hidden
#nullable disable
#nullable restore
#line 6 "D:\dotnet_core\GITHUB\management\WebManagement\Views\PartialViewModal\PVM_User.cshtml"
Write(Html.HiddenFor(model => model.SpaceUser, new { id = "SPACE_USER" }));

#line default
#line hidden
#nullable disable
            WriteLiteral(@"    <div class=""widget-box transparent"">
        <!-- #section:custom/widget-box.options -->
        <div class=""widget-header"">
            <h5 class=""widget-title bigger lighter"">
                <i class=""ace-icon fa fa-user""></i>
                ข้อมูลทั่วไป
            </h5>
        </div>
        <!-- /section:custom/widget-box.options -->
        <table style=""width:100%"">
            <tr><td colspan=""5"" style=""height:20px""></td></tr>
            <tr>
                <td style=""width:20px""></td>
                <td><label>คำนำหน้า</label></td>
                <td style=""width:5px""></td>
");
            WriteLiteral("                <td>\r\n                    ");
#nullable restore
#line 25 "D:\dotnet_core\GITHUB\management\WebManagement\Views\PartialViewModal\PVM_User.cshtml"
               Write(Html.TextBoxFor(model => model.Titile, new { @class = "form-control", id = "txb_title", placeholder = "คำนำหน้า" }));

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
                </td>
                <td style=""width:20px""></td>
            </tr>
            <tr><td colspan=""5"" style=""height:5px""></td></tr>
            <tr>
                <td style=""width:20px""></td>
                <td><label>ชื่อ</label></td>
                <td style=""width:5px""></td>
");
            WriteLiteral("                <td>\r\n                    ");
#nullable restore
#line 37 "D:\dotnet_core\GITHUB\management\WebManagement\Views\PartialViewModal\PVM_User.cshtml"
               Write(Html.TextBoxFor(model => model.FirstName, new { @class = "form-control", id = "txb_firstName", placeholder = "ชื่อ" }));

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
                </td>
                <td style=""width:20px""></td>
            </tr>
            <tr><td colspan=""5"" style=""height:5px""></td></tr>
            <tr>
                <td style=""width:20px""></td>
                <td><label>นามสกุล</label></td>
                <td style=""width:5px""></td>
");
            WriteLiteral("                <td>\r\n                    ");
#nullable restore
#line 49 "D:\dotnet_core\GITHUB\management\WebManagement\Views\PartialViewModal\PVM_User.cshtml"
               Write(Html.TextBoxFor(model => model.LastName, new { @class = "form-control", id = "txb_lastName", placeholder = "นามสกุล" }));

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
                </td>
                <td style=""width:20px""></td>
            </tr>
            <tr><td colspan=""5"" style=""height:5px""></td></tr>
            <tr>
                <td style=""width:20px""></td>
                <td><label>ตำแหน่ง</label></td>
                <td style=""width:5px""></td>
                <td>
                    <select id=""position"" class=""multiselect"" style=""width:100%"">
                        ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("option", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "6824d1d764ee29de9e37f9a65e240edcb14a5e7c7885", async() => {
                WriteLiteral("-- โปรดเลือก --");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.OptionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper.Value = (string)__tagHelperAttribute_0.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n");
            WriteLiteral("                        ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("option", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "6824d1d764ee29de9e37f9a65e240edcb14a5e7c9108", async() => {
                WriteLiteral("\r\n                            Administrator\r\n                        ");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.OptionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_1);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_2);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral(@"
                    </select>
                </td>
                <td style=""width:20px""></td>
            </tr>
            <tr><td colspan=""5"" style=""height:20px""></td></tr>
        </table>
    </div>
    <div class=""widget-box transparent"">
        <!-- #section:custom/widget-box.options -->
        <div class=""widget-header"">
            <h5 class=""widget-title bigger lighter"">
                <i class=""ace-icon fa fa-cog""></i>
                ข้อมูลระบบ
            </h5>
        </div>
        <!-- /section:custom/widget-box.options -->
        <div class=""widget-body"">
            <table style=""width:100%"">
                <tr><td colspan=""5"" style=""height:20px""></td></tr>
                <tr>
                    <td style=""width:20px""></td>
                    <td><label>ชื่อผู้ใช้งาน</label></td>
                    <td style=""width:5px""></td>
");
            WriteLiteral("                    <td>\r\n                        ");
#nullable restore
#line 94 "D:\dotnet_core\GITHUB\management\WebManagement\Views\PartialViewModal\PVM_User.cshtml"
                   Write(Html.TextBoxFor(model => model.Username, new { @class = "form-control", id = "txb_username", placeholder = "UserName" }));

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
                    </td>
                    <td style=""width:20px""></td>
                </tr>
                <tr><td colspan=""5"" style=""height:5px""></td></tr>
                <tr>
                    <td style=""width:20px""></td>
                    <td><label>รหัสผ่าน</label></td>
                    <td style=""width:5px""></td>
");
            WriteLiteral("                    <td>\r\n                        ");
#nullable restore
#line 106 "D:\dotnet_core\GITHUB\management\WebManagement\Views\PartialViewModal\PVM_User.cshtml"
                   Write(Html.TextBoxFor(model => model.Password, new { @class = "form-control", type = "password", id = "txb_password", placeholder = "Password" }));

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
                    </td>
                    <td style=""width:20px""></td>
                </tr>
                <tr><td colspan=""5"" style=""height:5px""></td></tr>
                <tr>
                    <td style=""width:20px""></td>
                    <td><label>ยืนยันรหัสผ่าน</label></td>
                    <td style=""width:5px""></td>
");
            WriteLiteral("                    <td>\r\n                        ");
#nullable restore
#line 118 "D:\dotnet_core\GITHUB\management\WebManagement\Views\PartialViewModal\PVM_User.cshtml"
                   Write(Html.TextBoxFor(model => model.Password_cof, new { @class = "form-control", type = "password", id = "txb_password_cof", placeholder = "Password" }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                    </td>\r\n                    <td style=\"width:20px\"></td>\r\n                </tr>\r\n                <tr><td colspan=\"5\" style=\"height:20px\"></td></tr>\r\n            </table>\r\n        </div>\r\n    </div>\r\n");
#nullable restore
#line 126 "D:\dotnet_core\GITHUB\management\WebManagement\Views\PartialViewModal\PVM_User.cshtml"
}

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n");
            WriteLiteral(@"
<script type=""text/javascript"">
    var ID, url, SPACE_USER;
 
    function StartPratialView(_url) {
        url = _url;
        ID = getParamValue(url, ""ID"");
        SPACE_USER = getParamValue(url, ""SPACE_USER"");

        $(""#ID"").val(ID);
        $(""#SPACE_USER"").val(SPACE_USER);
        if (ID != null) fnLoadDataUser(ID);
    }

    function LoadDataPosition() {
        //$.ajax({
        //    type: 'GET',
        //    cache: false,
        //    url: '/Account/LoadDataUser',
        //    data: ""ID="" + ID,
        //    success: function (data, textStatus, jqXHR) {
        //        if (data._ErrorMessageModel.code == ""OK"") {
        //            $(""#title"").val(data.titile);
        //            $(""#firstName"").val(data.firstName);
        //            $(""#lastName"").val(data.lastName);
        //            $(""#position"").val(data.position);
        //            $(""#username"").val(data.username);
        //            $(""#password"").val(data.password);
        //     ");
            WriteLiteral(@"       $(""#password_cof"").val(data.password);
        //        }
        //        else {
        //            showmessage(data._ErrorMessageModel.message);
        //        }
        //    },
        //    error: function (jqXHR, textStatus, errorThrown) {
        //        showmessage(jqXHR, textStatus, errorThrown);
        //    }
        //});
    }
    function fnLoadDataUser(ID) {
        $.ajax({
            type: 'GET',
            cache: false,
            url: '/Account/LoadDataUser',
            data: ""ID="" + ID,
            success: function (data, textStatus, jqXHR) {
                if (data._ErrorMessageModel.code == ""OK"") {
                    $(""#txb_title"").val(data.titile);
                    $(""#txb_firstName"").val(data.firstName);
                    $(""#txb_lastName"").val(data.lastName);
                    $(""#txb_position"").val(data.position);
                    $(""#txb_username"").val(data.username);
                    $(""#txb_password"").val(data.password");
            WriteLiteral(@");
                    $(""#txb_password_cof"").val(data.password);
                    $(""#txb_username"").attr(""disabled"", true);

                    if (SPACE_USER != ""WS"" && SPACE_USER != null) {
                        $(""#txb_username"").attr(""disabled"", true);
                        $(""#txb_password"").attr(""disabled"", true);
                        $(""#txb_password_cof"").attr(""disabled"", true);
                    }
                }
                else {
                    showmessage(data._ErrorMessageModel.message);
                }
            },
            error: function (jqXHR, textStatus, errorThrown) {
                showmessage(jqXHR, textStatus, errorThrown);
            }
        });
    }
    function SaveUser() {
        var ERROR = document.getElementById('ERROR');
        ERROR.innerHTML = """";
 
        if ($(""#txb_title"").val() == """") {
            ERROR.innerHTML = ""โปรดระบุตำแหน่ง"";
            return;
        }
        if ($(""#txb_username"").val() == """"");
            WriteLiteral(@") {
            ERROR.innerHTML = ""โปรดระบุชื่อผู้ใช้งาน"";
            return;
        }
        if ($(""#txb_password"").val() == """") {
            ERROR.innerHTML = ""โปรดระบุรหัสผ่าน"";
            return;
        }
        if ($(""#txb_password_cof"").val() == """") {
            ERROR.innerHTML = ""โปรดระบุยืนยันรหัสผ่าน"";
            return;
        }
        if ($(""#txb_password"").val() != $(""#txb_password_cof"").val()) {
            ERROR.innerHTML = ""รหัสผ่าน และ ยืนยันรหัสผ่าน ต้องเหมือนกัน"";
            return;
        }

        var data = $('#CNform').serialize();
        fnLoadingModal();
        $.ajax({
            type: 'POST',
            cache: false,
            url: '/Account/SaveUser',
            data: data,
            success: function (data, textStatus, jqXHR) {
                if (data._ErrorMessageModel.code == ""OK"")
                    showmessage(data._ErrorMessageModel.message, refreshAllData);
                else {
                    ERROR.innerHTML = data._");
            WriteLiteral("ErrorMessageModel.message;\r\n                    fnUnLoadingModal();\r\n                }\r\n            },\r\n            error: function (jqXHR, textStatus, errorThrown) {\r\n\r\n            }\r\n        });\r\n    }\r\n\r\n</script>\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<Account> Html { get; private set; } = default!;
        #nullable disable
    }
}
#pragma warning restore 1591
