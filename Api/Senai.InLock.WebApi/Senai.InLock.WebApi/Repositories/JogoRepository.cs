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

        public Jogos BuscarPorId(int id)
        {
            using (InLockContext ctx = new InLockContext())
            {
                return ctx.Jogos.FirstOrDefault(x => x.JogoId == id);
            }
        }

        public void Atualizar(Jogos jogos)
        {
            using (InLockContext ctx = new InLockContext())
            {
                Jogos jogoBuscado = ctx.Jogos.FirstOrDefault(x => x.JogoId == jogos.JogoId);
                jogoBuscado.NomeJogo = jogos.NomeJogo;
                jogoBuscado.Descricao = jogos.Descricao;
                jogoBuscado.DataLancamento = jogos.DataLancamento;
                jogoBuscado.Valor = jogos.Valor;
                jogoBuscado.EstudioId = jogos.EstudioId;
                ctx.Jogos.Update(jogoBuscado);
                ctx.SaveChanges();
            }
        }

        public void Deletar (int id)
        {
            using (InLockContext ctx = new InLockContext())
            {
                Jogos jogos = ctx.Jogos.Find(id);
                ctx.Jogos.Remove(jogos);
                ctx.SaveChanges();
                   
            }
        }
    }
}
