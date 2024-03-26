using System.Collections;
using System.Collections.Generic;
using Unity.Netcode;
using UnityEngine;

public class multiplayerstart : NetworkBehaviour
{
    // Start is called before the first frame update
    public Rigidbody2D rb;
    private float movement;
    public float speed;
    void Start()
    {
        GameObject.Find("online_game_controller").GetComponent<onlinegamecontroller>().Newplayer(gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        if(!IsOwner){
            return;
        }
        movement = Input.GetAxisRaw("Vertical");
        //movement = Input.GetAxisRaw("vertical2");
        rb.velocity = new Vector2(rb.velocity.x, movement * speed);

    }
}
