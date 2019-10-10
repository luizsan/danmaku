using UnityEngine;
using UnityEngine.UI;
using System.Collections;

[RequireComponent (typeof (Image))]
public class Mouse : MonoBehaviour {

	private Image img;

	private void Start(){
		img = GetComponent<Image>();
	}

	// Update is called once per frame
	private void Update () {
		
		Cursor.visible = false;
		img.transform.position = Input.mousePosition;
		img.enabled = true;

	}
}
