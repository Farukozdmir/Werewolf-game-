using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class ArcherSpawner : MonoBehaviour
{
    public GameObject archer;
    public Vector3 spawnpos;
    public GameObject player;
    public Wolf wolfSC;
    public int a = 6;
    private float x1,x2,randfac;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(ArcherSpawn());
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator ArcherSpawn()
    {
        while(!wolfSC.isDeath)
        {
            if (wolfSC.score < 10)
            {
                a=5;
            }

            else if (wolfSC.score < 20)
            {
                a=4;
            }

            else if (wolfSC.score < 30)
            {
                a=3;
            }

            else if (wolfSC.score < 40)
            {
                a=2;
            }

            else if (wolfSC.score < 50)
            {
                a=1;
            }

            yield return new WaitForSeconds(a);

            randfac = UnityEngine.Random.Range(0,2);
            x1 = UnityEngine.Random.Range(player.transform.position.x + 5 ,40);
            x2 = UnityEngine.Random.Range(player.transform.position.x - 5 ,-40);

            if (randfac == 1 && x1 < 40 )
            {
                Instantiate(archer,new Vector3(x1,-3,0),quaternion.identity);
            }
            else if (randfac == 0 && x2 > -40)
            {
                Instantiate(archer,new Vector3(x2,-3,0),quaternion.identity);
            }
        }
    }    
}
