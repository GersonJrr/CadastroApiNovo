using CadastroPessoasApi.ViewModel;
using Dapper;
using System.Data.SqlClient;

namespace CadastroPessoasApi.Data
{
    public class Repository
    {
        string conexao = @"Server=(localdb)\mssqllocaldb;Database=CADASTROPESSOAS;Trusted_Connection=True;MultipleActiveResultSets=True";
        public IEnumerable<PessoaViewModel> GetAll()
        {
            string query = "SELECT TOP 1000 * FROM PESSOAS";
            using (SqlConnection con = new SqlConnection(conexao))
            {
                return con.Query<PessoaViewModel>(query);
            }
        }

        public PessoaViewModel GetById(int pessoaId)
        {
            string query = "SELECT * FROM PESSOAS WHERE pessoaId = @pessoaId";
            using (SqlConnection con = new SqlConnection(conexao))
            {
                return con.QueryFirstOrDefault<PessoaViewModel>(query, new { pessoaId = pessoaId });
            }
        }
        public PessoaViewModel GetByPrimeiroNome(string primeiroNome)
        {
            string query = "SELECT * FROM PESSOAS WHERE primeiroNome = @primeiroNome";
            using (SqlConnection con = new SqlConnection(conexao))
            {
                return con.QueryFirstOrDefault<PessoaViewModel>(query, new { primeiroNome = primeiroNome });
            }
        }

        public string Create(PessoaViewModel pessoa)
        {
            try
            {
                string query = @"INSERT INTO PESSOAS (primeiroNome, nomeMeio, ultimoNome, CPF)Values(@primeiroNome, @nomeMeio, @ultimoNome, @CPF)";
                using (SqlConnection con = new SqlConnection(conexao))
                {

                    con.Execute(query, new
                    {
                        primeiroNome = pessoa.primeiroNome,
                        nomeMeio = pessoa.nomeMeio,
                        CPF = pessoa.CPF,
                        ultimoNome = pessoa.ultimoNome,

                    });
                }
                return null;
            }
            catch (Exception)
            {
                throw;
            }

        }

        public bool DeleteById(int pessoaId)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(conexao))
                {
                    con.Open();

                    string query = "DELETE FROM PESSOAS WHERE pessoaId = @pessoaId";
                    int rowsAffected = con.Execute(query, new { pessoaId });

                    return rowsAffected > 0;
                }
            }
            catch (Exception ex)
            {
                
                return false;
            }
        }
        public void UpdateById(int pessoaId, string novoNome, string NNomeMeio, string nUltimoNome, string nCPF)
        {
            string query = "UPDATE PESSOAS SET primeiroNome = @novoNome, nomeMeio  = @NNomeMeio, ultimoNome = @nUltimoNome, CPF = @nCPF WHERE pessoaId = @pessoaId";

            using (SqlConnection con = new SqlConnection(conexao))
            {
                con.Execute(query, new { novoNome = novoNome, NNomeMeio = NNomeMeio, nUltimoNome= nUltimoNome, nCPF = nCPF, pessoaId = pessoaId });
            }
        }


    }
}
