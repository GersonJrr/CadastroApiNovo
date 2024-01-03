using CadastroPessoasApi.Data;
using CadastroPessoasApi.ViewModel;

namespace CadastroPessoasApi.Service
{
    public class ServicePessoa
    {
        public IEnumerable<PessoaViewModel> GetAll()
        {
            var repository = new Repository();
            return repository.GetAll().ToList();
        }

        public PessoaViewModel GetById(int pessoaId)
        {
            var repository = new Repository();
            return repository.GetById(pessoaId);
        }
        public PessoaViewModel GetByprimeiroNome(string primeiroNome)
        {
            var repository = new Repository();
            return repository.GetByPrimeiroNome(primeiroNome);
        }


        public string Create (PessoaViewModel pessoa)
        {
            if (pessoa == null)
                return "Os dados são obrigatorios";
            if (pessoa != null && string.IsNullOrEmpty(pessoa.nomeMeio))
                return "O campo nomeMeio é obrigatorio";
            if (pessoa != null && string .IsNullOrEmpty(pessoa.ultimoNome))
                return "O campo ultimoNome é obrigatorio";
            if (pessoa != null && string.IsNullOrEmpty(pessoa.CPF))
                    return "O campo CPF é obrigatorio";

            var repository = new Repository();
            return repository.Create(pessoa);
        }
        
       
        private readonly Repository repository;

        public ServicePessoa()
        {
            repository = new Repository();
        }

           
        public bool DeleteById(int pessoaId)
        {
            return repository.DeleteById(pessoaId);
        }

        public void UpdateById(int pessoaId, string novoNome, string NNomeMeio, string nUltimoNome, string nCPF)
        {
            var repository = new Repository();
            repository.UpdateById(pessoaId, novoNome, NNomeMeio, nUltimoNome, nCPF);


        }

    }
}
