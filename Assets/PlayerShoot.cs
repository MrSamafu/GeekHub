using Mirror;
using UnityEngine;
using TMPro;
using System;
using UnityEngine.UI;




public class PlayerShoot : NetworkBehaviour
{
    public GameObject cam;
    private TMP_Text messageBox;
    private InputField messageSendingField;
    void Start()
    {
        messageSendingField = GameObject.Find("SendingMsgArea").GetComponent<InputField>();
        messageBox = GameObject.Find("Messages").GetComponent<TMP_Text>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Shoot();
        }
    }

    [Client]
    private void Shoot()
    {
        Debug.Log("Tire");
        RaycastHit _hit;
        if(Physics.Raycast(cam.transform.position, cam.transform.forward, out _hit, 100f, 1))
        {
            if(_hit.collider.tag == "OtherPlayer")
            {
                Debug.Log("Un otherplayer à été touch");
                CmdPlayerShot(_hit.collider.name);
            }
        }
    }
    [Command]
    void CmdPlayerShot(string _ID)
    {
        Debug.Log(_ID + " a été touché.");
    }
    [Command]
    public void SendingMessage(string msg)
    {
        ReceiveMsg(msg);
    }
    [Client]
    public void Send()
    {
        if (messageSendingField.text != "")
        {
            string msg = messageBox.text + DateTime.Now.ToString("MM/dd/yyyy HH:mm") + " - " + messageSendingField.text + "<br>";
            messageSendingField.text = "";
            SendingMessage(msg);
        }
    }
    [ClientRpc]
    public void ReceiveMsg(string msg)
    {
        messageBox.text = msg;
    }

}
