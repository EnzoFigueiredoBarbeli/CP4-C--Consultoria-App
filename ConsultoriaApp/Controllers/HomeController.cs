using Microsoft.AspNetCore.Mvc;

public class HomeController : Controller
{
    static List<Problema> problemas = new List<Problema>()
    {
        new Problema { Id = 1, Nome = "Bug no sistema", Descricao = "Erro crítico", TempoResposta = 24 },
        new Problema { Id = 2, Nome = "Nova funcionalidade", Descricao = "Criar nova feature", TempoResposta = 72 }
    };

    public IActionResult Index()
    {
        return View(problemas);
    }

    public IActionResult Solicitar(int id)
    {
        var problema = problemas.FirstOrDefault(p => p.Id == id);
        return View(problema);
    }

    [HttpPost]
    public IActionResult Solicitar(Solicitacao s)
    {
        s.Id = BancoFake.Solicitacoes.Count + 1;
        s.Status = "Pendente";

        BancoFake.Solicitacoes.Add(s);

        TempData["msg"] = "Pedido solicitado com sucesso!";
        return RedirectToAction("Index");
    }
}