using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;


public class SliderObserver : MonoBehaviour
{
	private Slider _slider;
	public TextMeshProUGUI _sliderText;
	public TMP_InputField _sliderInput;

	// Start is called before the first frame update
	void Start()
    {
		_slider = gameObject.GetComponent<Slider>();
		
		if (_sliderInput)
		{
			_sliderInput.onValueChanged.AddListener((v) =>
			{
				_slider.value = float.Parse(v);
			});
		}
		_slider.onValueChanged.AddListener((v) =>
		{
			if (_sliderText)
				_sliderText.text = v.ToString("0.00");
			if (_sliderInput)
				_sliderInput.text = v.ToString("0.00");
		});
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
