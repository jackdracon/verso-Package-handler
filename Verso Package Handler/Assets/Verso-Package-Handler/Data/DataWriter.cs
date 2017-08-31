using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Xml;

/// <summary>
/// Classe responsável por interpretar os dados da Luz, em que irá
/// converter os valores das variáveis em dados salvos externos.
/// </summary>
public class DataWriter : Data
{

    //private static DataWriter data;
    public override void Init()
    {
        base.Init();
    }

    public void SaveData(Light[] _lights, string _nameFile)
    {
        string _path = Application.dataPath;
        XmlDocument _docToSave = new XmlDocument();
        XmlDeclaration _declaration = _docToSave.CreateXmlDeclaration("1.0", "utf-8", null);
        XmlElement _root = _docToSave.DocumentElement;
        _docToSave.InsertBefore(_declaration, _root);

        XmlElement _bodyElement = _docToSave.CreateElement(string.Empty, "lights", string.Empty);
        _docToSave.AppendChild(_bodyElement);

        foreach(Light li in _lights)
        {
            Debug.Log("Creating Obj: " + li.name);
            //OBJ NODE
            XmlElement _objElement = _docToSave.CreateElement(string.Empty, "obj", string.Empty);
            XmlAttribute _objAttribName = _docToSave.CreateAttribute("name");
            _objAttribName.Value = li.name;

            _objElement.Attributes.SetNamedItem(_objAttribName);

            //POSITION NODE
            XmlElement _posElement = _docToSave.CreateElement(string.Empty, "pos", string.Empty);
            XmlAttribute _objAttribPosX = _docToSave.CreateAttribute("x");
            XmlAttribute _objAttribPosY = _docToSave.CreateAttribute("y");
            XmlAttribute _objAttribPosZ = _docToSave.CreateAttribute("z");
            _objAttribPosX.Value = li.transform.position.x.ToString();
            _objAttribPosY.Value = li.transform.position.y.ToString();
            _objAttribPosZ.Value = li.transform.position.z.ToString();

            _posElement.Attributes.SetNamedItem(_objAttribPosX);
            _posElement.Attributes.SetNamedItem(_objAttribPosY);
            _posElement.Attributes.SetNamedItem(_objAttribPosZ);

            _objElement.AppendChild(_posElement);

            //ORIENTATION NODE
            XmlElement _rotElement = _docToSave.CreateElement(string.Empty, "rot", string.Empty);
            XmlAttribute _objAttribRotX = _docToSave.CreateAttribute("x");
            XmlAttribute _objAttribRotY = _docToSave.CreateAttribute("y");
            XmlAttribute _objAttribRotZ = _docToSave.CreateAttribute("z");
            XmlAttribute _objAttribRotW = _docToSave.CreateAttribute("w");
            _objAttribRotX.Value = li.transform.rotation.x.ToString();
            _objAttribRotY.Value = li.transform.rotation.y.ToString();
            _objAttribRotZ.Value = li.transform.rotation.z.ToString();
            _objAttribRotW.Value = li.transform.rotation.w.ToString();

            _rotElement.Attributes.SetNamedItem(_objAttribRotX);
            _rotElement.Attributes.SetNamedItem(_objAttribRotY);
            _rotElement.Attributes.SetNamedItem(_objAttribRotZ);
            _rotElement.Attributes.SetNamedItem(_objAttribRotW);

            _objElement.AppendChild(_rotElement);

            //SCALE  NODE
            XmlElement _scaleElement = _docToSave.CreateElement(string.Empty, "scale", string.Empty);
            XmlAttribute _objAttribScaleX = _docToSave.CreateAttribute("x");
            XmlAttribute _objAttribScaleY = _docToSave.CreateAttribute("y");
            XmlAttribute _objAttribScaleZ = _docToSave.CreateAttribute("z");
            _objAttribScaleX.Value = "0";
            _objAttribScaleY.Value = "0";
            _objAttribScaleZ.Value = "0";

            _scaleElement.Attributes.SetNamedItem(_objAttribScaleX);
            _scaleElement.Attributes.SetNamedItem(_objAttribScaleY);
            _scaleElement.Attributes.SetNamedItem(_objAttribScaleZ);

            _objElement.AppendChild(_scaleElement);

            //COLOR NODE
            XmlElement _colorElement = _docToSave.CreateElement(string.Empty, "color", string.Empty);
            XmlAttribute _objAttribColorR = _docToSave.CreateAttribute("red");
            XmlAttribute _objAttribColorG = _docToSave.CreateAttribute("green");
            XmlAttribute _objAttribColorB = _docToSave.CreateAttribute("blue");
            _objAttribColorR.Value = li.color.r.ToString();
            _objAttribColorG.Value = li.color.b.ToString();
            _objAttribColorB.Value = li.color.g.ToString();

            _colorElement.Attributes.SetNamedItem(_objAttribColorR);
            _colorElement.Attributes.SetNamedItem(_objAttribColorG);
            _colorElement.Attributes.SetNamedItem(_objAttribColorB);

            _objElement.AppendChild(_colorElement);

            //MODE NODE
            XmlElement _modeElement = _docToSave.CreateElement(string.Empty, "mode", string.Empty);
            XmlText _modeTxt = _docToSave.CreateTextNode(li.renderMode.ToString());
            _modeElement.AppendChild(_modeTxt);

            _objElement.AppendChild(_modeElement);

            //INTENSITY NODE
            XmlElement _intensityElement = _docToSave.CreateElement(string.Empty, "intensity", string.Empty);
            XmlText _intensityTxt = _docToSave.CreateTextNode(li.intensity.ToString());
            _intensityElement.AppendChild(_intensityTxt);

            _objElement.AppendChild(_intensityElement);

            //SHADOW MODE
            XmlElement _shadowElement = _docToSave.CreateElement(string.Empty, "shadow", string.Empty);
            XmlAttribute _objAttribStrength = _docToSave.CreateAttribute("strength");
            XmlAttribute _objAttribBias = _docToSave.CreateAttribute("bias");
            XmlAttribute _objAttribNBias = _docToSave.CreateAttribute("normalbias");
            XmlAttribute _objAttribNearPlane = _docToSave.CreateAttribute("nearplane");
            XmlText _shadowTxt = _docToSave.CreateTextNode("NO_SHADOWS");
            _shadowElement.Attributes.SetNamedItem(_objAttribStrength);
            _shadowElement.Attributes.SetNamedItem(_objAttribBias);
            _shadowElement.Attributes.SetNamedItem(_objAttribNBias);
            _shadowElement.Attributes.SetNamedItem(_objAttribNearPlane);
            _shadowElement.AppendChild(_shadowTxt);

            _objElement.AppendChild(_shadowElement);

            //DRAW HALO MODE
            XmlElement _drawHaloElement = _docToSave.CreateElement(string.Empty, "draw-halo", string.Empty);
            XmlText _haloTxt = _docToSave.CreateTextNode("NO_SHADOWS");

            _drawHaloElement.AppendChild(_haloTxt);

            _objElement.AppendChild(_drawHaloElement);

            _bodyElement.AppendChild(_objElement);
        }
        Debug.Log(_nameFile);
        _docToSave.Save(_nameFile);
    }
}