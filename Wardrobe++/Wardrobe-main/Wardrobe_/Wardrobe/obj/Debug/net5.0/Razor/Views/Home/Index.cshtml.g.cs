#pragma checksum "C:\Users\Michal\Documents\GitHub\Wardrobe\Wardrobe++\Wardrobe-main\Wardrobe_\Wardrobe\Views\Home\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "3cec799292ba7328e8deef60b4d8fdbe290433e5"
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
#line 1 "C:\Users\Michal\Documents\GitHub\Wardrobe\Wardrobe++\Wardrobe-main\Wardrobe_\Wardrobe\Views\_ViewImports.cshtml"
using Wardrobe;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\Michal\Documents\GitHub\Wardrobe\Wardrobe++\Wardrobe-main\Wardrobe_\Wardrobe\Views\_ViewImports.cshtml"
using Wardrobe.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"3cec799292ba7328e8deef60b4d8fdbe290433e5", @"/Views/Home/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"95f9d87e664cdd2be4ec77523879bb197efd0b0b", @"/Views/_ViewImports.cshtml")]
    public class Views_Home_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<ClothesSearchModel>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("btn btn-sm btn-outline-secondary"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Details", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.ImageTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_ImageTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\n");
#nullable restore
#line 3 "C:\Users\Michal\Documents\GitHub\Wardrobe\Wardrobe++\Wardrobe-main\Wardrobe_\Wardrobe\Views\Home\Index.cshtml"
   ViewData["Title"] = "Index"; 

#line default
#line hidden
#nullable disable
            WriteLiteral("\n<h2>Sklep</h2>\n\n");
            WriteLiteral("\n");
            WriteLiteral("<div id=\"wielka\" class=\"d-flex flex-wrap\" style=\"margin-top:0 auto\">\n");
#nullable restore
#line 59 "C:\Users\Michal\Documents\GitHub\Wardrobe\Wardrobe++\Wardrobe-main\Wardrobe_\Wardrobe\Views\Home\Index.cshtml"
     foreach (var item in Model.Cloths)
    {
  

#line default
#line hidden
#nullable disable
            WriteLiteral("    <div id=\"karta\" class=\"card d-flex flex-column\" style=\"width: 300px; margin: 10px auto;\">\n\n        <div class=\"card-body \" style=\"margin-top: 20px; margin: auto;\">\n            ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("img", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "3cec799292ba7328e8deef60b4d8fdbe290433e54845", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_ImageTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.ImageTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_ImageTagHelper);
            BeginWriteTagHelperAttribute();
#nullable restore
#line 65 "C:\Users\Michal\Documents\GitHub\Wardrobe\Wardrobe++\Wardrobe-main\Wardrobe_\Wardrobe\Views\Home\Index.cshtml"
           WriteLiteral("~/image/" + item.CoverImageUrl);

#line default
#line hidden
#nullable disable
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __Microsoft_AspNetCore_Mvc_TagHelpers_ImageTagHelper.Src = __tagHelperStringValueBuffer;
            __tagHelperExecutionContext.AddTagHelperAttribute("src", __Microsoft_AspNetCore_Mvc_TagHelpers_ImageTagHelper.Src, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
#nullable restore
#line 65 "C:\Users\Michal\Documents\GitHub\Wardrobe\Wardrobe++\Wardrobe-main\Wardrobe_\Wardrobe\Views\Home\Index.cshtml"
__Microsoft_AspNetCore_Mvc_TagHelpers_ImageTagHelper.AppendVersion = true;

#line default
#line hidden
#nullable disable
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-append-version", __Microsoft_AspNetCore_Mvc_TagHelpers_ImageTagHelper.AppendVersion, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\n\n\n        </div>\n        <div id=\"title\">\n            ");
#nullable restore
#line 70 "C:\Users\Michal\Documents\GitHub\Wardrobe\Wardrobe++\Wardrobe-main\Wardrobe_\Wardrobe\Views\Home\Index.cshtml"
       Write(Html.DisplayFor(modelItem => item.Title));

#line default
#line hidden
#nullable disable
            WriteLiteral("\n        </div>\n        <div id=\"desc\">\n            ");
#nullable restore
#line 73 "C:\Users\Michal\Documents\GitHub\Wardrobe\Wardrobe++\Wardrobe-main\Wardrobe_\Wardrobe\Views\Home\Index.cshtml"
       Write(Html.DisplayFor(modelItem => item.Description));

#line default
#line hidden
#nullable disable
            WriteLiteral("\n        </div>\n        <div class=\" mt-auto btn-group\">\n            ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "3cec799292ba7328e8deef60b4d8fdbe290433e57692", async() => {
                WriteLiteral("Zapytaj o zakup");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_1.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
            if (__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
            {
                throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-id", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
            }
            BeginWriteTagHelperAttribute();
#nullable restore
#line 76 "C:\Users\Michal\Documents\GitHub\Wardrobe\Wardrobe++\Wardrobe-main\Wardrobe_\Wardrobe\Views\Home\Index.cshtml"
                                                                               WriteLiteral(item.Id);

#line default
#line hidden
#nullable disable
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"] = __tagHelperStringValueBuffer;
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-route-id", __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"], global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\n        </div>\n    </div>\n");
#nullable restore
#line 79 "C:\Users\Michal\Documents\GitHub\Wardrobe\Wardrobe++\Wardrobe-main\Wardrobe_\Wardrobe\Views\Home\Index.cshtml"
       
       
        }

#line default
#line hidden
#nullable disable
            WriteLiteral(@"    </div>





<script>
    function myFunction() {
        var x = document.getElementById(""Tabelka"");
        if (x.style.display === ""none"") {
            x.style.display = ""block"";
        } else {
            x.style.display = ""none"";
        }
    }
</script>

<script>
    function myFunction1() {
        var x = document.getElementById(""Tabelka2"");
        if (x.style.display === ""none"") {
            x.style.display = ""block"";
        } else {
            x.style.display = ""none"";
        }
    }
</script>



<style>

    img {
        vertical-align: middle;
        border-style: none;
        width: 250px;
        height: 497px;
        align-items: center;
    }


    .container {
        max-width: -webkit-fill-available;
        margin-left: 5%;
        
        
    }
    #desc {
        text-align: center;
        font-family: serif;
    }

    #title {
        font-family: cursive;
        font-size: 16px;
        text-align: center;
        margin-top: 5px;
        margin-bottom: 5px;
    }
");
            WriteLiteral(@"    #karta {
     
    }
    #wielka {
        background-color: #f8f9fa !important;
    }
    #Tabelka {
        background-color: #f8f9fa !important;
    }
    #Tabelka2 {
        background-color: #f8f9fa !important;
        
            
    }
    #srodek {
        text-align: center;
    }
     

</style>


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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<ClothesSearchModel> Html { get; private set; }
    }
}
#pragma warning restore 1591
