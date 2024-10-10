using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.UIElements;

public class ArcherSC : MonoBehaviour
{

    public GameObject player;
    public Rigidbody2D archerRB;
    public float playerx;
    public float archerx;
    public Vector2 archervelocity;
    public Vector3 archerscale;
    public bool archerwalk;
    public Animator archeranimator;
    public Wolf wolfscript;
    public GameObject arrow;
    public ArrowSC arrowscript;
    public GameObject arrowspawner;
    public float distancebtw;
    

    // Start is called before the first frame update
    void Start()
    {   
        player = GameObject.Find("Wolf");
        archerscale = gameObject.transform.localScale;
    }

    // Update is called once per frame
    void Update()
    {
        
        archerx = transform.position.x;
        playerx = player.transform.position.x;
        archerRB.velocity = archervelocity;
        gameObject.transform.localScale = archerscale;
        distancebtw = playerx - archerx;

        if (distancebtw < -10)
        {
            archervelocity.x = -3;
            archerwalk = true;
            archeranimator.SetBool("walk",true);
        }

        else if (distancebtw > 10)
        {
            archervelocity.x = 3;
            archerwalk = true;
            archeranimator.SetBool("walk",true);
        }

        else
        {
            archervelocity.x = 0;
            archerwalk = false;
            archeranimator.SetBool("walk",false);

        }

        if (player.transform.position.x > transform.position.x)
        {
            archerscale.x = 4;
        }

        if (player.transform.position.x < transform.position.x)
        {
            archerscale.x = -4;
        }

        }
 
}
