using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebApiContato.Models
{
    public class ContatoModel
    {
        public int IdContato { get; set; }

        public string Nome { get; set; }

        public string Canal { get; set; }

        public string Valor { get; set; }

        public string Obs { get; set; }

        public ContatoModel(){ }

        public ContatoModel(int id, string nome, string canal, string valor, string obs)
        {
            IdContato = id;
            Nome = nome;
            Canal = canal;
            Valor = valor;
            Obs = obs;
        }
    }
}