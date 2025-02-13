﻿/*
 * Description:             RedDotUnitInfo.cs
 * Author:                  TONYTANG
 * Create Date:             2022/08/14
 */

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// RedDotUnitInfo.cs
/// 红点运算单元信息类
/// </summary>
public class RedDotUnitInfo
{
    /// <summary>
    /// 红点运算单元类型
    /// </summary>
    public RedDotUnit RedDotUnit
    {
        get;
        private set;
    }

    /// <summary>
    /// 红点运算单元描述
    /// </summary>
    public string RedDotUnitDes
    {
        get;
        private set;
    }

    /// <summary>
    /// 红点运算单元对应显示的红点类型
    /// </summary>
    public RedDotType RedDotType
    {
        get;
        private set;
    }

    /// <summary>
    /// 影响的红点名列表
    /// </summary>
    public List<string> RedDotNameLsit
    {
        get;
        private set;
    }

    /// <summary>
    /// 红点运算单元对应红点计算回调
    /// </summary>
    public Func<int> RedDotUnitCalculateFunc
    {
        get;
        private set;
    }

    /// <summary>
    /// 构造函数
    /// </summary>
    private RedDotUnitInfo()
    {

    }

    /// <summary>
    /// 构造函数
    /// </summary>
    /// <param name="redDotUnit">红点运算单元类型</param>
    /// <param name="redDotUnitDes">红点运算单元描述</param>
    /// <param name="redDotUnitCalculateFunc">红点运算单元计算方法</param>
    /// <param name="redDotType">红点显示类型</param>
    public RedDotUnitInfo(RedDotUnit redDotUnit, string redDotUnitDes, Func<int> redDotUnitCalculateFunc, RedDotType redDotType)
    {
        RedDotUnit = redDotUnit;
        RedDotUnitDes = redDotUnitDes;
        RedDotUnitCalculateFunc = redDotUnitCalculateFunc;
        RedDotType = redDotType;
        RedDotNameLsit = new List<string>();
    }

    /// <summary>
    /// 添加影响的红点名
    /// </summary>
    /// <param name="redDotName"></param>
    /// <returns></returns>
    public bool AddRedDotName(string redDotName)
    {
        if(!RedDotNameLsit.Contains(redDotName))
        {
            RedDotNameLsit.Add(redDotName);
            return true;
        }
        Debug.LogError($"红点运算单元:{RedDotUnit.ToString()}重复添加影响红点名:{redDotName}");
        return false;
    }

    /// <summary>
    /// 移除影响的红点名
    /// </summary>
    /// <param name="redDotName"></param>
    /// <returns></returns>
    public bool RemoveRedDotName(string redDotName)
    {
        if (!RedDotNameLsit.Contains(redDotName))
        {
            Debug.LogError($"红点运算单元:{RedDotUnit.ToString()}未添加影响红点名:{redDotName},移除失败!");
            return false;
        }
        return RedDotNameLsit.Remove(redDotName);
    }
}