﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrackerLibrary.Models;

namespace TournamentTrackerForms
{
    public interface IPrizeRequestor
    {
        void PrizeComplete(PrizeModel model);
    }
}
