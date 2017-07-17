using System.Collections;
using System.Collections.Generic;
using System;
using System.Xml;
using System.Xml.Serialization;

using UnityEngine;

/// <summary>
/// Classe de refrência com os elementos a serem copiados os 
/// dados base.
/// </summary>
[Serializable]
public class VersoObject : MonoBehaviour
{
    /// <summary>
    /// Nome a ser salvo o arquivo externo
    /// </summary>
    public string nameSaveFile = "VersoObject.xml";

    public XmlDocument xmlDoc;

    public bool saveShadows = false;

    [TextArea]
    public string loaded_Value = "";

    public Light[] lightsCollection;

    public TextAsset loadDataAsset;

    //public DataReader data;

    //private STATUS_VERSO_OBJECT statusObj = STATUS_VERSO_OBJECT.FREE;

    public void Start()
    {
       
    }
}

/// <summary>
/// Status do objeto Verso.
/// FREE: Sem dados carregados
/// SAVED: Dados salvos
/// LOADED: Dados carregados
/// </summary>
public enum STATUS_VERSO_OBJECT
{
    FREE,
    SAVED,
    LOADED,
    SAVING
}