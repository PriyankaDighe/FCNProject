using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnHover : MonoBehaviour
{
    public bool condition = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }
    private void OnMouseEnter()
    {
        JSONReader[] children;
        children = GetComponentsInChildren<JSONReader>();
        for (int i = 1; i < transform.childCount; ++i)
        {
            if (!condition && i <= transform.childCount)
            {
                transform.GetChild(i).gameObject.SetActive(true); // or false
                //condition = true;
            }
            else
            {
                transform.GetChild(i).gameObject.SetActive(false); // or false
                //condition = false;
            }
            
        }
        if (condition)
            condition = false;
        else
            condition = true;

    }

   /* private void OnMouseExit()
    {
        for (int i = 1; i < transform.childCount; ++i)
        {
            Debug.Log("testing " + transform.gameObject);
            if(transform.gameObject != transform.GetChild(i).gameObject)
                transform.GetChild(i).gameObject.SetActive(false); // or false
        }
    }*/

    void OnMouseDown()
    {
        Application.OpenURL(LoadElements.url);
        //Application.OpenURL(url);
    }
    // Update is called once per frame
    void Update()
    {
        
    }
    
}
