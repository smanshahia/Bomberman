using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DebbugBombCount : MonoBehaviour {

    public GameObject player;
    Text t;
    int i;

    private void Start()
    {
        t = GetComponent<Text>();
    }

    private void Update()
    {
        i = player.gameObject.GetComponent<PlayerBehaviour>().bombLimit;
        t.text = i.ToString();
    }

}
