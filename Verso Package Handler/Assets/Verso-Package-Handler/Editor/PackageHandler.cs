using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using System.Xml.Serialization;
using System.Xml;

/// <summary>
/// Classe responsável pelo layout Inspector para o componente VersoObject.
/// </summary>
[CustomEditor(typeof(VersoObject))]
public class PackageHandler : Editor
{
    private List<LightsInfo> arrLights = new List<LightsInfo>();

    //public Object objSource;

    public override void OnInspectorGUI()
    {
        serializedObject.Update();

        EditorGUILayout.Space();

        VersoObject versoComp = (VersoObject)target;

        versoComp.nameSaveFile = EditorGUILayout.TextField("Nome do arquivo", versoComp.nameSaveFile);
        EditorGUILayout.Separator();
        //versoComp.loaded_Value = EditorGUILayout.TextArea(versoComp.loaded_Value, GUILayout.MaxHeight(50));
        //objSource = EditorGUILayout.ObjectField(objSource, typeof(Light), true);

        EditorGUILayout.BeginHorizontal();

        //Load Data
        if (GUILayout.Button("Load Data"))
        {
            DataReader _data = ScriptableObject.CreateInstance<DataReader>();
            _data.Init();

            _data.ReadXML();

            if (Data.file != null)
            {
                versoComp.loaded_Value = "";
                foreach (XmlNode _node in Data.file.SelectNodes("lights/obj"))
                {
                    var _attrib01 = _node.Attributes.GetNamedItem("name").Value;
                    var combinedValue ="Loaded: " + _attrib01 + "\r\n";

                    var lightElement = ScriptableObject.CreateInstance<LightElement>();
                    arrLights.Add(lightElement.Read(_node));

                    versoComp.loaded_Value += combinedValue;
                }
            }
            else
            {
                Debug.Log("NULL DATA");
            }
        }

        //Create the light
        if (GUILayout.Button("Create Light(s)"))
        {
            if (arrLights != null)
            {
                foreach (LightsInfo _lighObj in arrLights)
                {
                    Debug.Log("Light " + _lighObj.li_Name);
                    CreateElement(_lighObj);
                }
            }
            else
            {
                Debug.Log("NO VALUE LOADED!");
            }
        }
        EditorGUILayout.EndHorizontal();

        EditorGUILayout.Separator();
        //Save Data
        if (GUILayout.Button("Export Light(s)"))
        {
            //write data
            DataWriter _writer = new DataWriter();
            _writer.Init();

            var _collection = GameObject.FindObjectsOfType<Light>();
            Debug.Log("Export " + _collection.Length + " objs");

            _writer.SaveData(_collection, (Application.dataPath + "/" + versoComp.nameSaveFile));
        }

        serializedObject.ApplyModifiedProperties();
    }

    void CreateElement(LightsInfo _element)
    {
        GameObject _gOLimit = new GameObject(_element.li_Name);
        Light _light = _gOLimit.AddComponent<Light>();
        _light.color = _element.li_Color;
        _light.transform.position = _element.li_position;
        _light.transform.rotation = _element.li_rotation;
    }

    public void OnDestroy()
    {
        arrLights.Clear();
    }
}
