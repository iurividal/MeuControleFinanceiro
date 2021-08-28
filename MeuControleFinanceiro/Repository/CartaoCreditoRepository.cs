using MeuControleFinanceiro.Models;
using MeuControleFinanceiro.Repository.Servicos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;


namespace MeuControleFinanceiro.Repository
{
    public class CartaoCreditoRepository : ICartaoCreditoRepository
    {
        DB.IDBContext repository;

        public CartaoCreditoRepository(DB.IDBContext repository)
        {
            this.repository = repository;
        }

        public void AddCartao(CartaoCreditoModel cartao)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<CartaoCreditoModel> Get()
        {
          return repository.GetCollections<CartaoCreditoModel>("CartaoCredito");
        }
    }
}