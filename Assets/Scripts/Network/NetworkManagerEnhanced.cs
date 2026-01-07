// using FishNet.Managing;
// using Mirror;
// using UnityEngine;
//
// namespace Network
// {
//     public class NetworkManagerEnhanced : NetworkManager
//     {
//         [SerializeField] Transform spawnPointPlayer1;
//         [SerializeField] Transform spawnPointPlayer2;
//         GameObject cubePrefab;
//         
//         public override void OnServerAddPlayer(NetworkConnectionToClient conn)
//         {
//             // add player at correct spawn position
//             Transform start = numPlayers == 0 ? spawnPointPlayer1 : spawnPointPlayer2;
//             GameObject player = Instantiate(playerPrefab, start.position, start.rotation);
//             NetworkServer.AddPlayerForConnection(conn, player);
//
//             // spawn ball if two players
//             if (numPlayers == 2)
//             {
//                 cubePrefab = Instantiate(spawnPrefabs.Find(prefab => prefab.name == "Cube"));
//                 NetworkServer.Spawn(cubePrefab);
//             }
//         }
//         
//         public override void OnServerDisconnect(NetworkConnectionToClient conn)
//         {
//             // destroy ball
//             if (cubePrefab != null)
//                 NetworkServer.Destroy(cubePrefab);
//
//             // call base functionality (actually destroys the player)
//             base.OnServerDisconnect(conn);
//         }
//         
//     }
// }