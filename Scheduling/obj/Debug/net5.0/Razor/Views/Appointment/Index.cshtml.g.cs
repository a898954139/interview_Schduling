#pragma checksum "C:\Users\a8989\OneDrive\桌面\ASP.Net\Scheduling\Scheduling\Views\Appointment\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "c5efca8ae2e69c4c21dd1022b9121c42ff32b17b"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Appointment_Index), @"mvc.1.0.view", @"/Views/Appointment/Index.cshtml")]
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
#line 1 "C:\Users\a8989\OneDrive\桌面\ASP.Net\Scheduling\Scheduling\Views\_ViewImports.cshtml"
using Scheduling;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\a8989\OneDrive\桌面\ASP.Net\Scheduling\Scheduling\Views\_ViewImports.cshtml"
using Scheduling.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"c5efca8ae2e69c4c21dd1022b9121c42ff32b17b", @"/Views/Appointment/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"adb72943db91b94fc42e6f5b350f3b07a498016e", @"/Views/_ViewImports.cshtml")]
    public class Views_Appointment_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("<div class=\"row\">\r\n    <div class=\"container\">\r\n");
#nullable restore
#line 3 "C:\Users\a8989\OneDrive\桌面\ASP.Net\Scheduling\Scheduling\Views\Appointment\Index.cshtml"
         if (User.IsInRole(Scheduling.Utility.Helper.Admin))
        {

#line default
#line hidden
#nullable disable
            WriteLiteral("            <div class=\"form-group row col-2\" id=\"divDoctorList\">\r\n                <label> Select Doctor </label>\r\n                ");
#nullable restore
#line 7 "C:\Users\a8989\OneDrive\桌面\ASP.Net\Scheduling\Scheduling\Views\Appointment\Index.cshtml"
           Write(Html.DropDownList("divDoctorList", new SelectList(ViewBag.DoctorList, "ID", "Name")));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </div>\r\n");
#nullable restore
#line 9 "C:\Users\a8989\OneDrive\桌面\ASP.Net\Scheduling\Scheduling\Views\Appointment\Index.cshtml"
        }

#line default
#line hidden
#nullable disable
            WriteLiteral("    </div>\r\n</div>");
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
