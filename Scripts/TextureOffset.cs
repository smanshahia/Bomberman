using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextureOffset : MonoBehaviour
{

    public float speed;

    void Update()
    {
        GetComponent<Renderer>().material.mainTextureOffset = new Vector2(Time.time * -speed, Time.time * speed);
    }
}
