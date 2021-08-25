using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MeuControleFinanceiro.Models
{
    public class CategoriaModel
    {

        public object _id { get; set; }
        public string Categoria { get; set; }
        public string Subcategoria { get; set; }
        public int IdCategoria { get; set; }

        public CategoriaModel()
        {

        }

        public CategoriaModel(int idcategoria, string categoria)
        {
            this.IdCategoria = idcategoria;
            this.Categoria = categoria;
            
        }

    }

    public class SubCategoria
    {

        public int Id { get; set; }
        public string Descricao { get; set; }


        public SubCategoria(int id, string descricao)
        {
            this.Id = id;
            this.Descricao = descricao;
        }

       
    }
}