using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Interface
{
    public interface IShowRepository
    {
        Task<Show> GetShowByIdAsync(int id);
        Task<List<Show>> GetAllShowsAsync();
        Task AddShowsAsync(List<Show> shows);
        Task AddShowAsync(Show show);
    }
}
