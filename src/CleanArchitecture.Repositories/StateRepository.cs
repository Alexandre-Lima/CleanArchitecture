using CleanArchitecture.Borders.Dtos.Addressses;
using CleanArchitecture.Borders.Repositories;

namespace CleanArchitecture.Repositories
{
    public class StateRepository : IStateRepository
    {
        readonly List<StateResponse> _states;

        public StateRepository()
        {
            _states = new List<StateResponse>
            {
                new StateResponse { Code = "AC", Name = "Acre", CapitalCity = "Rio Branco"},
                new StateResponse { Code = "AL", Name = "Alagoas", CapitalCity = "Maceió"},
                new StateResponse { Code = "AP", Name = "Amapá", CapitalCity = "Macapá"},
                new StateResponse { Code = "AM", Name = "Amazonas", CapitalCity = "Manaus"},
                new StateResponse { Code = "BA", Name = "Bahia", CapitalCity = "Salvador"},
                new StateResponse { Code = "CE", Name = "Ceará", CapitalCity = "Fortaleza"},
                new StateResponse { Code = "DF", Name = "Distrito Federal", CapitalCity = "Brasília"},
                new StateResponse { Code = "ES", Name = "Espírito Santo", CapitalCity = "Vitória"},
                new StateResponse { Code = "GO", Name = "Goiás", CapitalCity = "Goiânia"},
                new StateResponse { Code = "MA", Name = "Maranhão", CapitalCity = "São Luís"},
                new StateResponse { Code = "MT", Name = "Mato Grosso", CapitalCity = "Cuiabá"},
                new StateResponse { Code = "MS", Name = "Mato Grosso do Sul", CapitalCity = "Campo Grande"},
                new StateResponse { Code = "MG", Name = "Minas Gerais", CapitalCity = "Belo Horizonte"},
                new StateResponse { Code = "PA", Name = "Pará", CapitalCity = "Belém"},
                new StateResponse { Code = "PB", Name = "Paraíba", CapitalCity = "João Pessoa"},
                new StateResponse { Code = "PR", Name = "Paraná", CapitalCity = "Curitiba"},
                new StateResponse { Code = "PE", Name = "Pernambuco", CapitalCity = "Recife"},
                new StateResponse { Code = "PI", Name = "Piauí", CapitalCity = "Teresina"},
                new StateResponse { Code = "RJ", Name = "Rio de Janeiro", CapitalCity = "Rio de Janeiro"},
                new StateResponse { Code = "RN", Name = "Rio Grande do Norte", CapitalCity = "Natal" },
                new StateResponse { Code = "RS", Name = "Rio Grande do Sul", CapitalCity = "Porto Alegre"},
                new StateResponse { Code = "RO", Name = "Rondônia", CapitalCity = "Porto Velho"},
                new StateResponse { Code = "RR", Name = "Roraima", CapitalCity = "Boa Vista"},
                new StateResponse { Code = "SC", Name = "Santa Catarina", CapitalCity = "Florianópolis"},
                new StateResponse { Code = "SP", Name = "São Paulo", CapitalCity = "São Paulo"},
                new StateResponse { Code = "SE", Name = "Sergipe", CapitalCity = "Aracaju"},
                new StateResponse { Code = "TO", Name = "Tocantins", CapitalCity = "Palmas"}
            };
        }

        public Task<StateResponse> GetState(string uf)
        {
            return Task.FromResult(_states.First(a => a.Code.Equals(uf, StringComparison.OrdinalIgnoreCase)));
        }

        public Task<List<StateResponse>> GetStates()
        {
            return Task.FromResult(_states);
        }
    }
}
