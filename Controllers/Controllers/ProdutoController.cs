using Microsoft.AspNetCore.Mvc;

namespace projeto_sistema_vendas.Controllers
{
    public class ProdutoController : Controller
    {
       [HttpGet("ProdutoTeste")]
        public string ProdutoTeste(string nomeProduto , int quantidadeProduto, decimal precoProduto)
        {
            string nome, quantidade, preco, resultado;
            nome = nomeProduto;
            quantidade = quantidadeProduto.ToString();
            preco = precoProduto.ToString();
            resultado = $"Produto: {nome}, Quantidade: {quantidade}, Preço: {preco}";
            return resultado;
        }
    }
}