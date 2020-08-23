using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainPlayerBase : MonoBehaviour
{
    [SerializeField] float playerBaseHP = 10;
    [SerializeField] int healthDecrease = -1;

    private void OnTriggerEnter(Collider other)
    {
        playerBaseHP -= healthDecrease;
    }
}

