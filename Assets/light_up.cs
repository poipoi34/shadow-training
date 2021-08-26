using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class light_up : MonoBehaviour
{
    [HideInInspector]
    public float activation;

    public Color deactivated_color;
 
    // Start is called before the first frame update
    void Start()
    {
        activation = 0;
        deactivated_color = new Color(0, 255, 0);
        this.GetComponent<Image>().color = deactivated_color;
    }

    // Update is called once per frame
    void Update()
    {
        if (activation < 0)
            deactivate();
        if (activation > 0)
            activation -= Time.deltaTime;
    }

    public void activate(float time,Color color)
    {
        activation = time;
        this.GetComponent<Image>().color = color;
    }

    void deactivate()
    {
        this.GetComponent<Image>().color = deactivated_color;
    }

}
