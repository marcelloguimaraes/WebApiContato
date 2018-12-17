using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApiContato.Models
{
    public class RepositorioContato
    {
        public static List<ContatoModel> contato;

        public static List<ContatoModel> Contato
        {
            get
            {
                if (contato == null)
                    GerarContato();
                return contato;
            }
            set
            {
                contato = value;
            }
        }

        private static void GerarContato()
        {
            contato = new List<ContatoModel>();

            contato.Add(new ContatoModel
            {
                IdContato = 1,
                Nome = "Marcello Guimarães",
                Canal = "Celular",
                Valor = "021983744669",
                Obs = ""
            });
        }
    }
}