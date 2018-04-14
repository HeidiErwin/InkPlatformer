using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InkManager : MonoBehaviour {

    public static InkManager Instance;

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
    }

	public void DecrementInk()
    {
        InkRemaining--;
    }

    public void Reset()
    {
        InkRemaining = InkMax;
    }
}
