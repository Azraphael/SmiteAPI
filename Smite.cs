using Smite.API.ResponseTypes;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Reflection;
using System.Threading.Tasks;
using System.Web.Script.Serialization;

namespace Smite.API
{
    public enum eLanguageCode
    {
        English = 1,
        German = 3,
        French = 3,
        Spanish = 7,
        Spanish_Latin_America = 9,
        Portuguese = 10
    }

    public enum QueueType
    {
        Conquest5v5 = 423,
        NoviceQueue = 424,
        Conquest = 426,
        Practice = 427,
        ConquestChallenge = 429,
        ConquestRanked = 430,
        Domination = 433,
        MOTD = 434,
        Arena = 435,
        ArenaChallenge = 438,
        DominationChallenge = 439,
        JoustLeague = 440,
        JoustChallenge = 441,
        Assault = 445,
        AssaultChallenge = 446,
        Joust3v3 = 448,
        ConquestLeague = 451,
        ArenaLeague = 452
    }

    public enum TierType
    {
        Bronze_V = 1,
        Bronze_IV = 2,
        Bronze_III = 3,
        Bronze_II = 4,
        Bronze_I = 5,
        Silver_V = 6,
        Silver_IV = 7,
        Silver_III = 8,
        Silver_II = 9,
        Silver_I = 10,
        Gold_V = 11,
        Gold_IV = 12,
        Gold_III = 13,
        Gold_II = 14,
        Gold_I = 15,
        Platinum_V = 16,
        Platinum_IV = 17,
        Platinum_III = 18,
        Platinum_II = 19,
        Platinum_I = 20,
        Diamond_V = 21,
        Diamond_IV = 22,
        Diamond_III = 23,
        Diamond_II = 24,
        Diamond_I = 25,
        Masters_I = 26
    }

    
    public static class SmiteAPI
    {
        private static string _devId;
        private static string _authKey;
        private static bool _createSession;
        private static string _apiUrl = "http://api.smitegame.com/smiteapi.svc/";
        private static string _timestamp;
        private static DateTime sessionCreated;
        private static ILogInterface Log;
        private static string _session;

        /// <summary>
        /// Create a new instace of Smite class
        /// </summary>
        /// <param name="DevID">DevID Supplied for API Access</param>
        /// <param name="AuthKey">AuthKey supplied for API Access</param>
        public static void Initialize(string DevID, string AuthKey, ILogInterface log)
        {
            _devId = DevID;
            _authKey = AuthKey;
            Log = log;
        }
        #region Synchronous Calls
        public static void CreateSession()
        {
            _timestamp = DateTime.UtcNow.ToString("yyyyMMddHHmmss");
            _session = GetResponse<SessionInfo>("createsession", false).session_id;
            _createSession = true;
            sessionCreated = DateTime.UtcNow;
        }
       
        public static List<Gods> GetGods(eLanguageCode languageCode)
        {
            return GetResponse<List<Gods>>("getgods", true, languageCode);
        }

        
        public static DataUsed GetDataUsed()
        {
            return GetResponse<List<DataUsed>>("getdataused", true)[0];
        }

        public static List<DemoDetails> GetDemoDetails(int matchID)
        {
            return GetResponse<List<DemoDetails>>("getdemodetails", true, matchID);
        }

        public static List<Friends> GetFriends(string playerName)
        {
            return GetResponse<List<Friends>>("getfriends", true, playerName);
        }
        public static List<Friends> GetFriends(int playerID)
        {
            return GetResponse<List<Friends>>("getfriends", true, playerID);
        }

        public static List<GodRanks> GetGodRanks(string playerName)
        {
            return GetResponse<List<GodRanks>>("getgodranks", true, playerName);
        }
        public static List<GodRanks> GetGodRanks(int playerID)
        {
            return GetResponse<List<GodRanks>>("getgodranks", true, playerID);            
        }

        public static List<Items> GetItems(eLanguageCode languageCode)
        {
            return GetResponse<List<Items>>("getitems", true, languageCode);
        }

        public static List<MatchDetails> GetMatchDetails(int matchID)
        {
            return GetResponse<List<MatchDetails>>("getmatchdetails", true, matchID);
        }

        public static List<MatchIds> GetMatchIdsByQueue(QueueType queue, DateTime date)
        {
            return GetResponse<List<MatchIds>>("getmatchidsbyqueue", true, queue, date);
        }

        public static List<TeamDetails> GetTeamDetails(int clanid)
        {
            return GetResponse<List<TeamDetails>>("getteamdetails", true, clanid);
        }

        public static List<MatchHistory> GetTeamMatchHistory(int clanid)
        {
            return GetResponse<List<MatchHistory>>("getteammatchhistory", true, clanid);
        }

        public static List<TeamPlayers> GetTeamPlayers(int clanid)
        {
            return GetResponse<List<TeamPlayers>>("getteamplayers", true, clanid);
        }

        public static List<TopMatches> GetTopMatches()
        {
            return GetResponse<List<TopMatches>>("gettopmatches", true);
        }

        public static List<Teams> SearchTeams(string searchTeam)
        {
            return GetResponse<List<Teams>>("searchteams", true, searchTeam);
        }

        public static List<GameInfo> GetLeagueLeaderBoard(QueueType queue, TierType tier, int season)
        {
            return GetResponse<List<GameInfo>>("getleagueleaderboard", true, queue, tier, season);
        }

        public static List<LeagueSeasons> GetLeagueSeasons(QueueType queue)
        {
            return GetResponse<List<LeagueSeasons>>("getleagueseasons", true, queue);
        }
        public static List<MatchHistory> GetMatchHistory(string playerName)
        {
            return GetResponse<List<MatchHistory>>("getmatchhistory", true, playerName);
        }
        public static List<MatchHistory> GetMatchHistory(int playerID)
        {            
            return GetResponse<List<MatchHistory>>("getmatchhistory", true, playerID);
        }

        public static Player GetPlayer(int playerID)
        {
            var items = GetResponse<List<Player>>("getplayer", true, playerID);

            if (items.Count > 0)
                return items[0];
            else
                return null;
        }
        public static Player GetPlayer(string playerName)
        {
            var items = GetResponse<List<Player>>("getplayer", true, playerName);

            if (items.Count > 0)
                return items[0];
            else
                return null;
                
        }

        public static List<QueueStats> GetQueueStats(string playerName, QueueType queue)
        {
            return GetResponse<List<QueueStats>>("getqueuestats", true, playerName, queue);
        }
        public static List<QueueStats> GetQueueStats(int playerID, QueueType queue) 
        {
            return GetResponse<List<QueueStats>>("getqueuestats", true, playerID, queue);
        }     

        private static string GetMD5Hash(string input)
        {
            var md5 = new System.Security.Cryptography.MD5CryptoServiceProvider();
            var bytes = System.Text.Encoding.UTF8.GetBytes(input);
            bytes = md5.ComputeHash(bytes);
            var sb = new System.Text.StringBuilder();
            foreach (byte b in bytes)
            {
                sb.Append(b.ToString("x2").ToLower());
            }
            return sb.ToString();
        }

        private static T GetResponse<T>(string service, bool requiresSession, params dynamic[] vars)
        {
            if (requiresSession) //Requires session, make sure its available.
            {
                //Check to see if a session was even created.
                if (!_createSession)
                {
                    CreateSession();
                }
                //First we need to verify it hasn't been over 15 minutes.
                TimeSpan sp = DateTime.UtcNow.Subtract(sessionCreated);

                if (sp.Minutes >= 15)  //Set to 5 until they fix timeout issue.
                {
                    //Create a new Session
                    CreateSession();
                }
            }
            if (_session == "")
            {
                CreateSession();
            }

            if (_session == "")
                throw new Exception("Session not being generated!");

            string signature = GetMD5Hash(_devId + service + _authKey + _timestamp);

            string urlKey = requiresSession ? _apiUrl + service + "json" + "/" + _devId + "/" + signature + "/" + _session + "/" + _timestamp : _apiUrl + service + "json" + "/" + _devId + "/" + signature + "/" + _timestamp;

            foreach (var p in vars)
            {
                if (p is DateTime)
                {
                    urlKey += "/" + p.ToString("yyyyMMdd");
                }
                else if (p is QueueType || p is TierType || p is eLanguageCode)
                {
                    urlKey += "/" + ((int)p).ToString();
                }
                else
                {
                    urlKey += "/" + p.ToString();
                }
            }

            WebRequest request = WebRequest.Create(urlKey);
            WebResponse response = request.GetResponse();
            Stream dataStream = response.GetResponseStream();
            StreamReader reader = new StreamReader(dataStream);

            string responseFromServer = reader.ReadToEnd();

            reader.Close();
            response.Close();

            var jsonString = responseFromServer;
            var jss = new JavaScriptSerializer();
            var g = jss.Deserialize<T>(jsonString);

            if (!IsSessionAlive(g))
            {
                TimeSpan sp = DateTime.UtcNow.Subtract(sessionCreated);
                //Log the error!
                Log.LogError(string.Format("Session timed out: Service: {0} - Session Alive: {1} minutes\r\n", service, sp.Minutes));
                CreateSession();
                return GetResponse<T>(service, requiresSession, vars); //Return again with the values.
            }
            return g;



        }
#endregion

        #region Asynchronous Calls
        public static async Task CreateSessionAsync()
        {
            _timestamp = DateTime.UtcNow.ToString("yyyyMMddHHmmss");
            var item = await GetResponseAsync<SessionInfo>("createsession", false);
            _session = item.session_id;
            _createSession = true;
            sessionCreated = DateTime.UtcNow;
        }
        private static async Task<T> GetResponseAsync<T>(string service, bool requiresSession, params dynamic[] vars)
        {
            if (requiresSession) //Requires session, make sure its available.
            {
                //Check to see if a session was even created.
                if (!_createSession)
                {
                    CreateSession();
                }
                //First we need to verify it hasn't been over 15 minutes.
                TimeSpan sp = DateTime.UtcNow.Subtract(sessionCreated);

                if (sp.Minutes >= 15)  //Set to 5 until they fix timeout issue.
                {
                    //Create a new Session
                    await CreateSessionAsync();
                }
            }
            if (_session == "")
            {
                await CreateSessionAsync();
            }

            if (_session == "")
                throw new Exception("Session not being generated!");

            string signature = GetMD5Hash(_devId + service + _authKey + _timestamp);

            string urlKey = requiresSession ? _apiUrl + service + "json" + "/" + _devId + "/" + signature + "/" + _session + "/" + _timestamp : _apiUrl + service + "json" + "/" + _devId + "/" + signature + "/" + _timestamp;

            foreach (var p in vars)
            {
                if (p is DateTime)
                {
                    urlKey += "/" + p.ToString("yyyyMMdd");
                }
                else if (p is QueueType || p is TierType || p is eLanguageCode)
                {
                    urlKey += "/" + ((int)p).ToString();
                }
                else
                {
                    urlKey += "/" + p.ToString();
                }
            }


            string responseFromServer = await GetJsonStringAsync(urlKey);
             
            
            var jss = new JavaScriptSerializer();
            var g = await jss.DeserializeAsync<T>(responseFromServer);

            
            if (!IsSessionAlive(g))
            {
                TimeSpan sp = DateTime.UtcNow.Subtract(sessionCreated);
                //Log the error!
                Log.LogError(string.Format("Session timed out: Service: {0} - Session Alive: {1} minutes\r\n", service, sp.Minutes));
                CreateSession();
                var item = GetResponseAsync<T>(service, requiresSession, vars); //Return again with the values.
                return await item;
            }
            else
            {
                return g;
            }
        }
        public async static Task<DataUsed> GetDataUsedAsync()
        {
            var item = await GetResponseAsync<List<DataUsed>>("getdataused", true);
            return item[0];
        }

        public static Task<List<DemoDetails>> GetDemoDetailsAsync(int matchID)
        {
            return GetResponseAsync<List<DemoDetails>>("getdemodetails", true, matchID);
        }

        public static Task<List<Friends>> GetFriendsAsync(string playerName)
        {
            return GetResponseAsync<List<Friends>>("getfriends", true, playerName);
        }
        public static Task<List<Friends>> GetFriendsAsync(int playerID)
        {
            return GetResponseAsync<List<Friends>>("getfriends", true, playerID);
        }

        public static Task<List<GodRanks>> GetGodRanksAsync(string playerName)
        {
            return GetResponseAsync<List<GodRanks>>("getgodranks", true, playerName);
        }
        public static Task<List<GodRanks>> GetGodRanksAsync(int playerID)
        {
            return GetResponseAsync<List<GodRanks>>("getgodranks", true, playerID);
        }

        public static Task<List<Items>> GetItemsAsync(eLanguageCode languageCode)
        {
            return GetResponseAsync<List<Items>>("getitems", true, languageCode);
        }

        public static Task<List<MatchDetails>> GetMatchDetailsAsync(int matchID)
        {
            return GetResponseAsync<List<MatchDetails>>("getmatchdetails", true, matchID);
        }

        public static Task<List<MatchIds>> GetMatchIdsByQueueAsync(QueueType queue, DateTime date)
        {
            return GetResponseAsync<List<MatchIds>>("getmatchidsbyqueue", true, queue, date);
        }

        public static Task<List<TeamDetails>> GetTeamDetailsAsync(int clanid)
        {
            return GetResponseAsync<List<TeamDetails>>("getteamdetails", true, clanid);
        }

        public static Task<List<MatchHistory>> GetMatchHistoryAsync(int playerID)
        {
            return GetResponseAsync<List<MatchHistory>>("getmatchhistory", true, playerID);
        }
        public static Task<List<MatchHistory>> GetTeamMatchHistoryAsync(int clanid)
        {
            return GetResponseAsync<List<MatchHistory>>("getteammatchhistory", true, clanid);
        }

        public static Task<List<TeamPlayers>> GetTeamPlayersAsync(int clanid)
        {
            return GetResponseAsync<List<TeamPlayers>>("getteamplayers", true, clanid);
        }

        public static Task<List<TopMatches>> GetTopMatchesAsync()
        {
            return GetResponseAsync<List<TopMatches>>("gettopmatches", true);
        }

        public static Task<List<Teams>> SearchTeamsAsync(string searchTeam)
        {
            return GetResponseAsync<List<Teams>>("searchteams", true, searchTeam);
        }

        public static Task<List<GameInfo>> GetLeagueLeaderBoardAsync(QueueType queue, TierType tier, int season)
        {
            return GetResponseAsync<List<GameInfo>>("getleagueleaderboard", true, queue, tier, season);
        }

        public static Task<List<LeagueSeasons>> GetLeagueSeasonsAsync(QueueType queue)
        {
            return GetResponseAsync<List<LeagueSeasons>>("getleagueseasons", true, queue);
        }
        public static Task<List<MatchHistory>> GetMatchHistoryAsync(string playerName)
        {
            return GetResponseAsync<List<MatchHistory>>("getmatchhistory", true, playerName);
        }      

        public static async Task<Player> GetPlayerAsync(int playerID)
        {
            var items = await GetResponseAsync<List<Player>>("getplayer", true, playerID);

            if (items.Count > 0)
                return items[0];
            else
                return null;
        }
        public static async Task<Player> GetPlayerAsync(string playerName)
        {
            var items = await GetResponseAsync<List<Player>>("getplayer", true, playerName);

            if (items.Count > 0)
                return items[0];
            else
                return null;

        }

        public static Task<List<QueueStats>> GetQueueStatsAsync(string playerName, QueueType queue)
        {
            return GetResponseAsync<List<QueueStats>>("getqueuestats", true, playerName, queue);
        }
        public static Task<List<Gods>> GetGodsAsync(eLanguageCode languageCode)
        {
            return GetResponseAsync<List<Gods>>("getgods", true, languageCode);
        }
        public static  Task<List<QueueStats>> GetQueueStatsAsync(int playerID, QueueType queue)
        {
            return GetResponseAsync<List<QueueStats>>("getqueuestats", true, playerID, queue);
        }
        public static Task<T> DeserializeAsync<T>(this JavaScriptSerializer js, string data) {
            return Task.Run(() =>
            {
                return js.Deserialize<T>(data);
            });
        }
        public static Task<Stream> GetRequestStreamAsync(this WebRequest request)
        {
            return Task.Factory.FromAsync<Stream>(
                request.BeginGetRequestStream, request.EndGetRequestStream, null);
        }
        
        private static async Task<string> GetJsonStringAsync(string urlKey)
        {
            HttpWebRequest request = HttpWebRequest.CreateHttp(urlKey);
            WebResponse response = await request.GetResponseAsync();            
            StreamReader reader = new StreamReader(response.GetResponseStream());

            string responseString = await reader.ReadToEndAsync();
            return responseString;

        }
        
        #endregion
        private static bool IsSessionAlive(object g)        
        {
            string prop;

            if (g is IList)
            {                
                IList a = (IList)g;
                if (a.Count > 0)
                {
                    prop = (string)a[0].GetType().GetProperty("ret_msg", typeof(string)).GetValue(a[0], null);
                }
                else
                {
                    return true;
                }
            }
            else
            {
                prop = (string)g.GetType().GetProperty("ret_msg", typeof(string)).GetValue(g, null);
            }

            if(string.IsNullOrEmpty(prop))
                return true;

            if(prop.Contains("Failed"))
                return false;

            return true;
        }

        //private static string GetResponseString(string service, bool requiresSession, params dynamic[] vars)
        //{
        //    if (requiresSession) //Requires session, make sure its available.
        //    {
        //        //First we need to verify it hasn't been over 15 minutes.
        //        TimeSpan sp = DateTime.Now.Subtract(sessionCreated);

        //        if (sp.Minutes >= 15)
        //        {
        //            //Create a new Session
        //            CreateSession();
        //        }
        //    }
        //    string signature = GetMD5Hash(_devId + service + _authKey + _timestamp);

        //    string urlKey = requiresSession ? _apiUrl + service + "json" + "/" + _devId + "/" + signature + "/" + _session + "/" + _timestamp : _apiUrl + service + "json" + "/" + _devId + "/" + signature + "/" + _timestamp;

        //    foreach (var p in vars)
        //    {
        //        if (p is DateTime)
        //        {
        //            urlKey += "/" + p.ToString("yyyyMMdd");
        //        }
        //        else if (p is QueueType || p is TierType || p is eLanguageCode)
        //        {
        //            urlKey += "/" + ((int)p).ToString();
        //        }
        //        else
        //        {
        //            urlKey += "/" + p.ToString();
        //        }
        //    }
        //    string responseFromServer;

        //    try
        //    {
        //        WebRequest request = WebRequest.Create(urlKey);
        //        request.Method = "GET";
        //        WebResponse response = request.GetResponse();
        //        Stream dataStream = response.GetResponseStream();
        //        StreamReader reader = new StreamReader(dataStream);

        //        responseFromServer = reader.ReadToEnd();

        //        reader.Close();
        //        response.Close();
        //    }
        //    catch (Exception ex)
        //    {
        //        responseFromServer = ex.Message;
        //    }

        //    return responseFromServer;
        //}
    }
}