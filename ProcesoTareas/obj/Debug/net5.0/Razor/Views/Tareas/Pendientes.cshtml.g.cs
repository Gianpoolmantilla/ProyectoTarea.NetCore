#pragma checksum "E:\Users\work\Desktop\PROYECTOS\ProyectoTarea.NetCore\ProcesoTareas\Views\Tareas\Pendientes.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "6248d2fc45a5fe20ff696fdff62485acc5ce213c"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Tareas_Pendientes), @"mvc.1.0.view", @"/Views/Tareas/Pendientes.cshtml")]
namespace AspNetCore
{
    #line hidden
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.ViewFeatures;
#nullable restore
#line 1 "E:\Users\work\Desktop\PROYECTOS\ProyectoTarea.NetCore\ProcesoTareas\Views\_ViewImports.cshtml"
using ProcesoTareas;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "E:\Users\work\Desktop\PROYECTOS\ProyectoTarea.NetCore\ProcesoTareas\Views\_ViewImports.cshtml"
using ProcesoTareas.Models;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "E:\Users\work\Desktop\PROYECTOS\ProyectoTarea.NetCore\ProcesoTareas\Views\_ViewImports.cshtml"
using Microsoft.AspNetCore.Identity;

#line default
#line hidden
#nullable disable
#nullable restore
#line 4 "E:\Users\work\Desktop\PROYECTOS\ProyectoTarea.NetCore\ProcesoTareas\Views\_ViewImports.cshtml"
using Microsoft.EntityFrameworkCore;

#line default
#line hidden
#nullable disable
#nullable restore
#line 5 "E:\Users\work\Desktop\PROYECTOS\ProyectoTarea.NetCore\ProcesoTareas\Views\_ViewImports.cshtml"
using System;

#line default
#line hidden
#nullable disable
#nullable restore
#line 6 "E:\Users\work\Desktop\PROYECTOS\ProyectoTarea.NetCore\ProcesoTareas\Views\_ViewImports.cshtml"
using Microsoft.AspNetCore.Mvc.Rendering;

#line default
#line hidden
#nullable disable
#nullable restore
#line 7 "E:\Users\work\Desktop\PROYECTOS\ProyectoTarea.NetCore\ProcesoTareas\Views\_ViewImports.cshtml"
using System.Collections.Generic;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"6248d2fc45a5fe20ff696fdff62485acc5ce213c", @"/Views/Tareas/Pendientes.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"0652008895878ae34fc2e5e93d775ed69bbd0431", @"/Views/_ViewImports.cshtml")]
    public class Views_Tareas_Pendientes : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IEnumerable<ProcesoTareas.Models.ViewModelEstados.Pendiente>>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Realizado", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("text-white"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Rechazado", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
#nullable restore
#line 3 "E:\Users\work\Desktop\PROYECTOS\ProyectoTarea.NetCore\ProcesoTareas\Views\Tareas\Pendientes.cshtml"
  
    ViewData["Title"] = "Pendientes";
    Layout = "_Layout";

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n\r\n");
            WriteLiteral(@"










<div class=""card-border-success"">
    <div class=""card-footer"">
        <h4 class=""text-center"">Pendientes</h4>
    </div>
    <br />
</div>
<table class=""table"">
    <thead>
        <tr>
            <th></th>
            <th>
                id
            </th>
            <th>
                Nombre
            </th>
            <th>
                Tipo de Tarea
            </th>
            <th>
                Observaci??n
            </th>
            <th>
                Prioridad
            </th>
            <th>
                Fecha Alta
            </th>
            <th>
                Vencimiento
            </th>


        </tr>
    </thead>
    <tbody>
");
#nullable restore
#line 137 "E:\Users\work\Desktop\PROYECTOS\ProyectoTarea.NetCore\ProcesoTareas\Views\Tareas\Pendientes.cshtml"
         foreach (var item in Model)
        {

#line default
#line hidden
#nullable disable
            WriteLiteral("        <tr>\r\n            <td>\r\n                <div class=\"col-sm-1\">\r\n                    <div>\r\n                        <button class=\"btn btn-success\" value=\"Realizado\" id=\"btnRealizado\">\r\n                            ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "6248d2fc45a5fe20ff696fdff62485acc5ce213c6932", async() => {
                WriteLiteral("<i class=\"far fa-check-circle\"></i>");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_0.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
            if (__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
            {
                throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-id", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
            }
            BeginWriteTagHelperAttribute();
#nullable restore
#line 144 "E:\Users\work\Desktop\PROYECTOS\ProyectoTarea.NetCore\ProcesoTareas\Views\Tareas\Pendientes.cshtml"
                                                        WriteLiteral(item.Id);

#line default
#line hidden
#nullable disable
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"] = __tagHelperStringValueBuffer;
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-route-id", __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"], global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_1);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n                        </button>\r\n                    </div>\r\n                    <br />\r\n                    ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "6248d2fc45a5fe20ff696fdff62485acc5ce213c9349", async() => {
                WriteLiteral("\r\n                        <button type=\"submit\" class=\"btn btn-danger\" value=\"DarBaja\">\r\n                            ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "6248d2fc45a5fe20ff696fdff62485acc5ce213c9730", async() => {
                    WriteLiteral(" <i class=\"far fa-trash-alt\"></i>");
                }
                );
                __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
                __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_2.Value;
                __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_2);
                if (__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
                {
                    throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-id", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
                }
                BeginWriteTagHelperAttribute();
#nullable restore
#line 150 "E:\Users\work\Desktop\PROYECTOS\ProyectoTarea.NetCore\ProcesoTareas\Views\Tareas\Pendientes.cshtml"
                                                        WriteLiteral(item.Id);

#line default
#line hidden
#nullable disable
                __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
                __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"] = __tagHelperStringValueBuffer;
                __tagHelperExecutionContext.AddTagHelperAttribute("asp-route-id", __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"], global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_1);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                WriteLiteral("\r\n                        </button>\r\n                    ");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Action = (string)__tagHelperAttribute_2.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_2);
            if (__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.RouteValues == null)
            {
                throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-id", "Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper", "RouteValues"));
            }
            BeginWriteTagHelperAttribute();
#nullable restore
#line 148 "E:\Users\work\Desktop\PROYECTOS\ProyectoTarea.NetCore\ProcesoTareas\Views\Tareas\Pendientes.cshtml"
                                                   WriteLiteral(item.Id);

#line default
#line hidden
#nullable disable
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.RouteValues["id"] = __tagHelperStringValueBuffer;
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-route-id", __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.RouteValues["id"], global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n\r\n\r\n                </div>\r\n\r\n            </td>\r\n            <td>\r\n                ");
#nullable restore
#line 159 "E:\Users\work\Desktop\PROYECTOS\ProyectoTarea.NetCore\ProcesoTareas\Views\Tareas\Pendientes.cshtml"
           Write(Html.DisplayFor(modelItem => item.Id));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </td>\r\n            <td>\r\n\r\n                ");
#nullable restore
#line 163 "E:\Users\work\Desktop\PROYECTOS\ProyectoTarea.NetCore\ProcesoTareas\Views\Tareas\Pendientes.cshtml"
           Write(item.Nombre);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </td>\r\n            <td>\r\n                ");
#nullable restore
#line 166 "E:\Users\work\Desktop\PROYECTOS\ProyectoTarea.NetCore\ProcesoTareas\Views\Tareas\Pendientes.cshtml"
           Write(item.TipoTarea);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </td>\r\n            <td>\r\n                ");
#nullable restore
#line 169 "E:\Users\work\Desktop\PROYECTOS\ProyectoTarea.NetCore\ProcesoTareas\Views\Tareas\Pendientes.cshtml"
           Write(Html.DisplayFor(modelItem => item.Observacion));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </td>\r\n            <td>\r\n                ");
#nullable restore
#line 172 "E:\Users\work\Desktop\PROYECTOS\ProyectoTarea.NetCore\ProcesoTareas\Views\Tareas\Pendientes.cshtml"
           Write(item.Prioridad);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </td>\r\n            <td>\r\n                ");
#nullable restore
#line 175 "E:\Users\work\Desktop\PROYECTOS\ProyectoTarea.NetCore\ProcesoTareas\Views\Tareas\Pendientes.cshtml"
           Write(Html.DisplayFor(modelItem => item.FechaAlta));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </td>\r\n            <td>\r\n                ");
#nullable restore
#line 178 "E:\Users\work\Desktop\PROYECTOS\ProyectoTarea.NetCore\ProcesoTareas\Views\Tareas\Pendientes.cshtml"
           Write(Html.DisplayFor(modelItem => item.FechaVencimiento));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </td>\r\n\r\n\r\n        </tr>\r\n");
#nullable restore
#line 183 "E:\Users\work\Desktop\PROYECTOS\ProyectoTarea.NetCore\ProcesoTareas\Views\Tareas\Pendientes.cshtml"
        }

#line default
#line hidden
#nullable disable
            WriteLiteral("    </tbody>\r\n</table>\r\n\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IEnumerable<ProcesoTareas.Models.ViewModelEstados.Pendiente>> Html { get; private set; }
    }
}
#pragma warning restore 1591
