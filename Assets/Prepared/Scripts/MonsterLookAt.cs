using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterLookAt : MonoBehaviour
{
    private Transform target;
    private Vector3 targetPosition;

    void Start()
    {
        target = Camera.main.transform;
    }

    // Update is called once per frame
    void Update()
    {
        if (target != null)
        {
            targetPosition = new Vector3(target.position.x, transform.position.y, target.position.z);
            transform.LookAt(targetPosition);
        }
    }
}
