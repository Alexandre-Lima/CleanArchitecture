using CleanArchitecture.Borders.Dtos.Addressses;

namespace CleanArchitecture.Borders.Repositories
{
    public interface IStateRepository
    {
        Task<StateResponse> GetState(string uf);

        Task<List<StateResponse>> GetStates();
    }
}
