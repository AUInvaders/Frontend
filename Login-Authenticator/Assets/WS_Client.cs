using WebSocketSharp;
using UnityEngine;

public class WS_Client : MonoBehaviour
{
    WebSocket ws;

    private RegisterMenu Registration;

    void Start()
    {
        ws = new WebSocket("ws://localhost: ");
        ws.Connect();
        ws.OnMessage += (sender, e) =>
        {
            Debug.Log("Message Recieved from " +
                      ((WebSocket) sender).Url + ", Data : " + e.Data);
        };
    }

    void Update()
    {
        if (ws == null)
        {
            return;
        }
        /*
        if (Input.GetKeyDown(KeyCode.Space))
        {
            ws.Send(Username);
        }
    */
    }
}
