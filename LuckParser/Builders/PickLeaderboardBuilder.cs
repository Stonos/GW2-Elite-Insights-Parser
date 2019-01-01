using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Windows.Forms;
using System.Xml;
using LuckParser.Controllers;
using LuckParser.Models;
using LuckParser.Models.DataModels;
using LuckParser.Models.JsonModels;
using LuckParser.Models.ParseModels;
using Newtonsoft.Json;
using LuckParser.Models.PickLeaderboardModels;

namespace LuckParser.Builders
{
    class PickLeaderboardBuilder
    {
        readonly ParsedLog _log;
        readonly PickLeaderboard _pickLeaderboard;
        readonly Statistics _statistics;
        readonly StreamWriter _sw;
        readonly string _fName;

        public PickLeaderboardBuilder(StreamWriter sw, ParsedLog log, Statistics statistics, string fName, string oldLeaderboardJson)
        {
            _log = log;
            _sw = sw;
            _fName = fName;
            _statistics = statistics;

            try
            {
                _pickLeaderboard = JsonConvert.DeserializeObject<PickLeaderboard>(oldLeaderboardJson);
            }
            catch (Exception e)
            {
                _pickLeaderboard = new PickLeaderboard()
                {
                    parsedLogs = new List<string>(),
                    players = new Dictionary<string, PickLeaderboardPlayer>()
                };
            }
        }

        public void CreatePickLeaderboard()
        {
            if (_pickLeaderboard.parsedLogs.Contains(_fName))
            {
                return;
            }

            _pickLeaderboard.parsedLogs.Add(_fName);

            HashSet<Mechanic> presMech = _log.MechanicData.GetPresentPlayerMechs(0);
            //Dictionary<string, HashSet<Mechanic>> presEnemyMech = log.MechanicData.getPresentEnemyMechs(phaseIndex);
            PhaseData phase = _statistics.Phases[0];
            //List<AbstractMasterPlayer> enemyList = log.MechanicData.getEnemyList(phaseIndex);
            Mechanic picked = presMech.FirstOrDefault(x => x.Description.Contains("Damaged by Ender's Echo"));

            foreach (Player p in _log.PlayerList)
            {
                PickLeaderboardPlayer leaderboardPlayer;
                if (_pickLeaderboard.players.ContainsKey(p.Account))
                {
                    leaderboardPlayer = _pickLeaderboard.players[p.Account];
                }
                else
                {
                    leaderboardPlayer = new PickLeaderboardPlayer();
                    _pickLeaderboard.players[p.Account] = leaderboardPlayer;
                }

                if (picked != null)
                {
                    long timeFilter = 0;
                    int filterCount = 0;
                    List<MechanicLog> mls = _log.MechanicData[picked].Where(x => x.Player.InstID == p.InstID && phase.InInterval(x.Time)).ToList();
                    int count = mls.Count;
                    foreach (MechanicLog ml in mls)
                    {
                        if (picked.InternalCooldown != 0 && ml.Time - timeFilter < picked.InternalCooldown)//ICD check
                        {
                            filterCount++;
                        }
                        timeFilter = ml.Time;
                    }

                    leaderboardPlayer.picks += (count - filterCount);
                }
                leaderboardPlayer.totalLogs++;
            }

            var serializer = new JsonSerializer
            {
                NullValueHandling = NullValueHandling.Ignore
            };
            var writer = new JsonTextWriter(_sw)
            {
                Formatting = Newtonsoft.Json.Formatting.Indented
            };

            serializer.Serialize(writer, _pickLeaderboard);
        }
    }
}
