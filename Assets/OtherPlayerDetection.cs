using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;

public class OtherPlayerDetection : NetworkBehaviour
{
    public GameObject marker;

    // Update is called once per frame
    void Update()
    {
        Debug.DrawRay(transform.position, transform.forward * 10, Color.red);
        if(GetComponent<PlayerMove>().enabled == true)
        {
            if (Input.GetMouseButton(0))
            {
                Detection();
            }
        }
    }

    [Client]
    public void Detection()
    {
        RaycastHit hit;
        if (Physics.Raycast(transform.position, transform.forward, out hit, 100f))
        {
            if (hit.collider.tag == "OtherPlayer")
            {
                InstantiateMarker(hit.collider.transform.position);
            }
        }
    }
    [Command]
    public void InstantiateMarker(Vector3 markerPosition)
    {
        DisplayMarker(markerPosition);
    }
    [ClientRpc]
    public void DisplayMarker(Vector3 markerPosition)
    {
        Instantiate(marker, markerPosition, Quaternion.identity);
        Debug.Log("Joueur toucher en " + markerPosition);
    }
}
