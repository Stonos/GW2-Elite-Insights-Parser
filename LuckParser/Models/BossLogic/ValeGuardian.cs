﻿using LuckParser.Models.DataModels;
using LuckParser.Models.ParseModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LuckParser.Models
{
    public class ValeGuardian : BossLogic
    {
        public ValeGuardian() : base()
        {
            mode = ParseMode.Raid;
            mechanicList.AddRange(new List<Mechanic>
            {
            new Mechanic(31860, "Unstable Magic Spike", Mechanic.MechType.SkillOnPlayer, ParseEnum.BossIDS.ValeGuardian, "symbol:'circle',color:'rgb(0,0,255)',", "G.TP",500), //Unstable Magic Spike (Green Guard Teleport),Green Guard TP
            new Mechanic(31392, "Unstable Magic Spike", Mechanic.MechType.SkillOnPlayer, ParseEnum.BossIDS.ValeGuardian, "symbol:'circle',color:'rgb(0,0,255)',", "B.TP",500), //Unstable Magic Spike (Boss Teleport), Boss TP
            new Mechanic(31340, "Distributed Magic", Mechanic.MechType.SkillOnPlayer, ParseEnum.BossIDS.ValeGuardian, "symbol:'circle',color:'rgb(0,128,0)',", "Grn",0), //Distributed Magic (Stood in Green), Green Team
            new Mechanic(31391, "Distributed Magic", Mechanic.MechType.SkillOnPlayer, ParseEnum.BossIDS.ValeGuardian, "symbol:'circle',color:'rgb(0,128,0)',", "Grn",0), //Distributed Magic (Stood in Green), Green Team
            new Mechanic(31529, "Distributed Magic", Mechanic.MechType.SkillOnPlayer, ParseEnum.BossIDS.ValeGuardian, "symbol:'circle',color:'rgb(0,128,0)',", "Grn",0), //Distributed Magic (Stood in Green), Green Team
            new Mechanic(31750, "Distributed Magic", Mechanic.MechType.SkillOnPlayer, ParseEnum.BossIDS.ValeGuardian, "symbol:'circle',color:'rgb(0,128,0)',", "Grn",0), //Distributed Magic (Stood in Green), Green Team
            new Mechanic(31886, "Magic Pulse", Mechanic.MechType.SkillOnPlayer, ParseEnum.BossIDS.ValeGuardian, "symbol:'circle-open',color:'rgb(255,0,0)',", "Skr",0), //Magic Pulse (Hit by Seeker), Seeker
            new Mechanic(31695, "Pylon Attunement: Red", Mechanic.MechType.PlayerBoon, ParseEnum.BossIDS.ValeGuardian, "symbol:'square',color:'rgb(255,0,0)',", "Att.R",0), //Pylon Attunement: Red, Red Attuned
            new Mechanic(31317, "Pylon Attunement: Blue", Mechanic.MechType.PlayerBoon, ParseEnum.BossIDS.ValeGuardian, "symbol:'square',color:'rgb(0,0,255)',", "Att.B",0), //Pylon Attunement: Blue, Blue Attuned
            new Mechanic(31852, "Pylon Attunement: Green", Mechanic.MechType.PlayerBoon, ParseEnum.BossIDS.ValeGuardian, "symbol:'square',color:'rgb(0,128,0)',", "Att.G",0), //Pylon Ättunement: Green, Green Attuned
            new Mechanic(31413, "Blue Pylon Power", Mechanic.MechType.EnemyBoonStrip, ParseEnum.BossIDS.ValeGuardian, "symbol:'square-open',color:'rgb(0,0,255)',", "InvlnStrp",0), //Stripped Blue Guard Invuln, Blue Invuln Strip
            new Mechanic(31539, "Unstable Pylon", Mechanic.MechType.SkillOnPlayer, ParseEnum.BossIDS.ValeGuardian, "symbol:'hexagram-open',color:'rgb(255,0,0)',", "Flr.R",0), // Unstable Pylon (Red Floor dmg), Floor dmg
            new Mechanic(31828, "Unstable Pylon", Mechanic.MechType.SkillOnPlayer, ParseEnum.BossIDS.ValeGuardian, "symbol:'hexagram-open',color:'rgb(0,0,255)',", "Flr.B",0), // Unstable Pylon (Blue Floor dmg), Floor dmg
            new Mechanic(31884, "Unstable Pylon", Mechanic.MechType.SkillOnPlayer, ParseEnum.BossIDS.ValeGuardian, "symbol:'hexagram-open',color:'rgb(0,128,0)',", "Flr.G",0), // Unstable Pylon (Green Floor dmg), Floor dmg
            new Mechanic(31419, "Magic Storm", Mechanic.MechType.EnemyCastStart, ParseEnum.BossIDS.ValeGuardian, "symbol:'star-diamond',color:'rgb(0,255,255)',", "Breakbar",0)
            });
        }

        public override CombatReplayMap getCombatMap()
        {
            return new CombatReplayMap("https://i.imgur.com/W7MocGz.png",
                            Tuple.Create(889, 889),
                            Tuple.Create(-6365, -22213, -3150, -18999),
                            Tuple.Create(-15360, -36864, 15360, 39936),
                            Tuple.Create(3456, 11012, 4736, 14212));
        }

        public override List<PhaseData> getPhases(Boss boss, ParsedLog log, List<CastLog> cast_logs)
        {
            long start = 0;
            long end = 0;
            long fight_dur = log.getBossData().getAwareDuration();
            List<PhaseData> phases = getInitialPhase(log);
            // Invul check
            List<CombatItem> invulsVG = getFilteredList(log, 757, boss.getInstid());
            for (int i = 0; i < invulsVG.Count; i++)
            {
                CombatItem c = invulsVG[i];
                if (c.isBuffremove() == ParseEnum.BuffRemove.None)
                {
                    end = c.getTime() - log.getBossData().getFirstAware();
                    phases.Add(new PhaseData(start, end));
                    if (i == invulsVG.Count - 1)
                    {
                        cast_logs.Add(new CastLog(end, -5, (int)(fight_dur - end), ParseEnum.Activation.None, (int)(fight_dur - end), ParseEnum.Activation.None));
                    }
                }
                else
                {
                    start = c.getTime() - log.getBossData().getFirstAware();
                    phases.Add(new PhaseData(end, start));
                    cast_logs.Add(new CastLog(end, -5, (int)(start - end), ParseEnum.Activation.None, (int)(start - end), ParseEnum.Activation.None));
                }
            }
            if (fight_dur - start > 5000 && start >= phases.Last().getEnd())
            {
                phases.Add(new PhaseData(start, fight_dur));
            }
            string[] namesVG = new string[] { "Phase 1", "Split 1", "Phase 2", "Split 2", "Phase 3" };
            for (int i = 1; i < phases.Count; i++)
            {
                PhaseData phase = phases[i];
                phase.setName(namesVG[i - 1]);
                if (i == 2 || i == 4)
                {
                    List<ParseEnum.ThrashIDS> ids = new List<ParseEnum.ThrashIDS>
                    {
                       ParseEnum.ThrashIDS.BlueGuardian,
                       ParseEnum.ThrashIDS.GreenGuardian,
                       ParseEnum.ThrashIDS.RedGuardian
                    };
                    List<AgentItem> guardians = log.getAgentData().getNPCAgentList().Where(x => ids.Contains(ParseEnum.getThrashIDS(x.getID()))).ToList();
                    foreach (AgentItem a in guardians)
                    {
                        long agentStart = a.getFirstAware() - log.getBossData().getFirstAware();
                        long agentEnd = a.getLastAware() - log.getBossData().getFirstAware();
                        if (phase.inInterval(agentStart))
                        {
                            phase.addRedirection(a);
                        }
                    }
                    phase.overrideStart(log.getBossData().getFirstAware());
                }
            }
            return phases;
        }

        public override List<ParseEnum.ThrashIDS> getAdditionalData(CombatReplay replay, List<CastLog> cls, ParsedLog log)
        {
            List<ParseEnum.ThrashIDS> ids = new List<ParseEnum.ThrashIDS>
            {
               ParseEnum.ThrashIDS.Seekers,
               ParseEnum.ThrashIDS.BlueGuardian,
               ParseEnum.ThrashIDS.GreenGuardian,
               ParseEnum.ThrashIDS.RedGuardian
            };
            List<CastLog> magicStorms = cls.Where(x => x.getID() == 31419).ToList();
            foreach (CastLog c in magicStorms)
            {
                replay.addCircleActor(new CircleActor(true, 0, 100, new Tuple<int, int>((int)c.getTime(), (int)c.getTime() + c.getActDur()), "rgba(0, 180, 255, 0.3)"));
            }
            return ids;
        }

        public override string getReplayIcon()
        {
            return "https://i.imgur.com/MIpP5pK.png";
        }
    }
}