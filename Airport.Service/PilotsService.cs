﻿using Aairport.Data.Repositories;
using Airport.Core.Repositories;
using Airport.Core.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApplication1;

namespace Airport.Service
{
    public class PilotsService:IpilotService
    {
        private readonly PilotRepository _pilotRepository;
        private int countId;
        private int CountID;
        private Pilot pilot;

        public PilotsService(PilotRepository pilotRepository)
        {
            _pilotRepository = pilotRepository;
        }

        public List<Pilot> GettAll()
        {
            return _pilotRepository.GetList();
        }
        public Pilot GetById(int Id)
        {

            Pilot foundPilot = _pilotRepository.GetList().Find(x => x.Id == Id);
            if (foundPilot == null)
            {
                return null;
            }
            return foundPilot;
        }
        public void PostNewPilot(Pilot p)
        {
            _pilotRepository.PostPilot(p);
            CountID++;

        }
        public void PutPilot(int id, Pilot p)
        {
            int index = _pilotRepository.GetList().FindIndex(x => x.Id == id);
            if (index != -1)
            {
                Pilot pilot = _pilotRepository.GetList()[index];
              pilot.Vettek = p.Vettek;
                pilot.Name = p.Name;
                pilot.NumWorker=p.NumWorker;
                pilot.Company= p.Company;
            }
            _pilotRepository.UpdatePilot(index, pilot);

        }
        public void DeletePilot(int id)
        {
            int index = _pilotRepository.GetList().FindIndex(x => x.Id == id);
            if (index != -1)
            {
                _pilotRepository.RemovePilot(index);
            }
        }
    }
}
