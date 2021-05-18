using System.Collections.Generic;

namespace DIO.Series.Interfaces
{
    public interface IRepositorio<T>
    {
        IList<T> Lista();
        T RetornarPorId(int id);
        void Insere(T entidade);
        void Exlui(int id);
        void Atualiza(int id, T entidade);
        int ProximoId();    
    }
}