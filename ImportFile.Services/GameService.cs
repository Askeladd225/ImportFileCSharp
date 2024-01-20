using ImportFile.Services.Interface;
using ImportFile.WebApi.Core.Domain;

namespace ImportFile.Services
{
    public class GameService : IGameService
    {
        List<Game> IGameService.GetGameList()
        {
            throw new NotImplementedException();
        }

        List<Game> IGameService.SaveGameList(List<Game> games)
        {
            throw new NotImplementedException();
        }
    }
}