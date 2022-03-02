using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class control : MonoBehaviour
{
    public float spd;
    public bool moveForward;
    public bool moveBackward;
    public bool moveLeft;
    public bool moveRight;
    public Animator myAni;
    // Start is called before the first frame update
    void Start()
    {
        myAni = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.W))
        {
            moveForward = true;
            moveBackward = false;
        }else if (Input.GetKey(KeyCode.S))
        {
            moveForward = false;
            moveBackward = true;
        }

        if (Input.GetKey(KeyCode.A))
        {
            moveLeft = true;
            moveRight = false;
        }else if (Input.GetKey(KeyCode.D))
        {
            moveRight = true;
            moveLeft = false;
        }

        if (Input.GetKeyUp(KeyCode.W))
        {
            moveForward = false;
        }
        if (Input.GetKeyUp(KeyCode.S))
        {
            moveBackward = false;
        }

        if (Input.GetKeyUp(KeyCode.A))
        {
            moveLeft = false;
        }

        if (Input.GetKeyUp(KeyCode.D))
        {
            moveRight = false;
        }
    }

    private void FixedUpdate()
    {
        if (moveForward || moveBackward || moveLeft || moveRight)
        {
            changeState("move");
        }
        else
        {
            changeState("idle");
        }

        if (moveForward)
        {
            transform.position += transform.forward * spd;
        }else if (moveBackward)
        {
            transform.position +=  -transform.forward * spd;
        }

        if (moveRight)
        {
            transform.position += transform.right * spd;
        }else if (moveLeft)
        {
            transform.position += -transform.right * spd;
        }

        transform.Rotate(new Vector3(0, Input.GetAxis("Mouse X"), 0) * 10);
    }


    public void changeState(string target)
    {
        myAni.Play(target);
    }
}
