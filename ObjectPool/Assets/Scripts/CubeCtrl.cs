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

public class CubeCtrl : MonoBehaviour {

	// Use this for initialization
	void Start ()
	{
		StartCoroutine(DestroyCube());
	}

	IEnumerator DestroyCube()
	{
		yield return new WaitForSeconds(5f);
		GameMgr.Instance.pool.UnSpwanObject("Cube", this.gameObject);
	}

	// Update is called once per frame
	void Update ()
	{
		transform.Rotate(Vector3.forward * 180 * Time.deltaTime);
	}
}
