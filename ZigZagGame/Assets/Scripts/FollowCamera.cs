using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowCamera : MonoBehaviour
{

    [SerializeField] GameObject target;
    Vector3 distance;
    // Start is called before the first frame update
    void Start()
    {
        distance = transform.position - target.transform.position;   
    }

    // Update is called once per frame
    void LateUpdate()
    {
        transform.position = target.transform.position + distance;
    }
}
