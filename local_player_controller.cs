using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class local_player_controller : MonoBehaviour
{
    // Start is called before the first frame update
    public Rigidbody2D rb;
    private float movement;
    public bool isPlayer1;
    public float speed;
    
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {   
        

    if(isPlayer1){
        movement = Input.GetAxisRaw("Vertical");
    }
    else{
        movement = Input.GetAxisRaw("vertical2");
    }
    rb.velocity = new Vector2(rb.velocity.x, movement * speed);
    
    }


}
