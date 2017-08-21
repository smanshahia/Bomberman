using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlusBomb : MonoBehaviour
{

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (other.GetComponent<PlayerBehaviour>().bombLimit < 10)
                other.GetComponent<PlayerBehaviour>().bombLimit++;
            Destroy(gameObject);
        }
    }
}
