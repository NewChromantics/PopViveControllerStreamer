using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JoystickUpdate : MonoBehaviour {


	public void FrameUpdate(OpenvrJoystickFrame Frame)
	{
		this.transform.position = Frame.Position;
		this.transform.rotation = Frame.Rotation;
	}
}
