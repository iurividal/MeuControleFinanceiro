using MeuControleFinanceiro.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MeuControleFinanceiro.Repository
{
    public interface ICategoriaRepository
    {

        IEnumerable<CategoriaModel> GetCategoria();

        void AddCategoria(CategoriaModel categoria);
    }
}
