using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerPlay : MonoBehaviour
{
    public GameObject obj;
    public Text text;

    private int[] coinX = { -4, 0, 4 };
    private float[] coinY = { 1.5f, 5.5f, -2.5f };
    private int xIndex;
    private int yIndex;

    private int coinCnt;

    private AudioSource mAudioSource = null;
    public AudioClip CoinSound = null;

    void Start()
    {
        coinCnt = 0;

        xIndex = Random.Range(0, 3);
        yIndex = Random.Range(0, 3);
        Instantiate(obj, new Vector2(coinX[xIndex], coinY[yIndex]), Quaternion.identity);
    }

    void Awake()
    {
        mAudioSource = GetComponent<AudioSource>();
    }

    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag.Equals("Coin"))
        {
            if (mAudioSource != null && CoinSound != null)
            {
                mAudioSource.PlayOneShot(CoinSound);
            }
            Destroy(other.gameObject);

            coinCnt++;
            text.text = "Score : " + coinCnt;

            xIndex = Random.Range(0, 3);
            yIndex = Random.Range(0, 3);
            Instantiate(obj, new Vector2(coinX[xIndex], coinY[yIndex]), Quaternion.identity);
        }
    }
}
