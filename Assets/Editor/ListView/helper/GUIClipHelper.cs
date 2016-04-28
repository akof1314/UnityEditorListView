using System;
using System.Collections.Generic;
using System.Reflection;
using UnityEditor;
using UnityEngine;

public static class GUIClipHelper
{
    private static Func<Rect> VisibleRect;

    public static void InitType()
    {
        var tyGUIClip = Type.GetType("UnityEngine.GUIClip,UnityEngine");
        if (tyGUIClip != null)
        {
            var piVisibleRect = tyGUIClip.GetProperty("visibleRect", BindingFlags.Static | BindingFlags.Public);
            if (piVisibleRect != null)
                VisibleRect = (Func<Rect>)Delegate.CreateDelegate(typeof(Func<Rect>), piVisibleRect.GetGetMethod());
        }
    }

    public static Rect visibleRect
    {
        get
        {
            InitType();
            return VisibleRect();
        }
    }
}