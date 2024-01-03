using CadastroPessoasApi.Data;
using CadastroPessoasApi.Service;
using CadastroPessoasApi.ViewModel;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CadastroPessoasApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PessoaController : ControllerBase
    {
        [HttpGet("GetAll")]
        public IEnumerable<PessoaViewModel> GetAll()
        {
            var service = new ServicePessoa();
            return service.GetAll();


        }
        [HttpGet("GetById")]
        public PessoaViewModel GetById(int pessoaId)
        {
            var service = new ServicePessoa();
            return service.GetById(pessoaId);
        }
        [HttpGet("GetByprimeiroNome/{primeiroNome}")]
        public PessoaViewModel GetByprimeiroNome(string primeiroNome)
        {
            var service = new ServicePessoa();
            return service.GetByprimeiroNome(primeiroNome);
        }

        [HttpPost("create")]

        public ActionResult Create(PessoaViewModel pessoa)
        {
            var service = new ServicePessoa();
            var resultado = service.Create(pessoa);

            var result = new
            {
                success = true,
                Data = resultado,
            };
            return Ok(result);
        }
        [HttpDelete("DeleteById/{pessoaId}")]
        public IActionResult DeleteById(int pessoaId)
        {
            var service = new ServicePessoa();
            var result = service.DeleteById(pessoaId);

            if (result)
            {
                var successResponse = new
                {
                    Success = true,
                    Message = "Deletado Com sucesso."
                };
                return Ok(successResponse);
            }
            else
            {
                var errorResponse = new
                {
                    Success = false,
                    Message = "Falha ao deletar."
                };
                return BadRequest(errorResponse);
            }
        }


        [HttpPut("UpdateById/{pessoaId}")]

        public void Update(int pessoaId, string novoNome, string NNomeMeio, string nUltimoNome, string nCPF)
        {
            var service = new ServicePessoa();
            service.UpdateById(pessoaId, novoNome, NNomeMeio, nUltimoNome, nCPF);

        }

    }
}
