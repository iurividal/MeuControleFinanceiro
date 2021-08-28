using MeuControleFinanceiro.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MeuControleFinanceiro.Repository
{
    public interface ILancamentoRepository
    {
        IEnumerable<LancamentoModel> GetAll();
        IEnumerable<LancamentoModel> GetDesepesa();
        IEnumerable<LancamentoModel> GetReceita();
        IEnumerable<LancamentoModel> GetCartaoCredito();

        void Insert(LancamentoModel lancamento);

        void Delete(int id);

        int GetNextValue();

    }
}
