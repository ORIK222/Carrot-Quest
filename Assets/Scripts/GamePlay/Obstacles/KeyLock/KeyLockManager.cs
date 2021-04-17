using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyLockManager : MonoBehaviour
{
    private Lock _lock;
    private Key _key;

    private void Start()
    {
        _lock = transform.GetChild(1).GetComponent<Lock>();
        _key = transform.GetChild(0).transform.GetChild(0).GetComponent<Key>(); 
    }
    private void Update()
    {
        if (_key.transform.childCount == 0) _lock.KeyIsPickUp = true;
        if (_lock.transform.childCount == 0) _key.KeyImage.gameObject.SetActive(false);
    }

}
