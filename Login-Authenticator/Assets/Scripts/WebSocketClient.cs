using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using WebSocketSharp;

public class WebSocketClient : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        using (WebSocket ws = new WebSocket("ws://127.0.0.1:7890/Echo"))
        {
            ws.OnMessage += Webs_OnMessage;

            ws.Connect();
            ws.Send("Hello from client");

            Console.ReadKey();
        }

    }
    private static void Webs_OnMessage(object sender, MessageEventArgs e)
    {
        Console.WriteLine("Recieved from the server: " + e.Data);

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
