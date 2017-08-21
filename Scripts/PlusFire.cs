using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlusFire : MonoBehaviour
{

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Destroy(gameObject);
            if (other.GetComponent<PlayerBehaviour>().fireLength < 6)
                other.GetComponent<PlayerBehaviour>().fireLength++;
            
        }
    }

}
