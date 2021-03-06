﻿using SuperPowerApp.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperPowerApp
{
    public class SuperPowerHandler
    {
        public int currentSuperheroID { get; set; }
        public DBHandler dbHandler { get; set; }
        public Superhero currentSuperhero { get; set; }
        public List<Affinity> Affinities { get; set; }

        public SuperPowerHandler()
        {
            this.dbHandler = new DBHandler();
            this.Affinities = new List<Affinity>();
            this.Affinities = dbHandler.GetAffinities();
            this.currentSuperhero = dbHandler.ReadSuperCharacter(dbHandler.GetMinSuperheroID());
            if (this.currentSuperhero != null)
            {
                this.currentSuperheroID = currentSuperhero.SuperheroID;
                this.currentSuperhero.SuperheroID = this.currentSuperheroID;
            }
            else
            {
                this.currentSuperheroID = 0;
                this.currentSuperhero = new Superhero();
                this.currentSuperhero.SuperheroID = this.currentSuperheroID;
                this.currentSuperhero.Name = "Null";
                
            }
        }

        public int SetPreviousSuperheroID() {
            Superhero superhero = dbHandler.ReadSuperCharacter(this.currentSuperheroID - 1);
            while (superhero == null && this.currentSuperheroID >= 0)
            {
                this.currentSuperheroID -= 1;
                superhero = dbHandler.ReadSuperCharacter(this.currentSuperheroID );
            }
            //if there is no previous Superhero, the method will return -1, else the current Superhero's ID 
            if (superhero == null)
            {
                return -1;
            }
            this.currentSuperheroID = superhero.SuperheroID;
            this.currentSuperhero = superhero;
            return this.currentSuperheroID;
        }

        public int SetNextSuperheroID()
        {
            Superhero superhero = dbHandler.ReadSuperCharacter(this.currentSuperheroID + 1);
            int max = dbHandler.GetMaxSuperheroID();
            while (superhero == null && this.currentSuperheroID < max)
            {
                this.currentSuperheroID += 1;
                superhero = dbHandler.ReadSuperCharacter(this.currentSuperheroID);
            }
            //if there is no next Superhero, the method will return -1, else the current Superhero's ID 
            if (superhero == null)
            {
                return -1;
            }
            this.currentSuperheroID = superhero.SuperheroID;
            this.currentSuperhero = superhero;
            return this.currentSuperheroID;
        }

        public int DeleteSuperhero(int superheroID) {
            dbHandler.DeleteSuperCharacter(superheroID);
            this.currentSuperheroID = superheroID;
            return this.SetNextSuperheroID();
        }

        public void UpdateSuperhero(Superhero superhero) {
            dbHandler.UpdateSuperCharacter(superhero);
        }
        public Affinity CreateAffinity(string type) {
            dbHandler.CreateAffinity(type);
            this.Affinities = dbHandler.GetAffinities();
            return this.Affinities.Where(a => a.Type == type).FirstOrDefault();
        }

        public void CreateSuperHero(Superhero superhero) {
            dbHandler.CreateSuperCharacter(superhero);
        }
    }
}
