using System.Collections.Generic;
using UnityEngine;

public class CoinCollector : MonoBehaviour
{
    public GameObject redModel;
    public GameObject yellowModel;
    public GameObject blueModel;

    public int score = 0;
    public TMPro.TextMeshProUGUI scoreText;

    public AudioClip coinCollectSound;
    public ParticleSystem coinCollectEffect;

    private Dictionary<CoinType, GameObject> coinModels;

    void Start()
    {
        coinModels = new Dictionary<CoinType, GameObject>
        {
            { CoinType.Red, redModel },
            { CoinType.Yellow, yellowModel },
            { CoinType.Blue, blueModel }
        };
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Coin"))
        {
            Coin coin = other.GetComponent<Coin>();
            if (coinModels.TryGetValue(coin.coinType, out GameObject model))
            {
                model.SetActive(true);
            }

            if (coinCollectSound != null)
            {
                AudioSource.PlayClipAtPoint(coinCollectSound, transform.position);
            }

            if (coinCollectEffect != null)
            {
                Instantiate(coinCollectEffect, other.transform.position, Quaternion.identity);
            }

            score += coin.value;
            scoreText.text = "Score: " + score;
            Destroy(other.gameObject);
        }
    }
}