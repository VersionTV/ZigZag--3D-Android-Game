using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowCamera : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField]
    GameObject target;
    Vector3 distance;

    private void Start()
    {
        distance = transform.position - target.transform.position; 
    }
    private void LateUpdate()
    {
        if(PlyrController.IsDead)
        {
            return;
        }
        transform.position = target.transform.position + distance;
    }
}
