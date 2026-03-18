using AgendaWeb.Data.Commands;
using AgendaWeb.Data.DTOS.Contactos;
using AgendaWeb.Data.Entities;

namespace AgendaWeb.Services
{
    public class ContactoServices
    {
        private readonly ContactoCommand _contactoCommand;

        public ContactoServices(ContactoCommand contactoCommand)
        {
            _contactoCommand = contactoCommand;
        }

        public async Task InsertarAsync(ContactoNuevoDto contactoNuevoDto)
        {
            Contacto contacto = new Contacto();
            contacto.Nombre = contactoNuevoDto.Nombre;
            contacto.Telefono = contactoNuevoDto.Telefono;
            contacto.Email = contactoNuevoDto.Email;

            int registrosAfectados = await _contactoCommand.InsertarContactoAsync(contacto);

            if (registrosAfectados == 0)
            {
                throw new Exception("No se pudo insertar el contacto.");
            }
        }
        public async Task<int> EliminarContactoAsync(int id)
        {
            return await _contactoCommand.EliminarContactoAsync(id);
        }

        public async Task<int> ActualizarContactoAsync(int id, ContactoActualizarDto contactoActualizarDto)
        {
            Contacto contacto = new Contacto
            {
                Nombre = contactoActualizarDto.Nombre,
                Telefono = contactoActualizarDto.Telefono,
                Email = contactoActualizarDto.Email
            };
            return await _contactoCommand.ActualizarContactoAsync(id, contacto);
        }
    }
}
