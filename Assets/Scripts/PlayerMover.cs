using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMover : MonoBehaviour
{
    [SerializeField] private float _moveSpeed = 1f;

    void Update()
    {
        transform.position += new Vector3(0, 0, _moveSpeed * Time.deltaTime);
    }
}
