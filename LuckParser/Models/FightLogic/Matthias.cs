﻿using LuckParser.Models.DataModels;
using LuckParser.Models.ParseModels;
using System;
using System.Collections.Generic;
using System.Linq;
using static LuckParser.Models.DataModels.ParseEnum.TrashIDS;

namespace LuckParser.Models.Logic
{
    public class Matthias : RaidLogic
    {
        public Matthias(ushort triggerID) : base(triggerID)
        {
            MechanicList.AddRange(new List<Mechanic>
            {

            new Mechanic(34380, "Oppressive Gaze", Mechanic.MechType.SkillOnPlayer, new MechanicPlotlySetting("hexagram","rgb(255,0,0)"), "Ball","Oppressive Gaze (Hadouken projectile)", "Hadouken",0),//human
            new Mechanic(34371, "Oppressive Gaze", Mechanic.MechType.SkillOnPlayer, new MechanicPlotlySetting("hexagram","rgb(255,0,0)"), "Ball","Oppressive Gaze (Hadouken projectile)", "Hadouken",0),//abom
            new Mechanic(34480, "Blood Shards", Mechanic.MechType.SkillOnPlayer, new MechanicPlotlySetting("diamond-wide-open","rgb(255,0,255)"), "RpFire","Blood Shard projectiles during bubble", "Rapid Fire",0),// //human
            new Mechanic(34440, "Blood Shards", Mechanic.MechType.SkillOnPlayer, new MechanicPlotlySetting("diamond-wide-open","rgb(255,0,255)"), "RpFire","Blood Shard projectiles during bubble", "Rapid Fire", 0),// //abom
            new Mechanic(34404, "Shards of Rage", Mechanic.MechType.SkillOnPlayer, new MechanicPlotlySetting("star-diamond","rgb(255,0,0)"), "Shrds","Shards of Rage (Jump)", "Jump Shards",1000),//human
            new Mechanic(34411, "Shards of Rage", Mechanic.MechType.SkillOnPlayer, new MechanicPlotlySetting("star-diamond","rgb(255,0,0)"), "Shrds","Shards of Rage (Jump)", "Jump Shards",1000),//abom
            new Mechanic(34466, "Fiery Vortex", Mechanic.MechType.SkillOnPlayer, new MechanicPlotlySetting("triangle-down-open","rgb(255,200,0)"), "Torndo","Fiery Vortex (Tornado)", "Tornado",250),
            new Mechanic(34543, "Thunder", Mechanic.MechType.SkillOnPlayer, new MechanicPlotlySetting("triangle-up-open","rgb(0,255,255)"), "Storm","Thunder Storm hit (air phase)", "Storm cloud",0),
            new Mechanic(34450, "Unstable Blood Magic", Mechanic.MechType.PlayerBoon, new MechanicPlotlySetting("diamond","rgb(255,0,0)"), "Well","Unstable Blood Magic application", "Well",0),
            new Mechanic(34336, "Well of the Profane", Mechanic.MechType.SkillOnPlayer, new MechanicPlotlySetting("diamond-open","rgb(255,0,0)"), "W.dmg","Unstable Blood Magic AoE hit", "Stood in Well",0),
            new Mechanic(34416, "Corruption", Mechanic.MechType.PlayerBoon, new MechanicPlotlySetting("circle","rgb(255,140,0)"), "Crptn","Corruption Application", "Corruption",0),
            new Mechanic(34473, "Corruption", Mechanic.MechType.SkillOnPlayer, new MechanicPlotlySetting("circle-open","rgb(255,140,0)"), "C.dmg","Hit by Corruption AoE", "Corruption dmg",0),
            new Mechanic(34442, "Sacrifice", Mechanic.MechType.PlayerBoon, new MechanicPlotlySetting("diamond-tall","rgb(0,160,150)"), "Scrfc","Sacrifice (Breakbar)", "Sacrifice",0),
            new Mechanic(34442, "Sacrifice", Mechanic.MechType.PlayerBoonRemove, new MechanicPlotlySetting("diamond-tall","rgb(0,160,0)"), "CC.End","Sacrifice (Breakbar) ended", "Sacrifice End",0,(condition => condition.CombatItem.Value>25)),
            new Mechanic(34442, "Sacrificed", Mechanic.MechType.PlayerBoonRemove, new MechanicPlotlySetting("diamond-tall","rgb(255,0,0)"), "CC.Fail","Sacrifice time ran out", "Sacrificed",0,(condition => condition.CombatItem.Value<=25)),
            new Mechanic(34367, "Unbalanced", Mechanic.MechType.PlayerBoonRemove, new MechanicPlotlySetting("square","rgb(200,140,255)"), "KD","Unbalanced (triggered Storm phase Debuff)", "Knockdown",0,(condition => condition.CombatItem.Value > 0)),
            //new Mechanic(34367, "Unbalanced", Mechanic.MechType.PlayerOnPlayer, ParseEnum.BossIDS.Matthias, new MechanicPlotlySetting("square","rgb(0,140,0)"), "KD","Unbalanced (triggered Storm phase Debuff) only on successful interrupt", "Knockdown (interrupt)",0,(condition => condition.getCombatItem().Result == ParseEnum.Result.Interrupt)),
            //new Mechanic(34367, "Unbalanced", Mechanic.MechType.SkillOnPlayer, ParseEnum.BossIDS.Matthias, new MechanicPlotlySetting("square","rgb(0,140,0)"), "KD","Unbalanced (triggered Storm phase Debuff) only on successful interrupt", "Knockdown (interrupt)",0,(condition => condition.getDLog().GetResult() == ParseEnum.Result.Interrupt)),
            //new Mechanic(34422, "Blood Fueled", Mechanic.MechType.PlayerBoon, ParseEnum.BossIDS.Matthias, new MechanicPlotlySetting("square","rgb(255,0,0)"), "Ate Reflects(good)",0),//human //Applied at the same time as Backflip Shards since it is the buff applied by them, can be omitted imho
            //new Mechanic(34428, "Blood Fueled", Mechanic.MechType.PlayerBoon, ParseEnum.BossIDS.Matthias, new MechanicPlotlySetting("square","rgb(255,0,0)"), "Ate Reflects(good)",0),//abom
            new Mechanic(34376, "Blood Shield", Mechanic.MechType.EnemyBoon, new MechanicPlotlySetting("octagon","rgb(255,0,0)"), "Bble","Blood Shield (protective bubble)", "Bubble",0),//human
            new Mechanic(34518, "Blood Shield", Mechanic.MechType.EnemyBoon, new MechanicPlotlySetting("octagon","rgb(255,0,0)"), "Bble","Blood Shield (protective bubble)", "Bubble",0),//abom
            new Mechanic(34511, "Zealous Benediction", Mechanic.MechType.PlayerBoon, new MechanicPlotlySetting("circle","rgb(255,200,0)"), "Bombs",0),
            new Mechanic(26766, "Icy Patch", Mechanic.MechType.PlayerBoon, new MechanicPlotlySetting("circle-open","rgb(0,0,255)"), "Icy KD","Knockdown by Icy Patch", "Icy Patch KD",0,(condition => condition.CombatItem.Value == 10000)),
            new Mechanic(34413, "Surrender", Mechanic.MechType.SkillOnPlayer, new MechanicPlotlySetting("circle-open","rgb(0,0,0)"), "Sprt","Surrender (hit by walking Spirit)", "Spirit hit",0)
            });
            Extension = "matt";
            IconUrl = "https://wiki.guildwars2.com/images/5/5d/Mini_Matthias_Abomination.png";
        }

        protected override CombatReplayMap GetCombatMapInternal()
        {
            return new CombatReplayMap("https://i.imgur.com/3X0YveK.png",
                            Tuple.Create(880, 880),
                            Tuple.Create(-7248, 4585, -4625, 7207),
                            Tuple.Create(-12288, -27648, 12288, 27648),
                            Tuple.Create(2688, 11906, 3712, 14210));
        }

        public override List<PhaseData> GetPhases(ParsedLog log, bool requirePhases)
        {
            long fightDuration = log.FightData.FightDuration;
            List<PhaseData> phases = GetInitialPhase(log);
            Target mainTarget = Targets.Find(x => x.ID == (ushort)ParseEnum.TargetIDS.Matthias);
            if (mainTarget == null)
            {
                throw new InvalidOperationException("Main target of the fight not found");
            }
            phases[0].Targets.Add(mainTarget);
            if (!requirePhases)
            {
                return phases;
            }
            // Special buff cast check
            CombatItem heatWave = log.GetBoonData(34526).FirstOrDefault();
            if (heatWave != null)
            {
                phases.Add(new PhaseData(0, log.FightData.ToFightSpace(heatWave.Time) - 1));
                CombatItem downPour = log.GetDamageData(mainTarget.InstID, mainTarget.FirstAware, mainTarget.LastAware).Find(x => x.SkillID == 34554);
                if (downPour != null)
                {
                    phases.Add(new PhaseData(log.FightData.ToFightSpace(heatWave.Time), log.FightData.ToFightSpace(downPour.Time) - 1));
                    List<CastLog> castLogs = mainTarget.GetCastLogs(log, 0, log.FightData.FightEnd);
                    CastLog abo = castLogs.Find(x => x.SkillId == 34427);
                    if (abo != null)
                    {
                        phases.Add(new PhaseData(log.FightData.ToFightSpace(downPour.Time), abo.Time - 1));
                        CombatItem invulRemove = log.GetBoonDataByDst(mainTarget.InstID, log.FightData.ToLogSpace(abo.Time), log.FightData.ToLogSpace(abo.Time) + 10000).FirstOrDefault(x => x.SkillID == 757 && x.IsBuffRemove != ParseEnum.BuffRemove.None);
                        if (invulRemove != null)
                        {
                            phases.Add(new PhaseData(log.FightData.ToFightSpace(invulRemove.Time), fightDuration));
                        }
                    }
                    else
                    {
                        phases.Add(new PhaseData(log.FightData.ToFightSpace(downPour.Time), fightDuration));
                    }
                }
                else
                {
                    phases.Add(new PhaseData(log.FightData.ToFightSpace(heatWave.Time), fightDuration));
                }
            }
            else
            {
                phases.Add(new PhaseData(0, fightDuration));
            }
            string[] namesMat = new [] { "Ice Phase", "Fire Phase", "Storm Phase", "Abomination Phase" };
            for (int i = 1; i < phases.Count; i++)
            {
                phases[i].Name = namesMat[i - 1];
                phases[i].DrawStart = i > 1;
                phases[i].Targets.Add(mainTarget);
            }
            return phases;
        }

        protected override List<ParseEnum.TrashIDS> GetTrashMobsIDS()
        {
            return new List<ParseEnum.TrashIDS>
            {
                Storm,
                Spirit,
                Spirit2,
                IcePatch,
                Tornado
            };
        }

        public override void ComputeAdditionalThrashMobData(Mob mob, ParsedLog log)
        {
            CombatReplay replay = mob.CombatReplay;
            int start = (int)replay.TimeOffsets.Item1;
            int end = (int)replay.TimeOffsets.Item2;
            Tuple<int, int> lifespan = new Tuple<int, int>(start, end);
            switch(mob.ID)
            {
                case (ushort)Storm:
                    replay.Actors.Add(new CircleActor(false, 0, 260, lifespan, "rgba(0, 80, 255, 0.5)", new AgentConnector(mob)));
                    break;
                case (ushort)Spirit:
                case (ushort)Spirit2:
                    replay.Actors.Add(new CircleActor(true, 0, 180, lifespan, "rgba(255, 0, 0, 0.5)", new AgentConnector(mob)));
                    break;
                case (ushort)IcePatch:
                    replay.Actors.Add(new CircleActor(true, 0, 200, lifespan, "rgba(0, 0, 255, 0.5)", new AgentConnector(mob)));
                    break;
                case (ushort)Tornado:
                    replay.Actors.Add(new CircleActor(true, 0, 90, lifespan, "rgba(255, 0, 0, 0.5)", new AgentConnector(mob)));
                    break;
                default:
                    throw new InvalidOperationException("Unknown ID in ComputeAdditionalData");
            }
        }

        public override void ComputeAdditionalTargetData(Target target, ParsedLog log)
        {
            // TODO: needs facing information for hadouken
            CombatReplay replay = target.CombatReplay;
            List<CastLog> cls = target.GetCastLogs(log, 0, log.FightData.FightDuration);
            switch (target.ID)
            {
                case (ushort)ParseEnum.TargetIDS.Matthias:
                    List<CastLog> humanShield = cls.Where(x => x.SkillId == 34468).ToList();
                    List<int> humanShieldRemoval = log.GetBoonData(34518).Where(x => x.IsBuffRemove == ParseEnum.BuffRemove.All).Select(x => (int)(log.FightData.ToFightSpace(x.Time))).Distinct().ToList();
                    for (var i = 0; i < humanShield.Count; i++)
                    {
                        var shield = humanShield[i];
                        if (i < humanShieldRemoval.Count)
                        {
                            int removal = humanShieldRemoval[i];
                            replay.Actors.Add(new CircleActor(true, 0, 250, new Tuple<int, int>((int)shield.Time, removal), "rgba(255, 0, 255, 0.5)", new AgentConnector(target)));
                        }
                        else
                        {
                            replay.Actors.Add(new CircleActor(true, 0, 250, new Tuple<int, int>((int)shield.Time, (int)log.FightData.FightDuration), "rgba(255, 0, 255, 0.5)", new AgentConnector(target)));
                        }
                    }
                    List<CastLog> aboShield = cls.Where(x => x.SkillId == 34510).ToList();
                    List<int> aboShieldRemoval = log.GetBoonData(34376).Where(x => x.IsBuffRemove == ParseEnum.BuffRemove.All).Select(x => (int)(log.FightData.ToFightSpace(x.Time))).Distinct().ToList();
                    for (var i = 0; i < aboShield.Count; i++)
                    {
                        var shield = aboShield[i];
                        if (i < aboShieldRemoval.Count)
                        {
                            int removal = aboShieldRemoval[i];
                            replay.Actors.Add(new CircleActor(true, 0, 250, new Tuple<int, int>((int)shield.Time, removal), "rgba(255, 0, 255, 0.5)", new AgentConnector(target)));
                        }
                        else
                        {
                            replay.Actors.Add(new CircleActor(true, 0, 250, new Tuple<int, int>((int)shield.Time, (int)log.FightData.FightDuration), "rgba(255, 0, 255, 0.5)", new AgentConnector(target)));
                        }
                    }
                    List<CastLog> rageShards = cls.Where(x => x.SkillId == 34404 || x.SkillId == 34411).ToList();
                    foreach (CastLog c in rageShards)
                    {
                        int start = (int)c.Time;
                        int end = start + c.ActualDuration;
                        replay.Actors.Add(new CircleActor(false, 0, 300, new Tuple<int, int>(start, end), "rgba(255, 0, 0, 0.5)", new AgentConnector(target)));
                        replay.Actors.Add(new CircleActor(true, end, 300, new Tuple<int, int>(start, end), "rgba(255, 0, 0, 0.5)", new AgentConnector(target)));
                    }
                    List<CastLog> hadouken = cls.Where(x => x.SkillId == 34371 || x.SkillId == 34380).ToList();
                    foreach (CastLog c in hadouken)
                    {
                        int start = (int)c.Time;
                        int preCastTime = 1000;
                        int duration = 750;
                        int width = 4000; int height = 130;
                        Point3D facing = replay.Rotations.LastOrDefault(x => x.Time <= start+1000);
                        if (facing != null)
                        {
                            int direction = (int)(Math.Atan2(facing.Y, facing.X) * 180 / Math.PI);
                            replay.Actors.Add(new RotatedRectangleActor(true, 0, width, height, direction, width / 2, new Tuple<int, int>(start, start + preCastTime), "rgba(255, 0, 0, 0.1)", new AgentConnector(target)));
                            replay.Actors.Add(new RotatedRectangleActor(true, 0, width, height, direction, width / 2, new Tuple<int, int>(start + preCastTime, start + preCastTime + duration), "rgba(255, 0, 0, 0.7)", new AgentConnector(target)));
                        }
                    }
                        break;
                default:
                    throw new InvalidOperationException("Unknown ID in ComputeAdditionalData");
            }
            
        }

        public override void ComputeAdditionalPlayerData(Player p, ParsedLog log)
        {
            // Corruption
            CombatReplay replay = p.CombatReplay;
            List<CombatItem> corruptedMatthias = GetFilteredList(log, 34416, p);
            corruptedMatthias.AddRange(GetFilteredList(log, 34473, p));
            int corruptedMatthiasStart = 0;
            foreach (CombatItem c in corruptedMatthias)
            {
                if (c.IsBuffRemove == ParseEnum.BuffRemove.None)
                {
                    corruptedMatthiasStart = (int)(log.FightData.ToFightSpace(c.Time));
                }
                else
                {
                    int corruptedMatthiasEnd = (int)(log.FightData.ToFightSpace(c.Time));
                    replay.Actors.Add(new CircleActor(true, 0, 180, new Tuple<int, int>(corruptedMatthiasStart, corruptedMatthiasEnd), "rgba(255, 150, 0, 0.5)", new AgentConnector(p)));
                    Point3D wellNextPosition = replay.Positions.FirstOrDefault(x => x.Time >= corruptedMatthiasEnd);
                    Point3D wellPrevPosition = replay.Positions.LastOrDefault(x => x.Time <= corruptedMatthiasEnd);
                    if (wellNextPosition != null || wellPrevPosition != null)
                    {
                        replay.Actors.Add(new CircleActor(true, 0, 180, new Tuple<int, int>(corruptedMatthiasEnd, corruptedMatthiasEnd + 100000), "rgba(0, 0, 0, 0.3)", new InterpolatedPositionConnector(wellPrevPosition, wellNextPosition, corruptedMatthiasEnd)));
                        replay.Actors.Add(new CircleActor(true, corruptedMatthiasEnd + 100000, 180, new Tuple<int, int>(corruptedMatthiasEnd, corruptedMatthiasEnd + 100000), "rgba(0, 0, 0, 0.3)", new InterpolatedPositionConnector(wellPrevPosition, wellNextPosition, corruptedMatthiasEnd)));
                    }
                }
            }
            // Well of profane
            List<CombatItem> wellMatthias = GetFilteredList(log, 34450, p);
            int wellMatthiasStart = 0;
            foreach (CombatItem c in wellMatthias)
            {
                if (c.IsBuffRemove == ParseEnum.BuffRemove.None)
                {
                    wellMatthiasStart = (int)(log.FightData.ToFightSpace(c.Time));
                }
                else
                {
                    int wellMatthiasEnd = (int)(log.FightData.ToFightSpace(c.Time));
                    replay.Actors.Add(new CircleActor(false, 0, 120, new Tuple<int, int>(wellMatthiasStart, wellMatthiasEnd), "rgba(150, 255, 80, 0.5)", new AgentConnector(p)));
                    replay.Actors.Add(new CircleActor(true, wellMatthiasStart + 9000, 120, new Tuple<int, int>(wellMatthiasStart, wellMatthiasEnd), "rgba(150, 255, 80, 0.5)", new AgentConnector(p)));
                    Point3D wellNextPosition = replay.Positions.FirstOrDefault(x => x.Time >= wellMatthiasEnd);
                    Point3D wellPrevPosition = replay.Positions.LastOrDefault(x => x.Time <= wellMatthiasEnd);
                    if (wellNextPosition != null || wellPrevPosition != null)
                    {
                        replay.Actors.Add(new CircleActor(true, 0, 300, new Tuple<int, int>(wellMatthiasEnd, wellMatthiasEnd + 90000), "rgba(255, 0, 50, 0.5)", new InterpolatedPositionConnector(wellPrevPosition, wellNextPosition, wellMatthiasEnd)));
                    }
                }
            }
            // Sacrifice
            List<CombatItem> sacrificeMatthias = GetFilteredList(log, 34442, p);
            int sacrificeMatthiasStart = 0;
            foreach (CombatItem c in sacrificeMatthias)
            {
                if (c.IsBuffRemove == ParseEnum.BuffRemove.None)
                {
                    sacrificeMatthiasStart = (int)(log.FightData.ToFightSpace(c.Time));
                }
                else
                {
                    int sacrificeMatthiasEnd = (int)(log.FightData.ToFightSpace(c.Time));
                    replay.Actors.Add(new CircleActor(true, 0, 120, new Tuple<int, int>(sacrificeMatthiasStart, sacrificeMatthiasEnd), "rgba(0, 150, 250, 0.2)", new AgentConnector(p)));
                    replay.Actors.Add(new CircleActor(true, sacrificeMatthiasStart + 10000, 120, new Tuple<int, int>(sacrificeMatthiasStart, sacrificeMatthiasEnd), "rgba(0, 150, 250, 0.35)", new AgentConnector(p)));
                }
            }
            // Bombs
            List<CombatItem> zealousBenediction = log.GetBoonData(34511).Where(x => (x.DstInstid == p.InstID && x.IsBuffRemove == ParseEnum.BuffRemove.None)).ToList();
            foreach (CombatItem c in zealousBenediction)
            {
                int zealousStart = (int)(log.FightData.ToFightSpace(c.Time)) ;
                int zealousEnd = zealousStart + 5000;
                replay.Actors.Add(new CircleActor(true, 0, 180, new Tuple<int, int>(zealousStart, zealousEnd), "rgba(200, 150, 0, 0.2)", new AgentConnector(p)));
                replay.Actors.Add(new CircleActor(true, zealousEnd, 180, new Tuple<int, int>(zealousStart, zealousEnd), "rgba(200, 150, 0, 0.4)", new AgentConnector(p)));
            }
        }
       
    }
}
