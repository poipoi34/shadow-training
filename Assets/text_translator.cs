using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class text_translator : MonoBehaviour
{
    // Start is called before the first frame update
    public string text_francais;
    public string text_english;
    GameObject game_handler;
    string current_language = null;
    void Start()
    {
        int it = 0;
        game_handler = this.GetComponent<Transform>().parent.gameObject;
        while (game_handler.GetComponent<interface_handler>() == null && it < 10)
        {
            game_handler = game_handler.GetComponent<Transform>().parent.gameObject;
            it += 1;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (current_language != game_handler.GetComponent<interface_handler>().language)
        {
            current_language = game_handler.GetComponent<interface_handler>().language;
            if (current_language == "français")
                this.GetComponent<Text>().text = text_francais;
            if (current_language == "english")
                this.GetComponent<Text>().text = text_english;
        }
    }
}
