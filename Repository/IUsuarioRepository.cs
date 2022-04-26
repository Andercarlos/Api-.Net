using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using usuario.Model;

namespace usuario.Repository
{
    public interface IUsuarioRepository 
    {
        Task <IEnumerable<Usuario>> BuscarTodos();

        Task <Usuario> BuscarPeloId(int id);

        void AdicionarUsuario(Usuario usuario);

        void AtulizarUsuario(Usuario usuario);
        void DeletarUsuario(Usuario usuario);

        Task<bool> SaveChangesAsync();

    }
}