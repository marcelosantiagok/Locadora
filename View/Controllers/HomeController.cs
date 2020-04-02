using Model;
using Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace View.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            
            ClienteController controller = new ClienteController();

            List<Cliente> lst = controller.Listar();

            return View(lst);
        }

        public ActionResult Visualizar(int id)
        {
            ClienteController controller = new ClienteController();
            var registro = controller.Buscar(id);

            return View(registro);
        }

        public ActionResult Inserir()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Inserir(Cliente registro)
        {
            if (!ModelState.IsValid)
            {
                return View(registro);
            }

            ClienteController controller = new ClienteController();
            controller.Inserir(registro);

            return RedirectToAction("Index");
        }

        public ActionResult Editar(int id)
        {
            ClienteController controller = new ClienteController();
            var registro = controller.Buscar(id);

            return View(registro);
        }

        [HttpPost]
        public ActionResult Editar(Cliente registro)
        {
            if (!ModelState.IsValid)
            {
                return View(registro);
            }

            ClienteController controller = new ClienteController();
            controller.Atualizar(registro);

            return RedirectToAction("Index");
        }

        public ActionResult Excluir(int id)
        {
            ClienteController controller = new ClienteController();
            var registro = controller.Buscar(id);

            return View(registro);
        }

        [HttpPost, ActionName("Excluir")]
        public ActionResult ExcluirConfirmar(int id)
        {
            ClienteController controller = new ClienteController();
            controller.Excluir(id);

            return RedirectToAction("Index");
        }
    }
}