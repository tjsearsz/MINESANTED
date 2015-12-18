using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DatosSKD;
using DominioSKD;

namespace  DatosSKD.DAO.InterfazDAO.Modulo16
{
    public interface IdaoCarrito : Idao<Entidad>
    {

        void agregarEventoaCarrito(Entidad persona, Entidad idEvento, int cantidad, int precio);
        void agregarInventarioaCarrito(Entidad persona, Entidad idimplemento, int cantidad, int precio);
        void agregarMatriculaaCarrito(Entidad persona, Entidad idmatricula, int cantidad, int precio);
        void eliminarItem(int tipoObjeto, int objetoBorrar, Entidad parametro);
        void getEvento(Entidad idusuario);
        void getImplemento(Entidad idusuario);
        void getMatricula(Entidad idusuario);
        void modificarCarritoevento(Entidad persona, Entidad idevento, int cantidad);
        void modificarCarritoimplemento(Entidad persona, Entidad idimplemento, int cantidad);
        void modificarCarritomatricula(Entidad persona, Entidad idmatricula, int cantidad);
        void registrarPago(String tipoPago, List<int> datos, Entidad persona);


    }
}
