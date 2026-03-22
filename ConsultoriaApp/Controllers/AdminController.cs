using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;

[Authorize(Roles = "Admin")]
public class AdminController : Controller
{
    public IActionResult Index()
    {
        return View(BancoFake.Solicitacoes);
    }

    public IActionResult Aprovar(int id)
    {
        var s = BancoFake.Solicitacoes.FirstOrDefault(x => x.Id == id);
        if (s != null) s.Status = "Aprovado";

        return RedirectToAction("Index");
    }

    public IActionResult Reprovar(int id)
    {
        var s = BancoFake.Solicitacoes.FirstOrDefault(x => x.Id == id);
        if (s != null) s.Status = "Reprovado";

        return RedirectToAction("Index");
    }
}