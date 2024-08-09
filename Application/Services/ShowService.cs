using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Interface;
using Core.Entities;

namespace Application.Services
{
    public class ShowService
    {
        private readonly IShowRepository _showRepository;

        public ShowService(IShowRepository showRepository)
        {
            _showRepository = showRepository;
        }

        public virtual async Task<List<Show>> GetShowsAsync()
        {
            return await _showRepository.GetAllShowsAsync();
        }

        public virtual async Task<Show> GetShowByIdAsync(int id)
        {
            return await _showRepository.GetShowByIdAsync(id);
        }

        public async Task StoreShowsAsync(List<Show> shows)
        {
            var newShow = new Show();
            foreach (var show in shows)
            {
                newShow.Id = show.Id;
                newShow.Name = show.Name;
                newShow.Url = show.Url;
                newShow.Type = show.Type;
                newShow.Language = show.Language;
                newShow.Genres = show.Genres;
                newShow.Status = show.Status;
                newShow.Runtime = show.Runtime;
                newShow.AverageRuntime = show.AverageRuntime;
                newShow.Premiered = show.Premiered;
                newShow.Ended = show.Ended;
                newShow.OfficialSite = show.OfficialSite;
                newShow.Schedule = show.Schedule;
                newShow.Rating = show.Rating;
                newShow.Weight = show.Weight;
                newShow.Network = show.Network;
                newShow.WebChannel = show.WebChannel;
                newShow.DvdCountry = show.DvdCountry;
                newShow.Externals = show.Externals;
                newShow.Image = show.Image;
                newShow.Summary = show.Summary;
                newShow.Updated = show.Updated;
                newShow.Links = show.Links;

                await _showRepository.AddShowAsync(newShow);
            }
        }

        public async Task AddShowAsync(Show show)
        {
            await _showRepository.AddShowAsync(show);
        }
    }
}
