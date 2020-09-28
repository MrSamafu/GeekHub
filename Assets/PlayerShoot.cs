using Mirror;
using UnityEngine;

public class PlayerShoot : NetworkBehaviour
{
    public GameObject cam;
    void Start()
    {

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
}
