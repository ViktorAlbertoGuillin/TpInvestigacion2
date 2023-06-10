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

        public Servicio(IRepositorio repositorio)   
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
            bloque.Tiempo = DateTime.Now;

            if (_repositorio.ContadorBloques() == 0)
            {
                bloque.HashAnterior = "0";
            }
            else
            {
                var ultimoBloque = _repositorio.UltimoBloque();
                bloque.HashAnterior = ultimoBloque.Hash;
            }
            string palabraConcatenada = bloque.Datos + bloque.HashAnterior + bloque.Tiempo;
            bloque.Hash = CalcularHash( palabraConcatenada);
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
            int i = 0;
            while (i< listaDatos.Count)
            {
                
                int IdActual = 0;
                int IdAnterior = 0;
                int indiceAnterior = 0;
                if(listaDatos[i] != null) 
                {
                    indiceAnterior = i - 1;
                    Bloque bloque = listaDatos[i];
                    if (!HashIntacto(bloque)) 
                    {
                        return "Al menos un bloque de informacion fue alterado, el hash almacenado no coincide con la informacion del bloque";
                    }
                    if( i == 0 )
                    {
                        if (bloque.HashAnterior != "0")
                        {
                            return "Falta el bloque de informacion inicial ";
                        }   
                    }
                    else
                    {
                        Bloque bloqueAnterior = listaDatos[indiceAnterior];
                        if (bloque.HashAnterior != bloqueAnterior.Hash)
                        {
                            return "Falta al menos un bloque de informacion";
                        }
                    }
                }
                else
                {
                    return "La lista esta vacia";
                }
                i++;
            }
            return "La cadena de bloque se encuentra completa y su contenido no fue alterado";
        }
        private Boolean HashIntacto(Bloque bloque)
        {
            string palabraConcatenada = bloque.Datos + bloque.HashAnterior + bloque.Tiempo;
            string hashCalculado= CalcularHash(palabraConcatenada);
            if (hashCalculado.Equals(bloque.Hash))
            {
                return true;
            }
            else
            {
                return false;
            }
            
        }
    }
}
