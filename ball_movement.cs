using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor.Callbacks;

public class ball_movement : MonoBehaviour
{
    public float speed;
    public Rigidbody2D rb;
    // Start is called before the first frame update
    public void Play()
    {
        float x = Random.Range(0,2) == 0 ? -1 : 1; 
        float y = Random.Range(0,2) == 0 ? -1 : 1;
        rb.velocity = new Vector2(speed * x, speed *y);     
    }
     public bool isplayeronegoal;
    private void OnTriggerEnter2D(Collider2D collision){
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
