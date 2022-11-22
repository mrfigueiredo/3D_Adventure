using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Scaler
{
    public static void ScaleAbsolute(this Transform transform, Vector3 scale)
    {
        transform.localScale = scale;
    }
    
    public static void ScaleAbsolute(this GameObject gameObject, Vector3 scale)
    {
        gameObject.transform.localScale = scale;
    }
    
    public static void ScaleAbsolute(this Transform transform, float scale)
    {
        transform.localScale = new Vector3(scale, scale,scale);
    }
    
    public static void ScaleAbsolute(this GameObject gameObject, float scale)
    {
        gameObject.transform.localScale = new Vector3(scale, scale, scale);
    }
    
    public static void ScaleRelative(this Transform transform, float scale)
    {
        transform.localScale *= scale;
    }
    
    public static void ScaleRelative(this GameObject gameObject, float scale)
    {
        gameObject.transform.localScale *= scale;
    }
}
