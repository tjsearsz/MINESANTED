using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DatosSKD;
using DatosSKD.IntefazDAO;
using DominioSKD;

namespace  DatosSKD.InterfazDAO.Modulo16
{
    public interface IdaoCarrito : IDao<Entidad, bool>
    {

        bool agregarEventoaCarrito(Entidad persona, Entidad idEvento, int cantidad, int precio);
        bool agregarInventarioaCarrito(Entidad persona, Entidad idimplemento, int cantidad, int precio);
        bool agregarMatriculaaCarrito(Entidad persona, Entidad idmatricula, int cantidad, int precio);
        bool eliminarItem(int tipoObjeto, int objetoBorrar, Entidad parametro);
        bool getEvento(Entidad idusuario);
        bool getImplemento(Entidad idusuario);
        bool getMatricula(Entidad idusuario);
        bool modificarCarritoevento(Entidad persona, Entidad idevento, int cantidad);
        bool modificarCarritoimplemento(Entidad persona, Entidad idimplemento, int cantidad);
        bool modificarCarritomatricula(Entidad persona, Entidad idmatricula, int cantidad);
        bool registrarPago(String tipoPago, List<int> datos, Entidad persona);


    }
}
