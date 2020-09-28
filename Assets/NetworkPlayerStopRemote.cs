using Mirror;
using UnityEngine;

public class NetworkPlayerStopRemote : NetworkBehaviour
{
    private void Start()
    {
        //string id = string.Format("{0}", netId);
        PlayerMove playerMove = GetComponent<PlayerMove>();
        Camera camera = GetComponentInChildren<Camera>();
        AudioListener audioListener = GetComponentInChildren<AudioListener>();

        if (isLocalPlayer == true)
        {
            playerMove.enabled = true;
            camera.enabled = true;
            audioListener.enabled = true;
            transform.tag = "Player";
            
        }
        else
        {
            playerMove.enabled = false;
            camera.enabled = false;
            audioListener.enabled = false;
            transform.tag = "OtherPlayer";


        }
    }
    public override void OnStartClient()
    {
        base.OnStartClient();

        string _netID = GetComponent<NetworkIdentity>().netId.ToString();
        Player _player = GetComponent<Player>();
        GameManager.RegisterPlayer(_netID, _player);
        Debug.Log(_netID);
    }
    private void OnDisable()
    {
        GameManager.UnRegisterPlayer(transform.name);
    }
}
