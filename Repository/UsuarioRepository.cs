using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using usuario.Data;
using usuario.Model;
using Microsoft.EntityFrameworkCore;

namespace usuario.Repository
{
    public class UsuarioRepository : IUsuarioRepository
    {
        private readonly UsuarioContext _usuarioContext;

        public UsuarioRepository(UsuarioContext usuarioContext)
            {
            _usuarioContext = usuarioContext;
        }




        public void AdicionarUsuario(Usuario usuario)
        {
            _usuarioContext.Add(usuario);
        }

        public void AtulizarUsuario(Usuario usuario)
        {
            _usuarioContext.Update(usuario);
        }

        public async Task<Usuario> BuscarPeloId(int id)
        {
            return await _usuarioContext.TabelaUsuarios
            .Where(x=>x.id==id).FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<Usuario>> BuscarTodos()
        {
            return await _usuarioContext.TabelaUsuarios.ToListAsync();
        }

        public void DeletarUsuario(Usuario usuario)
        {
            _usuarioContext.Remove(usuario);
        }

        public async Task<bool> SaveChangesAsync()
        {
            return await _usuarioContext.SaveChangesAsync()>0;
        }
    }
}