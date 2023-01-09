using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHandler : MonoBehaviour
{
    private Enemy test;
    // Start is called before the first frame update
    void Start()
    {
        test = new Enemy(new Vector3(2,0.25f,2));
        
    }

    // Update is called once per frame
    void Update()
    {
       
        test.move(); 
    }
}
