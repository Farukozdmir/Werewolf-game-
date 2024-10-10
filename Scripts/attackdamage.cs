using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class attackdamage : MonoBehaviour
{
    public GameObject player;
    public Wolf wolfscript;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Wolf");
        wolfscript = player.GetComponent<Wolf>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
       if ( other.gameObject.tag == "enemy")
       {
            Destroy(other.gameObject);
            wolfscript.score++;
       } 
    }
}
