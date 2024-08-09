using Core.Interface;
using Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories
{
    public class ShowRepository : IShowRepository
    {
        private readonly TvMazeContext _context;

        public ShowRepository(TvMazeContext context)
        {
            _context = context;
        }

        public async Task<List<Show>> GetAllShowsAsync()
        {
            return await _context.Shows
                .Include(s => s.Network)
                .ThenInclude(n => n.Country)
                .ToListAsync();
        }

        public async Task<Show> GetShowByIdAsync(int id)
        {
            return await _context.Shows
                .Include(s => s.Network)
                .ThenInclude(n => n.Country)
                .Include(s => s.Schedule)
                .Include(s => s.Rating)
                .Include(s => s.Externals)
                .Include(s => s.Image)
                .Include(s => s.Links)
                .Include(s => s.WebChannel)
                .ThenInclude(w => w.country)
                .FirstOrDefaultAsync(s => s.Id == id);
        }

        public async Task AddShowAsync(Show show)
        {
            AttachRelatedEntities(show);
            _context.Shows.Add(show);
            await _context.SaveChangesAsync();
        }

        public async Task AddShowsAsync(List<Show> shows)
        {
            await _context.Shows.AddRangeAsync(shows);
            await _context.SaveChangesAsync();
        }

        private void AttachRelatedEntities(Show show)
        {
            
            if (show.Network != null)
            {
                var existingNetwork = _context.Networks
                    .Include(n => n.Country)
                    .FirstOrDefault(s => s.Id == show.Network.Id);
                if (existingNetwork != null)
                {
                    _context.Entry(existingNetwork).CurrentValues.SetValues(show.Network);
                    
                    show.Network = existingNetwork;
                }
                
            }

            if (show.WebChannel != null)
            {
                var existingWebChannel = _context.WebChannels
                    .Include(n => n.country)
                    .FirstOrDefault(s => s.Id == show.WebChannel.Id);
                if (existingWebChannel != null)
                {
                    _context.Entry(existingWebChannel).CurrentValues.SetValues(show.WebChannel);

                    show.WebChannel = existingWebChannel;
                }

            }
        }
    }
}
