﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControllerUpdate : MonoBehaviour {

	public GameObject		Template;

	List<GameObject>		ControllerObjects;

	GameObject				GetControllerObject(int ControllerIndex)
	{
		if ( ControllerObjects == null )
			ControllerObjects = new List<GameObject>();

		//	add padding controllers
		while ( ControllerObjects.Count < ControllerIndex+1 )
		{
			var NewIndex = ControllerObjects.Count;
			var NewObject = GameObject.Instantiate( Template, this.transform );
			NewObject.name += " " + NewIndex;
			NewObject.SetActive(false);
			ControllerObjects.Add( NewObject );
		}

		return ControllerObjects[ControllerIndex];
	}

	void UpdateController(GameObject Controller, OpenvrControllerFrame Frame)
	{
		Controller.SetActive( Frame.Attached );
		Controller.transform.localPosition = Frame.Position;
		Controller.transform.localRotation = Frame.Rotation;
	}

	public void				UpdateControllers(List<OpenvrControllerFrame> ControllerFrames)
	{
		for ( int i=0;	i<ControllerFrames.Count;	i++ )
		{
			try
			{
				var Controller = GetControllerObject(i);
				UpdateController( Controller, ControllerFrames[i] );
			}
			catch
			{
			}
		}

	}

	void OnEnable()
	{
		Template.SetActive(false);
	}
}