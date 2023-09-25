using Microsoft.EntityFrameworkCore;
using SHYPI.Data;
using SHYPI.Models;
using SHYPI.Repositorios.Interfaces;

namespace SHYPI.Repositorios {
    public class UsuarioRepositorio : IUsuarioRepositorio {

        private readonly SistemaTarefasDBContext _dbContext;

        public UsuarioRepositorio(SistemaTarefasDBContext sistemaTarefasDBContext) {
            _dbContext = sistemaTarefasDBContext;
        }

        public async Task<UsuarioModel> BuscarPorId(int id) {
            return await _dbContext.Usuarios.FirstOrDefaultAsync(x => x.Id ==  id);
        }

        public async Task<List<UsuarioModel>> BuscarTodosUsuarios() {
            return await _dbContext.Usuarios.ToListAsync();
        }

        public async Task<UsuarioModel> Adicionar(UsuarioModel usuario) {
            await _dbContext.Usuarios.AddAsync(usuario);
            await _dbContext.SaveChangesAsync();

            return usuario;
        }

        public async Task<bool> Apagar(int id) {
            UsuarioModel usuarioPorId = await BuscarPorId(id);

            if (usuarioPorId == null) {
                throw new NotImplementedException($"Usuário para o ID: {id} não foi encontrado.");
            }

            _dbContext.Usuarios.Remove(usuarioPorId);
            await _dbContext.SaveChangesAsync();

            return true;
        }

        public async Task<UsuarioModel> Atualizar(UsuarioModel usuario, int id) {
            UsuarioModel usuarioPorId = await BuscarPorId(id);

            if(usuarioPorId == null) { 
                throw new NotImplementedException($"Usuário para o ID: {id} não foi encontrado."); 
            } else {
                usuarioPorId.Name = usuario.Name;
                usuarioPorId.Email = usuario.Email;
                usuarioPorId.Senha = usuario.Senha;
                usuarioPorId.Picture = usuario.Picture;
                usuarioPorId.Cargo = usuario.Cargo;

                _dbContext.Usuarios.Update(usuarioPorId);
                await _dbContext.SaveChangesAsync();

                return usuarioPorId;
            }
        }
        
    }
}