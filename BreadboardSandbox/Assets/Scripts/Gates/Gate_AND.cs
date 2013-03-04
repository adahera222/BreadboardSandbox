using UnityEngine;
using System.Collections;

public class Gate_AND : MonoBehaviour {

	private Stream_1bit and;
	
	// Use this for initialization
	void Start () {
		and = ScriptableObject.CreateInstance<Stream_1bit>();
		if (GetComponent<IO_1bit>().outputs.GetLength(0) <= 0)
		{
			GetComponent<IO_1bit>().outputs = new Stream_1bit[1];
		}
		
		GetComponent<IO_1bit>().outputs[0] = and;
		and.value = false;
	}
	
	// Update is called once per frame
	void Update () {
		if (GetComponent<IO_1bit>().inputs.GetLength(0) >= 2
			&& GetComponent<IO_1bit>().inputs[0] != null
			&& GetComponent<IO_1bit>().inputs[1] != null)
		{
			and.value = (GetComponent<IO_1bit>().inputs[0].value
						&& GetComponent<IO_1bit>().inputs[1].value);
		}
	}
}
