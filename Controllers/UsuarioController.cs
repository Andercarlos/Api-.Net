using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using usuario.Model;
using usuario.Repository;

namespace usuario.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UsuarioController  : ControllerBase
    {
        
        private readonly IUsuarioRepository _repository;

        public UsuarioController(IUsuarioRepository repository)
        {
            _repository = repository;
        }
        [HttpGet]
        public async Task<IActionResult> Get(){
            var usuarios = await _repository.BuscarTodos();
            return usuarios.Any()?
            Ok(usuarios)
            :NotFound();
        }
        [HttpGet("{idUrl}")]
        public async Task<IActionResult> GetByID(int idUrl){
            var usuario = await _repository.BuscarPeloId(idUrl);
            return usuario!=null?
            Ok(usuario)
            :NotFound("Id "+ (idUrl) + " não existe!");
        }
        [HttpPost]
        public async Task<IActionResult> Post(Usuario usuario)
        {
           _repository.AdicionarUsuario(usuario);
            return await _repository.SaveChangesAsync()?
               Ok("Adicionado com sucesso")
             : BadRequest("Erro ao adicionar");

        }
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, Usuario usuario){
            var usuarioBanco = await _repository.BuscarPeloId(id);
            if(usuarioBanco == null) return NotFound("Não econtrado");

            usuarioBanco.nome = usuario.nome ?? usuarioBanco.nome;
            usuarioBanco.dataNasc = usuario.dataNasc != new DateTime() ?
            usuario.dataNasc : usuarioBanco.dataNasc; 
            
            _repository.AtulizarUsuario(usuarioBanco);

            return await _repository.SaveChangesAsync()?
            Ok("Atulizado com sucesso")
            :NotFound("Erro ao atualizar");
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Deletar(int id){
            var usuarioDB = await _repository.BuscarPeloId(id);
            if(usuarioDB == null) return NotFound("O Id "+(id)+" não encontrado");

            _repository.DeletarUsuario(usuarioDB);

            return await _repository.SaveChangesAsync()
            ?Ok("deletado com sucesso")
            :NotFound("Erro ao deletar");
        }


        
    }
}