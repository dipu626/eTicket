﻿using eticket.Models;
using Microsoft.EntityFrameworkCore;

namespace eticket.Data.Services
{
    public class ActorsService : IActorsService
    {
        private readonly AppDbContext _context;

        public ActorsService(AppDbContext context)
        {
            _context = context;
        }

        void IActorsService.Add(Actor actor)
        {
            throw new NotImplementedException();
        }

        void IActorsService.Delete(int id)
        {
            throw new NotImplementedException();
        }

        async Task<IEnumerable<Actor>> IActorsService.GetAll()
        {
            var result = await _context.Actors.ToListAsync();
            return result;
        }

        Actor IActorsService.GetById(int id)
        {
            throw new NotImplementedException();
        }

        Actor IActorsService.Update(int id, Actor newActor)
        {
            throw new NotImplementedException();
        }
    }
}
