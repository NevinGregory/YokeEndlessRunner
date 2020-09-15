using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RocketScript : MonoBehaviour
{
    public float speed, lerpSpeed, dashSpeed;
    public int nextIndex, currIndex;
    public Vector3 desiredPosition;

    private Animator anim;
    private Rigidbody rb;
    private ScoreManager sc;

    private Vector2 initialPosition;

    private Vector3[] directions = { new Vector3(-5, 0, 0), new Vector3(0, 0, 0), new Vector3(5, 0, 0) };

    private void Start()
    {
        currIndex = 1;
        nextIndex = currIndex;
        anim = GetComponentInChildren<Animator>();
        rb = GetComponent<Rigidbody>();
        sc = Camera.main.GetComponent<ScoreManager>();
    }

    void Update()
    {
        //float h = Input.GetAxisRaw("Horizontal");
        //float currX = transform.position.x;

        if(Input.GetKeyDown(KeyCode.RightArrow) || Input.GetKeyDown(KeyCode.D))
        {
            nextIndex++;
        } else if(Input.GetKeyDown(KeyCode.LeftArrow) || Input.GetKeyDown(KeyCode.A))
        {
            nextIndex--;
        }
        else if (Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.W))
        {
            anim.SetTrigger("Dash");
            Vector3 d = desiredPosition + new Vector3(0, 0, 10);
            Vector3.MoveTowards(transform.position, d, Time.deltaTime);
        }

        if (Input.touchCount == 1)
        {
            Touch touch = Input.GetTouch(0);

            if (touch.phase == TouchPhase.Began)
            {
                initialPosition = touch.position;
            }
            else if (touch.phase == TouchPhase.Moved || touch.phase == TouchPhase.Stationary)
            {
                // get the moved direction compared to the initial touch position
                var direction = touch.position - initialPosition;

                // get the signed x direction
                // if(direction.x >= 0) 1 else -1
                var signedDirection = Mathf.Sign(direction.x);

                // are you sure you want to become faster over time?
                nextIndex += (int)signedDirection;
            } 
        }

        nextIndex = Mathf.Clamp(nextIndex, 0, 2);

        desiredPosition = directions[nextIndex];

        if (Vector3.Distance(transform.position, desiredPosition) >= 0.1f)
            transform.position = Vector3.Lerp(transform.position, desiredPosition, Time.deltaTime * lerpSpeed);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Defender"))
        {
            if (anim.GetCurrentAnimatorStateInfo(0).IsName("Dash"))
            {
                other.GetComponent<Defender>().Die();
                sc.Tackled();
            }
            else {
                anim.SetTrigger("Tackled");

                SceneMan.GameOver();
            }
        } else if (other.CompareTag("Coin"))
        {
            Destroy(other.gameObject);

            sc.IncreaseCoins();
        } else if(other.CompareTag("H_Defender"))
        {
            anim.SetTrigger("Tackled"); 

            other.GetComponent<HeavyDefender>().Tackled();

            //SceneMan.GameOver();
            Invoke("SceneMan.GameOver()", 1);
        }
    }
}
