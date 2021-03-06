using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Car.Extensions;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Car.Models.ViewModels
{
    public class CarViewModel
    {
        public Sale Sale { get; set; }
        public IEnumerable<Make> Makes { get; set; }
        public IEnumerable<Model> Models { get; set; }
        public IEnumerable<Currency> Currencies { get; set; }

        public List<Currency> CList = new List<Currency>();
        public List<Currency> CreateList()
        {
            CList.Add(new Currency("USD", "USD"));
            CList.Add(new Currency("TRY", "TRY"));
            return CList;
        }

        public CarViewModel()
        {
            Currencies = CreateList();
        }

    }


    public class Currency
    {
        public String Id { get; set; }
        public String Name { get; set; }
        public Currency(String id, String value)
        {
            Id = id;
            Name = value;
        }
    }
}
