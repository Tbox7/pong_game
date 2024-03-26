using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using Unity.Netcode;

public class ball_movement : NetworkBehaviour
{
    public float speed;
    public Rigidbody2D rb;
    public Vector2 startPos;
    // Start is called before the first frame update
    public void Start(){
        startPos = transform.position;
    }


    public void Play()
    {
        float x = Random.Range(0,2) == 0 ? -1 : 1; 
        float y = Random.Range(0,2) == 0 ? -1 : 1;
        rb.velocity = new Vector2(speed * x, speed *y);     
    }
     public bool isplayeronegoal,online = false;
    private void OnTriggerEnter2D(Collider2D collision){
        if(online){
            if(!IsHost){
                return;
            }
            if(collision.gameObject.CompareTag("pong item")){
                if(!isplayeronegoal){
                    GameObject.Find("online_game_controller").GetComponent<onlinegamecontroller>().Player1Scored();
                }
                else {
                    GameObject.Find("online_game_controller").GetComponent<onlinegamecontroller>().Player2Scored();
                }   
            }
        }
        else{
            if(collision.gameObject.CompareTag("pong item")){
                if(!isplayeronegoal){
                    GameObject.Find("gamecontroller").GetComponent<local_game_controller>().Player1Scored();
                }
                else {
                    GameObject.Find("gamecontroller").GetComponent<local_game_controller>().Player2Scored();
                }   
            }
        }    
    }
    public void Reset(){
        rb.velocity = Vector2.zero;
        transform.position = startPos;
    }

}
