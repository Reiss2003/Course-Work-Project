using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    public Transform target;
    void LateUpdate()
    {
        Vector3 pos = new Vector3(Mathf.Clamp(target.position.x,-20,180),
    Mathf.Clamp(target.position.y,-80,150 ), transform.position.z);
        transform.position = Vector3.Lerp(transform.position,pos, Time.deltaTime * 3.0f);
    }
}
