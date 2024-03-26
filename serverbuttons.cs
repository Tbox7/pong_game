using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Netcode;
using UnityEngine;

public class serverbuttons : NetworkBehaviour
{
    // Start is called befo{re the first frame update
    public void Hostbutton(){
        NetworkManager.Singleton.StartHost();
    }
    public void Joinbutton(){
        NetworkManager.Singleton.StartClient();
    }
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
