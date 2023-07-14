using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class score : MonoBehaviour
{
    playerController pc;
    
    private float life = 25.0f;

    
    
    
        
        void Start()
    {
        pc = FindObjectOfType<playerController>();
    }
        
        void Update()
    {
        if (life > 0)
        {
            life = life - Time.deltaTime;
            Debug.Log(life);
        }
        else
        {
            Debug.Log("Game Over");
            pc.resetPosition();
            life = 20f;
        }
    }
        
    
        

    private void OnTriggerEnter2D(Collider2D collision)
    {

        switch (collision.gameObject.tag)
        {
            case "banana":
                {
                    life = life + 1;
                    
                    Debug.Log(life);
                    break;
                }
            case "apple":
                {
                    life += 2;
                    
                    Debug.Log(life);
                    break;
                }     

        }
        
        
    }
}
