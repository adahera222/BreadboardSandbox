using UnityEngine;
using System.Collections;

public class Pixel_1bit : MonoBehaviour {
	
	public Color on = Color.green;
	public Color off = Color.black;
	
	private const int textureHeight = 1;
	private const int textureWidth = 1;
	
	private Texture2D texture;
	
	// Use this for initialization
	void Start ()
	{
		texture = new Texture2D(textureWidth, textureHeight, TextureFormat.RGB24, false);
		renderer.material.mainTexture = texture;
	}
	
	// Update is called once per frame
	void Update ()
	{
		if (GetComponent<IO_1bit>().inputs.GetLength(0) <= 0
			|| GetComponent<IO_1bit>().inputs[0] == null
			|| GetComponent<IO_1bit>().inputs[0].value == false)
		{
			texture.SetPixel(0,0,off);
		}
		else
		{
			texture.SetPixel(0,0,on);
		}
		texture.Apply();
	}
}
