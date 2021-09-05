using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using TMP = TMPro.TextMeshProUGUI;

public class SettingVariable : MonoBehaviour
{

	public string Name;
	private string _Value {
		get { return Value; }
		set {
			foreach(TMP t in UI_Link)
			{
				t.SetText(value.ToString());
			}
			Value = value;
		}
	}
	public string Value;
	public enum SettingType
	{
		Int,
		Float,
		String
	};
	public SettingType Type;

	public List<TMP> UI_Link;

    // Start is called before the first frame update
    void Start()
    {
        foreach (TMP t in UI_Link)
		{
			t.SetText(Value.ToString());
		}
    }

	// Update is called once per frame
	void Update()
	{
		
		foreach (TMP t in UI_Link)
		{
			if (t.GetParsedText() != Value)
			{
				_Value = t.GetParsedText();
				break;
			}
		}
		if (_Value != Value)
			_Value = Value;
	}
}
