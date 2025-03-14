using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable] // ƒл€ отображени€ класса в unity
public class Imagess_15
{
    public Sprite LevelLogo; // Ћого картинки дл€ меню
    public Sprite[] details = new Sprite[16]; // ћассим из 16 деталей(картинки)
}
public class Manager_15 : MonoBehaviour
{
    public GameObject ProtoButton;
    public GameObject Samurai;
    GameObject[,] cells = new GameObject[4, 4];
    public Transform SakuraPanel;
    public Transform MenuPanel;
    public Text TransNum;
    public Text LevelNum;
    public int LevelNum_int;
    public Imagess_15[] levels = new Imagess_15[5]; // массив 6 уровней картинок
    //Sprite[] current_image = new Sprite [16];
    public GameObject[] LevelButtons = new GameObject[5]; // массив кнопок выбора уровней
    public GameObject LevelButton; // прототип кнопки выбора уровн€
    bool Game_started = false;

    void Start()
    {
        CreateMenu();
        //Generate_Map();
        //Random_Move();
    }

    // Update is called once per frame
    void Update()
    {
        if (Game_started)
        {
            MapUpdate();
            Victory();
        }
    }
    
    public void CreateMenu()
    {
        for (int i = 0; i < levels.Length; i++)
        {
            LevelButtons[i] = Instantiate(LevelButton);
            LevelButtons[i].transform.SetParent(MenuPanel);
            LevelButtons[i].transform.localPosition = new Vector3((i%2) * 430 - 220, (i/2) * (-420) + 450, 1);
            LevelButtons[i].transform.localScale = new Vector3(1, 1, 1);
            LevelButtons[i].GetComponent<Image>().sprite = levels[i].LevelLogo;
            LevelButtons[i].GetComponentInChildren<Text>().text = (i).ToString();
        }
    }

    public void Generate_Map()
    {
        MenuPanel.gameObject.SetActive(false);
        LevelNum_int = System.Convert.ToInt32(LevelNum.text);
        
        for (int i = 0; i < cells.GetLength(0); i++)
        {
            for (int j = 0; j < cells.GetLength(1); j++)
            {
                cells[i, j] = Instantiate(ProtoButton);
                cells[i, j].transform.SetParent(SakuraPanel);
                cells[i, j].transform.localPosition = new Vector3(j * 205 - 300, i * (-205) + 350, 1);
                cells[i, j].transform.localScale = new Vector3(1, 1, 1);
                cells[i, j].GetComponentInChildren<Text>().text = (i * 4 + j + 1).ToString();
                cells[i, j].GetComponent<Image>().sprite = levels[LevelNum_int].details[i * 4 + j];
                //cells[i, j].GetComponent<Image>().sprite = kartinki[i*4+j];
            }
        }  
        Game_started = true;
    }
    public void MapUpdate()
    {
        for (int i = 0; i < cells.GetLength(0); i++)
        {
            for (int j = 0; j < cells.GetLength(1); j++)
            {
                if(cells[i, j].GetComponentInChildren<Text>().text == 16.ToString())
                {
                    cells[i, j].GetComponent<Button>().interactable = false;
                    cells[i, j].GetComponentInChildren<Text>().color = new Vector4(1, 1, 1, 0.0f);
                }
                else
                {
                    cells[i, j].GetComponent<Button>().interactable = true;
                    cells[i, j].GetComponentInChildren<Text>().color = new Vector4(0, 0.0f, 0.0f, 0.5f);
                }
                
            }
        }
    }
    public void Move()
    {
        string Trans = TransNum.GetComponent<Text>().text;
        
        int h16 = 0, w16 = 0, hi = 0, wj = 0;
        for (int i = 0; i < cells.GetLength(0); i++)
        {
            for (int j = 0; j < cells.GetLength(1); j++)
            {
                if (cells[i, j].GetComponentInChildren<Text>().text == Trans)
                {
                    hi = i;
                    wj = j;
                }
                if (cells[i, j].GetComponentInChildren<Text>().text == 16.ToString())
                {
                    h16 = i;
                    w16 = j;
                }
            }
        }
        Sprite iTrans = cells[hi, wj].GetComponent<Image>().sprite;
        if ((hi == h16 && (wj == (w16+1) || wj == (w16 - 1))) || (wj == w16 && ((hi == (h16 - 1)) || (hi == (h16+1)))))
        {
            cells[hi, wj].GetComponentInChildren<Text>().text = 16.ToString();
            cells[h16, w16].GetComponentInChildren<Text>().text = Trans;
            cells[hi, wj].GetComponent<Image>().sprite = cells[h16, w16].GetComponent<Image>().sprite;
            cells[h16, w16].GetComponent<Image>().sprite = iTrans;
        }
        
    }

    public void Random_Move()
    {
        int h16 = 0, w16 = 0, hi = 0, wj = 0;
        for(int k = 0; k < 1000; k++)
        {
            for (int i = 0; i < cells.GetLength(0); i++)
            {
                for (int j = 0; j < cells.GetLength(1); j++)
                {
                    if (cells[i, j].GetComponentInChildren<Text>().text == 16.ToString())
                    {
                        h16 = i;
                        w16 = j;
                    }
                }
            }
            hi = Random.Range(0, 4);
            wj = Random.Range(0, 4);
            string Trans = cells[hi, wj].GetComponentInChildren<Text>().text;
            Sprite iTrans = cells[hi, wj].GetComponent<Image>().sprite;
            if ((hi == h16 && (wj == (w16 + 1) || wj == (w16 - 1))) || (wj == w16 && ((hi == (h16 - 1)) || (hi == (h16 + 1)))))
            {
                cells[hi, wj].GetComponentInChildren<Text>().text = 16.ToString();
                cells[h16, w16].GetComponentInChildren<Text>().text = Trans;
                cells[hi, wj].GetComponent<Image>().sprite = cells[h16, w16].GetComponent<Image>().sprite;
                cells[h16, w16].GetComponent<Image>().sprite = iTrans;
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
            Samurai.SetActive(true);
        }
    }
    public void Restart()
    {
        Random_Move();
        Samurai.SetActive(false);
    }

}
