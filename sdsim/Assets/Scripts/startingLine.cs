using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class startingLine : MonoBehaviour
{
    public int index = 0;
    string target = "body";
    PrivateAPI privateAPI;
    private float lastTriggerTime = 0.0f;
    public float triggerDelay = 0.01f; // Delay in seconds

    void Start()
    {
        privateAPI = GameObject.FindObjectOfType<PrivateAPI>();
    }

    void OnTriggerEnter(Collider col)
    {
        

        if (col.gameObject.name != target) { return; }
        float time = Time.fixedTime;

        Transform parent = col.transform.parent.parent;
        if (parent == null) { return; }

        string carName = parent.name;
        tk.TcpCarHandler client = parent.GetComponentInChildren<tk.TcpCarHandler>();

        if (client != null)
            UnityMainThreadDispatcher.Instance().Enqueue(client.SendCollisionWithStartingLine(index, time));

        if (privateAPI != null)
            privateAPI.CollisionWithStatingLine(carName, index, time);


        Timer timers = GameObject.FindObjectOfType<Timer>();
        timers.RecordLapTime();
        if (time - lastTriggerTime < triggerDelay)
        {
            Debug.Log("Trigger activation too soon. Waiting for delay.");
            return; // Exit the method if the delay hasn't passed
        }

    }
}
