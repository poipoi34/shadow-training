using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class language_changer : MonoBehaviour
{
    // Start is called before the first frame update
    [HideInInspector] public GameObject game_handler;
    List<string> languages = new List<string>() {"english","français" };
    void Start()
    {
        int it = 0;
        game_handler = this.GetComponent<Transform>().parent.gameObject;
        while (game_handler.GetComponent<interface_handler>() == null && it < 10){
            game_handler = game_handler.GetComponent<Transform>().parent.gameObject;
            it += 1;
        }
            
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void change_language()
    {
        game_handler.GetComponent<interface_handler>().language = languages[this.GetComponent<Dropdown>().value];
    }
}
