using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrollingObjController : MonoBehaviour
{
    public string prefabName = default;
    public int scrollingObjCount = default;
    private GameObject objPrefab = default;
    private List<GameObject> scrollingPool = default;
    Vector2 objPrefabSize;


    void Start()
    {
        objPrefab = gameObject.FindChildObj(prefabName);
        objPrefabSize = objPrefab.GetRectSizeDelta();
        scrollingPool = new List<GameObject> ();
        GFunc.Assert(objPrefab != null || objPrefab != default);

        GameObject tempObj = default;
        if(scrollingPool.Count <= 0)
        {
            for (int i = 0; i < scrollingObjCount; i++)
            {
                tempObj = Instantiate(objPrefab, objPrefab.transform.position,
                    objPrefab.transform.rotation, transform);

                scrollingPool.Add(tempObj);
                tempObj = default;
            } // loop : 스크롤링 오브젝트 초기화 루프
        }

        objPrefab.SetActive(false);

        int scrollCntIndex = scrollingObjCount - 1;
        float horizonPos = 0f;
        for (int i = 0; i < scrollingPool.Count; i++)
        {
            horizonPos = objPrefabSize.x * scrollCntIndex * (-1 + i) * 0.5f;
            scrollingPool[i].SetLocalPos(horizonPos, 0f, 0f);
        }
        //objPrefabSize.x * scrollingObjCount;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
