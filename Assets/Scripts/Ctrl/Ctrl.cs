using System.Collections;
using System.Collections.Generic;
using System.Linq;
using QFramework;
using QFramework.Tetris;
using UnityEngine;

public class Ctrl : MonoBehaviour {

	// Use this for initialization
	private void Awake()
	{
		MakeFSM();
		
		ResMgr.Init();

		UIMgr.OpenPanel<UIHomePanel>();
	}

	private FSMSystem mFSM;

	void MakeFSM()
	{
		mFSM = new FSMSystem();

		var states = gameObject.GetComponentsInChildren<FSMState>();

		states.ForEach(state => { mFSM.AddState(state); });

		var menuState = states.First(state => state is MenuState);

		mFSM.SetCurrentState(menuState);
	}
}
