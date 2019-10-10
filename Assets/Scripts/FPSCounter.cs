﻿/* **************************************************************************
 * FPS COUNTER
 * **************************************************************************
 * Written by: Annop "Nargus" Prapasapong
 * Created: 7 June 2012
 * *************************************************************************/
 
using UnityEngine;
using UnityEngine.UI;
using System.Collections;
 
/* **************************************************************************
 * CLASS: FPS COUNTER
 * *************************************************************************/ 
//[RequireComponent(typeof(GUIText))]
public class FPSCounter : MonoBehaviour {
	/* Public Variables */
	public float frequency = 0.5f;
	public int digits = 2;
	public string label = "";
 
	/* **********************************************************************
	 * PROPERTIES
	 * *********************************************************************/
	public int FramesPerSec { get; protected set; }
	public string display = "";
 
	/* **********************************************************************
	 * EVENT HANDLERS
	 * *********************************************************************/
	/*
	 * EVENT: Start
	 */
	private void Start() {
		StartCoroutine(FPS());
	}
 
	/*
	 * EVENT: FPS
	 */
	private IEnumerator FPS() {
		for(;;){
			// Capture frame-per-second
			int lastFrameCount = Time.frameCount;
			float lastTime = Time.realtimeSinceStartup;
			yield return new WaitForSeconds(frequency);
			float timeSpan = Time.realtimeSinceStartup - lastTime;
			int frameCount = Time.frameCount - lastFrameCount;
 
			// Display it
			FramesPerSec = Mathf.RoundToInt(frameCount / timeSpan);
			display = FramesPerSec.ToString("f"+digits);

			GetComponent<Text>().text = display+label;

		}
	}
}