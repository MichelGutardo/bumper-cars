using System.Collections;
using UnityEngine;
using UnityEngine.Networking;


public class LocalPlayer : NetworkBehaviour {

    void Start()
    {
        if(isLocalPlayer)
        {
            GetComponent<PlayerController>().enabled = true;
            Camera.player =  this.gameObject.transform ;
        }
    }

}