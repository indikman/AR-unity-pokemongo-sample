using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PokeBall : MonoBehaviour
{
    public float forceFactor = 10;

    private Rigidbody ball;

    private float startTime, endTime;
    private Vector3 startPos, endPos;
    private Vector3 force;


    void Start()
    {
        ball = GetComponent<Rigidbody>();
        ball.useGravity = false;
        ball.isKinematic = true;

        transform.position = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width / 2, Screen.height / 7, 1f));
        //transform.LookAt(2* transform.position - Camera.main.transform.position);
       // transform.SetParent(Camera.main.transform);
    }

    // Update is called once per frame
    void Update()
    {
       

        if(Input.touchCount >0 && Input.GetTouch(0).phase == TouchPhase.Began)
        {
            Debug.Log("Touch began");
            startPos = Input.GetTouch(0).position;
            startPos.z = transform.position.z - Camera.main.transform.position.z;
            startPos = Camera.main.ScreenToWorldPoint(startPos);
            startTime = Time.time;

            
        }
        else if(Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Ended)
        {
            Debug.Log("Touch END");
            endPos = Input.GetTouch(0).position;
            endPos.z = transform.position.z - Camera.main.transform.position.z;
            endPos = Camera.main.ScreenToWorldPoint(endPos);
            endTime = Time.time;

            // Force Calculations

            force = endPos - startPos;
            force.z = force.magnitude;
            force /= (endTime - startTime); // Divide force by the time difference, to get the time factor

            ball.isKinematic = false;
            ball.useGravity = true;
            

            //transform.SetParent(null);

            ball.AddForce(force * forceFactor);

            Invoke("ResetBall", 3);
        }
    }

    void ResetBall()
    {
        ball.useGravity = false;
        ball.isKinematic = true;
        
        transform.position = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width / 2, Screen.height / 7, 1f));
        //transform.SetParent(Camera.main.transform);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("monster"))
        {
            Destroy(other.gameObject);
        }
    }
}
