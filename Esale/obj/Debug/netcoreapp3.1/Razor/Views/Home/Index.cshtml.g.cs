#pragma checksum "C:\Users\Jakub\source\repos\eSaleFinal\eSale\eSaleApp\Views\Home\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "749eb538280b6767dcc26a695eaadd736d7663aa"
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
#line 1 "C:\Users\Jakub\source\repos\eSaleFinal\eSale\eSaleApp\Views\_ViewImports.cshtml"
using eSale.Models;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\Jakub\source\repos\eSaleFinal\eSale\eSaleApp\Views\_ViewImports.cshtml"
using eSale.ViewModels;

#line default
#line hidden
#nullable disable
#nullable restore
#line 7 "C:\Users\Jakub\source\repos\eSaleFinal\eSale\eSaleApp\Views\_ViewImports.cshtml"
using Microsoft.AspNetCore.Identity;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"749eb538280b6767dcc26a695eaadd736d7663aa", @"/Views/Home/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"6548b4048de7bfbe802220bc8188b4900388d043", @"/Views/_ViewImports.cshtml")]
    public class Views_Home_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 1 "C:\Users\Jakub\source\repos\eSaleFinal\eSale\eSaleApp\Views\Home\Index.cshtml"
  
    ViewData["Title"] = "Graty z Chaty";

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
<section class=""home_banner_area pt-4"">
    <div class=""banner_inner d-flex align-items-center"">
        <div class=""container w-100"">
            <div class=""banner_content mx-auto row text-center"">
                <div style=""background-color: rgba(0, 0, 0, 0.575)"" class=""col-lg-12 p-3"">
                    <p class=""sub text-uppercase""><b>Graty z Chaty</b>, wyprzedaż rzeczy walających się</p>
                    <h3>
                    <span>Znajdź</span> Coś<br/>
                    Dla <span>Siebie</span><br/>
                    <span>");
#nullable restore
#line 14 "C:\Users\Jakub\source\repos\eSaleFinal\eSale\eSaleApp\Views\Home\Index.cshtml"
                     Write(Model);

#line default
#line hidden
#nullable disable
            WriteLiteral(@" </span>
                    </h3>
                    <h4>Od pamiatek, przez ksiazki do ubran i monet.</h4>
                    <a class=""main_btn mt-40"" href=""#"">Zobacz oferty</a>
                </div>
            </div>
        </div>
    </div>
</section
<h2> Hello ");
#nullable restore
#line 23 "C:\Users\Jakub\source\repos\eSaleFinal\eSale\eSaleApp\Views\Home\Index.cshtml"
      Write(Model);

#line default
#line hidden
#nullable disable
            WriteLiteral(@"</h2>
<!-- Start feature Area -->
<section class=""feature-area section_gap_bottom_custom"">
    <div class=""container"">
        <div class=""row"">
            <div class=""col-lg-3 col-md-6"">
                <div class=""single-feature"">
                    <a href=""#"" class=""title"">
                        <i class=""flaticon-money""></i>
                        <h3>Niska cena</h3>
                    </a>
                    <p>Shall open divide a one</p>
                </div>
            </div>

            <div class=""col-lg-3 col-md-6"">
                <div class=""single-feature"">
                    <a href=""#"" class=""title"">
                        <i class=""flaticon-truck""></i>
                        <h3>Free Delivery</h3>
                    </a>
                    <p>Shall open divide a one</p>
                </div>
            </div>

            <div class=""col-lg-3 col-md-6"">
                <div class=""single-feature"">
                    <a href=""#"" class=""title"">
    ");
            WriteLiteral(@"                    <i class=""flaticon-support""></i>
                        <h3>Alway support</h3>
                    </a>
                    <p>Shall open divide a one</p>
                </div>
            </div>

            <div class=""col-lg-3 col-md-6"">
                <div class=""single-feature"">
                    <a href=""#"" class=""title"">
                        <i class=""flaticon-blockchain""></i>
                        <h3>Secure payment</h3>
                    </a>
                    <p>Shall open divide a one</p>
                </div>
            </div>
        </div>
    </div>
</section>
<!-- End feature Area -->
<section class=""feature_product_area section_gap_bottom_custom"">
    <div class=""container"">
        <div class=""row justify-content-center"">
            <div class=""col-lg-12"">
                <div class=""main_title"">
                    <h2><span>Featured product</span></h2>
                    <p>Bring called seed first of third give itself now ment");
            WriteLiteral(@"</p>
                </div>
            </div>
        </div>

        <div class=""row"">
            <div class=""col-lg-4 col-md-6"">
                <div class=""single-product"">
                    <div class=""product-img"">
                        <img class=""img-fluid w-100"" src=""img/product/feature-product/f-p-1.jpg""");
            BeginWriteAttribute("alt", " alt=\"", 3277, "\"", 3283, 0);
            EndWriteAttribute();
            WriteLiteral(@" />
                        <div class=""p_icon"">
                            <a href=""#"">
                                <i class=""ti-eye""></i>
                            </a>
                            <a href=""#"">
                                <i class=""ti-heart""></i>
                            </a>
                            <a href=""#"">
                                <i class=""ti-shopping-cart""></i>
                            </a>
                        </div>
                    </div>
                    <div class=""product-btm"">
                        <a href=""#"" class=""d-block"">
                            <h4>Latest men’s sneaker</h4>
                        </a>
                        <div class=""mt-3"">
                            <span class=""mr-4"">$25.00</span>
                            <del>$35.00</del>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>

</section>");
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
