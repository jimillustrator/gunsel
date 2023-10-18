using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponSwitcher : MonoBehaviour
{
    //This script is being attached to the Weapons Empty,
    //not to the individual weapons or the Player

    [SerializeField] int currentWeapon = 0;

    void Start()
    {
        SetWeaponActive();
    }

    void Update()
    {
        //This establishes the baseline with the weapon the game starts with 
        int previousWeapon = currentWeapon;

        //These two change the current weapon for the following if statement to evaluate
        ProcessKeyInput();
        ProcessScrollWheeel();

        if(previousWeapon != currentWeapon)
        {
            SetWeaponActive();
        }
    }

    void ProcessKeyInput()
    {
        //Alpha1 is the keycode for the 1 key on the keyboard
        if(Input.GetKeyDown(KeyCode.Alpha1))
        {
            currentWeapon = 0;
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            currentWeapon = 1;
        }
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            currentWeapon = 2;
        }
    }

    void ProcessScrollWheeel()
    {
        //Mouse ScrollWheel is a string reference that we got from the Edit>
        //Project Settings>Input Manager>Mouse ScrollWheel in Unity iself

        if(Input.GetAxis("Mouse ScrollWheel") < 0)
        {
            //the "-1" is to convert it to index number
            //thetransform is the trasform of the weapons empty, since this script is on that
            if(currentWeapon >= transform.childCount-1)
            {
                currentWeapon = 0;
            }
            else
            {
                currentWeapon++;
            }
        }

        if(Input.GetAxis("Mouse ScrollWheel") > 0)
        {
            if(currentWeapon <= 0)
            {
                currentWeapon = transform.childCount-1;
            }
            else
            {
                currentWeapon--;
            }
        }
    }



    void SetWeaponActive()
    {
        int weaponIndex = 0;

        foreach (Transform weapon in transform)
        {
            if (weaponIndex == currentWeapon)
            {
                weapon.gameObject.SetActive(true);
            }
            else
            {
                weapon.gameObject.SetActive(false);
            }
            weaponIndex++;
        }
    }
}