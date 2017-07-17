using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Dados de sombra
/// </summary>
public struct ShadowInfos
{
    public SHADOWTYPE type;

    public float strength;
    public float bias;
    public float normalBias;
    public float nearPlane;
}

/// <summary>
/// Tipos de sombra
/// </summary>
public enum SHADOWTYPE
{
    NO_SHADOWS,
    HARD_SHADOWS,
    SOFT_SHADOWS
}
