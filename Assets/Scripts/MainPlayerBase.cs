using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainPlayerBase : MonoBehaviour
{
    [SerializeField] int playerBaseHP = 10;
    [SerializeField] int healthDecrease = 1;

    [SerializeField] Text playerBaseHPText;
    [SerializeField] AudioClip playerDamageSFX;

    private void Start()
    {
        UpdatePlayerBaseHPText();
    }

    private void OnTriggerEnter(Collider other)
    {
        playerBaseHP -= healthDecrease;
        GetComponent<AudioSource>().PlayOneShot(playerDamageSFX);
        print(playerBaseHP);
        UpdatePlayerBaseHPText();
    }

    private void UpdatePlayerBaseHPText()
    {
        playerBaseHPText.text = "Base HP - " + playerBaseHP;
    }

}

