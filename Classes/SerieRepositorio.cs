using System.Collections.Generic;
using DIO.Series.Interfaces;

namespace DIO.Series.Classes
{
    public class SerieRepositorio : 
        IRepositorio<Serie>
    {
        private IList<Serie> listaSerie;

        public SerieRepositorio()
        {
            this.listaSerie = new List<Serie>();
        }

        public IList<Serie> Lista()
        {
            return listaSerie;
        }
        public Serie RetornarPorId(int id)
        {
            return listaSerie[id];
        }
        public void Insere(Serie entidade)
        {
            listaSerie.Add(entidade);
        }
        public void Exlui(int id)
        {
            listaSerie[id].Excluir();
        }
        public void Atualiza(int id, Serie entidade)
        {
            listaSerie[id] = entidade;
        }
        public int ProximoId()
        {
            return listaSerie.Count;
        }  
    }
}