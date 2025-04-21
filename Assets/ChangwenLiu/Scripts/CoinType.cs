using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum CoinType { Red, Yellow, Blue }

public class Coin : MonoBehaviour
{
    public CoinType coinType;
    public int value = 10;
}