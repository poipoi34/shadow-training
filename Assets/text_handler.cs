using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class text_handler : MonoBehaviour
{

    public GameObject language_changer;
    public List<GameObject> texts;
    public List<string> languages;
    private Dictionary< string,Dictionary<string, Dictionary<string, string> > > translator;
    private string c_language1;
    private string c_language2;
    // Start is called before the first frame update
    void Start()
    {
        languages = new List<string>() { "english", "français" };
        translator = new Dictionary<string, Dictionary<string, Dictionary<string, string>>>();
        foreach (string l1 in languages) {
            translator.Add(l1, new Dictionary<string, Dictionary<string, string>>());
            foreach (string l2 in languages)
                if (l1 != l2)
                    translator[l1].Add(l2, new Dictionary<string, string>());
        }

        c_language1 =  "english";
        c_language2 = "français";
        add_translation("<- Back", "<- Retour");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void change_language()
    {
        int i_language = language_changer.GetComponent<Dropdown>().value;
        if (i_language == 0)
        {

        }
    }

    void add_translation(string language1,string language2,string expression1,string expression2)
    {
        translator[language1][language2][expression1] = expression2;
        translator[language2][language1][expression2] = expression1;


    }

    void add_translation(string exp1,string exp2)
    {
        add_translation(c_language1, c_language2, exp1, exp2);
    }
}
