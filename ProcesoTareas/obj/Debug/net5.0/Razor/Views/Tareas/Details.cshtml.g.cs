#pragma checksum "E:\Users\work\Desktop\PROYECTOS\ProyectoTarea.NetCore\ProcesoTareas\Views\Tareas\Details.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "818232e956dac834667f74d2ced9402ec1700e1a"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Tareas_Details), @"mvc.1.0.view", @"/Views/Tareas/Details.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"818232e956dac834667f74d2ced9402ec1700e1a", @"/Views/Tareas/Details.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"f08ff280e0d16da2f50928d4478b7c905ea11730", @"/Views/_ViewImports.cshtml")]
    public class Views_Tareas_Details : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<ProcesoTareas.Models.Tarea>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
#nullable restore
#line 3 "E:\Users\work\Desktop\PROYECTOS\ProyectoTarea.NetCore\ProcesoTareas\Views\Tareas\Details.cshtml"
  
    ViewData["Title"] = "Details";
    Layout = "_Layout";

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n<h1>Details</h1>\r\n\r\n<div>\r\n    <h4>Tarea</h4>\r\n    <hr />\r\n    <dl class=\"row\">\r\n        <dt class=\"col-sm-2\">\r\n            ");
#nullable restore
#line 15 "E:\Users\work\Desktop\PROYECTOS\ProyectoTarea.NetCore\ProcesoTareas\Views\Tareas\Details.cshtml"
       Write(Html.DisplayNameFor(model => model.Nombre));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dt>\r\n        <dd class=\"col-sm-10\">\r\n            ");
#nullable restore
#line 18 "E:\Users\work\Desktop\PROYECTOS\ProyectoTarea.NetCore\ProcesoTareas\Views\Tareas\Details.cshtml"
       Write(Html.DisplayFor(model => model.Nombre));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dd>\r\n        <dt class=\"col-sm-2\">\r\n            ");
#nullable restore
#line 21 "E:\Users\work\Desktop\PROYECTOS\ProyectoTarea.NetCore\ProcesoTareas\Views\Tareas\Details.cshtml"
       Write(Html.DisplayNameFor(model => model.TipoTareaId));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dt>\r\n        <dd class=\"col-sm-10\">\r\n            ");
#nullable restore
#line 24 "E:\Users\work\Desktop\PROYECTOS\ProyectoTarea.NetCore\ProcesoTareas\Views\Tareas\Details.cshtml"
       Write(Html.DisplayFor(model => model.TipoTareaId));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dd>\r\n        <dt class=\"col-sm-2\">\r\n            ");
#nullable restore
#line 27 "E:\Users\work\Desktop\PROYECTOS\ProyectoTarea.NetCore\ProcesoTareas\Views\Tareas\Details.cshtml"
       Write(Html.DisplayNameFor(model => model.Observacion));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dt>\r\n        <dd class=\"col-sm-10\">\r\n            ");
#nullable restore
#line 30 "E:\Users\work\Desktop\PROYECTOS\ProyectoTarea.NetCore\ProcesoTareas\Views\Tareas\Details.cshtml"
       Write(Html.DisplayFor(model => model.Observacion));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dd>\r\n        <dt class=\"col-sm-2\">\r\n            ");
#nullable restore
#line 33 "E:\Users\work\Desktop\PROYECTOS\ProyectoTarea.NetCore\ProcesoTareas\Views\Tareas\Details.cshtml"
       Write(Html.DisplayNameFor(model => model.PrioridadId));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dt>\r\n        <dd class=\"col-sm-10\">\r\n            ");
#nullable restore
#line 36 "E:\Users\work\Desktop\PROYECTOS\ProyectoTarea.NetCore\ProcesoTareas\Views\Tareas\Details.cshtml"
       Write(Html.DisplayFor(model => model.PrioridadId));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dd>\r\n        <dt class=\"col-sm-2\">\r\n            ");
#nullable restore
#line 39 "E:\Users\work\Desktop\PROYECTOS\ProyectoTarea.NetCore\ProcesoTareas\Views\Tareas\Details.cshtml"
       Write(Html.DisplayNameFor(model => model.EstadoId));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dt>\r\n        <dd class=\"col-sm-10\">\r\n            ");
#nullable restore
#line 42 "E:\Users\work\Desktop\PROYECTOS\ProyectoTarea.NetCore\ProcesoTareas\Views\Tareas\Details.cshtml"
       Write(Html.DisplayFor(model => model.EstadoId));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dd>\r\n        <dt class=\"col-sm-2\">\r\n            ");
#nullable restore
#line 45 "E:\Users\work\Desktop\PROYECTOS\ProyectoTarea.NetCore\ProcesoTareas\Views\Tareas\Details.cshtml"
       Write(Html.DisplayNameFor(model => model.Debaja));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dt>\r\n        <dd class=\"col-sm-10\">\r\n            ");
#nullable restore
#line 48 "E:\Users\work\Desktop\PROYECTOS\ProyectoTarea.NetCore\ProcesoTareas\Views\Tareas\Details.cshtml"
       Write(Html.DisplayFor(model => model.Debaja));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dd>\r\n        <dt class=\"col-sm-2\">\r\n            ");
#nullable restore
#line 51 "E:\Users\work\Desktop\PROYECTOS\ProyectoTarea.NetCore\ProcesoTareas\Views\Tareas\Details.cshtml"
       Write(Html.DisplayNameFor(model => model.FechaAlta));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dt>\r\n        <dd class=\"col-sm-10\">\r\n            ");
#nullable restore
#line 54 "E:\Users\work\Desktop\PROYECTOS\ProyectoTarea.NetCore\ProcesoTareas\Views\Tareas\Details.cshtml"
       Write(Html.DisplayFor(model => model.FechaAlta));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dd>\r\n        <dt class=\"col-sm-2\">\r\n            ");
#nullable restore
#line 57 "E:\Users\work\Desktop\PROYECTOS\ProyectoTarea.NetCore\ProcesoTareas\Views\Tareas\Details.cshtml"
       Write(Html.DisplayNameFor(model => model.UserId));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dt>\r\n        <dd class=\"col-sm-10\">\r\n            ");
#nullable restore
#line 60 "E:\Users\work\Desktop\PROYECTOS\ProyectoTarea.NetCore\ProcesoTareas\Views\Tareas\Details.cshtml"
       Write(Html.DisplayFor(model => model.UserId));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dd>\r\n        <dt class=\"col-sm-2\">\r\n            ");
#nullable restore
#line 63 "E:\Users\work\Desktop\PROYECTOS\ProyectoTarea.NetCore\ProcesoTareas\Views\Tareas\Details.cshtml"
       Write(Html.DisplayNameFor(model => model.FechaMod));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dt>\r\n        <dd class=\"col-sm-10\">\r\n            ");
#nullable restore
#line 66 "E:\Users\work\Desktop\PROYECTOS\ProyectoTarea.NetCore\ProcesoTareas\Views\Tareas\Details.cshtml"
       Write(Html.DisplayFor(model => model.FechaMod));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dd>\r\n    </dl>\r\n</div>\r\n<div>\r\n    ");
#nullable restore
#line 71 "E:\Users\work\Desktop\PROYECTOS\ProyectoTarea.NetCore\ProcesoTareas\Views\Tareas\Details.cshtml"
Write(Html.ActionLink("Edit", "Edit", new { id = Model.Id }));

#line default
#line hidden
#nullable disable
            WriteLiteral(" |\r\n    ");
#nullable restore
#line 72 "E:\Users\work\Desktop\PROYECTOS\ProyectoTarea.NetCore\ProcesoTareas\Views\Tareas\Details.cshtml"
Write(Html.ActionLink("Back to List", "Index"));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n</div>\r\n\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<ProcesoTareas.Models.Tarea> Html { get; private set; }
    }
}
#pragma warning restore 1591