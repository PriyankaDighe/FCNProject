using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using Newtonsoft.Json;
//using System.Json;

public class JSONReader : MonoBehaviour
{
    private string path;
    private string jsonString;
    public LoadElements sendinfo;

    [System.Serializable]
    public class Location
    {
        public int x;
        public int y;
    }
    [System.Serializable]
    public class Size
    {
        public double height;
        public double width;
    }
    [System.Serializable]
    public class Main
    {
        public string identifier;
        public Location location;
        public Size size;
        public string bgcolor;
    }
    [System.Serializable]
    public class Btn1
    {
        public string text;
        public Location location;
        public Size size;
        public string fontsize;
        public string href;
        public string textcolor;
        public string bgcolor;
    }
   
    [System.Serializable]
    public class Btn21
    {
        public string inner_text;
        public string elem_color;
        public string bg_color;
        public string font_size;
        public string href;
    }

    [System.Serializable]
    public class Btn22
    {
        public string inner_text;
        public string elem_color;
        public string bg_color;
        public string font_size;
        public string href;
    }

    [System.Serializable]
    public class Btn23
    {
        public string inner_text;
        public string elem_color;
        public string bg_color;
        public string font_size;
        public string href;
    }

    [System.Serializable]
    public class Btn24
    {
        public string inner_text;
        public string elem_color;
        public string bg_color;
        public string font_size;
        public string href;
    }

    [System.Serializable]
    public class Btn25
    {
        public string inner_text;
        public string elem_color;
        public string bg_color;
        public string font_size;
        public string href;
    }

    [System.Serializable]
    public class Btn26
    {
        public string inner_text;
        public string elem_color;
        public string bg_color; 
        public string font_size; 
        public string href;
    }

    [System.Serializable]
    public class Btn27
    {
        public string inner_text; 
        public string elem_color; 
        public string bg_color; 
        public string font_size; 
        public string href; 
    }

    [System.Serializable]
    public class Btn28
    {
        public string inner_text; 
        public string elem_color; 
        public string bg_color; 
        public string font_size; 
        public string href;
    }

    [System.Serializable]
    public class Btn29
    {
        public string inner_text; 
        public string elem_color; 
        public string bg_color; 
        public string font_size; 
        public string href; 
    }

    [System.Serializable]
    public class Allbtns
    {
        public Btn21 btn21; 
        public Btn22 btn22; 
        public Btn23 btn23; 
        public Btn24 btn24; 
        public Btn25 btn25; 
        public Btn26 btn26; 
        public Btn27 btn27; 
        public Btn28 btn28; 
        public Btn29 btn29; 
        /*public Btn31 btn31 { get; set; }
        public Btn32 btn32 { get; set; }
        public Btn33 btn33 { get; set; }
        public Btn34 btn34 { get; set; }
        public Btn35 btn35 { get; set; }
        public Btn36 btn36 { get; set; }
        public Btn37 btn37 { get; set; }
        public Btn41 btn41 { get; set; }
        public Btn42 btn42 { get; set; }
        public Btn43 btn43 { get; set; }
        public Btn44 btn44 { get; set; }
        public Btn45 btn45 { get; set; }
        public Btn46 btn46 { get; set; }
        public Btn51 btn51 { get; set; }
        public Btn52 btn52 { get; set; }
        public Btn61 btn61 { get; set; }
        public Btn62 btn62 { get; set; }
        public Btn63 btn63 { get; set; }
        public Btn64 btn64 { get; set; }*/
    }

    [System.Serializable]
    public class Btn2
    {
        public string text; 
        public Location location; 
        public Size size; 
        public string fontsize; 
        public string href; 
        public string textcolor; 
        public string bgcolor; 
        public Allbtns allbtns; 
    }

    [System.Serializable]
    public class Btn3
    {
        public string text; 
        public Location location; 
        public Size size; 
        public string fontsize; 
        public string href; 
        public string textcolor; 
        public string bgcolor; 
        public Allbtns allbtns; 
    }

    [System.Serializable]
    public class Btn4
    {
        public string text; 
        public Location location; 
        public Size size; 
        public string fontsize; 
        public string href; 
        public string textcolor; 
        public string bgcolor; 
        public Allbtns allbtns; 
    }

    [System.Serializable]
    public class Btn5
    {
        public string text; 
        public Location location; 
        public Size size; 
        public string fontsize; 
        public string href; 
        public string textcolor; 
        public string bgcolor; 
        public Allbtns allbtns; 
    }

    [System.Serializable]
    public class Btn6
    {
        public string text; 
        public Location location; 
        public Size size; 
        public string fontsize; 
        public string href; 
        public string textcolor; 
        public string bgcolor; 
        public Allbtns allbtns; 
    }

    [System.Serializable]
    public class Btn7
    {
        public string text;  
        public Location location;  
        public Size size;  
        public string fontsize;  
        public string href;  
        public string textcolor;  
        public string bgcolor;  
        public Allbtns allbtns;  
    }

    [System.Serializable]
    public class Children
    {
        public Btn1 btn1;  
        public Btn2 btn2;  
        public Btn3 btn3;  
        public Btn4 btn4;  
        public Btn5 btn5;  
        public Btn6 btn6;  
        public Btn7 btn7;  
    }

    [System.Serializable]
    public class Root
    {
        public Main main;  
        public Children children;
    }
  
    public Root myMain = new Root();

    public object JSON { get; private set; }

    // Start is called before the first frame update
    void Start()
    {
        path = "C:/Users/Doris/FCN_Final/Assets/Resources/webelements.json";
        //path = "/Users/dorisgutierrezrosales/FCN_Final/Assets/Resources/webelements.json";
        loadElements(path);
    }

    public void loadElements(string path)
    {
        jsonString = File.ReadAllText(path);
        myMain = JsonConvert.DeserializeObject<Root>(jsonString);
       
        var deserializedObject = JsonConvert.DeserializeObject<Dictionary<object, object>>(jsonString);      
      
        sendinfo.getElements(myMain);

    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
