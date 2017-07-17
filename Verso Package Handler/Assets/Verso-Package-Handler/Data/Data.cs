using System.Collections;
using System.Collections.Generic;
using System;
using System.Xml;
using System.Xml.Serialization;
using System.IO;

using UnityEngine;
using UnityEditor;
using UnityEngine.Networking;

/// <summary>
/// [BR] Classe que contém os elementos dos dados a serem interpretados.
/// CONCEITO: Salvar os valores dos objetos da Unity, habilitando para que seja
/// viável e prático carrega-los posteriormente.
/// </summary>
public class Data : ScriptableObject
{
    public static Data instance;

    public static XmlDocument file;

    /// <summary>
    /// KEY: Nome do objeto
    /// VALUE: Valores do objeto(a principio apenas luzes)
    /// </summary>
    private Dictionary<string, Light> _objColl;

    /// <summary>
    /// Caminho do arquivo a ser interpretado
    /// </summary>
    private string dt_Path = "";

    #region BASE
    public virtual void Init()
    {
        if(_objColl == null)
            _objColl = new Dictionary<string, Light>();
    }
    
    public void OnDestroy()
    {
        ClearCollection();
    }
    #endregion
    
    /// <summary>
    /// Instância do objeto para manter uma única instância
    /// </summary>
    public static Data Instance
    {
        get {
            if (instance == null) instance = new Data(); 
            return instance;
        }
    }

    /// <summary>
    /// Procura pelos valores-chave
    /// </summary>
    /// <param name="_keyValue"></param>
    /// <returns></returns>
    public bool HasKey(string _keyValue)
    {
        return _objColl.ContainsKey(_keyValue);
    }

    /// <summary>
    /// Deleta o valor de entrada dentro da biblioteca
    /// </summary>
    /// <param name="_keyValue"></param>
    public void DeleteKey(string _keyValue)
    {
        if (HasKey(_keyValue))
        {
            _objColl.Remove(_keyValue);
        }
    }

    /// <summary>
    /// Insere o objeto de luz na biblioteca de iluminação.
    /// </summary>
    /// <param name="_obj">Objeto de Luz</param>
    public void InsertLight(Light _obj)
    {
        if (!HasKey(_obj.name))
        {
            _objColl.Add(_obj.name, _obj);
        }
    }

    /// <summary>
    /// Caminho do objeto a ser intepretado.
    /// </summary>
    public string Path
    {
        get { return dt_Path; }
        set { dt_Path = value; }
    }

    /// <summary>
    /// Load XML's function
    /// </summary>
    /// <returns>Loaded XML </returns>
    public XmlDocument LoadXMLFile()
    {
        Path = EditorUtility.OpenFilePanel("Select file...", "", "xml");

        string _totalPath = "file:///" + Path;

        XmlDocument _doc = new XmlDocument();
        _doc.Load(_totalPath);
        
        return _doc;
    }

    /// <summary>
    /// Clean Collection
    /// </summary>
    public void ClearCollection()
    {
        _objColl.Clear();
    }
}
