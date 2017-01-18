using UnityEngine;
using System.Collections;

public class HealthBar : MonoBehaviour
{
    public float up = 1.0f;
    //Health Bar
    public float health = 0.25f;
    public float armor = 0.25f;
    public Vector2 hpbarPos = new Vector2(20, 40);
    public Vector2 hpbarSize = new Vector2(50, 20);
    public Texture2D progressBarEmpty;
    public Texture2D progressBarFull;

    Rect hpBar;
    Vector2 pos;

    private GUIStyle currentStyle1 = null;
    private GUIStyle currentStyle2 = null;
    private GUIStyle currentStyle3 = null;
    //public GUIStyle myStyle;

    void OnGUI()
    {
        InitStyles();
        Vector3 screenPos = Camera.main.WorldToScreenPoint(transform.position);
        screenPos.y = Screen.height - (screenPos.y + 1) + up;    

        GUI.BeginGroup(new Rect(screenPos.x - (hpbarSize.x/2), screenPos.y - (hpbarSize.x / 2) + 10, hpbarSize.x, hpbarSize.y));
            GUI.Box(new Rect(0, 0, hpbarSize.x, hpbarSize.y), "", currentStyle1);
               GUI.BeginGroup(new Rect(0, 0, hpbarSize.x * health, hpbarSize.y));
                GUI.Box(new Rect(0, 0, hpbarSize.x, hpbarSize.y),"", currentStyle2);
               GUI.EndGroup();
               GUI.BeginGroup(new Rect(0, 0, hpbarSize.x * armor, hpbarSize.y));
                GUI.Box(new Rect(0, 0, hpbarSize.x, hpbarSize.y), "", currentStyle3);
               GUI.EndGroup();
        GUI.EndGroup();
    }

    private void InitStyles()
    {
        if( currentStyle1 == null )
        {
            currentStyle1 = new GUIStyle(GUI.skin.box);
            currentStyle2 = new GUIStyle(GUI.skin.box);
            currentStyle3 = new GUIStyle(GUI.skin.box);
            currentStyle1.normal.background = MakeTex( 2, 2, new Color( 0.75f, 0.75f, 0.75f, 0.25f));
            currentStyle2.normal.background = MakeTex(2, 2, new Color(1f, 0f, 0f, 1f));
            currentStyle3.normal.background = MakeTex(2, 2, new Color(0.5f, 0.5f, 0.5f, 0.5f));
        }
    }

    private Texture2D MakeTex( int width, int height, Color col )
    {
        Color[] pix = new Color[width * height];
        for( int i = 0; i < pix.Length; ++i )
        {
            pix[ i ] = col;
        }
        Texture2D result = new Texture2D( width, height );
        result.SetPixels( pix );
        result.Apply();
        return result;
    }

}
