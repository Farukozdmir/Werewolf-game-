
using System;
using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using Unity.Mathematics;
using UnityEngine;


public class ArrowSC : MonoBehaviour
{
    public GameObject player;
    private Vector3 playerlocation;
    private float playerx;
    private float playery;
    private float distance;
    public Rigidbody2D arrowRB;
    public float velocityconstant;
    public bool isdeath;
    public Wolf wolfstring;
    

    // Start is called before the first frame update
    void Start()
    {
        
        Destroy(gameObject,7);
        player = GameObject.Find("Wolf");
        playerlocation = player.transform.position;
        playerx = playerlocation.x-transform.position.x;
        playery = playerlocation.y-transform.position.y;
        distance = math.sqrt((playerx * playerx) + (playery * playery));
        wolfstring = player.GetComponent<Wolf>();

    }

    // Update is called once per frame
    void Update()
    {
        arrowRB.velocity = new Vector2(((playerx/distance)*velocityconstant),((playery/distance)*velocityconstant));
    }

  private void OnTriggerEnter2D(Collider2D other) 
  {
    if (other.gameObject.tag == "Player")
        {
            Destroy(gameObject);
            wolfstring.PlayerHealth -= 10;
            
        }
  }


}
