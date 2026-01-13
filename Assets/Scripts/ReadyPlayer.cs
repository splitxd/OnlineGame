using Steamworks;

namespace DefaultNamespace
{
    public class ReadyPlayer
    {
        public bool IsReady {get; set;}
        public CSteamID SteamId { get; set; }
        
        public ReadyPlayer()
        {
            IsReady = false;
            SteamId = new CSteamID(0);
        }

        public ReadyPlayer(bool isReady, CSteamID steamId)
        {
            IsReady = isReady;
            SteamId = steamId;
        }
    }
}