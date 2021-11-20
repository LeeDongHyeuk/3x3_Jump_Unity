using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class DieScore : MonoBehaviour
{
    public Text text;

    void Start()
    {
        text.text = "Your Score is\n\n" + PlayerPlay.getScore(); // 점수 출력
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.R)) // R 눌러서 게임 다시 시작
        {
            SceneManager.LoadScene("GamePlayScene");
        }

        if (Input.GetKeyDown(KeyCode.M)) // M 눌러서 메인 화면
        {
            SceneManager.LoadScene("GameTitleScene");
        }
    }
}
