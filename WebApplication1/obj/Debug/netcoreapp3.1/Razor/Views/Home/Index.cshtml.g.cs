#pragma checksum "/Users/gozdemogus/Desktop/UpSchool_SignalR_Api/WebApplication1/Views/Home/Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "df1522067fef655ad3c2c77b31ea141bcfc60e95"
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
#line 1 "/Users/gozdemogus/Desktop/UpSchool_SignalR_Api/WebApplication1/Views/_ViewImports.cshtml"
using WebApplication1;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "/Users/gozdemogus/Desktop/UpSchool_SignalR_Api/WebApplication1/Views/_ViewImports.cshtml"
using WebApplication1.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"df1522067fef655ad3c2c77b31ea141bcfc60e95", @"/Views/Home/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"729efaa87342638aecfe1a972ce9f9f8dff55b4c", @"/Views/_ViewImports.cshtml")]
    #nullable restore
    public class Views_Home_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    #nullable disable
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("src", new global::Microsoft.AspNetCore.Html.HtmlString("~/lib/microsoft/signalr/dist/browser/signalr.min.js"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 1 "/Users/gozdemogus/Desktop/UpSchool_SignalR_Api/WebApplication1/Views/Home/Index.cshtml"
  
    ViewData["Title"] = "Home Page";

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("script", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "df1522067fef655ad3c2c77b31ea141bcfc60e953702", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n\r\n");
            DefineSection("Scripts", async() => {
                WriteLiteral(@"
    <script type=""text/javascript"">


        $(document).ready(() => {

            var connection = new signalR.HubConnectionBuilder().withAutomaticReconnect([1000, 2000, 3000, 8000]).withUrl(""https://localhost:5001/MyHub"").build();

            function statusShow() {
                $(""#conStatus"").text(connection.connectionState);
            }
           
            statusShow();

            connection.start().then(() => {
                statusShow();
                $(""#loading"").hide();
                connection.invoke(""GetNames"");
            }).catch((err) => { console.log(err) });

            $(""#btnSave"").click(() => {
                connection.invoke(""SendName"", $(""#txtName"").val())
                    .catch((err) => {console.log(err)})
            })

            connection.on(""ReceiveName"", (name) => {
                /*console.log(name);*/
                $(""#namesList"").append(`<li class=""list-group-item"">${name}</li>`)
            })

            connect");
                WriteLiteral(@"ion.onreconnecting(err => {
                $(""#loading"").show();
                statusShow();
                console.log(err);
            })

            connection.onreconnected(err => {
                $(""#loading"").hide();
                statusShow();
                console.log(err);
            })

            //baglanmaya cal??s??rken method ismi de??il, icindeki ReceiveClientCount gibi olan ilk parametre

            connection.on(""ReceiveClientCount"", (ClientCount) => {
                $(""#clientCount"").text(ClientCount);
            })

            connection.on(""Notify"", (countText) => {
                $(""#notify"").html(`<div class=""alert alert-success"">${countText}</div>`);
            })

            connection.on(""Error"", (errorText) => {
                alert(errorText);
            })


            //eski isimleri de g??rebilecek

            connection.on(""ReceiveNames"", (names) => {
                $(""#namesList"").empty();
                names.forEach((item, inde");
                WriteLiteral(@"x) => {
                    $(""#namesList"").append(`<li class=""list-group-item"">${item}</li>`);
                })
            })

            $(""#btnroomname"").click(() => {
                let name = $(""#txtName"").val();
                let roomname = $(""input[type=radio]:checked"").val();

                if (roomname == null) {
                    alert(""L??tfen sehir secimi yap??n??z."");
                } else {
                    connection.invoke(""SendNameByGroup"", name, roomname).cathc((err) => {
                        console.log(err);
                    });
                }
            })

            connection.on(""ReceiveMessageByGroup"", (name, roomID) => {
                let listName;
                if (roomID == 1) {
                    listName = ""AnkaraRoomList""
                } else {
                    listName=""BursaRoomList""
                }
                $(`#${listName}`).append(`<li class=""list-group-item"">${name}</li>`)
            })

            $(""input[type=radio]"").c");
                WriteLiteral(@"hange(() => {
                let value = $(`input[type=radio]:checked`).val();
                if (value == ""Ankara"")
                {
                    connection.invoke(""AddToGroup"", value);
                    connection.invoke(""RemoveToGroup"", ""Bursa"");
                } else
                {
                    connection.invoke(""AddToGroup"", value);
                    connection.invoke(""RemoveToGroup"", ""Ankara"");
                }
            });

        })

    </script>
");
            }
            );
            WriteLiteral(@"<div class=""row"">
    <div class=""col-md-8 offset-2"">
        <input type=""text"" class=""form-control"" id=""txtName"" />
        <hr />
        <button class=""btn btn-warning"" id=""btnSave"">??smi Kaydet</button>
        <button class=""btn btn-primary"" id=""btnroomname"">Odaya Ki??i Ekle</button>
        <div class=""alert alert-info mt-2"">
            <div class=""float-left"">
                Ba??lant?? Durumu:<strong id=""conStatus""></strong>
                ,Client Say??s??:<strong id=""clientCount""></strong>
            </div>
            <div class=""float-right"">
                <div id=""loading"" class=""spinner-border"" role=""status"">
                    <span class=""visually-hidden""></span>
                </div>
            </div>
            <div class=""clearfix""></div>
        </div>
        <div id=""notify""></div>
    </div>
    <div class=""col-md-8 offset-2"">
        <ul class=""list-group"" id=""namesList""></ul>
    </div>
</div>

<div class=""rom"">
    <div class=""col-md-8 offset-2"">

     ");
            WriteLiteral(@"   <div class=""form-check form-check-inline"">
            <input class=""form-check-input"" type=""radio"" name=""roomgroup"" value=""Ankara"" />
            <label class=""form-check-label"">Ankara Odas??</label>
        </div>

        <div class=""form-check form-check-inline"">
            <input class=""form-check-input"" type=""radio"" name=""roomgroup"" value=""Bursa"" />
            <label class=""form-check-label"">Bursa Odas??</label>
        </div>

    </div>

    <div class=""col-md-8"" offset-2>
        <div class=""row"">
            <div class=""col-md-6"">
                <h3>Ankara Odas??</h3>
                <ul class=""list-group"" id=""AnkaraRoomList""></ul>
            </div>

            <div class=""col-md-6"">
                <h3>Bursa Odas??</h3>
                <ul class=""list-group"" id=""BursaRoomList""></ul>
            </div>


        </div>
    </div>

</div>");
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
