using Microsoft.AspNetCore.Mvc;
using MessageBoardClient.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Linq;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using System.Threading.Tasks;
using System.Security.Claims;
using System.Collections.Generic;

namespace MessageBoardClient.Controllers
{
  public class MessagesController : Controller
  {
    public IActionResult Index()
    {
      var allMessages = Message.GetMessages();
      return View(allMessages);
    }
    public IActionResult Details(int id)
    {
      var message = Message.GetDetails(id);
      return View(message);
    }
    public ActionResult Create()
    {
      return View();
    }
    [HttpPost]
    public ActionResult Create(Message message)
    {
      message.Date = System.DateTime.Now;
      Message.Post(message);
      return RedirectToAction("Index");
    }
    public ActionResult Edit(int id)
    {
      var message = Message.GetDetails(id);
      return View(message);
    }
    [HttpPost]
    public ActionResult Edit(Message message)
    {
      message.Date = System.DateTime.Now;
      Message.Put(message);
      return RedirectToAction("Details", new {id = message.MessageId});
    }
    public ActionResult Delete(int id)
    {
      var message = Message.GetDetails(id);
      return View(message);
    }
    [HttpPost, ActionName("Delete")]
    public ActionResult DeleteConfirmed(int id)
    {
      Message.Delete(id);
      return RedirectToAction("Index");
    }
  }
}