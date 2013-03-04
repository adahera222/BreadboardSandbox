using UnityEngine;
using System.Collections;

public class Linker : MonoBehaviour {
	
	public GameObject wire;
	
	private GameObject selection1;
	private GameObject selection2;
	
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		CheckInput();
	}
	
	void CheckInput()
	{
		if (Input.GetButtonDown("Fire1"))
		{
			if (selection1 == null)
			{
				selection1 = GetObjectAtMouse();
			}
			else
			{
				selection2 = GetObjectAtMouse();
				if (selection2 != null)
				{
					LinkObjects();
				}
			}
		}
		else if (Input.GetButtonDown("Fire2"))
		{
			selection1 = GetObjectAtMouse();
			if (selection1 != null)
			{
				selection1.GetComponent<IO_1bit>().UnplugAll();
			}
			selection1 = null;
			selection2 = null;
		}
	}
	
	void LinkObjects()
	{
		if (selection1.GetComponent<IO_1bit>().PlugThisIntoThat(selection2))
		{
			GameObject newWire = (GameObject)Instantiate(wire);
			float distance = Vector3.Distance(selection1.transform.position,
											selection2.transform.position);
			newWire.transform.position = (selection1.transform.position + selection2.transform.position) / 2;
			newWire.transform.localScale += new Vector3(0, distance, 0);
			newWire.transform.LookAt(selection1.transform.position);
			newWire.transform.Rotate(new Vector3(-90, 0 ,0));
		}
		selection1 = null;
		selection2 = null;
	}
	
	static GameObject GetObjectAtMouse()
	{
		RaycastHit hit;
		if(Physics.Raycast(Camera.mainCamera.ScreenPointToRay(Input.mousePosition), out hit))
		{
			return hit.collider.gameObject;
		}
		else
		{
			return null;
		}
	}
}
