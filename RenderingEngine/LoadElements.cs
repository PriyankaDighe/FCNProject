using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using TMPro;
using System;
using System.Text.RegularExpressions;

public class LoadElements : MonoBehaviour
{ 
    public GameObject prefabBtn;
    public GameObject prefabMenuBar;
    private GameObject info;
    private Canvas canvas;
    GameObject prefabmenu;
    GameObject prefab1, prefab2, prefab3, prefab4, prefab5, prefab6, prefab7;
    private TextMeshProUGUI newText;
    private string[] titles;
    //public JSONReader obj;/// = new JSONReader();
    public static string url;
    public string url2;
  
    private string path;

    float x = 0.0f;//-3.62f;
    float y = 2.53f;
    float z = 89.75f;
    float h, h0 ;
    float w, w0;

    int index = 1;
    // Start is called before the first frame update
    void Start()
    {
        canvas = GameObject.FindGameObjectWithTag("MainCanvas").GetComponent<Canvas>();
    }

    public void getElements(JSONReader.Root info)
    {
        string text, color;
        float x1;
        float y1;
        double height;
        double width;
        int i = 1;
        var menu = info.main;
        var child = info.children;
        // Debug.Log("THIS IS CHILD: " + child);
        /******************** Menu Bar Properties *************************/
        text = "";
        x1 = menu.location.x; //JSONReader + Children
        y1 = menu.location.y/56;
        height = menu.size.height;
        width = menu.size.width;
        color = menu.bgcolor;
        CreateMenu(text, x1, y1, height, width, color);

        /******************** Btn1 HOME *************************/
        text = child.btn1.text;
        x1 = -child.btn1.location.x / 20;
        y1 = child.btn1.location.y / 56;
        height = child.btn1.size.height;
        width = child.btn1.size.width;
        // titles[i] = text;
        CreateBtns(text, x1, y1, height, width, i);
        i++;

        /******************** Btn2 ABOUT US *************************/
        text = child.btn2.text;
        x1 = -child.btn2.location.x / 69f;
        y1 = child.btn2.location.y / 56;
        height = child.btn2.size.height;
        width = child.btn2.size.width;
        CreateBtns(text, x1, y1, height, width, i);
        i++;

        /******************** Btn21 *************************/
        text = child.btn2.allbtns.btn21.inner_text;
        y1 = child.btn2.location.y / 71f;
        width = child.btn2.size.width;
        color = child.btn2.allbtns.btn21.bg_color;
        url = child.btn2.allbtns.btn21.href;
        Debug.Log("COLOR: " + color);
        CreateBtnsChildrens(text, x1, y1, height, width, color, url);

        /******************** Btn22 *************************/
        text = child.btn2.allbtns.btn22.inner_text;
        y1 = child.btn2.location.y / 97.1f;
        width = child.btn2.size.width;
        color = child.btn2.allbtns.btn22.bg_color;
        url2 = child.btn2.allbtns.btn22.href;
        //Debug.Log("URL: " + url);
        CreateBtnsChildrens(text, x1, y1, height, width, color, url);

        /******************** Btn3 ADMISSION *************************/
        text = child.btn3.text;
        x1 = -child.btn3.location.x / 231f;
        y1 = child.btn3.location.y / 56;
        height = child.btn3.size.height;
        width = child.btn3.size.width;
        CreateBtns(text, x1, y1, height, width, i);
        i++;

        /******************** Btn4 PEOPLE *************************/
        text = child.btn4.text;
        x1 = child.btn4.location.x /1400f;
        y1 = child.btn4.location.y / 56;
        height = child.btn4.size.height;
        width = child.btn4.size.width;
        CreateBtns(text, x1, y1, height, width, i);
        i++;

        /******************** Btn5 RESEARCH*************************/
        text = child.btn5.text;
        x1 = child.btn5.location.x / 270f;
        y1 = child.btn5.location.y / 56;
        height = child.btn5.size.height;
        width = child.btn5.size.width;
        CreateBtns(text, x1, y1, height, width, i);
        i++;

        /******************** Btn6 PROGRAMS*************************/
        text = child.btn6.text;
        x1 = child.btn6.location.x / 175f;
        y1 = child.btn6.location.y / 56;
        height = child.btn6.size.height;
        width = child.btn6.size.width;
        CreateBtns(text, x1, y1, height, width, i);
        i++;
    }

    public void CreateMenu(string text, float x1, float y1, double heigth, double width, string color)
    {
        canvas = GameObject.FindGameObjectWithTag("MainCanvas").GetComponent<Canvas>();

        prefabmenu = Instantiate(prefabMenuBar, canvas.transform, false);
        prefabmenu.transform.position = new Vector3(x, y1, z);
        prefabmenu.transform.localScale += new Vector3(2, 0, 1);
    }

    public void CreateBtns(string text, float x1, float y1, double heigth, double width, int i)
    {
        
        canvas = GameObject.FindGameObjectWithTag("MainCanvas").GetComponent<Canvas>();
        prefab1 = Instantiate(prefabBtn, canvas.transform, false);
        //prefab1.transform.SetParent(prefabBtn.transform);
        prefab1.transform.position = new Vector3(x1, y1, z - 0.2f);

        info = prefab1.transform.GetChild(0).gameObject;
        newText = info.GetComponent<TextMeshProUGUI>();
        newText.text = text;

        prefab1.AddComponent<OnHover>();
    }

    public void CreateBtnsChildrens(string text, float x1, float y1, double heigth, double width, string color, string url)
    {
        char[] delimiterChars = { ',', '(', ')' };
        string[] words = color.Split(delimiterChars);

        canvas = GameObject.FindGameObjectWithTag("MainCanvas").GetComponent<Canvas>();
        prefab2 = Instantiate(prefabBtn, canvas.transform, false);
        prefab2.transform.SetParent(prefab1.transform);

        prefab2.transform.position = new Vector3(x1 + 0.20f, y1, z - 0.2f);
        prefab2.gameObject.transform.localScale += new Vector3(.2f, .2f, 0.1f);
        prefab2.GetComponent<Renderer>().material.color = new Color(Int32.Parse(words[1])/255, Int32.Parse(words[2])/255, Int32.Parse(words[3])/255, 255);


        info = prefab2.transform.GetChild(0).gameObject;
        newText = info.GetComponent<TextMeshProUGUI>();
        newText.text = text;

        prefab2.SetActive(false);
        prefab2.AddComponent<OnHover>();
    }

    // Update is called once per frame
    void Update()
    {

    }
}
