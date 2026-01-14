using Botiga.EndPoints;
using Botiga.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Botiga.Classes
{
    static class CalculsCarroDeLaCompra
    {
        public static decimal CalcularImport(List<CarroDeLaCompra> llista)
        {
            decimal total = 0;

            foreach (var item in llista)
            {
                total += item.Preu * item.Quantitat;
            }

            return total;
        }

       

        public static decimal DescomptePremium(List<CarroDeLaCompra> llista)
        {
            decimal total = CalcularImport(llista);
            decimal descompte = total * 0.10m;

            return total - descompte;
        }




    }

}