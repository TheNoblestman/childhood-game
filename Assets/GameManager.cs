using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public GameObject pauseMenu;
    public static bool toggle1;
    public static bool toggle2;
    public static bool toggle3;
    public static bool toggle4;
    public static bool paused = false;
    private void Update(){
        if(Input.GetKeyDown(KeyCode.Escape)){
            if(paused){
                resume();
            }
            else{
                pauseMenu.SetActive(true);
                paused = true;
                Time.timeScale = 0;
            }
        }
    }
    public void resume(){
        pauseMenu.SetActive(false);
        paused = false;
        Time.timeScale =1;
    }
    public void Toggle_1(bool newVal){
        toggle1 = newVal;
    }
    public void Toggle_2(bool newVal){
        toggle2 = newVal;
    }
    public void Toggle_3(bool newVal){
        toggle3 = newVal;
    }
    public void Toggle_4(bool newVal){
        toggle4 = newVal;
    }
}
