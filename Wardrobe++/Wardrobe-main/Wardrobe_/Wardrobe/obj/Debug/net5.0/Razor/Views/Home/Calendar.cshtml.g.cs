#pragma checksum "C:\Users\Michal\Documents\GitHub\Wardrobe\Wardrobe++\Wardrobe-main\Wardrobe_\Wardrobe\Views\Home\Calendar.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "ce65c34f37b724fde8982f5425d4e0dcf5c26fc8"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Home_Calendar), @"mvc.1.0.view", @"/Views/Home/Calendar.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"ce65c34f37b724fde8982f5425d4e0dcf5c26fc8", @"/Views/Home/Calendar.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"95f9d87e664cdd2be4ec77523879bb197efd0b0b", @"/Views/_ViewImports.cshtml")]
    public class Views_Home_Calendar : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IEnumerable<MvcEvent.Models.Event>>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\n");
#nullable restore
#line 3 "C:\Users\Michal\Documents\GitHub\Wardrobe\Wardrobe++\Wardrobe-main\Wardrobe_\Wardrobe\Views\Home\Calendar.cshtml"
   ViewData["Title"] = "Calendar";

                var events = (IEnumerable<MvcEvent.Models.Event>)ViewData["events"];
                var length = events.Count(); 

#line default
#line hidden
#nullable disable
            WriteLiteral("\n<table id=\"todoTable\">\n");
#nullable restore
#line 9 "C:\Users\Michal\Documents\GitHub\Wardrobe\Wardrobe++\Wardrobe-main\Wardrobe_\Wardrobe\Views\Home\Calendar.cshtml"
     for (int i = 0; i < length; i++)
    {

#line default
#line hidden
#nullable disable
            WriteLiteral("<tr>\n    <td>");
#nullable restore
#line 12 "C:\Users\Michal\Documents\GitHub\Wardrobe\Wardrobe++\Wardrobe-main\Wardrobe_\Wardrobe\Views\Home\Calendar.cshtml"
   Write(Html.Encode(events.ElementAt(i).Id));

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\n    <td>");
#nullable restore
#line 13 "C:\Users\Michal\Documents\GitHub\Wardrobe\Wardrobe++\Wardrobe-main\Wardrobe_\Wardrobe\Views\Home\Calendar.cshtml"
   Write(Html.Encode(events.ElementAt(i).Title));

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\n    <td>");
#nullable restore
#line 14 "C:\Users\Michal\Documents\GitHub\Wardrobe\Wardrobe++\Wardrobe-main\Wardrobe_\Wardrobe\Views\Home\Calendar.cshtml"
   Write(Html.Encode(events.ElementAt(i).StartDate));

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\n</tr>");
#nullable restore
#line 15 "C:\Users\Michal\Documents\GitHub\Wardrobe\Wardrobe++\Wardrobe-main\Wardrobe_\Wardrobe\Views\Home\Calendar.cshtml"
     }

#line default
#line hidden
#nullable disable
            WriteLiteral(@"</table>


<div class=""calendarContainer"">
    <div id=""calendar""></div>
</div>

<link rel=""stylesheet"" href=""https://cdn.jsdelivr.net/npm/fullcalendar@5.1.0/main.min.css"">
<script src=""https://cdn.jsdelivr.net/npm/fullcalendar@5.1.0/main.min.js""></script>

<script>let eventsArr = loadData();
    let calendar = initCalendar();

    function loadData() {
        let eventsArr = [];

        let todoTable = document.getElementById(""todoTable"");
        let trElem = todoTable.getElementsByTagName(""tr"");
        console.log(trElem);
        for (let tr of trElem) {
            console.log(tr);
            let tdElems = tr.getElementsByTagName(""td"");
            let eventObj = {
                id: tdElems[0].innerText,
                title: tdElems[1].innerText,
                start: tdElems[2].innerText,
            }

            eventsArr.push(eventObj);
        }

        return eventsArr;
    }

    function initCalendar() {
        var calendarEl = document.getElementById('calendar');

        let calenda");
            WriteLiteral(@"r = new FullCalendar.Calendar(calendarEl, {
        initialView: 'dayGridMonth',
        headerToolbar: {
            left: 'prev,next today',
            center: 'title',
            right: 'dayGridMonth,timeGridWeek,timeGridDay'
        },
        events: eventsArr,
    });

    calendar.render();

    return calendar;
    }</script>
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IEnumerable<MvcEvent.Models.Event>> Html { get; private set; }
    }
}
#pragma warning restore 1591
