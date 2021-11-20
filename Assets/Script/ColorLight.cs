using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorLight : MonoBehaviour
{
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

    private SpriteRenderer[,] lights = new SpriteRenderer[6, 2];

    public GameObject spike1;
    public GameObject spike2;
    public GameObject spike3;
    public GameObject spike4;
    public GameObject spike5;
    public GameObject spike6;
    public GameObject spike7;
    public GameObject spike8;
    public GameObject spike9;

    private GameObject[,] spikes = new GameObject[3, 3];

    private int xIdx;
    private int xIdx2;
    private int yIdx;
    private int yIdx2;

    private int xIdx1_1;
    private int xIdx1_2;
    private int xIdx2_1;
    private int xIdx2_2;
    private int yIdx1_1;
    private int yIdx1_2;
    private int yIdx2_1;
    private int yIdx2_2;

    private float yellowTime = 1f;
    private float redTime = 4.5f;

    private float xPos1 = 4.6f;
    private float xPos2 = 0.6f;
    private float xPos3 = -3.4f;

    private float plusX = 0.8f;

    void Start()
    {
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

        spikes[0, 0] = spike1;
        spikes[0, 1] = spike2;
        spikes[0, 2] = spike3;
        spikes[1, 0] = spike4;
        spikes[1, 1] = spike5;
        spikes[1, 2] = spike6;
        spikes[2, 0] = spike7;
        spikes[2, 1] = spike8;
        spikes[2, 2] = spike9;

        GreenLight();

        InvokeRepeating("RandomLights", 2f, 10f);
    }

    void Update()
    {

    }

    void RandomLights()
    {
        int xMany = Random.Range(1, 3);
        int yMany = Random.Range(1, 3);

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

        Invoke("GreenLight", redTime + 3f);
    }

    void XYellowLight1()
    {
        xIdx = Random.Range(0, 3);
        xIdx2 = Random.Range(0, 2);

        lights[xIdx, xIdx2].color = Color.yellow;
    }

    void XYellowLight2()
    {
        do
        {
            xIdx1_1 = Random.Range(0, 3);
            xIdx1_2 = Random.Range(0, 3);
            xIdx2_1 = Random.Range(0, 2);
            xIdx2_2 = Random.Range(0, 2);
        } while (xIdx1_1 == xIdx1_2);


        lights[xIdx1_1, xIdx2_1].color = Color.yellow;
        lights[xIdx1_2, xIdx2_2].color = Color.yellow;
    }

    void XRedLight1()
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

    void XRedLight2()
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

    void YYellowLight1()
    {
        yIdx = Random.Range(3, 6);
        yIdx2 = Random.Range(0, 2);

        lights[yIdx, yIdx2].color = Color.yellow;
    }

    void YYellowLight2()
    {
        do
        {
            yIdx1_1 = Random.Range(3, 6);
            yIdx1_2 = Random.Range(3, 6);
            yIdx2_1 = Random.Range(0, 2);
            yIdx2_2 = Random.Range(0, 2);
        } while (yIdx1_1 == yIdx1_2);

        lights[yIdx1_1, yIdx2_1].color = Color.yellow;
        lights[yIdx1_2, yIdx2_2].color = Color.yellow;
    }

    void YRedLight1()
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

    void YRedLight2()
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

    void GreenLight()
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
