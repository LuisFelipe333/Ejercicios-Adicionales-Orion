using Ejercicio4.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ejercicio4.Clases
{
    public class Cetes : BondDeal, IProduct
    {
        //Pertenecen a la interfaz
        public string DealName { get; set; } 

        public string LocalId { get; set; }    

        public int Titulos { get; set; }
        public int Titles => Titulos;

        public DateTime SettlementDate { get; set; }
        public DateTime AvailableSince => SettlementDate;


        //Independientes de la clase

        public decimal Precio { get; set; }
        public string Contraparte { get; set; }
        
        

    }
}
