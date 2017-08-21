using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DebugFireLength : MonoBehaviour
{

    public GameObject player;
    Text t;
    int i;

    private void Start()
    {
        t = GetComponent<Text>();
    }

    private void Update()
    {
        i = player.gameObject.GetComponent<PlayerBehaviour>().fireLength;
        t.text = i.ToString();
    }

}
