using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorLight : MonoBehaviour
{
    // 신호등 오브젝트 받아오기
    public GameObject lightX1_1;
    public GameObject lightX1_2;
    public GameObject lightX2_1;
    public GameObject lightX2_2;
    public GameObject lightX3_1;
    public GameObject lightX3_2;
    public GameObject lightY1_1;
    public GameObject lightY1_2;
    public GameObject lightY2_1;
    public GameObject lightY2_2;
    public GameObject lightY3_1;
    public GameObject lightY3_2;

    // 신호등 오브젝트의 색상 변경을 위한 SpriteRenderer
    private SpriteRenderer lightX1_1_Color;
    private SpriteRenderer lightX1_2_Color;
    private SpriteRenderer lightX2_1_Color;
    private SpriteRenderer lightX2_2_Color;
    private SpriteRenderer lightX3_1_Color;
    private SpriteRenderer lightX3_2_Color;
    private SpriteRenderer lightY1_1_Color;
    private SpriteRenderer lightY1_2_Color;
    private SpriteRenderer lightY2_1_Color;
    private SpriteRenderer lightY2_2_Color;
    private SpriteRenderer lightY3_1_Color;
    private SpriteRenderer lightY3_2_Color;

    private SpriteRenderer[,] lights = new SpriteRenderer[6, 2]; // 신호등 배열 생성

    // 가시 오브젝트 받아오기
    public GameObject spike1;
    public GameObject spike2;
    public GameObject spike3;
    public GameObject spike4;
    public GameObject spike5;
    public GameObject spike6;
    public GameObject spike7;
    public GameObject spike8;
    public GameObject spike9;

    private GameObject[,] spikes = new GameObject[3, 3]; // 가시 배열 생성

    private int xIdx; // 가로 줄에서 하나만 켜질 경우의 인덱스
    private int xIdx2; // 왼 또는 오를 위한 인덱스
    private int yIdx; // 세로 줄에서 하나만 켜질 경우의 인덱스
    private int yIdx2; // 위 또는 아래를 위한 인덱스

    private int xIdx1_1; // 가로 줄에서 두 개가 켜질 경우의 첫 번째 인덱스
    private int xIdx1_2; // 가로 줄에서 두 개가 켜질 경우의 두 번째 인덱스
    private int xIdx2_1; // 첫 번째 인덱스의 왼 오를 정하는 인덱스
    private int xIdx2_2; // 두 번째 인덱스의 왼 오를 정하는 인덱스
    private int yIdx1_1; // 세로 줄에서 두 개가 켜질 경우의 첫 번째 인덱스
    private int yIdx1_2; // 세로 줄에서 두 개가 켜질 경우의 첫 번째 인덱스
    private int yIdx2_1; // 첫 번째 인덱스의 위 아래를 정하는 인덱스
    private int yIdx2_2; // 첫 번째 인덱스의 위 아래를 정하는 인덱스

    private float yellowTime = 1f; // 노란 불이 켜질 초
    private float redTime = 4.5f; // 빨간 불이 켜질 초

    private float xPos1 = 4.6f; // 첫 번째 가로줄의 좌표
    private float xPos2 = 0.6f; // 두 번째 가로줄의 좌표
    private float xPos3 = -3.4f; // 세 번째 가로줄의 좌표

    private float plusX = 0.8f; // 좌표 조정을 위한 값

    void Start()
    {
        // 신호등의 색깔 관련 컴포넌트 받아오기
        lightX1_1_Color = lightX1_1.GetComponent<SpriteRenderer>();
        lightX1_2_Color = lightX1_2.GetComponent<SpriteRenderer>();
        lightX2_1_Color = lightX2_1.GetComponent<SpriteRenderer>();
        lightX2_2_Color = lightX2_2.GetComponent<SpriteRenderer>();
        lightX3_1_Color = lightX3_1.GetComponent<SpriteRenderer>();
        lightX3_2_Color = lightX3_2.GetComponent<SpriteRenderer>();
        lightY1_1_Color = lightY1_1.GetComponent<SpriteRenderer>();
        lightY1_2_Color = lightY1_2.GetComponent<SpriteRenderer>();
        lightY2_1_Color = lightY2_1.GetComponent<SpriteRenderer>();
        lightY2_2_Color = lightY2_2.GetComponent<SpriteRenderer>();
        lightY3_1_Color = lightY3_1.GetComponent<SpriteRenderer>();
        lightY3_2_Color = lightY3_2.GetComponent<SpriteRenderer>();

        // 배열에 신호등 색깔 관련 컴포넌트를 저장
        lights[0, 0] = lightX1_1_Color;
        lights[0, 1] = lightX1_2_Color;
        lights[1, 0] = lightX2_1_Color;
        lights[1, 1] = lightX2_2_Color;
        lights[2, 0] = lightX3_1_Color;
        lights[2, 1] = lightX3_2_Color;
        lights[3, 0] = lightY1_1_Color;
        lights[3, 1] = lightY1_2_Color;
        lights[4, 0] = lightY2_1_Color;
        lights[4, 1] = lightY2_2_Color;
        lights[5, 0] = lightY3_1_Color;
        lights[5, 1] = lightY3_2_Color;

        // 가시 배열 저장
        spikes[0, 0] = spike1;
        spikes[0, 1] = spike2;
        spikes[0, 2] = spike3;
        spikes[1, 0] = spike4;
        spikes[1, 1] = spike5;
        spikes[1, 2] = spike6;
        spikes[2, 0] = spike7;
        spikes[2, 1] = spike8;
        spikes[2, 2] = spike9;

        GreenLight(); // 전부 초록불로 바꾸는 함수

        InvokeRepeating("RandomLights", 2f, 10f); // 2초 뒤 RandomLights 함수 실행 10초 단위로 재호출
    }

    void RandomLights()
    {
        int xMany = Random.Range(1, 3); // x줄에 들어올 신호등의 개수
        int yMany = Random.Range(1, 3); // y줄에 들어올 신호등의 개수

        if (xMany == 1)
        {
            Invoke("XYellowLight1", yellowTime);
            Invoke("XRedLight1", redTime);  
        }

        if (xMany == 2)
        {
            Invoke("XYellowLight2", yellowTime);
            Invoke("XRedLight2", redTime);
        }

        if (yMany == 1)
        {
            Invoke("YYellowLight1", yellowTime);
            Invoke("YRedLight1", redTime);
        }

        if (yMany == 2)
        {
            Invoke("YYellowLight2", yellowTime);
            Invoke("YRedLight2", redTime);
        }

        Invoke("GreenLight", redTime + 3f); // 파란 불로 바꿔주는 함수
    }

    void XYellowLight1() // x줄에 랜덤으로 노란 불이 한 개 들어오는 함수
    {
        xIdx = Random.Range(0, 3);
        xIdx2 = Random.Range(0, 2);

        lights[xIdx, xIdx2].color = new Color(255 / 255f, 215 / 255f, 0 / 255f);
    }

    void XYellowLight2() // x줄에 랜덤으로 노란 불이 두 개 들어오는 함수
    {
        do
        {
            xIdx1_1 = Random.Range(0, 3);
            xIdx1_2 = Random.Range(0, 3);
            xIdx2_1 = Random.Range(0, 2);
            xIdx2_2 = Random.Range(0, 2);
        } while (xIdx1_1 == xIdx1_2);


        lights[xIdx1_1, xIdx2_1].color = new Color(255 / 255f, 215 / 255f, 0 / 255f);
        lights[xIdx1_2, xIdx2_2].color = new Color(255 / 255f, 215 / 255f, 0 / 255f);
    }

    void XRedLight1() // x줄에 노란 불이 한 개 들어오는 함수의 후속, 빨간 불로 바꾸고 그 줄에 가시를 올라오게 함
    {   
        switch(xIdx)
        {
            case 0:
                for (int i = 0; i < 3; i++)
                {
                    spikes[xIdx, i].transform.position = new Vector2(spikes[xIdx, i].transform.position.x, xPos1 + plusX);
                }
                break;
            case 1:
                for (int i = 0; i < 3; i++)
                {
                    spikes[xIdx, i].transform.position = new Vector2(spikes[xIdx, i].transform.position.x, xPos2 + plusX);
                }
                break;
            case 2:
                for (int i = 0; i < 3; i++)
                {
                    spikes[xIdx, i].transform.position = new Vector2(spikes[xIdx, i].transform.position.x, xPos3 + plusX);
                }
                break;
        }

        lights[xIdx, xIdx2].color = Color.red;
    }

    void XRedLight2() // x줄에 노란 불이 2개 들어오는 함수의 후속, 빨간 불로 변하고 그 줄들에 가시가 올라옴
    {
        switch (xIdx1_1)
        {
            case 0:
                for (int i = 0; i < 3; i++)
                {
                    spikes[xIdx1_1, i].transform.position = new Vector2(spikes[xIdx1_1, i].transform.position.x, xPos1 + plusX);
                }
                break;
            case 1:
                for (int i = 0; i < 3; i++)
                {
                    spikes[xIdx1_1, i].transform.position = new Vector2(spikes[xIdx1_1, i].transform.position.x, xPos2 + plusX);
                }
                break;
            case 2:
                for (int i = 0; i < 3; i++)
                {
                    spikes[xIdx1_1, i].transform.position = new Vector2(spikes[xIdx1_1, i].transform.position.x, xPos3 + plusX);
                }
                break;
        }

        switch (xIdx1_2)
        {
            case 0:
                for (int i = 0; i < 3; i++)
                {
                    spikes[xIdx1_2, i].transform.position = new Vector2(spikes[xIdx1_2, i].transform.position.x, xPos1 + plusX);
                }
                break;
            case 1:
                for (int i = 0; i < 3; i++)
                {
                    spikes[xIdx1_2, i].transform.position = new Vector2(spikes[xIdx1_2, i].transform.position.x, xPos2 + plusX);
                }
                break;
            case 2:
                for (int i = 0; i < 3; i++)
                {
                    spikes[xIdx1_2, i].transform.position = new Vector2(spikes[xIdx1_2, i].transform.position.x, xPos3 + plusX);
                }
                break;
        }

        lights[xIdx1_1, xIdx2_1].color = Color.red;
        lights[xIdx1_2, xIdx2_2].color = Color.red;
    }

    void YYellowLight1() // y줄에 노란 불이 하나 들어오는 함수
    {
        yIdx = Random.Range(3, 6);
        yIdx2 = Random.Range(0, 2);

        lights[yIdx, yIdx2].color = new Color(255 / 255f, 215 / 255f, 0 / 255f);
    }

    void YYellowLight2() // y줄에 노란 불이 2개 들어오는 함수
    {
        do
        {
            yIdx1_1 = Random.Range(3, 6);
            yIdx1_2 = Random.Range(3, 6);
            yIdx2_1 = Random.Range(0, 2);
            yIdx2_2 = Random.Range(0, 2);
        } while (yIdx1_1 == yIdx1_2);

        lights[yIdx1_1, yIdx2_1].color = new Color(255 / 255f, 215 / 255f, 0 / 255f);
        lights[yIdx1_2, yIdx2_2].color = new Color(255 / 255f, 215 / 255f, 0 / 255f);
    }

    void YRedLight1() // y줄에 노란 불이 하나 들어오는 함수의 후속, 빨간 불로 바꾸고 그 줄에 가시가 올라오게 함
    {
        switch (yIdx - 3)
        {
            case 0:
                for (int i = 0; i < 3; i++)
                {
                    switch (i)
                    {
                        case 0:
                            spikes[i, yIdx - 3].transform.position = new Vector2(spikes[i, yIdx - 3].transform.position.x, xPos1 + plusX);
                            break;
                        case 1:
                            spikes[i, yIdx - 3].transform.position = new Vector2(spikes[i, yIdx - 3].transform.position.x, xPos2 + plusX);
                            break;
                        case 2:
                            spikes[i, yIdx - 3].transform.position = new Vector2(spikes[i, yIdx - 3].transform.position.x, xPos3 + plusX);
                            break;
                    }

                }
                break;
            case 1:
                for (int i = 0; i < 3; i++)
                {
                    switch (i)
                    {
                        case 0:
                            spikes[i, yIdx - 3].transform.position = new Vector2(spikes[i, yIdx - 3].transform.position.x, xPos1 + plusX);
                            break;
                        case 1:
                            spikes[i, yIdx - 3].transform.position = new Vector2(spikes[i, yIdx - 3].transform.position.x, xPos2 + plusX);
                            break;
                        case 2:
                            spikes[i, yIdx - 3].transform.position = new Vector2(spikes[i, yIdx - 3].transform.position.x, xPos3 + plusX);
                            break;
                    }

                }
                break;
            case 2:
                for (int i = 0; i < 3; i++)
                {
                    switch (i)
                    {
                        case 0:
                            spikes[i, yIdx - 3].transform.position = new Vector2(spikes[i, yIdx - 3].transform.position.x, xPos1 + plusX);
                            break;
                        case 1:
                            spikes[i, yIdx - 3].transform.position = new Vector2(spikes[i, yIdx - 3].transform.position.x, xPos2 + plusX);
                            break;
                        case 2:
                            spikes[i, yIdx - 3].transform.position = new Vector2(spikes[i, yIdx - 3].transform.position.x, xPos3 + plusX);
                            break;
                    }

                }
                break;
        }

        lights[yIdx, yIdx2].color = Color.red;
    }

    void YRedLight2() // y줄에 노란 불이 2개 들어오는 함수의 후속, 빨간 불로 바꾸고 그 줄들에 가시가 올라오게 함
    {
        switch (yIdx1_1 - 3)
        {
            case 0:
                for (int i = 0; i < 3; i++)
                {
                    switch(i)
                    {
                        case 0:
                            spikes[i, yIdx1_1 - 3].transform.position = new Vector2(spikes[i, yIdx1_1 - 3].transform.position.x, xPos1 + plusX);
                            break;
                        case 1:
                            spikes[i, yIdx1_1 - 3].transform.position = new Vector2(spikes[i, yIdx1_1 - 3].transform.position.x, xPos2 + plusX);
                            break;
                        case 2:
                            spikes[i, yIdx1_1 - 3].transform.position = new Vector2(spikes[i, yIdx1_1 - 3].transform.position.x, xPos3 + plusX);
                            break;
                    }
                    
                }
                break;
            case 1:
                for (int i = 0; i < 3; i++)
                {
                    switch (i)
                    {
                        case 0:
                            spikes[i, yIdx1_1 - 3].transform.position = new Vector2(spikes[i, yIdx1_1 - 3].transform.position.x, xPos1 + plusX);
                            break;
                        case 1:
                            spikes[i, yIdx1_1 - 3].transform.position = new Vector2(spikes[i, yIdx1_1 - 3].transform.position.x, xPos2 + plusX);
                            break;
                        case 2:
                            spikes[i, yIdx1_1 - 3].transform.position = new Vector2(spikes[i, yIdx1_1 - 3].transform.position.x, xPos3 + plusX);
                            break;
                    }

                }
                break;
            case 2:
                for (int i = 0; i < 3; i++)
                {
                    switch (i)
                    {
                        case 0:
                            spikes[i, yIdx1_1 - 3].transform.position = new Vector2(spikes[i, yIdx1_1 - 3].transform.position.x, xPos1 + plusX);
                            break;
                        case 1:
                            spikes[i, yIdx1_1 - 3].transform.position = new Vector2(spikes[i, yIdx1_1 - 3].transform.position.x, xPos2 + plusX);
                            break;
                        case 2:
                            spikes[i, yIdx1_1 - 3].transform.position = new Vector2(spikes[i, yIdx1_1 - 3].transform.position.x, xPos3 + plusX);
                            break;
                    }

                }
                break;
        }

        switch (yIdx1_2 - 3)
        {
            case 0:
                for (int i = 0; i < 3; i++)
                {
                    switch (i)
                    {
                        case 0:
                            spikes[i, yIdx1_2 - 3].transform.position = new Vector2(spikes[i, yIdx1_2 - 3].transform.position.x, xPos1 + plusX);
                            break;
                        case 1:
                            spikes[i, yIdx1_2 - 3].transform.position = new Vector2(spikes[i, yIdx1_2 - 3].transform.position.x, xPos2 + plusX);
                            break;
                        case 2:
                            spikes[i, yIdx1_2 - 3].transform.position = new Vector2(spikes[i, yIdx1_2 - 3].transform.position.x, xPos3 + plusX);
                            break;
                    }

                }
                break;
            case 1:
                for (int i = 0; i < 3; i++)
                {
                    switch (i)
                    {
                        case 0:
                            spikes[i, yIdx1_2 - 3].transform.position = new Vector2(spikes[i, yIdx1_2 - 3].transform.position.x, xPos1 + plusX);
                            break;
                        case 1:
                            spikes[i, yIdx1_2 - 3].transform.position = new Vector2(spikes[i, yIdx1_2 - 3].transform.position.x, xPos2 + plusX);
                            break;
                        case 2:
                            spikes[i, yIdx1_2 - 3].transform.position = new Vector2(spikes[i, yIdx1_2 - 3].transform.position.x, xPos3 + plusX);
                            break;
                    }

                }
                break;
            case 2:
                for (int i = 0; i < 3; i++)
                {
                    switch (i)
                    {
                        case 0:
                            spikes[i, yIdx1_2 - 3].transform.position = new Vector2(spikes[i, yIdx1_2 - 3].transform.position.x, xPos1 + plusX);
                            break;
                        case 1:
                            spikes[i, yIdx1_2 - 3].transform.position = new Vector2(spikes[i, yIdx1_2 - 3].transform.position.x, xPos2 + plusX);
                            break;
                        case 2:
                            spikes[i, yIdx1_2 - 3].transform.position = new Vector2(spikes[i, yIdx1_2 - 3].transform.position.x, xPos3 + plusX);
                            break;
                    }

                }
                break;
        }

        lights[yIdx1_1, yIdx2_1].color = Color.red;
        lights[yIdx1_2, yIdx2_2].color = Color.red;
    }

    void GreenLight() // 전부 초록불로 바꾸고 가시가 내려가게 함
    {
        for (int i = 0; i < 6; i++)
        {
            for (int j = 0; j < 2; j++)
            {
                lights[i, j].color = Color.green;
            }
        }

        for (int i = 0; i < 3; i++)
        {
            for (int j = 0; j < 3; j++)
            {
                switch (i)
                {
                    case 0:
                        spikes[i, j].transform.position = new Vector2(spikes[i, j].transform.position.x, xPos1);
                        break;
                    case 1:
                        spikes[i, j].transform.position = new Vector2(spikes[i, j].transform.position.x, xPos2);
                        break;
                    case 2:
                        spikes[i, j].transform.position = new Vector2(spikes[i, j].transform.position.x, xPos3);
                        break;
                }
            }
        }
    }
}
