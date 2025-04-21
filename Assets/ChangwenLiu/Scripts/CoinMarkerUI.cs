using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

public class CoinMarkerUI : MonoBehaviour
{
    public GameObject redMarkerPrefab;
    public GameObject blueMarkerPrefab;
    public GameObject yellowMarkerPrefab;

    public Camera mainCamera;

    private Dictionary<Transform, GameObject> coinToMarker = new Dictionary<Transform, GameObject>();

    void Start()
    {
        Coin[] coins = FindObjectsOfType<Coin>();
        foreach (var coin in coins)
        {
            GameObject markerPrefab = GetMarkerPrefabByType(coin.coinType);
            if (markerPrefab != null)
            {
                GameObject marker = Instantiate(markerPrefab, transform);
                coinToMarker.Add(coin.transform, marker);
            }
        }
    }

    void Update()
    {
        List<Transform> toRemove = new List<Transform>();

        foreach (var kv in coinToMarker)
        {
            Transform coin = kv.Key;
            GameObject marker = kv.Value;

            if (coin == null)
            {
                Destroy(marker);
                toRemove.Add(coin);
                continue;
            }

            Vector3 screenPos = mainCamera.WorldToScreenPoint(coin.position);

            if (screenPos.z > 0)
            {
                marker.SetActive(true);
                marker.transform.position = screenPos;
            }
            else
            {
                marker.SetActive(false);
            }
        }

        foreach (var t in toRemove)
        {
            coinToMarker.Remove(t);
        }
    }

    GameObject GetMarkerPrefabByType(CoinType type)
    {
        switch (type)
        {
            case CoinType.Red: return redMarkerPrefab;
            case CoinType.Blue: return blueMarkerPrefab;
            case CoinType.Yellow: return yellowMarkerPrefab;
            default: return null;
        }
    }
}
