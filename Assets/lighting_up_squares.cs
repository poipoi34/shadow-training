using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class lighting_up_squares : MonoBehaviour
{
    /*
    [HideInInspector] public float top_left_delay;
    [HideInInspector] public float top_right_delay;
    [HideInInspector] public float bot_left_delay;
    [HideInInspector] public float bot_right_delay;
    [HideInInspector] public float mid_left_delay;
    [HideInInspector] public float mid_right_delay;
    */

    [HideInInspector] public bool doing_shit = false;

    private float T_before_next;

    GameObject bot_right_square;
    GameObject bot_left_square;
    GameObject mid_left_square;
    GameObject mid_right_square;
    GameObject top_left_square;
    GameObject top_right_square;
    List<GameObject> square_list;
    List<float> delay_list;

    

    [HideInInspector] public List<float> coeff_list;
    public float global_time_delay;
    int fake_rolled = 0;
    public int max_fake_roll;
    public float fake_frequency;
    public float training_time;
    public float deception_time = 0.4f;

    [HideInInspector] public float training_time_left;
    GameObject last_faked_guy = null; 

    public float defence_frequency = 0.5f;

    Color red = new Color(1, 0, 0);
    Color blue = new Color(0, 0, 1);
    Color grey = new Color(0.5f, 0.5f, 0.5f);

    //useful Gameobjects link
    public GameObject game_handler;
    public GameObject training_time_left_text;

    //textboxes are stored here so that i can at start of execution fill the input boxes (didn't find better way)
    public GameObject input_delay_time;
    public GameObject input_fake_frequency;
    public GameObject input_defence_frequency;
    public GameObject coeff_inputs;
    public GameObject input_deception_time;



    // Start is called before the first frame update
    void Start()
    {

        top_left_square = this.transform.GetChild(0).gameObject;
        top_right_square = this.transform.GetChild(1).gameObject;
        mid_left_square = this.transform.GetChild(2).gameObject;
        mid_right_square = this.transform.GetChild(3).gameObject;
        bot_left_square = this.transform.GetChild(4).gameObject;
        bot_right_square = this.transform.GetChild(5).gameObject;

        square_list = new List<GameObject>();
        delay_list = new List<float>();

        square_list.Add(top_left_square);
        square_list.Add(top_right_square);
        square_list.Add(mid_left_square);
        square_list.Add(mid_right_square);
        square_list.Add(bot_left_square);
        square_list.Add(bot_right_square);

        coeff_list = new List<float>() { 1f, 1f, 1f, 1f, 1.3f, 1.3f };

        delay_list = new List<float>() { -1f, -1f, -1f, -1f, -1f, -1f };
        fill_delay_list_with_coeff();

        T_before_next = 2f;

        fill_input_boxes();
    }

    // Update is called once per frame
    void Update()
    {
        
        if (doing_shit)
        {
            if (training_time_left < 0)
                game_handler.GetComponent<interface_handler>().Set_mode("menu");

            training_time_left -= Time.deltaTime;
            training_time_left_text.GetComponent<Text>().text = ((int)training_time_left).ToString();
            T_before_next -= Time.deltaTime;
            if (T_before_next <= 0)
            {
                int i = Random.Range(0, 6);
                while (last_faked_guy != null && square_list[i] == last_faked_guy)
                    i = Random.Range(0, 6);
                bool fake_roll = Random.Range(0.0f, 1.0f) < fake_frequency && fake_rolled < max_fake_roll;
                bool defence_roll = Random.Range(0.0f, 1.0f) < defence_frequency;

                if (last_faked_guy != null){
                    last_faked_guy.GetComponent<light_up>().activate(deception_time*0.8f, grey);
                    last_faked_guy = null;
                }
                if (fake_roll)
                {
                    square_list[i].GetComponent<light_up>().activate(deception_time, red);
                    T_before_next += deception_time;
                    fake_rolled += 1;
                    last_faked_guy = square_list[i];
                }
                else if (defence_roll)
                {
                    square_list[i].GetComponent<light_up>().activate(1f, blue);
                    T_before_next = delay_list[i];
                }
                else//attack_roll
                {
                    square_list[i].GetComponent<light_up>().activate(1f, red);
                    T_before_next = delay_list[i];
                }
                if (!fake_roll && fake_rolled>0)
                    fake_rolled = 0;
            }
        }
    }

    void fill_input_boxes()
    {
        input_delay_time.GetComponent<InputField>().text = global_time_delay.ToString();
        input_fake_frequency.GetComponent<InputField>().text = fake_frequency.ToString();
        input_defence_frequency.GetComponent<InputField>().text = defence_frequency.ToString();
        for (int i = 0; i < 6; i++)
            coeff_inputs.GetComponent<Transform>().GetChild(i).GetComponent<InputField>().text = coeff_list[i].ToString();
        input_deception_time.GetComponent<InputField>().text = deception_time.ToString();
    }

    public void fill_delay_list_with_coeff()
    {
        for (int i = 0; i < 6; i++)
            delay_list[i] = coeff_list[i] * global_time_delay;
    }

    public void set_fake_frequency(float p)
    {
        fake_frequency = p;
    }

    public void set_defence_frequency(float p)
    {
        defence_frequency = p;
    }

    public void set_delay_time(int i,float t)
    {
        float t2 = t * coeff_list[i];
        if (t2 < 0.5f)
            t2 = 0.5f;
        delay_list[i] = t2;
    }
   
}
