#pragma checksum "C:\Estudos\DOTNET\Dominios_Ricos\WShopping\src\WShopping.Catalogo.MVC\Views\Vitrine\ProdutoDetalhe.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "c8e8b76b9a795a6b335d3496dbbb5c9c508d9a92"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Vitrine_ProdutoDetalhe), @"mvc.1.0.view", @"/Views/Vitrine/ProdutoDetalhe.cshtml")]
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
#line 1 "C:\Estudos\DOTNET\Dominios_Ricos\WShopping\src\WShopping.Catalogo.MVC\Views\_ViewImports.cshtml"
using WShopping.Catalogo.MVC;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Estudos\DOTNET\Dominios_Ricos\WShopping\src\WShopping.Catalogo.MVC\Views\_ViewImports.cshtml"
using WShopping.Catalogo.MVC.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"c8e8b76b9a795a6b335d3496dbbb5c9c508d9a92", @"/Views/Vitrine/ProdutoDetalhe.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"337140c8d6c480fc4b79740e4fa6235c6f79e1a7", @"/Views/_ViewImports.cshtml")]
    public class Views_Vitrine_ProdutoDetalhe : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<WShopping.Catalogo.Application.DTOs.ProdutoDTO>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("width", new global::Microsoft.AspNetCore.Html.HtmlString("400"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("height", new global::Microsoft.AspNetCore.Html.HtmlString("400"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
#line 2 "C:\Estudos\DOTNET\Dominios_Ricos\WShopping\src\WShopping.Catalogo.MVC\Views\Vitrine\ProdutoDetalhe.cshtml"
  
    ViewData["Title"] = "Produto Detalhe";

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
<style>
    ul > li {
        margin-right: 25px;
        font-weight: lighter;
        cursor: pointer
    }

    li.active {
        border-bottom: 3px solid silver;
    }

    .item-photo {
        display: flex;
        justify-content: center;
        align-items: center;
        border-right: 1px solid #f6f6f6;
    }

    .menu-items {
        list-style-type: none;
        font-size: 11px;
        display: inline-flex;
        margin-bottom: 0;
        margin-top: 20px
    }

    .btn-success {
        width: 100%;
        border-radius: 0;
    }

    .section {
        width: 100%;
        margin-left: -15px;
        padding: 2px;
        padding-left: 15px;
        padding-right: 15px;
        background: #f8f9f9
    }

    .title-price {
        margin-top: 30px;
        margin-bottom: 0;
        color: black
    }

    .title-attr {
        margin-top: 0;
        margin-bottom: 0;
        color: black;
    }

    .btn-minus {
        cursor: po");
            WriteLiteral(@"inter;
        font-size: 7px;
        display: flex;
        align-items: center;
        padding: 5px;
        padding-left: 10px;
        padding-right: 10px;
        border: 1px solid gray;
        border-radius: 2px;
        border-right: 0;
    }

    .btn-plus {
        cursor: pointer;
        font-size: 7px;
        display: flex;
        align-items: center;
        padding: 5px;
        padding-left: 10px;
        padding-right: 10px;
        border: 1px solid gray;
        border-radius: 2px;
        border-left: 0;
    }

    div.section > div {
        width: 100%;
        display: inline-flex;
    }

        div.section > div > input {
            margin: 0;
            padding-left: 5px;
            font-size: 10px;
            padding-right: 5px;
            max-width: 18%;
            text-align: center;
        }

    .attr, .attr2 {
        cursor: pointer;
        margin-right: 5px;
        height: 20px;
        font-size: 10px;
        padding:");
            WriteLiteral(" 2px;\r\n        border: 1px solid gray;\r\n        border-radius: 2px;\r\n    }\r\n\r\n        .attr.active, .attr2.active {\r\n            border: 1px solid orange;\r\n        }\r\n\r\n    ");
            WriteLiteral(@"@media (max-width: 426px) {
        .container {
            margin-top: 0px !important;
        }

            .container > .row {
                padding: 0 !important;
            }

                .container > .row > .col-xs-12.col-sm-5 {
                    padding-right: 0;
                }

                .container > .row > .col-xs-12.col-sm-9 > div > p {
                    padding-left: 0 !important;
                    padding-right: 0 !important;
                }

                .container > .row > .col-xs-12.col-sm-9 > div > ul {
                    padding-left: 10px !important;
                }

        .section {
            width: 104%;
        }

        .menu-items {
            padding-left: 0;
        }
    }
</style>
<div class=""container"">
    <div class=""row"">
        <div class=""col-xs-4 item-photo"">

            ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("img", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "c8e8b76b9a795a6b335d3496dbbb5c9c508d9a927407", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_1);
            BeginAddHtmlAttributeValues(__tagHelperExecutionContext, "src", 2, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            AddHtmlAttributeValue("", 3254, "~/Images/", 3254, 9, true);
#nullable restore
#line 147 "C:\Estudos\DOTNET\Dominios_Ricos\WShopping\src\WShopping.Catalogo.MVC\Views\Vitrine\ProdutoDetalhe.cshtml"
AddHtmlAttributeValue("", 3263, Model.Imagem, 3263, 13, false);

#line default
#line hidden
#nullable disable
            EndAddHtmlAttributeValues(__tagHelperExecutionContext);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n        </div>\r\n        <div class=\"col-xs-5\" style=\"border:20px solid white\">\r\n            <h3>");
#nullable restore
#line 150 "C:\Estudos\DOTNET\Dominios_Ricos\WShopping\src\WShopping.Catalogo.MVC\Views\Vitrine\ProdutoDetalhe.cshtml"
           Write(Model.Nome);

#line default
#line hidden
#nullable disable
            WriteLiteral("</h3>\r\n\r\n            <h6 class=\"title-price\"><small>OFERTA</small></h6>\r\n            <h3 style=\"margin-top:0px;\">");
#nullable restore
#line 153 "C:\Estudos\DOTNET\Dominios_Ricos\WShopping\src\WShopping.Catalogo.MVC\Views\Vitrine\ProdutoDetalhe.cshtml"
                                   Write(Model.Valor.ToString("C"));

#line default
#line hidden
#nullable disable
            WriteLiteral("</h3>\r\n\r\n            <p>Apenas ");
#nullable restore
#line 155 "C:\Estudos\DOTNET\Dominios_Ricos\WShopping\src\WShopping.Catalogo.MVC\Views\Vitrine\ProdutoDetalhe.cshtml"
                 Write(Model.QuantidadeEstoque);

#line default
#line hidden
#nullable disable
            WriteLiteral(" em estoque!</p>\r\n            <p>");
#nullable restore
#line 156 "C:\Estudos\DOTNET\Dominios_Ricos\WShopping\src\WShopping.Catalogo.MVC\Views\Vitrine\ProdutoDetalhe.cshtml"
          Write(Model.Descricao);

#line default
#line hidden
#nullable disable
            WriteLiteral(@"</p>

            <div class=""section"" style=""padding-bottom:20px;"">
                <h6 class=""title-attr""><small>QUANTIDADE</small></h6>
                <div>
                    <div class=""btn-minus""><span style=""font-size: 15px"">-</span></div>
                    <input style=""font-size: 15px"" type=""text"" value=""1"" />
                    <div class=""btn-plus""><span style=""font-size: 15px"">+</span></div>
                </div>
            </div>

            <!-- Botones de compra -->
            <div class=""section"" style=""padding-bottom:20px;"">
                <button class=""btn btn-success""><span style=""margin-right:20px"" aria-hidden=""true""></span> Comprar agora!</button>
            </div>
        </div>
    </div>
</div>


");
            DefineSection("Scripts", async() => {
                WriteLiteral(@"
    <script>
        $(document).ready(function () {
            //-- Click on detail
            $(""ul.menu-items > li"").on(""click"", function () {
                $(""ul.menu-items > li"").removeClass(""active"");
                $(this).addClass(""active"");
            })

            $("".attr,.attr2"").on(""click"", function () {
                var clase = $(this).attr(""class"");

                $(""."" + clase).removeClass(""active"");
                $(this).addClass(""active"");
            })

            //-- Click on QUANTITY
            $("".btn-minus"").on(""click"", function () {
                var now = $("".section > div > input"").val();
                if ($.isNumeric(now)) {
                    if (parseInt(now) - 1 > 0) { now--; }
                    $("".section > div > input"").val(now);
                } else {
                    $("".section > div > input"").val(""1"");
                }
            })
            $("".btn-plus"").on(""click"", function () {
                var now = $(");
                WriteLiteral(@""".section > div > input"").val();
                if ($.isNumeric(now)) {
                    $("".section > div > input"").val(parseInt(now) + 1);
                } else {
                    $("".section > div > input"").val(""1"");
                }
            })
        })
    </script>
");
            }
            );
            WriteLiteral("\r\n\r\n\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<WShopping.Catalogo.Application.DTOs.ProdutoDTO> Html { get; private set; }
    }
}
#pragma warning restore 1591
