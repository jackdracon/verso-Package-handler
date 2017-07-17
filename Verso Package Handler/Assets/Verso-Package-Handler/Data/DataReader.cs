using System.Collections;
using System.Collections.Generic;
using System;
using System.Xml;
using System.IO;

using UnityEngine;
using UnityEditor;

/// <summary>
/// Interpretador de leitura dos dados em XML.
/// </summary>
public class DataReader : Data
{
    /// <summary>
    /// Read XML
    /// </summary>
    public void ReadXML()
    {
        file = LoadXMLFile();
        Debug.Log("Arquivo carregado");
    }
}
