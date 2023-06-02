using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TpInvestigacion.Data.Entidades;
using TpInvestigacion.Data.Interface;

namespace TpInvestigacion.Data
{
    public class Repositorio : IRepositorio
    {
        public readonly TpInvestigacionContext _contexto;

        public Repositorio(TpInvestigacionContext contexto)
        {
            _contexto = contexto;
        }

        public List<Bloque> ListarTodo()
        {
            List<Bloque> lista = _contexto.Bloques.ToList();
            return lista;
        }

        public void GuardarBloque(Bloque bloque)
        {
            _contexto.Add(bloque);
            _contexto.SaveChanges();
        }

        public int ContadorBloques()
        {
            return _contexto.Bloques.Count();
        }

        public Bloque UltimoBloque()
        {
            return _contexto.Bloques.OrderBy(e => e.Id).Last();
        }

        public void EliminarBloque(int Id)
        {
            Bloque bloque = _contexto.Bloques.Find(Id);
            _contexto.Bloques.Remove(bloque);
            _contexto.SaveChanges();
        }

        public Bloque BuscarBloquePorId(int Id)
        {
            return _contexto.Bloques.Find(Id);
        }

        public void ModificarBloque(Bloque bloqueEditado)
        {
            Bloque bloque = _contexto.Bloques.Find(bloqueEditado.Id);
            bloque.Id = bloqueEditado.Id;
            bloque.Datos = bloqueEditado.Datos;
            bloque.Hash = bloqueEditado.Hash;
            bloque.HashAnterior = bloqueEditado.HashAnterior;
            bloque.Tiempo = bloqueEditado.Tiempo;
            _contexto.SaveChanges();
        }
    }
}
