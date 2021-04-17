using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameValuta : MonoBehaviour
{
    public static int ValutaCount;

    [SerializeField] private Text _valutaCountText;

   private void Start()
   {
        ValutaCount = PlayerPrefs.GetInt("Valuta");
   }
   private void Update()
   {
        _valutaCountText.text = ValutaCount.ToString();
   }
}
