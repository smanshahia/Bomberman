using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombBehaviour : MonoBehaviour
{

    public GameObject explosion;
    public GameObject brickExplosion;
    public LayerMask layer;
    public int fireLength;

    private void Start()
    {
        Invoke("Explode", 5.0f);
    }


    public void Explode()
    {
        //Instantiate( explosion, transform.position, transform.rotation);

        StartCoroutine(ExplodeChain(Vector3.forward));
        StartCoroutine(ExplodeChain(Vector3.back));
        StartCoroutine(ExplodeChain(Vector3.left));
        StartCoroutine(ExplodeChain(Vector3.right));
        Destroy(gameObject);
    }

    private void OnTriggerExit(Collider other)
    {
        GetComponent<Collider>().isTrigger = false;
    }

    

    IEnumerator ExplodeChain(Vector3 direction)
    {
        for (int i = 0; i < fireLength; i++)
        {
            RaycastHit hit;
            Physics.Raycast(transform.position, direction, out hit, i, layer);
            if (!hit.collider)
            {
                Instantiate(explosion, transform.position + (i * direction), explosion.transform.rotation);
            }
            else if(hit.transform.tag == "Brick")
            {
                hit.transform.GetComponent<BrickBehaviour>().DestroyBrick();
                break;           
            }
            else if (hit.transform.tag == "Player")
            {
                Instantiate(explosion, transform.position + (i * direction), explosion.transform.rotation);
                break;
            }
            else if (hit.transform.tag == "PowerUp")
            {
                Destroy(hit.transform.gameObject);
                Instantiate(explosion, transform.position + (i * direction), explosion.transform.rotation);
                break;
            }
            
        }
        yield return new WaitForSeconds(0.05f);
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Explosion"))
        {
            CancelInvoke("Explode");
            Explode();
        }
    }

}
