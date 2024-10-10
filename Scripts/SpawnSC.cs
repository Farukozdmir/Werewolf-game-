using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnSC : MonoBehaviour
{

    public GameObject hands;
    public Vector3 handpos;
    public float waiting;


    // Start is called before the first frame update
    void Start()
    {
        handpos = new Vector3(15,-4,0);

        StartCoroutine(SpawnObject());

    }

    // Update is called once per frame


    public IEnumerator SpawnObject()
    {
        while(true)
        {
        yield return new WaitForSeconds(waiting);
        Instantiate(hands,handpos,transform.rotation);
        }
    }

    
}
