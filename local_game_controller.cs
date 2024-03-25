using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
using TMPro;
using UnityEditor.Callbacks;
using System.Runtime.CompilerServices;
using JetBrains.Annotations;
using UnityEditor.PackageManager.Requests;
using Unity.VisualScripting;
using System;
using UnityEngine.SceneManagement;

public class local_game_controller : MonoBehaviour
{
    public GameObject playerObject, pongitem, playball,playeronegoal,playertwogoal;
    public TextMeshProUGUI countdown, player1text, player2text;
    float count = 3;
    private int playerScore1;
    private int playerScore2;
    // Start is called before the first frame update
    void Start()
    {  
        GameObject g = Instantiate(playerObject, new Vector2(-8,0),quaternion.identity);
        g.GetComponent<local_player_controller>().isPlayer1 = true;
        g = Instantiate(playerObject, new Vector2(8,0),quaternion.identity);
        g.GetComponent<local_player_controller>().isPlayer1 = false;
        playball = Instantiate(pongitem, new Vector2(0,0),quaternion.identity);
    }
    // Update is called once per frame
    void Update()
    {
        if(count!=999){
            countdown.text = Mathf.RoundToInt(count).ToString();
            count-=Time.deltaTime;
        }
        if(count<=0){
            count = 999;
            countdown.text = "";
            playball.GetComponent<ball_movement>().Play(); 
        }
        if(playerScore1 == 2 ){
            countdown.text = "PLAYER ONE WINS";
            playball.GetComponent<ball_movement>().Reset();
            StartCoroutine(Loop());
        }
        if(playerScore2 == 2 ){
            countdown.text = "PLAYER TWO WINS";
            playball.GetComponent<ball_movement>().Reset();
            StartCoroutine(Loop());
        }
    }

    IEnumerator Loop(){
        yield return new WaitForSeconds(5f);
        SceneManager.LoadScene("menu",LoadSceneMode.Single);
        playerScore1=0;
        playerScore2=0;
    }
    
   
    public void Player1Scored(){
        playerScore1++;
        player1text.text = playerScore1.ToString();
        playball.GetComponent<ball_movement>().Reset();
        count = 3;
    }
    public void Player2Scored(){
        playerScore2++;
        player2text.text = playerScore2.ToString();
        playball.GetComponent<ball_movement>().Reset();
        count = 3;
    }
    
}

