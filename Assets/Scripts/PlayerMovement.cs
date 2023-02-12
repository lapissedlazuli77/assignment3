using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed;
    Animator anim;
    Rigidbody rigbody;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        rigbody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 currentPosition = transform.position;

        if (Input.GetKey("left") || Input.GetKey("a")) {
            currentPosition.x -= speed;
            var temp = transform.rotation.eulerAngles;
            temp.y = -180.0f;
            transform.rotation = Quaternion.Euler(temp);
        }
        if (Input.GetKey("right") || Input.GetKey("d")) {
            currentPosition.x += speed;
            var temp = transform.rotation.eulerAngles;
            temp.y = 0.0f;
            transform.rotation = Quaternion.Euler(temp);
        }
        if (Input.GetKey("up") || Input.GetKey("w")) {
            currentPosition.z += speed;
            var temp = transform.rotation.eulerAngles;
            temp.y = -90.0f;
            transform.rotation = Quaternion.Euler(temp);
        }
        if (Input.GetKey("down") || Input.GetKey("s")) {
            currentPosition.z -= speed;
            var temp = transform.rotation.eulerAngles;
            temp.y = 90.0f;
            transform.rotation = Quaternion.Euler(temp);
        }
        transform.position = currentPosition;

        if (rigbody.velocity.x > 1 || rigbody.velocity.x < 1 || rigbody.velocity.z > 1 || rigbody.velocity.z < 1)
        {
            anim.SetBool("isMoving", true);
        } else { anim.SetBool("isMoving", false); }
    }
}
