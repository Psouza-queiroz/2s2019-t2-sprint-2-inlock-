using Senai.InLock.WebApi.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.InLock.WebApi.Repositories
{
    public class JogoRepository
    {
        public List<Jogos> Listar()
        {
            using (InLockContext ctx = new InLockContext())
            {
                return ctx.Jogos.ToList();
            }

        
        }

        public void Cadastrar(Jogos jogos)
        {
            using (InLockContext ctx = new InLockContext())
            {
                ctx.Jogos.Add(jogos);
                ctx.SaveChanges();
            }
        }

    }
}
