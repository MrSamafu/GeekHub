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
            
        }
        else
        {
            playerMove.enabled = false;
            camera.enabled = false;
            audioListener.enabled = false;

        }
    }
}
