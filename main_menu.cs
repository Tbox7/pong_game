using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class main_menu : MonoBehaviour
{
    
    // Start is called before the first frame update
    public void StartLocalGame()
    {
        SceneManager.LoadScene("Game Field",LoadSceneMode.Single);
        
    }
    public void startmultiGame()
    {
        SceneManager.LoadScene("online game field",LoadSceneMode.Single);
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
