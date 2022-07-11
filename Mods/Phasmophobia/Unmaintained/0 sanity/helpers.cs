//thx to OFWModz for making this code
//https://github.com/OFWModz
using System.Collections.Generic;
using System.Linq;
using Object = UnityEngine.Object;
namespace _0_sanity
{
    public class Helpers
    {
        public static Player GetLocalPlayer()
        {
            List<Player> players = GetAllPlayers();
            if (players == null || players.Count == 0)
            {
                return null;
            }
            else if (players.Count == 1)
            {
                return players[0];
            }
            else
            {
                foreach (Player player in players)
                {
                    if (player != null && player.field_Public_PhotonView_0 != null && player.field_Public_PhotonView_0.AmOwner)
                    {
                        return player;
                    }
                }
                return null;
            }
        }
        public static List<Player> GetAllPlayers()
        {
            Player[] players = Object.FindObjectsOfType<Player>();
            if (players == null || players.Length == 0)
            {
                return null;
            }
            else
            {
                return players.ToList();
            }
        }
    }
}