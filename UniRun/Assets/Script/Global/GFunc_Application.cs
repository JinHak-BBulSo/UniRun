using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.Search;
using UnityEngine;
using UnityEngine.SceneManagement;

public static partial class GFunc
{
    public static void QuitThisGame()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif
    }

    public static void KJH(this GameObject obj_, int a, int b)
    {
        Debug.Log("This is my Function. Absolutly created by KJH");
    }

    public static GameObject GetRootObj(string objName_)
    {
        Scene activeScene = GetActiveScene();
        GameObject[] rootObjs_ = activeScene.GetRootGameObjects();
        GameObject targetObj = default;

        foreach (var item in rootObjs_)
        {
            if (item.name.Equals(objName_))
            {
                targetObj = item;
                return targetObj;
            }
            else { continue; }
        }

        return targetObj;
    }

    public static GameObject GetChildObj(this GameObject targetObj_, string ObjName_)
    {
        GameObject searchObject = default;
        for (int i = 0; i < targetObj_.transform.childCount; i++)
        {
            if (targetObj_.transform.GetChild(i).gameObject.name.Equals(ObjName_))
            {
                searchObject = targetObj_.transform.GetChild(i).gameObject;
                return searchObject;
            }
            else continue;
        }
        return searchObject;
    }

    public static GameObject FindChildObj(this GameObject targetObj_, string? ObjName_)
    {
        GameObject searchResult = default;
        GameObject searchTarget = default;
        for (int i = 0; i < targetObj_.transform.childCount; i++)
        {
            searchTarget = targetObj_.transform.GetChild(i).gameObject;
            if (searchTarget.name.Equals(ObjName_))
            {
                searchResult = searchTarget;
                return searchResult;
            }
            else
            {
                searchResult = FindChildObj(searchTarget, ObjName_);
            }
        }
        if (searchResult == null || searchResult == default) { /* Do nothing*/ }
        else { return searchResult; }
        return searchResult;
    }
    public static Scene GetActiveScene()
    {
        return SceneManager.GetActiveScene();
    }
}