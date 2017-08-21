using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BrickBehaviour : MonoBehaviour
{

    public GameObject brickExplosion;
    public GameObject plusBomb;
    public GameObject plusFire;
    int r;

    private void Start()
    {
        r = Random.Range(0, 4);
    }

    
    public void DestroyBrick()
    {
        Destroy(gameObject);
        Instantiate(brickExplosion, transform.position, transform.rotation);
        if (r == 1)
        {
            Instantiate(plusFire, transform.position, transform.rotation);
            return;
        }
        else if (r == 3)
        {
            Instantiate(plusBomb, transform.position, transform.rotation);
            return;
        }
    }
}
