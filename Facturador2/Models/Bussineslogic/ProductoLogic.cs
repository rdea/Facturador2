using Facturador2.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Facturador2.Models.Bussineslogic
{
    public class ProductoLogic
    {
        public List<Producto> Buscar(string nombre)
        {
            using (var context = new FacturadorContext())
            {
                context.Configuration.LazyLoadingEnabled = false;
                context.Configuration.ProxyCreationEnabled = false;

                var productos = context.Producto.OrderBy(x => x.Nombre)
                                        .Where(x => x.Nombre.Contains(nombre))
                                        .Take(10)
                                        .ToList();

                return productos;
            }
        }

    }
}