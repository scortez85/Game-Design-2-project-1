﻿using UnityEngine;
using System.Collections;

public class menuTransfer : MonoBehaviour {
    public GameObject multiMenu,mainMenu,optionsMenu,netMenu,nameMenu;
    public Vector3 rotNorm = new Vector3(1, 1, 1);
    public Vector3 rotHide = new Vector3(0, 0, 0);
    public float timer;

    public string nextName;

    public void setNextMenu(string nextMenu)
    {
        nextName = nextMenu;
        timer = 2.5f;
    }
    public void Update()
    {
        if (timer > 0)
            timer -= 0.1f;

        if (timer<1 && nextName.Equals("Multi"))
        {
            mainMenu.transform.localScale = rotHide;
            netMenu.transform.localScale = rotHide;
            multiMenu.transform.localScale = rotNorm;
            nameMenu.transform.localScale = rotHide;
        }
        else if(timer<1 && nextName.Equals("Main"))
        {
            mainMenu.transform.localScale = rotNorm;
            multiMenu.transform.localScale = rotHide;
            optionsMenu.transform.localScale = rotHide;
            nameMenu.transform.localScale = rotHide;
        }
        else if ((timer<1 &&  nextName.Equals("Exit")))
        {
            Application.Quit();
        }
        else if ((timer<1 && nextName.Equals("Options")))
        {
            mainMenu.transform.localScale = rotHide;
            optionsMenu.transform.localScale = rotNorm;
            nameMenu.transform.localScale = rotHide;

        }
        else if ((timer<1 && nextName.Equals("Net")))
        {
            netMenu.transform.localScale = rotNorm;
            multiMenu.transform.localScale = rotHide;
            nameMenu.transform.localScale = rotHide;
        }
        else if ((timer<1 && nextName.Equals("Name")))
        {
            netMenu.transform.localScale = rotHide;
            multiMenu.transform.localScale = rotHide;
            nameMenu.transform.localScale = rotNorm;
            mainMenu.transform.localScale = rotHide;

        }



    }
  public void changeMenu(string menu)
    {
        timer = 10;
        if (menu.Equals("Multi"))
        {
                mainMenu.transform.localScale = rotHide;
                multiMenu.transform.localScale = rotNorm;
        }
        else if (menu.Equals("Main"))
        {
                mainMenu.transform.localScale = rotNorm;
                multiMenu.transform.localScale = rotHide;

        }

    }
}
