using Lab04MVCWebRole.ServiceReference1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Lab04MVCWebRole.Controllers
{
    public class TransactionsController : Controller
    {
        ServiceReference1.Service1Client sc = new Service1Client();

        // GET: Transactions
        public ActionResult Index()
        {
            //return View();
            return View(sc.GetAccountList());
        }

        [HttpPost]
        public ActionResult Transaction(string txtAccount, int txtAmount, string btnTransaction)
        {
            if (btnTransaction == "Deposit")
            {
                sc.Deposit(txtAccount, txtAmount);
            }
            else if (btnTransaction == "Withdraw")
            {
                sc.Withdraw(txtAccount, txtAmount);
            }

            return RedirectToAction("Index");
        }

        [HttpPost]
        public ActionResult SendMoney(string txtSender, string txtReceiver, string txtAmountToSend)
        {
            sc.SendMoney(txtSender, txtReceiver, txtAmountToSend);
            return RedirectToAction("Index");
        }
    }
}