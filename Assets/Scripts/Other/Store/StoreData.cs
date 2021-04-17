using UnityEngine;

public class StoreData
{
    public bool[] _isBuy = new bool[10];
    public StoreData()
    {
        _isBuy[0] = true;
        for (int i = 1; i < _isBuy.Length; i++)
        {
            _isBuy[i] = false;
        }
    }
}
