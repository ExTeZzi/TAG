using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    public GameObject ProtoButton;
    public Transform Sakura;
    GameObject[,] cells = new GameObject[4, 4];
    GameObject[,] perfect_map = new GameObject[4, 4];
    public Text h;
    public Text w;
    public Text num;
    int h0, w0, hi, wj;
    public GameObject WinPanel;
    // Start is called before the first frame update
    void Start()
    {
        Create_Map();
        Rand_move();
    }

    // Update is called once per frame
    void Update()
    {
        Recreate();
        Victory();
    }
    public void Create_Map()
    {
        System.Random rnd = new System.Random();
        //for(int i = 0; i < 4; i++)
        //{
        //    for (int j = 0; j < 4; j++)
        //   {
        //        //ôîíîâàÿ êàðòà
        //        perfect_map[i, j] = Instantiate(ProtoButton);
        //        perfect_map[i, j].transform.SetParent(Sakura);
        //        perfect_map[i, j].transform.localPosition = new Vector3(j * 205 - 307, i * (-205) + 307, 1);
        //        perfect_map[i, j].GetComponentInChildren<Text>().text = (i * 4 + j + 1).ToString();
        //        if (perfect_map[i, j].GetComponentInChildren<Text>().text == "16")
        //        {
        //            perfect_map[i, j].GetComponentInChildren<Text>().text = "0";
        //        }
        //        perfect_map[i, j].GetComponentInChildren<Text>().color = new Vector4(0f, 0f, 0f, 0.2f);
        //        perfect_map[i, j].GetComponent<Image>().color = new Vector4(1f, 1f, 1f, 0.2f);
        //    }
        // }
        for (int i = 0; i < 4; i++)
        {
            for (int j = 0; j < 4; j++)
            {
                //îñíîâíàÿ êàðòà
                cells[i, j] = Instantiate(ProtoButton);
                cells[i, j].transform.SetParent(Sakura);
                cells[i, j].transform.localPosition = new Vector3(j * 205 - 307, i * (-205) + 307, 1);
                cells[i, j].transform.localScale = new Vector3(1, 1, 1);
                cells[i, j].GetComponentInChildren<Text>().text = (i * 4 + j).ToString();
                if (cells[i, j].GetComponentInChildren<Text>().text == "0")
                {
                    cells[i, j].GetComponentInChildren<Text>().color = new Vector4(1f, 1f, 1f, 0f);
                    cells[i, j].GetComponent<Image>().color = new Vector4(1f, 1f, 1f, 0f);
                    cells[i, j].GetComponent<Button>().interactable = false;
                }
                else
                {
                    //cells[i, j].GetComponent<Button>().interactable = false;
                }
            }
        }
    }
    public int Search_0_h()
    {
        int h = 0;
        for (int i = 0; i < 4; i++)
        {
            for (int j = 0; j < 4; j++)
            {
                if (cells[i, j].GetComponentInChildren<Text>().text == "0")
                {
                    h = i;
                }
            }
        }
        return h;
    }
    public int Search_0_w()
    {
        int w = 0;
        for (int i = 0; i < 4; i++)
        {
            for (int j = 0; j < 4; j++)
            {
                if (cells[i, j].GetComponentInChildren<Text>().text == "0")
                {
                    w = j;
                }
            }
        }
        return w;
    }
    public void move()
    {
        for (int i = 0; i < 4; i++)
        {
            for (int j = 0; j < 4; j++)
            {
                if (cells[i, j].GetComponentInChildren<Text>().text == 0.ToString())
                {
                    h0 = i;
                    w0 = j;
                }
                if (cells[i, j].GetComponentInChildren<Text>().text == num.GetComponent<Text>().text)
                {
                    hi = i;
                    wj = j;
                }
            }
        }
        if ((h0 == hi && (w0 == wj + 1 || w0 == wj - 1)) || (w0 == wj && (h0 == hi + 1 || h0 == hi - 1)))
        {
            string trans = cells[h0, w0].GetComponentInChildren<Text>().text;
            cells[h0, w0].GetComponentInChildren<Text>().text = num.GetComponent<Text>().text;
            cells[hi, wj].GetComponentInChildren<Text>().text = trans;
        }
    }
    public void Recreate()
    {
        for (int i = 0; i < 4; i++)
        {
            for (int j = 0; j < 4; j++)
            {
                if (cells[i, j].GetComponentInChildren<Text>().text == "0")
                {
                    cells[i, j].GetComponentInChildren<Text>().color = new Vector4(0.5f, 0.1f, 0f, 0.1f);
                    cells[i, j].GetComponent<Image>().color = new Vector4(1.0f, 0.2f, 0f, 0.0f);
                    cells[i, j].GetComponent<Button>().interactable = false;
                }
                else
                {
                    cells[i, j].GetComponentInChildren<Text>().color = new Vector4(1f, 1f, 1f, 0.80f);
                    cells[i, j].GetComponent<Image>().color = new Vector4(1f, 0f, 1f, 0.70f);
                    cells[i, j].GetComponent<Button>().interactable = true;
                }
            }
        }
    }
    public void Rand_move()
    {
        System.Random rnd = new System.Random();
        for (int r = 0; r < 500; r++)
        {
            hi = rnd.Next(0, 4);
            wj = rnd.Next(0, 4);
            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    if (cells[i, j].GetComponentInChildren<Text>().text == 0.ToString())
                    {
                        h0 = i;
                        w0 = j;
                    }
                }
            }
            if ((h0 == hi && (w0 == wj + 1 || w0 == wj - 1)) || (w0 == wj && (h0 == hi + 1 || h0 == hi - 1)))
            {
                string trans = cells[h0, w0].GetComponentInChildren<Text>().text;
                cells[h0, w0].GetComponentInChildren<Text>().text = cells[hi, wj].GetComponentInChildren<Text>().text;
                cells[hi, wj].GetComponentInChildren<Text>().text = trans;
            }
        }

    }

    public void Victory()
    {
        if (cells[0, 0].GetComponentInChildren<Text>().text == 1.ToString() &&
            cells[0, 1].GetComponentInChildren<Text>().text == 2.ToString() &&
            cells[0, 2].GetComponentInChildren<Text>().text == 3.ToString() &&
            cells[0, 3].GetComponentInChildren<Text>().text == 4.ToString() &&
            cells[1, 0].GetComponentInChildren<Text>().text == 5.ToString() &&
            cells[1, 1].GetComponentInChildren<Text>().text == 6.ToString() &&
            cells[1, 2].GetComponentInChildren<Text>().text == 7.ToString() &&
            cells[1, 3].GetComponentInChildren<Text>().text == 8.ToString() &&
            cells[2, 0].GetComponentInChildren<Text>().text == 9.ToString() &&
            cells[2, 1].GetComponentInChildren<Text>().text == 10.ToString() &&
            cells[2, 2].GetComponentInChildren<Text>().text == 11.ToString() &&
            cells[2, 3].GetComponentInChildren<Text>().text == 12.ToString() &&
            cells[3, 0].GetComponentInChildren<Text>().text == 13.ToString() &&
            cells[3, 1].GetComponentInChildren<Text>().text == 14.ToString() &&
            cells[3, 2].GetComponentInChildren<Text>().text == 15.ToString())
        { 
            WinPanel.SetActive(true);
        }
    }
    public void Restart()
    {
        Rand_move();
        WinPanel.SetActive(false);
    }

}
