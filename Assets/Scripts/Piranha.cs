using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Piranha : MonoBehaviour
{

    Animator anim;
    Rigidbody rigbody;
    NavMeshAgent nav;
    Transform mainCamera;

    string currentDirection = "Right";
    float timer_Direction = 0;
    float timer_DirectionTotal = 1;

    public Transform player;

    float timer = 0;
    float timertime = 2;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        rigbody = GetComponent<Rigidbody>();
        nav = GetComponent<NavMeshAgent>();
        mainCamera = Camera.main.transform;

        nav.SetDestination(player.position);
        transform.LookAt(player);
        nav.speed = 5;
    }

    // Update is called once per frame
    void Update()
    {
        if (timer >= timertime)
        {
            nav.speed = 0;
            float chancetochange = Random.Range(0f, 1f);
            if (chancetochange >= 0.3f)
            {
                nav.SetDestination(player.position);
                transform.LookAt(player);
                nav.speed = 5;
            }
            timer = 0;
        }
        if (timer_Direction > timer_DirectionTotal)
        {
            timer_Direction = 0;
            timer_DirectionTotal = Random.Range(0.2f, 1.23f);
            float currentRelativeDirection = Vector3.Dot(nav.velocity, mainCamera.right);
            if (currentRelativeDirection > 0 && currentDirection == "Right")
            {
                currentDirection = "Left";
                var localS = this.transform.localScale;
                localS.x *= -1;
                this.transform.localScale = localS;
            }
            else if (currentRelativeDirection < 0 && currentDirection == "Left")
            {
                currentDirection = "Right";
                var localS = this.transform.localScale;
                localS.x *= -1;
                this.transform.localScale = localS;
            }
        }
        timer += Time.deltaTime;
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Destroy(collision.gameObject);
        }
    }
}
