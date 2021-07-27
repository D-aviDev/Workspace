using System;
using System.Collections.Generic;
using MRV_DIO.Series.Interfaces;

namespace MRV_DIO.Series.Classes
{
    public class RepositorySeries : IRepository<Serie>
    {
        private List<Serie> SeriesList = new List<Serie>();
        public List<Serie> List()
        {
            return SeriesList;
        }

        public Serie ReturnById(int id) => SeriesList[id];
        public void Insert(Serie objeto) => SeriesList.Add(objeto);
        public void Delete(int id) => SeriesList[id].Delete();
        public void Update(int id, Serie objeto) => SeriesList[id] = objeto;
        public int NextId() => SeriesList.Count;    //Sempre incrementa em função do número de registros
    }
}