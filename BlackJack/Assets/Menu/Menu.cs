using UnityEngine;
using System.Collections;

public class Menu : MonoBehaviour {

    public int window;
	void Start () {
        window = 1;
	}
    void OnGUI() {
        GUI.BeginGroup(new Rect(Screen.width / 2 - 100, Screen.height / 2 - 100, 200, 200));
        if (window == 1)
        {
            if (GUI.Button(new Rect(10, 30, 180, 30), "Играть"))
            {
                window = 2;
                Application.LoadLevel(1);
            }
            if (GUI.Button(new Rect(10, 70, 180, 30), "Об Авторах"))
            {
                window = 3;
            }
            if (GUI.Button(new Rect(10, 110, 180, 30), "Об Игре"))
            {
                window = 4;
            }
            if (GUI.Button(new Rect(10, 150, 180, 30), "Выход"))
            {
                window = 5;
            }
        }
        
        if (window == 3)
        {
            GUI.Label(new Rect(50, 10, 180, 30), "Об Авторах");
            GUI.Label(new Rect(10, 40, 180, 40), "Информация об авторах");
            if (GUI.Button(new Rect(10, 160, 180, 30), "Назад"))
            {
                window = 1;
            }
        }


        if (window == 4)
        {
            GUI.Label(new Rect(50, 10, 180, 30), "Об Игре");
            GUI.Label(new Rect(10, 40, 180, 40), "Правила игры");
            if (GUI.Button(new Rect(10, 90, 180, 30), "Назад"))
            {
                window = 1;
            }
        }



        if (window == 5)
        {
            GUI.Label(new Rect(50, 10, 180, 30), "Вы уже выходите?");
            if (GUI.Button(new Rect(10, 40, 180, 30), "Да"))
            {
                Application.Quit();
            }
            if (GUI.Button(new Rect(10, 80, 180, 30), "Нет"))
            {
                window = 1;
            }
        } 
        GUI.EndGroup(); 
    }
	
}
