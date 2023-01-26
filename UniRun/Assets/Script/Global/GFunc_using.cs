using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using TMPro;

static public partial class GFunc
{
    public static void SetText(GameObject obj_, string text_)
    {
        TMP_Text Txt = obj_.GetComponent<TMP_Text>();
        if (Txt == null || Txt == default(TMP_Text))
        {
            return;
        } // TMP_Text가 존재하지 않는 경우

        Txt.text = text_;
    }
}