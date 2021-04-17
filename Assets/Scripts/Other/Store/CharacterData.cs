using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterData
{
    public int Price;
    public bool IsBuyed;
    public bool isAvailable;
    public bool isSelect;

   public CharacterData()
    {
        IsBuyed = false;
        isAvailable = false;
        isSelect = false;
    }
}
