using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Piranha : MonoBehaviour
{

    Animator anim;
    Rigidbody rigbody;
    NavMeshAgent nav;
    public PlayerMovement player;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        rigbody = GetComponent<Rigidbody>();
        nav = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        nav.SetDestination(restaurant.position);
        nav.speed = 3;
    }
}
