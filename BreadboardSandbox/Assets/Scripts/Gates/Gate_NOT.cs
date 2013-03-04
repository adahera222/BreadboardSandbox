using UnityEngine;
using System.Collections;

public class Gate_NOT : MonoBehaviour {
	
	private Stream_1bit inverse;
	
	// Use this for initialization
	void Start ()
	{
		inverse = ScriptableObject.CreateInstance<Stream_1bit>();
		if (GetComponent<IO_1bit>().outputs.GetLength(0) <= 0)
		{
			GetComponent<IO_1bit>().outputs = new Stream_1bit[1];
		}
		
		GetComponent<IO_1bit>().outputs[0] = inverse;
		inverse.value = false;
	}
	
	// Update is called once per frame
	void Update () {
		if (GetComponent<IO_1bit>().inputs.GetLength(0) >= 1
			&& GetComponent<IO_1bit>().inputs[0] != null)
		{
			inverse.value = !GetComponent<IO_1bit>().inputs[0].value;
		}
	}
}
