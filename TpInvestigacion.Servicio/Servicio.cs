using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using TpInvestigacion.Data.Entidades;
using TpInvestigacion.Data.Interface;
using TpInvestigacion.Servicio.Interface;

namespace TpInvestigacion.Servicio
{
    public class Servicio : IServicio
    {
        readonly IRepositorio _repositorio;

        public Servicio(IRepositorio repositorio)    // importantisimo tener este constructor para enlazar con el repositorio
        {
            _repositorio = repositorio;
        }

        public List<Bloque> ListarTodo()
        {
            List<Bloque> lista = _repositorio.ListarTodo();
            return lista;
        }

        private string CalcularHash(string dato)
        {
            SHA256 sha256 = SHA256.Create();
            byte[] inputBytes = Encoding.ASCII.GetBytes($"{dato}");
            byte[] outputBytes = sha256.ComputeHash(inputBytes);
            return Convert.ToBase64String(outputBytes);
        }

        public void GuardarBloque(string dato)
        {
            Bloque bloque = new Bloque();
            bloque.Datos = dato;
            bloque.Tiempo = DateTime.Now.Date;

            if (_repositorio.ContadorBloques() == 0)
            {
                bloque.HashAnterior = "0";
            }
            else
            {
                var ultimoBloque = _repositorio.UltimoBloque();
                bloque.HashAnterior = ultimoBloque.Hash;
            }
            bloque.Hash = CalcularHash(bloque.Id + bloque.Datos + bloque.Tiempo + bloque.HashAnterior);
            _repositorio.GuardarBloque(bloque);
        }

        public void EliminarBloque(int Id)
        {
            _repositorio.EliminarBloque(Id);
        }

        public Bloque BuscarBloquePorId(int Id)
        {
            return _repositorio.BuscarBloquePorId(Id);
        }

        public void ModificarBloque(Bloque bloqueMoficado)
        {
            _repositorio.ModificarBloque(bloqueMoficado);
        }

        public string VerificarIntegridad()
        {
            string hash = null;
            List<Bloque> listaDatos = _repositorio.ListarTodo();
            for (int i = 0; i < listaDatos.Count; i++)
            {
                int IdActual = 0;
                int IdAnterior = 0;

                Bloque bloque = listaDatos[i];
                Bloque bloqueAnterior = listaDatos[i - 1];
                

                if (i == 0)
                {
                    if (bloque.HashAnterior != "0")
                    {
                        return "Falta el bloque de informacion inicial ";
                    }
                    
                }
                else
                {
                    
                    IdAnterior = bloqueAnterior.Id;
                    if (bloque.HashAnterior != bloqueAnterior.Hash)
                    {
                        return "Falta al menos un bloque de informacion";
                    }
                    
                }
                string hashActual = CalcularHash(bloque.Id + bloque.Datos + bloque.Tiempo + bloque.HashAnterior);
                string hashAnterior = CalcularHash(bloqueAnterior.Id + bloqueAnterior.Datos + bloqueAnterior.Tiempo + bloqueAnterior.HashAnterior);
                if (hashActual != hashAnterior)
                {
                    return "Al menos un bloque de informacion fue alterado, el hash almacenado no coincide con la informacion del bloque";
                }

            }
            return "La cadena de bloque se encuentra completa y su contenido no fue alterado";
        }
    }
}
