/**====================================
 *Copyright(C) 2018 by Wipace 
 *All rights reserved. 
 *FileName:     .cs 
 *Author:       CGzhao 
 *Version:      1.0 
 *UnityVersion：2018.2.3 
 *Date:         2018-12-224 
 *Email:		1341674064@qq.com
 *Description:  对象池
 *History: 
======================================**/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPool{
    /// <summary>
    /// 对象容器
    /// </summary>
    private List<GameObject> m_pool = new List<GameObject>();

    /// <summary>
    /// 对象预制体的名字
    /// </summary>
    private string m_poolName { get; set; }

    /// <summary>
    /// 对象的预制体
    /// </summary>
    private GameObject m_Prefab { get; set; }

    /// <summary>
    /// 对象的父节点
    /// </summary>
    private GameObject m_Parent { get; set; }

    /// <summary>
    /// 构造函数
    /// </summary>
    /// <param name="poolName"></param>
    public ObjectPool(string poolName, GameObject parent = null)
    {
        m_poolName = poolName;
        m_Prefab = Resources.Load<GameObject>("Prefabs/" + m_poolName);
        m_Parent = parent;
    }

    /// <summary>
    /// 获取对象
    /// </summary>
    /// <param name="poolName"></param>
    /// <returns></returns>
    public GameObject SpwanObject(string poolName, GameObject parent = null)
    {
        GameObject obj = null;
        if (m_poolName != poolName)
        {
            Debug.Log(string.Format("找错池子了，这个对象池获取的是{0}，而你要获取的是{1}", m_poolName, poolName));
            return obj;
        }

        if (m_pool.Count > 0) //池子有多余的对象存在
        {
            obj = m_pool[0];
            m_pool.Remove(obj);
            obj.SetActive(true);
        }
        else //不存在多余的对象，生成一个并返回
        {
            obj = GameObject.Instantiate(m_Prefab) as GameObject;
            if (parent != null)
            {
                m_Parent = parent;
            }
            else
            {
                if (m_Parent == null)
                {
                    m_Parent = new GameObject( m_poolName + "Pool");
                }
            }

            obj.transform.localPosition = Vector3.zero;
            obj.transform.localRotation = Quaternion.identity;
            obj.transform.localScale = Vector3.one;
            obj.transform.SetParent(m_Parent.transform);
        }

        return obj;

    }

    /// <summary>
    /// 回收对象
    /// </summary>
    /// <param name="poolName"></param>
    /// <param name="gameObject"></param>
    public void UnSpwanObject(string poolName, GameObject gameObject)
    {
        if (m_poolName != poolName)
        {
            Debug.Log(string.Format("找错池子了，这个对象池存放的是{0},而你要存放的是{1}", m_poolName, poolName));
            return;
        }
        
        m_pool.Add(gameObject);
        gameObject.SetActive(false);
    }
}
