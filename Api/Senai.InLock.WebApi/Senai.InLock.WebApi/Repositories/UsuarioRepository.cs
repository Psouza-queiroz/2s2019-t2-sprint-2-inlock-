using Senai.InLock.WebApi.Domains;
using Senai.InLock.WebApi.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.InLock.WebApi.Repositories
{
    public class UsuarioRepository
    {
        public List<Usuarios> Listar()
        {
            using (InLockContext ctx = new InLockContext())
            {
                return ctx.Usuarios.ToList();
            }
        }
        public Usuarios LogarPorEmailESenha(LoginViewModel login)
        {
            using (InLockContext ctx = new InLockContext())
            {
                Usuarios usuario = ctx.Usuarios.FirstOrDefault(x => x.Email == login.Email && x.Senha == login.Senha);
                if (usuario == null)
                    return null;
                return usuario;
            }
        }
    }
}

