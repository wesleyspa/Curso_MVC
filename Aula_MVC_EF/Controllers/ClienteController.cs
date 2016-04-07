﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Aula_MVC_EF.Models;

namespace Aula_MVC_EF.Controllers
{
    public class ClienteController : Controller
    {
        // GET: Cliente
        public ActionResult Index()
        {
            using (ClienteContext clienteContext = new ClienteContext())
            {
                List<Cliente> clientes = clienteContext.clientes.ToList();
                return View(clientes);
            };
        }

        public ActionResult Detalhes(int id)
        {
            using (ClienteContext clienteContext = new ClienteContext())
            {
                Cliente cliente = clienteContext.clientes.Single(cli => cli.ClienteId == id);
                return View(cliente);
            }
        }
    }
}