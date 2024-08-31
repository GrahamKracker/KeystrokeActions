using System;
using KeystrokeActions.Actions.Normal;
using UnityEngine;

namespace KeystrokeActions;

[RegisterTypeInIl2Cpp(false)]
public class TowerScaler(IntPtr ptr) : MonoBehaviour(ptr)
{
    private void LateUpdate()
    {
        transform.localScale = new Vector3(MonkeysGrow.TowerScale, MonkeysGrow.TowerScale, MonkeysGrow.TowerScale);
    }
}