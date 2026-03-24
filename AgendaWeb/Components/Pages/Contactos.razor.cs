using AgendaWeb.Data.DTOS.Contactos;
using AgendaWeb.Services;
using Microsoft.AspNetCore.Components;

namespace AgendaWeb.Components.Pages
{
    public partial class Contactos
    {
        [Inject] ContactoServices Services { get; set; } = default!;

        private List<ContactoDto> ListaDeContactos = new List<ContactoDto>();

        protected async override Task OnInitializedAsync()
        {
            ListaDeContactos = await Services.ObtenerTodosAsync();
            
        }
    }
}
