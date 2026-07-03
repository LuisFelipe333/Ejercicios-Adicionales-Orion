using Ejercicio4.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ejercicio4.Clases
{
    public class ReverseRepo: RepoDeal, IProduct
    {
        //Pertenecen a la interfaz
        private string DealName { get; set; }
        private string LocalId { get; set; }
        private int Titles { get; set; }
        private DateTime StartDate { get; set; }

        //Lo hacemos de esta forma para mantener los datos privados que se solicitan
        public ReverseRepo(string localId, int titles, DateTime startDate, string dealName)
        {
            LocalId = localId;
            Titles = titles;
            StartDate = startDate;
            DealName = dealName;
        }

        string IProduct.LocalId => this.LocalId;
        int IProduct.Titles => this.Titles;
        string IProduct.DealName => this.DealName;
        DateTime IProduct.AvailableSince => this.StartDate;


        //Independientes de la clase
        private decimal Price { get; set; }
        private string Counterparty { get; set; }
        
        private DateTime EndDate { get; set; }
    }
}
