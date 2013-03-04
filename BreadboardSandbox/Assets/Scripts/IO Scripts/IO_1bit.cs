using UnityEngine;
using System.Collections;

public class IO_1bit : MonoBehaviour {
	
	public Stream_1bit[] inputs;
	public Stream_1bit[] outputs;
	
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	public bool PlugThisIntoThat(GameObject that)
	{
		
		if (this.outputs.GetLength(0) <= 0 ||
			this.outputs[0] == null ||
			that.GetComponent<IO_1bit>().inputs.GetLength(0) <= 0)
		{
			print(string.Format("{0} cannot be be plugged into {1}",this.name,that.name));
			return false;
		}
		else
		{
			int numberOfInputs = that.GetComponent<IO_1bit>().inputs.GetLength(0);
			for (int i = 0; i < numberOfInputs; ++i)
			{
				if (that.GetComponent<IO_1bit>().inputs[i] == null)
				{
					that.GetComponent<IO_1bit>().inputs[i] = this.outputs[0];
					print(string.Format("{0} plugged into {1} successfully",this.name,that.name));
					return true;
				}
			}
			that.GetComponent<IO_1bit>().inputs[0] = this.outputs[0];
			print(string.Format("{0} plugged into {1} successfully",this.name,that.name));
			return true;
		}
	}
	
	public bool PlugThatIntoThis(GameObject that) {
		if (this.inputs.GetLength(0) <= 0 ||
			that.GetComponent<IO_1bit>().outputs.GetLength(0) <= 0 ||
			that.GetComponent<IO_1bit>().outputs[0] == null)
		{
			return false;
		}
		else
		{
			this.inputs[0] = that.GetComponent<IO_1bit>().outputs[0];
			return true;
		}
	}
	
	public void UnplugAll()
	{
		print (string.Format("unplugged all inputs from {0}",this.name));
		for (int i = 0; i < inputs.GetLength(0); ++i)
		{
			inputs[i] = null;
		}
	}
}
