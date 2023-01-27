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

    // 뒤에 int a, int b는 인자임.
    public static void KJH(this GameObject obj_, int a, int b)
    {
        Debug.Log("This is my Function. Absolutly created by KJH");
    } // GameObject 내부 메소드에 추가. Extended Method(확장 메서드)

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

    public static GameObject FindChildObj(this GameObject targetObj_, string ObjName_)
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
    public static void LoadScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }
    // T의 이름을 바꿔서 줄 수 있음을 보여주는 코드
    public static T GetComponentMust<T>(this GameObject obj_)
    {
        T component_ = obj_.GetComponent<T>();
        GFunc.Assert(component_.IsValid(), 
            string.Format("{0}에서 {1}을 찾을 수 없습니다.", obj_.name, component_.GetType().Name));
        return component_;
    }

    // RectTransform 에서 sizeDelta를 찾아서 리턴
    public static Vector2 GetRectSizeDelta(this GameObject obj_)
    {
        return obj_.GetComponent<RectTransform>().sizeDelta;
    }

    public static void SetLocalPos(this GameObject obj_, float x, float y, float z)
    {
        obj_.transform.localPosition = new Vector3(x, y, z);
    }

    public static void AddLocalPos(this GameObject obj_, float x, float y, float z)
    {
        obj_.transform.localPosition += new Vector3(x, y, z);
    }
}