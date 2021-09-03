using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class interface_handler : MonoBehaviour
{
    // Start is called before the first frame update
    //3 mode: config,game, and menu
    public GameObject game;
    public GameObject menu;
    public GameObject config;
    public GameObject coeff_config;
    public GameObject info;

    public GameObject language_handler;

    public string language;

    public GameObject square_handler;
    [HideInInspector] public string mode;
    Dictionary<string, GameObject> interfaces;


    void Start()
    {
        mode = null;
        
        interfaces = new Dictionary<string,GameObject>();

        interfaces.Add("menu", menu);

        interfaces.Add("config",config);

        interfaces.Add("game",game);

        interfaces.Add("coeff config",coeff_config);

        interfaces.Add("info", info);

        Set_mode("menu");


    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Set_mode(string p_mode)
    {
        
        if (mode != null)
        {
            interfaces[mode].SetActive(false);
            if (mode == "game")
                square_handler.GetComponent<lighting_up_squares>().doing_shit = false;
            if (mode == "info")
                square_handler.SetActive(true);
                
                
        }
        mode = p_mode;

        interfaces[mode].SetActive(true);

        if (mode == "game")
        {
            square_handler.GetComponent<lighting_up_squares>().doing_shit = true;
            square_handler.GetComponent<lighting_up_squares>().training_time_left = square_handler.GetComponent<lighting_up_squares>().training_time;
        }

        if (mode == "menu" || mode == "config")
            language_handler.SetActive(true);
        else
            language_handler.SetActive(false);
        if (mode == "info")
            square_handler.SetActive(false);


        /*
        if (mode == "game" || mode == "menu")
            change_alpha_squares(1f); 
        else
            change_alpha_squares(0.5f);
        */
    }

    private void change_alpha_squares(float a)
    {
        for (int i = 0; i < 6; i++)
        {
            GameObject square = square_handler.GetComponent<Transform>().GetChild(i).gameObject;
            float r = square.GetComponent<Image>().color.r;
            float g = square.GetComponent<Image>().color.g;
            float b = square.GetComponent<Image>().color.b;
            square.GetComponent<Image>().color = new Color(r,g,b,a);
        }
    }
}
