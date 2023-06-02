using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TpInvestigacion.Data.Entidades;

namespace TpInvestigacion.Data.Interface
{
    public interface IRepositorio
    {
        List<Bloque> ListarTodo();
        void GuardarBloque(Bloque bloque);
        int ContadorBloques();
        public Bloque UltimoBloque();
        void EliminarBloque(int Id);
        Bloque BuscarBloquePorId(int Id);
        void ModificarBloque(Bloque bloqueEditado);
    }
}
