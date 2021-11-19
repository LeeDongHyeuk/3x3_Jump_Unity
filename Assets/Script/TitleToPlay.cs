using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TitleToPlay : MonoBehaviour
{
    void Update()
    {
        if (Input.GetButton("Jump"))
        {
            SceneManager.LoadScene("GamePlayScene");
        }

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }
    }
}
