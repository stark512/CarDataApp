﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Car_Data_Application.Models.Vehicle_Classes
{
    public class Tanks
    {
        public int LPG { get; set; }
        public int Gasoline { get; set; }
        public int Diesel { get; set; }

        public Tanks()
        {
            this.Gasoline = 0;
            this.Diesel = 0;
            this.LPG = 0;
        }

        public Tanks(int lpg, int gasoline, int diesel)
        {
            this.Diesel = diesel;
            this.Gasoline = gasoline;
            this.LPG = lpg;
        }
    }
}
