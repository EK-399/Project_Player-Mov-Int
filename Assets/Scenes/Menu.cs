using NUnit.Framework;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Menu : MonoBehaviour
{
    public Image[] sprites; //Fixed
    public List<Image> spritesList; //Can be changed at runtime. Add/Remove

    public Image image;
    public Color[] colors;
    int colorIndex = -1;

    //ARRAY / LIST = Group of variables
    //FOR EACH / FOR LOOP = Itreate through a list or arry

    //SYNTAX
    // = Setting something
    // - Minus
    // + Add
    // * Multiply
    // / Divide

    // && AND (Two things have to be true.)
    // || (One OR the other thing has to be true.)

    // ! NOT THE SAME
    // == SAME AS

    private void Start()
    {

        //foreach(var sprite in sprites)
       //{
            //preform the action
       //      sprite.color = Color.purple;
       //}

        //for (int i = 0; i < sprites.Length; i++)
        //{
        //    sprites[i].color = Color.blue;
        //}
    }

    public void Changecolor()
    {
        //color index to go up by 1 number

        if(colorIndex == colors.Length - 1)
        {
            colorIndex = 0;
        }
        else
        {
            colorIndex++; // + 1
        }

        image.color = colors[colorIndex];
    }

public void ChangeScene(string sceneName) //void + () = function
    {
        SceneManager.LoadScene(sceneName);
    }
    
    public void QuitGame()
    {
        Debug.Log("Quitting Game!");
        Application.Quit(); //Closes the build
    }
}
