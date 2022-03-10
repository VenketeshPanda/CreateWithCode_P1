using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    [SerializeField] private Vector3 offset = new Vector3(0, 5, -6.5f);

    public GameObject player;
    void LateUpdate()
    {
        transform.position = player.transform.position + offset;
    }
}
