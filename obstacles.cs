using System.Collections;
using System.Collections.Generic;
using TreeEditor;
using UnityEngine;





public class obstacles : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Obst();
        
    }
    [SerializeField]public List<GameObject>choice = new List<GameObject>();
    public void Obst(){   
    choice[Random.Range(0, choice.Count-1)].SetActive(true);
    }
} 
