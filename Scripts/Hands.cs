using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hands : MonoBehaviour
{
    public Rigidbody2D handsRB2;
    public float handsspeed;
    public float destroytime;

    // Start is called before the first frame update
    void Start()
    {

        Destroy(gameObject,destroytime);
        handsRB2 = GetComponent<Rigidbody2D>();
        
    }

    // Update is called once per frame
    void Update()
    {
        handsRB2.velocity = new Vector2(-handsspeed,0);
    }
}
