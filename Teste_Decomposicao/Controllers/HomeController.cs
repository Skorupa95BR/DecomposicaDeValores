using Microsoft.AspNetCore.Mvc;

namespace Teste_Decomposicao.Controllers
{
    public class HomeController : Controller
    {

        public IActionResult Home()
        {
            return View();
        }

        public IActionResult SobreMim()
        {
            return View();
        }

        public IActionResult Index()
        {
            return View();
        }

        public ActionResult DecomposicaoValores()
        {
            decimal[] valores = { 153647.00m, 2341.56m, 34567345.34m, 5239820.00m, 928374.00m, 34234.00m, 3.01m, 1234.56m, 888.99m, 327563.56m, 1658.56m, 12568.96m, 65785.96m, 12.69m, 25132.65m, 458.61m, 0.07m, 12569874.52m, 58932.12m, 14523.01m, 965.58m, 85471.12m, 96312.57m, 95625.32m, 1870.45m, 920.15m, 4.65m, 5568598546.00m, 8596547.85m, 45985.56m, 985624.00m, 51217.12m, 7125.00m, 8513m, 43.21m, 985.54m, 145.98m, 458.32m, 444.85m, 458.48m, 689.56m, 321.65m, 420.89m, 369.45m, 1250.69m, 12.65m, 1.25m, 1.50m, 7.89m, 14.32m };

            List<string> valoresDecompostos = new List<string>();

            decimal[] valoresNotas = { 200, 100, 50, 20, 10, 5, 2 };
            decimal[] valoresMoedas = { 1, 0.5m, 0.1m, 0.05m, 0.01m };

            foreach (decimal valor in valores)
            {
                Dictionary<decimal, int> notas = new Dictionary<decimal, int>();
                Dictionary<decimal, int> moedas = new Dictionary<decimal, int>();
                decimal valorRestante = valor;

                foreach (decimal nota in valoresNotas)
                {
                    int qtdNotas = (int)Math.Floor(valorRestante / nota);
                    notas.Add(nota, qtdNotas);
                    valorRestante -= qtdNotas * nota;
                }

                foreach (decimal moeda in valoresMoedas)
                {
                    int qtdMoedas = (int)Math.Floor(valorRestante / moeda);
                    moedas.Add(moeda, qtdMoedas);
                    valorRestante -= qtdMoedas * moeda;
                }

                string valorDecomposto = $"{valor:C2} = ";
                foreach (var nota in notas)
                {
                    if (nota.Value > 0)
                    {
                        valorDecomposto += $"{nota.Value} nota(s) de {nota.Key:C2}, ";
                    }
                }

                foreach (var moeda in moedas)
                {
                    if (moeda.Value > 0)
                    {
                        valorDecomposto += $"{moeda.Value} moeda(s) de {moeda.Key:C2}, ";
                    }
                }

                valorDecomposto = valorDecomposto.TrimEnd(',', ' ');

                valoresDecompostos.Add(valorDecomposto);
            }

            ViewBag.ValoresDecompostos = valoresDecompostos;

            return View();
        }

    }
}