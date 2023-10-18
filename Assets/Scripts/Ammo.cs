using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ammo : MonoBehaviour
{
    //this creates an array for the ammo slots
    [SerializeField] AmmoSlot[] ammoSlots;

    //this is a new class that's only visible to the Ammo class (which is, itself, public)
    //the public variables that are created in it can only be used by the Ammo class
    //the System.Serializable essentially makes the entire class like a SerializeField,
    //so it can appear in the Inspector

    [System.Serializable]
    private class AmmoSlot
    {
        public AmmoType ammoType;
        public int ammoAmount;
    }

    //public int GetCurrentAmmo()
    //{
    //    return ammoAmount;
    //}

    //public void ReduceCurrentAmmo()
    //{
    //    ammoAmount--;
    //}
}
