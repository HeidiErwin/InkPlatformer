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
