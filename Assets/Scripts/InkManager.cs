using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InkManager : MonoBehaviour {

    public static InkManager Instance;
	public Slider inkSlider;
	public Text inkCounter;
    public float InkMax = 10;
    public float InkRemaining { get; private set; }

    private void Start()
    {
        if (inkSlider == null)
        {
            inkSlider = GameObject.Find("Inkwell").GetComponent<Slider>();
        }
        if (inkCounter == null)
        {
            inkCounter = GameObject.Find("Counter").GetComponent<Text>();
        }

        InkMax = 10;
        if(Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(this);
        }

        InkRemaining = InkMax;
		inkCounter.text = InkMax.ToString();
    }

	public void DecrementInk()
    {
        InkRemaining--;
		inkSlider.value = InkRemaining;
		inkCounter.text = InkRemaining.ToString();
    }

    public void Reset()
    {
        InkRemaining = InkMax;
    }
}
