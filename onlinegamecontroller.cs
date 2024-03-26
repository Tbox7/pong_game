using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Netcode;
using UnityEditor;
using UnityEngine.UIElements;
using TMPro;
using UnityEngine.SceneManagement;
using Unity.Mathematics;

public class onlinegamecontroller : NetworkBehaviour
{
    // Start is called before the first frame update
    public int playerNumber = 1; 
    float count = 999;
    public TextMeshProUGUI countdown, player1text, player2text;
    public GameObject playerObject, playeronegoal,playertwogoal;
    private int playerScore1;
    private NetworkObject playball;
    public NetworkObject pongitem;
    private int playerScore2;
    public void Newplayer(GameObject p){
        if(!IsHost){
            p.transform.position = new Vector2(8,0);
            return;
        }
        
        if(playerNumber == 1){
            p.transform.position = new Vector2(-8,0);
            playerNumber++;
        }
        else{
            playerNumber++;
        }
        if(playerNumber == 3){
            playball = Instantiate(pongitem, new Vector2(0,0),quaternion.identity);
            playball.SpawnWithOwnership(OwnerClientId);
            startcountClientRPC();
        }
    }
    [ClientRpc]
    void startcountClientRPC(){count = 3;}

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
            if(IsHost){playball.GetComponent<ball_movement>().Play();} 
        }
        if(playerScore1 == 2 ){
            countdown.text = "PLAYER ONE WINS";
            StartCoroutine(Loop());
        }
        if(playerScore2 == 2 ){
            countdown.text = "PLAYER TWO WINS";
            StartCoroutine(Loop());
        }
    }
    [ClientRpc]
    void updatescoreClientRpc(int p1,int p2){
        playerScore1 = p1;
        playerScore2 =p2;
        player1text.text = p1.ToString();
        player2text.text = p2.ToString();        
    }
    IEnumerator Loop(){
        if(IsHost){ Destroy(playball);}
        yield return new WaitForSeconds(5f);
        NetworkManager.Singleton.Shutdown();
        SceneManager.LoadScene("menu",LoadSceneMode.Single);
        playerScore1=0;
        playerScore2=0;
    }
        public void Player1Scored(){
        if(!IsHost){return;}
        playerScore1++;
        updatescoreClientRpc(playerScore1,playerScore2);
        playball.GetComponent<ball_movement>().Reset();
        startcountClientRPC();
    }
    public void Player2Scored(){
        playerScore2++;
        updatescoreClientRpc(playerScore1,playerScore2);
        playball.GetComponent<ball_movement>().Reset();
        startcountClientRPC();
    }
}
