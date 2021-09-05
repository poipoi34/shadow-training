using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Globalization;

public class var_changer : MonoBehaviour
{
    public GameObject square_handler;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void change_fake_frequency()
    {
        float p = 0;
        if (this.GetComponent<InputField>().text.Contains("."))
            p = float.Parse(this.GetComponent<InputField>().text, NumberStyles.Any, CultureInfo.InvariantCulture);
        else
            p = float.Parse(this.GetComponent<InputField>().text);
        if (p > 1)
            p = 1;
        if (p < 0)
            p = 0;
        square_handler.GetComponent<lighting_up_squares>().fake_frequency = p;
    }

    public void change_defence_frequency()
    {
        float p = 0;
        if (this.GetComponent<InputField>().text.Contains("."))
            p = float.Parse(this.GetComponent<InputField>().text, NumberStyles.Any, CultureInfo.InvariantCulture);
        else
            p = float.Parse(this.GetComponent<InputField>().text);
        if (p > 1)
            p = 1;
        if (p < 0)
            p = 0;
        square_handler.GetComponent<lighting_up_squares>().defence_frequency = p;
    }

    public void change_delay_time()
    {
        float t = 0;
        if (this.GetComponent<InputField>().text.Contains("."))
            t = float.Parse(this.GetComponent<InputField>().text, NumberStyles.Any, CultureInfo.InvariantCulture);
        else
            t = float.Parse(this.GetComponent<InputField>().text);

        if (t < 0.5f)
            t = 0.5f;
        square_handler.GetComponent<lighting_up_squares>().global_time_delay = t;
        square_handler.GetComponent<lighting_up_squares>().fill_delay_list_with_coeff();
    }

    public void change_coeff(int i)
    {
        float a = 0;
        if (this.GetComponent<InputField>().text.Contains("."))
            a = float.Parse(this.GetComponent<InputField>().text, NumberStyles.Any, CultureInfo.InvariantCulture);
        else
            a = float.Parse(this.GetComponent<InputField>().text);

        if (a < 0)
            a = 0f;
        if (a > 50)
            a = 50f;
        if (0 <= i && i < 6)
            square_handler.GetComponent<lighting_up_squares>().coeff_list[i] = a;
            
    }

    public void change_max_successive_fake()
    {
        float a = 0;
        if (this.GetComponent<InputField>().text.Contains("."))
            a = float.Parse(this.GetComponent<InputField>().text, NumberStyles.Any, CultureInfo.InvariantCulture);
        else
            a = float.Parse(this.GetComponent<InputField>().text);
        square_handler.GetComponent<lighting_up_squares>().max_fake_roll = (int)a;
    }

    public void change_training_time()
    {
        float a = 0;
        if (this.GetComponent<InputField>().text.Contains("."))
            a = float.Parse(this.GetComponent<InputField>().text, NumberStyles.Any, CultureInfo.InvariantCulture);
        else
            a = float.Parse(this.GetComponent<InputField>().text);
        square_handler.GetComponent<lighting_up_squares>().training_time = (int)a;
    }

    public void change_deception_time()
    {
        float a = 0;
        if (this.GetComponent<InputField>().text.Contains("."))
            a = float.Parse(this.GetComponent<InputField>().text, NumberStyles.Any, CultureInfo.InvariantCulture);
        else
        a = float.Parse(this.GetComponent<InputField>().text);
        
        square_handler.GetComponent<lighting_up_squares>().deception_time = a;
    }

}
