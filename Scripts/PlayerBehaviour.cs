using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBehaviour : MonoBehaviour
{

    public GameObject explosion;
    public GameObject bomb;
    public KeyCode up;
    public KeyCode down;
    public KeyCode left;
    public KeyCode right;
    public KeyCode drop;
    public float speed;


    bool underBombLimit;
    bool canDropBomb;
    public bool isAlive;
    int bombCount;
    public int bombLimit;
    public int fireLength;

    private Rigidbody rigidBody;

    public void Awake()
    {
        bombCount = 0;
        bombLimit = 1;
        canDropBomb = true;
        underBombLimit = true;
        isAlive = true;
        fireLength = 2;
    }

    private void Start()
    {
        rigidBody = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        if (isAlive)
        {

            if (bombCount >= bombLimit)
            {
                underBombLimit = false;
            }
            else
            {
                underBombLimit = true;
            }

            if (Input.GetKeyUp(up))
            {
                rigidBody.velocity = new Vector3(rigidBody.velocity.x, rigidBody.velocity.y, 0);
                transform.rotation = Quaternion.Euler(0, 0, 0);
            }
            if (Input.GetKeyUp(down))
            {
                rigidBody.velocity = new Vector3(rigidBody.velocity.x, rigidBody.velocity.y, 0);
                transform.rotation = Quaternion.Euler(0, 180, 0);
            }
            if (Input.GetKeyUp(left))
            {
                rigidBody.velocity = new Vector3(0, rigidBody.velocity.y, rigidBody.velocity.z);
                transform.rotation = Quaternion.Euler(0, 270, 0);
            }
            if (Input.GetKeyUp(right))
            {
                rigidBody.velocity = new Vector3(0, rigidBody.velocity.y, rigidBody.velocity.z);
                transform.rotation = Quaternion.Euler(0, 90, 0);
            }
            if (Input.GetKeyDown(drop) && canDropBomb && underBombLimit)
            {
                DropBomb();
                Invoke("UpdateBombCount", 5.0f);

            }
        }
    }

    void FixedUpdate()
    {
        if (Input.GetKey(up))
        {
            rigidBody.velocity = new Vector3(rigidBody.velocity.x, rigidBody.velocity.y, speed);
            transform.rotation = Quaternion.Euler(0, 0, 0);
        }
        if (Input.GetKey(down))
        {
            rigidBody.velocity = new Vector3(rigidBody.velocity.x, rigidBody.velocity.y, -speed);
            transform.rotation = Quaternion.Euler(0, 180, 0);
        }
        if (Input.GetKey(left))
        {
            rigidBody.velocity = new Vector3(-speed, rigidBody.velocity.y, rigidBody.velocity.z);
            transform.rotation = Quaternion.Euler(0, 270, 0);
        }
        if (Input.GetKey(right))
        {
            rigidBody.velocity = new Vector3(speed, rigidBody.velocity.y, rigidBody.velocity.z);
            transform.rotation = Quaternion.Euler(0, 90, 0);
        }

    }

    void DropBomb()
    {
        GameObject b = (GameObject)Instantiate(bomb, new Vector3(Mathf.RoundToInt(transform.position.x), 0.5f, Mathf.RoundToInt(transform.position.z)), bomb.transform.rotation);
        b.GetComponent<BombBehaviour>().fireLength = fireLength;
        canDropBomb = false;
        bombCount++;
    }
    void UpdateBombCount()
    {
        bombCount--;
    }

    private void OnTriggerExit(Collider other)
    {
        canDropBomb = true;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Explosion"))
            isAlive = false;
    }

}
