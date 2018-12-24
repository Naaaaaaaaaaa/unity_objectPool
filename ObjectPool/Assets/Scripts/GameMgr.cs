/**====================================
 *Copyright(C) 2018 by Wipace 
 *All rights reserved. 
 *FileName:     .cs 
 *Author:       CGzhao 
 *Version:      1.0 
 *UnityVersion：2018.2.3 
 *Date:         2018-11-27 
 *Email:		1341674064@qq.com
 *Description:    
 *History: 
======================================**/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameMgr : MonoBehaviour
{
	public static GameMgr Instance;
	
	public ObjectPool pool;

	private void Awake()
	{
		Instance = this;
	}

	// Use this for initialization
	void Start () {
		pool  = new ObjectPool("Cube");
		for (int i = 0; i < 3; i++)
		{
			pool.SpwanObject("Cube");
		}
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetMouseButtonDown(0))
		{
			pool.SpwanObject("Cube");
		}
	}
}
