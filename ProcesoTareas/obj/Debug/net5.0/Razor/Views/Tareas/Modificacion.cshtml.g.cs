#pragma checksum "E:\Users\work\Desktop\PROYECTOS\ProyectoTarea.NetCore\ProcesoTareas\Views\Tareas\Modificacion.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "64e024445caa047f2ecfc71d61a20b9bd0e5d2b3"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Tareas_Modificacion), @"mvc.1.0.view", @"/Views/Tareas/Modificacion.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"64e024445caa047f2ecfc71d61a20b9bd0e5d2b3", @"/Views/Tareas/Modificacion.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"0652008895878ae34fc2e5e93d775ed69bbd0431", @"/Views/_ViewImports.cshtml")]
    public class Views_Tareas_Modificacion : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IEnumerable<ProcesoTareas.Models.ViewModelEstados.Modificacion>>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Edit", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("text-white"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
#nullable restore
#line 3 "E:\Users\work\Desktop\PROYECTOS\ProyectoTarea.NetCore\ProcesoTareas\Views\Tareas\Modificacion.cshtml"
  
    ViewData["Title"] = "Modificacion";
    Layout = "_Layout";

    List<SelectListItem> listaPrioridad = (List<SelectListItem>)ViewBag.itemsPrioridad;

    List<SelectListItem> listaTipoTarea = (List<SelectListItem>)ViewBag.itemsTipoT;




#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n\r\n\r\n");
#nullable restore
#line 17 "E:\Users\work\Desktop\PROYECTOS\ProyectoTarea.NetCore\ProcesoTareas\Views\Tareas\Modificacion.cshtml"
 using (Html.BeginForm())
{


#line default
#line hidden
#nullable disable
            WriteLiteral("<div class=\"card-border-success\">\r\n\r\n    <div class=\"card-footer\">\r\n        <h4 class=\"text-center\">Modificar Tarea</h4>\r\n    </div>\r\n    <br />\r\n    <div class=\"control-label col-md-4\">Prioridad</div>\r\n    <div class=\"col-4\">\r\n        ");
#nullable restore
#line 28 "E:\Users\work\Desktop\PROYECTOS\ProyectoTarea.NetCore\ProcesoTareas\Views\Tareas\Modificacion.cshtml"
   Write(Html.DropDownList("prioridad", listaPrioridad as IEnumerable<SelectListItem>, "Seleccione un prioridad..", new { id = "normalDropwn2", @class = "form-control" }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        <span class=\"text-danger\"></span>\r\n    </div>\r\n    <div class=\"form-group\">\r\n        <div class=\"control-label col-md-4\">Tipo de tarea</div>\r\n        <div class=\"col-4\">\r\n            ");
#nullable restore
#line 34 "E:\Users\work\Desktop\PROYECTOS\ProyectoTarea.NetCore\ProcesoTareas\Views\Tareas\Modificacion.cshtml"
       Write(Html.DropDownList("tipoTarea", listaTipoTarea as IEnumerable<SelectListItem>, "Seleccione un prioridad..", new { id = "normalDropwn2", @class = "form-control" }));

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
            <span class=""text-danger""></span>
        </div>
    </div>
    <div class=""form-group"">
        <div class=""col-md-offset-2 col-md-12"">
            <input type=""submit"" value=""Buscar"" class=""btn btn-success"" />
        </div>
    </div>
    <br />

</div>
");
#nullable restore
#line 46 "E:\Users\work\Desktop\PROYECTOS\ProyectoTarea.NetCore\ProcesoTareas\Views\Tareas\Modificacion.cshtml"
 
  
}

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
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
                Observación
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
            WriteLiteral("\r\n");
#nullable restore
#line 83 "E:\Users\work\Desktop\PROYECTOS\ProyectoTarea.NetCore\ProcesoTareas\Views\Tareas\Modificacion.cshtml"
         foreach (var item in Model)
        {

#line default
#line hidden
#nullable disable
            WriteLiteral("        <tr>\r\n            <td>\r\n                <div class=\"col-sm-2\">\r\n                    <div>\r\n                        <button class=\"btn btn-dark text-white\" value=\"Editar\">\r\n                            ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "64e024445caa047f2ecfc71d61a20b9bd0e5d2b38381", async() => {
                WriteLiteral("<i class=\"far fa-edit\"></i>");
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
#line 90 "E:\Users\work\Desktop\PROYECTOS\ProyectoTarea.NetCore\ProcesoTareas\Views\Tareas\Modificacion.cshtml"
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
            WriteLiteral("\r\n                        </button>\r\n                    </div>\r\n                    <br />\r\n                    <div>\r\n");
            WriteLiteral("                    </div>\r\n\r\n\r\n\r\n");
            WriteLiteral("                </div>\r\n\r\n            </td>\r\n            <td>\r\n                ");
#nullable restore
#line 111 "E:\Users\work\Desktop\PROYECTOS\ProyectoTarea.NetCore\ProcesoTareas\Views\Tareas\Modificacion.cshtml"
           Write(Html.DisplayFor(modelItem => item.Id));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </td>\r\n            <td>\r\n\r\n                ");
#nullable restore
#line 115 "E:\Users\work\Desktop\PROYECTOS\ProyectoTarea.NetCore\ProcesoTareas\Views\Tareas\Modificacion.cshtml"
           Write(item.Nombre);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </td>\r\n            <td>\r\n                ");
#nullable restore
#line 118 "E:\Users\work\Desktop\PROYECTOS\ProyectoTarea.NetCore\ProcesoTareas\Views\Tareas\Modificacion.cshtml"
           Write(item.TipoTarea);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </td>\r\n            <td>\r\n                ");
#nullable restore
#line 121 "E:\Users\work\Desktop\PROYECTOS\ProyectoTarea.NetCore\ProcesoTareas\Views\Tareas\Modificacion.cshtml"
           Write(Html.DisplayFor(modelItem => item.Observacion));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </td>\r\n            <td>\r\n                ");
#nullable restore
#line 124 "E:\Users\work\Desktop\PROYECTOS\ProyectoTarea.NetCore\ProcesoTareas\Views\Tareas\Modificacion.cshtml"
           Write(item.Prioridad);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </td>\r\n            <td>\r\n                ");
#nullable restore
#line 127 "E:\Users\work\Desktop\PROYECTOS\ProyectoTarea.NetCore\ProcesoTareas\Views\Tareas\Modificacion.cshtml"
           Write(Html.DisplayFor(modelItem => item.FechaAlta));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </td>\r\n            <td>\r\n                ");
#nullable restore
#line 130 "E:\Users\work\Desktop\PROYECTOS\ProyectoTarea.NetCore\ProcesoTareas\Views\Tareas\Modificacion.cshtml"
           Write(Html.DisplayFor(modelItem => item.FechaVencimiento));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </td>\r\n\r\n\r\n        </tr>\r\n");
#nullable restore
#line 135 "E:\Users\work\Desktop\PROYECTOS\ProyectoTarea.NetCore\ProcesoTareas\Views\Tareas\Modificacion.cshtml"
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IEnumerable<ProcesoTareas.Models.ViewModelEstados.Modificacion>> Html { get; private set; }
    }
}
#pragma warning restore 1591
