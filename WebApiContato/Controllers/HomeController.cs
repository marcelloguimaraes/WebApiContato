using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebApiContato.Controllers
{
    public class HomeController : Controller
    {
        public RedirectResult Index()
        {
            //Retorna para o método principal da Api, que retorna os contatos em JSON
            return Redirect("api/Contato");
        }
    }
}
