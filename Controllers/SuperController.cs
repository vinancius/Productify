using Microsoft.AspNetCore.Mvc;
using Productify.Repositories;

namespace Productify.Controllers
{
    [ApiController]
    public class SuperController : ControllerBase
    {
        protected readonly ProdutoRepository _produtoRepository;

        protected SuperController(ProdutoRepository produtoRepository)
        {
            _produtoRepository = produtoRepository;
        }
    }
}
