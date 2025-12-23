using UnityEngine;
using UnityEngine.UI;
using UnityUtils.ScriptUtils;
using UnityUtils.ScriptUtils.Objects;
using UnityEngine.SceneManagement;
using UnityUtils.ScriptUtils.Cameras;

public class TestingScript2 : MonoBehaviour
{
    private void Start()
    {
        ObjectDelays.CallFunctionAfterTime(() => CameraShake.Screenshake(intensity: 5), 3);
        ObjectDelays.CallFunctionAfterTime(() => GetComponent<ObjectColorFlash>().FlashColor(Color.blue, 2), 3);
    }
}
