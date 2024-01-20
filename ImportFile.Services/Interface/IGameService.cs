using ImportFile.WebApi.Core.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImportFile.Services.Interface
{
    public interface IGameService
    {
        List<Game> SaveGameList(List<Game> games);
        List<Game> GetGameList();
    }
}
