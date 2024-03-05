﻿using Airport.Core.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApplication1;

namespace Aairport.Data.Repositories
{
   
    public class PassengerRepository:IpassengerRepository
    {
        private readonly DataContext _context;
        public PassengerRepository(DataContext context)
        {
            _context = context;
        }
        public List<Passenger> GetList()
        {
            return _context.Passengers.Include(p => p.flight).ToList();  
        }
        public async void PostPassengerAsync(Passenger p)
        {
            _context.Passengers.Add(p);
         await  _context.SaveChangesAsync();


        }
        public async void UpdatePassengerAsync(int index, Passenger p)
        {
            _context.Passengers.ToList()[index].Name= p.Name;
            _context.Passengers.ToList()[index].NumBags = p.NumBags;
            _context.Passengers.ToList()[index].CountryOrigion = p.CountryOrigion;
            _context.Passengers.ToList()[index].distnationCountry = p.distnationCountry;
          await _context.SaveChangesAsync();

        }
        public async void RemovePassengerAsync(int index)
        {
            _context.Passengers.Remove(_context.Passengers.ToList()[index]);
          await _context.SaveChangesAsync();

        }
    }
}
