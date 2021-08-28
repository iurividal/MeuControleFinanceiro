using MeuControleFinanceiro.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MeuControleFinanceiro.Repository.Servicos
{
    public interface IDespesaRepository
    {

        IEnumerable<DespesaModel> Get();

        void AddDespesa(DespesaModel despesa);

    
   

    }
}
