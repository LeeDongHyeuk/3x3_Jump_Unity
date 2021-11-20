using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerPlay : MonoBehaviour
{
    public GameObject coin; // 코인 오브젝트
    public Text text; // 점수 표시 텍스트

    private int[] coinX = { -4, 0, 4 }; // 코인 x좌표 배열
    private float[] coinY = { 1.5f, 5.5f, -2.5f }; // 코인 y좌표 배열
    private int xIndex; // 코인 x인덱스
    private int yIndex; // 코인 y인덱스

    private static int coinCnt; // 먹은 코인 개수

    private AudioSource mAudioSource = null;
    public AudioClip CoinSound = null; // 코인 먹을 때 날 소리
    public AudioClip DieSound = null; // 죽을 때 날 소리

    void Start()
    {
        coinCnt = 0;

        xIndex = Random.Range(0, 3); // 코인 랜덤 x인덱스
        yIndex = Random.Range(0, 3); // 코인 랜덤 y인덱스
        Instantiate(coin, new Vector2(coinX[xIndex], coinY[yIndex]), Quaternion.identity); // 코인 생성
    }

    void Awake()
    {
        mAudioSource = GetComponent<AudioSource>();
        mAudioSource.volume = 0.2f;
    }

    // 코인과 캐릭터가 닿을 때
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag.Equals("Coin"))
        {
            if (mAudioSource != null && CoinSound != null)
            {
                mAudioSource.PlayOneShot(CoinSound); // 코인 소리 출력
            }
            Destroy(other.gameObject); // 코인 파괴

            coinCnt++;
            text.text = "Score : " + coinCnt; // 점수 출력

            xIndex = Random.Range(0, 3);
            yIndex = Random.Range(0, 3);
            Instantiate(coin, new Vector2(coinX[xIndex], coinY[yIndex]), Quaternion.identity); // 랜덤한 위치에 다시 생성
        }

        if (other.gameObject.tag.Equals("Spike") || other.gameObject.tag.Equals("Floor")) // 가시에 닿거나 바닥으로 떨어질 때
        {
            if (mAudioSource != null && DieSound != null)
            {
                mAudioSource.PlayOneShot(DieSound); // 죽는 소리 출력
                SceneManager.LoadScene("DieScene");
            }
        }
    }

    public static int getScore()
    {
        return coinCnt;
    }
}
