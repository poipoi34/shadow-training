using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class boundary_controller : MonoBehaviour
{
    // Start is called before the first frame update
    private float y_lowest;
    private float y_highest;
    void Start()
    {
        y_lowest = 0;
        Transform transform = this.GetComponent<Transform>();
        Transform last_child = transform.GetChild(transform.childCount - 1);

        y_highest = -370 - last_child.transform.localPosition.y + last_child.GetComponent<RectTransform>().rect.height;
        print(y_highest);
    }

    // Update is called once per frame
    void Update()
    {
        RectTransform transform = this.GetComponent<RectTransform>();
        if (transform.localPosition.y < y_lowest)
            transform.localPosition = new Vector3(0, y_lowest, 0);
        if (transform.localPosition.y > y_highest)
            transform.localPosition = new Vector3(0, y_highest, 0);
    }
}
