using Microsoft.EntityFrameworkCore;
using ProyectoLogin.Models;
using ProyectoLogin.Servicios.Contrato;

namespace ProyectoLogin.Servicios.Implementacion
{
    public class UsuarioService : IUsuarioService
    {

        private readonly DbpruebasContext _dbContext;

        public UsuarioService(DbpruebasContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Usuario> GetUsuario(string correo, string clave)
        {
            Usuario usuarioEncontrado = await _dbContext.Usuarios.Where(u => 
            u.Correo == correo && u.Clave == clave)
                .FirstOrDefaultAsync();
            return usuarioEncontrado;
        }

        public async Task<Usuario> SaveUsuario(Usuario modelo)
        {
            _dbContext.Usuarios.Add(modelo);

            await _dbContext.SaveChangesAsync();
            return modelo;
        }
    }
}
