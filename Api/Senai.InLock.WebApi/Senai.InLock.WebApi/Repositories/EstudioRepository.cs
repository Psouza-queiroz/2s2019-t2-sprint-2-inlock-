using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Senai.InLock.WebApi.Domains;
using Senai.InLock.WebApi.ViewModel;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.InLock.WebApi.Repositories
{
    public class EstudioRepository
    {
        private string StringConexao = "Data Source=.\\SqlExpress; Initial Catalog=T_InLock;User Id=sa;Pwd=132";


        public List<Estudios> Listar()
        {
            using (InLockContext ctx = new InLockContext())
            {
                return ctx.Estudios.ToList();

            }
        }


        public void Cadastrar(Estudios estudio)
        {
            using (InLockContext ctx = new InLockContext())
            {
                ctx.Estudios.Add(estudio);
                ctx.SaveChanges();
            }
        }


        public Estudios BuscarPorId(int id)
        {
            using (InLockContext ctx = new InLockContext())
            {
                return ctx.Estudios.FirstOrDefault(x => x.EstudioId == id);
            }
        }


        public void Atualizar (Estudios estudios)
        {
            using (InLockContext ctx = new InLockContext())
            {
                Estudios EstudioBuscado = ctx.Estudios.FirstOrDefault(x => x.EstudioId == estudios.EstudioId);
                EstudioBuscado.NomeEstudio = estudios.NomeEstudio;
                EstudioBuscado.PaisOrigem = estudios.PaisOrigem;
                EstudioBuscado.DataCriacao = estudios.DataCriacao;
                EstudioBuscado.UsuarioId = estudios.UsuarioId;
                ctx.Estudios.Update(EstudioBuscado);
                ctx.SaveChanges();
            }
        }


        public void Deletar(int id)
        {
            using (InLockContext ctx = new InLockContext())
            {
                Estudios estudios = ctx.Estudios.Find(id);
                ctx.Estudios.Remove(estudios);
                ctx.SaveChanges();
            }
        }



        public List<Estudios> ListarEstudioJogo()
        {
            using (InLockContext ctx = new InLockContext())
            {
                return ctx.Estudios.Include(x => x.Navigation).ToList();
            }
        }
    }
}
