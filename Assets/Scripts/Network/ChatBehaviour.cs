// using System;
// using Mirror;
// using TMPro;
// using UnityEngine;
// using UnityEngine.InputSystem;
//
// namespace Network
// {
//     public class ChatBehaviour : NetworkBehaviour
//     {
//         [SerializeField] private GameObject chatUI;
//         [SerializeField] private TMP_Text chatText;
//         [SerializeField] private TMP_InputField inputField;
//         
//         private static event Action<string> OnChatMessage;
//
//         public void SetActiveInputField()
//         {
//             inputField.ActivateInputField();
//         }
//
//         public override void OnStartAuthority()
//         {
//             chatUI.SetActive(true);
//             OnChatMessage += HandleNewMessage;
//         }
//
//         [ClientCallback]
//         private void OnDestroy()
//         {
//             if (!authority) { return; }
//             OnChatMessage -= HandleNewMessage;
//         }
//
//         private void HandleNewMessage(string message)
//         {
//             chatText.text += message;
//         }
//
//         [Client]
//         public void Send(string message)
//         {
//             Debug.Log("HERE");
//             if (!Input.GetKeyDown(KeyCode.Return))
//             {
//                 Debug.Log("!Input.GetKeyDown(KeyCode.Return)");
//                 return;
//             }
//
//             if (string.IsNullOrWhiteSpace(message)) { return; }
//             CmdSendMessage(inputField.text);
//             inputField.text = string.Empty;
//         }
//
//         [Command]
//         private void CmdSendMessage(string message)
//         {
//             RpcHandleMessage($"[{connectionToClient.connectionId}] {message}");
//         }
//
//         [ClientRpc]
//         private void RpcHandleMessage(string message)
//         {
//             OnChatMessage?.Invoke($"\n{message}");
//         }
//      }
// }