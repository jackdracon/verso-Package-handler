using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Xml;


public class LightElement : ScriptableObject
{

#region NOMES OBJETOS
    public string field_name = "name";
    public string field_position = "pos";
    public string field_rotation = "rot";
    public string field_scale = "scale";
    public string field_color = "color";
    public string field_mode = "mode";
    public string field_intensity = "intensity";
    public string field_shadow = "shadow";
    public string field_halo = "draw-halo";

#endregion

    private LightsInfo info;

    //private Dictionary<string, object> collInfos = new Dictionary<string, object>();

    /// <summary>
    /// Interpreta o objeto carregado,
    /// 
    /// </summary>
    /// <param name="_element"></param>
    public LightsInfo Read(XmlNode _element)
    {
        info = new LightsInfo();
        //string _retValue = "";

        if (_element.Attributes.Count > 0)
        {
            info.li_Name = _element.Attributes.GetNamedItem(field_name).Value;
            foreach (XmlNode _node in _element)
            {
                //Position
                if (_node.Name == field_position)
                {
                    float posX = (float) System.Convert.ToDouble(_node.Attributes.GetNamedItem("x").Value);
                    float posY = (float)System.Convert.ToDouble(_node.Attributes.GetNamedItem("y").Value);
                    float posZ = (float)System.Convert.ToDouble(_node.Attributes.GetNamedItem("z").Value);
                    info.li_position = new Vector3(posX, posY, posZ);
                }
                //Scale
                if (_node.Name == field_scale)
                {
                    float scaX = (float)System.Convert.ToDouble(_node.Attributes.GetNamedItem("x").Value);
                    float scaY = (float)System.Convert.ToDouble(_node.Attributes.GetNamedItem("y").Value);
                    float scaZ = (float)System.Convert.ToDouble(_node.Attributes.GetNamedItem("z").Value);
                    info.li_Scale = new Vector3(scaX, scaY, scaZ);
                }
                //Rotation
                if (_node.Name == field_rotation)
                {
                    float rotX = (float)System.Convert.ToDouble(_node.Attributes.GetNamedItem("x").Value);
                    float rotY = (float)System.Convert.ToDouble(_node.Attributes.GetNamedItem("y").Value);
                    float rotZ = (float)System.Convert.ToDouble(_node.Attributes.GetNamedItem("z").Value);
                    float rotW = (float)System.Convert.ToDouble(_node.Attributes.GetNamedItem("w").Value);
                    info.li_rotation = new Quaternion(rotX, rotY, rotZ, rotW);
                }
                //Color
                if (_node.Name == field_color)
                {
                    float redColor = (float)System.Convert.ToDouble(_node.Attributes.GetNamedItem("red").Value);
                    float greenColor = (float)System.Convert.ToDouble(_node.Attributes.GetNamedItem("green").Value);
                    float blueColor = (float)System.Convert.ToDouble(_node.Attributes.GetNamedItem("blue").Value);
                    info.li_Color = new Color(redColor, greenColor, blueColor);
                }
                //Mode
                if (_node.Name == field_mode)
                {
                    string _modeValue = _node.InnerText;
                    switch (_modeValue)
                    {
                        case ("REALTIME"):
                            info.li_Mode = LIGHT_MODE.REALTIME;
                        break;
                        case ("MIXED"):
                            info.li_Mode = LIGHT_MODE.MIXED;
                            break;
                        case ("BAKED"):
                            info.li_Mode = LIGHT_MODE.BAKED;
                            break;
                    }
                }
                //Intensity
                if (_node.Name == field_intensity)
                {
                    int intensity = (int)System.Convert.ToDouble(_node.Value);
                    info.li_Intensity = intensity;
                }

                //Draw Halo
                if (_node.Name == field_halo)
                {
                    bool drawHalo = System.Convert.ToBoolean(_node.Value);
                    info.li_DrawHalo = drawHalo;
                }
                //Shadows
                if (_node.Name == field_shadow)
                {
                    var _type = _node.Value;
                    switch (_type)
                    {
                        case ("NO_SHADOWS"):
                            info.li_Shadow.type = SHADOWTYPE.NO_SHADOWS;
                            break;
                        case ("HARD_SHASOWS"):
                            info.li_Shadow.type = SHADOWTYPE.HARD_SHADOWS;
                            break;
                        case ("SOFT_SHADOWS"):
                            info.li_Shadow.type = SHADOWTYPE.SOFT_SHADOWS;
                            break;
                    }
                    info.li_Shadow.bias = (float)System.Convert.ToDouble(_node.Attributes.GetNamedItem("bias").Value);
                    info.li_Shadow.normalBias = (float)System.Convert.ToDouble(_node.Attributes.GetNamedItem("normalbias").Value);
                    info.li_Shadow.nearPlane = (float)System.Convert.ToDouble(_node.Attributes.GetNamedItem("nearplane").Value);
                    info.li_Shadow.strength = (float)System.Convert.ToDouble(_node.Attributes.GetNamedItem("strength").Value);
                }
            }
        }
        else
        {
            Debug.Log("Not default!");
        }

        return info;
    }
}
