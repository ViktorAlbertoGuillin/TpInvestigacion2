using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TpInvestigacion.Data.Entidades;

namespace TpInvestigacion.Servicio.Interface
{
    public interface IServicio
    {
        List<Bloque> ListarTodo();
        public void GuardarBloque(string dato);
        void EliminarBloque(int Id);
        Bloque BuscarBloquePorId(int Id);
        void ModificarBloque(Bloque bloqueMoficado);
        string VerificarIntegridad();
    }
}
