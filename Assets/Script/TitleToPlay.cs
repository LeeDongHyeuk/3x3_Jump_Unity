using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TitleToPlay : MonoBehaviour
{
    void Update()
    {
        // 스페이스바를 누를 경우 게임 시작
        if (Input.GetButton("Jump"))
        {
            SceneManager.LoadScene("GamePlayScene");
        }

        // Esc 키를 누를 경우 게임 종료
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }
    }
}
