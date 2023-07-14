using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class killPlayer : MonoBehaviour
{

    playerController pc;

    // Start is called before the first frame update
    void Start()
    {
        pc = FindObjectOfType<playerController>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        pc.resetPosition();
    }


}
