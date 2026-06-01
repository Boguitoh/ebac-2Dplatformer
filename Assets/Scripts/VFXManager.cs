using ebac.Core.Singleton;
using NUnit.Framework;
using System.Collections.Generic;
using UnityEngine;

public class VFXManager : Singleton<VFXManager>
{
    public List<VFXManagerSetup> vfxSetup;

    public enum VFXType
    {
        JUMP,
        VFX_2
    }

    public void PlayVFXByType(VFXType vfxType, Vector3 position)
    {
        foreach (var i in vfxSetup)
        {
            if(i.vfxType == vfxType)
            {
                var item = Instantiate(i.prefab);
                item.transform.position = position;
                Destroy(item.gameObject, 5f);
                break;
            }
        }
    }
}

[System.Serializable]
public class VFXManagerSetup
{
    public VFXManager.VFXType vfxType;
    public GameObject prefab;
}