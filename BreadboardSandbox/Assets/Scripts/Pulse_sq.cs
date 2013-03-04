using UnityEngine;
using System.Collections;

public class Pulse_sq : MonoBehaviour {
	
	public float period;
	
	private float timeSinceLast = 0f;
	private Stream_1bit pulse;

	// Use this for initialization
	void Start () {
		pulse = ScriptableObject.CreateInstance<Stream_1bit>();
		if (GetComponent<IO_1bit>().outputs.GetLength(0) <= 0)
		{
			GetComponent<IO_1bit>().outputs = new Stream_1bit[1];
		}
		
		GetComponent<IO_1bit>().outputs[0] = pulse;
		pulse.value = false;
	}
	
	// Update is called once per frame
	void Update () {
		timeSinceLast += Time.deltaTime;
		if (timeSinceLast >= period)
		{
			pulse.value = !pulse.value;
			timeSinceLast = 0f;
		}
	}
}
