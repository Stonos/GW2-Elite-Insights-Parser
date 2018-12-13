﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LuckParser.Models.ParseModels
{
    public class BoonSimulationItemOverstack : AbstractBoonSimulationItemWasted
    {

        public BoonSimulationItemOverstack(ushort src, long overstack, long time) : base(src, overstack, time)
        {
        }

        public override void SetBoonDistributionItem(Dictionary<ushort, BoonDistributionItem> distrib)
        {
            throw new NotImplementedException();
        }
    }
}
