
using System.Transactions;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackGr : MonoBehaviour

{
    
    public Vector3 Rightpos;
    public Vector3 Leftpos;
    public Vector3 backgroundpos;
    public Vector3 middlepos;
    public GameObject right;
    public GameObject left;
    public GameObject backgroundfolder;
    public GameObject middle;
    public Rigidbody2D background;
    public Wolf wolfscript;
    
    
    


    // Start is called before the first frame update
    void Start()
    {
        right = GameObject.Find("right");
        left = GameObject.Find("left");
        Rightpos = right.transform.position;
        Leftpos = left.transform.position;
        backgroundpos = backgroundfolder.transform.position;
        middlepos = middle.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
          
        


        if (right.transform.position.x < middlepos.x)
        {
            backgroundfolder.transform.position = backgroundpos;
        }

        if (left.transform.position.x > middlepos.x)
        {
            backgroundfolder.transform.position = backgroundpos;
            
        }    
    }
   
}


