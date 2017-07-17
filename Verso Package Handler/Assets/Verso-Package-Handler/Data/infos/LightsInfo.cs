using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/// <summary>
/// Para facilitar a integração no processo de criar e 
/// interpretar o arquivo externo, criamos um arquivo 
/// relacionado as informações do objeto, já que esse
/// será apenas um objeto temporário, e com base nele
/// as luzes serão geradas na cena, ou exportadas da
/// mesma.
/// </summary>
public struct LightsInfo
{
    //---propriedades do objeto-----
    public string li_Name;
    public Vector3 li_position;
    public Quaternion li_rotation;
    public Vector3 li_Scale;
    public Color li_Color;
    public LIGHT_MODE li_Mode;
    public float li_Intensity;
    public ShadowInfos li_Shadow;
    public bool li_DrawHalo;
    //------------------------------

}

/// <summary>
/// Os modos de luzes
/// </summary>
public enum LIGHT_MODE
{
    MIXED,
    REALTIME,
    BAKED
}