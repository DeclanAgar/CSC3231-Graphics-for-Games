using UnityEngine;
using UnityEngine.UI;
using Unity.Profiling;

public class UserInterface : MonoBehaviour
{
    // Text fields to be updated
    [SerializeField]
    Text framerate;
    [SerializeField]
    Text totalMemory;
    [SerializeField]
    Text reservedMemory;

    // ProfilerRecorder objects
    private ProfilerRecorder memoryUsage;
    private ProfilerRecorder memoryReserved;

    private float timer;

    // Start is called before the first frame update
    private void Start()
    {
        // Set values to be equal to used and reserved memory values
        memoryUsage = ProfilerRecorder.StartNew(ProfilerCategory.Memory, "Total Used Memory");
        memoryReserved = ProfilerRecorder.StartNew(ProfilerCategory.Memory, "Total Reserved Memory");
    }

    // Update is called once per frame
    private void Update()
    {
        timer += Time.unscaledDeltaTime;

        // Update framerate every half second
        if (timer > 0.5)
        {
            timer = 0;
            framerate.text = (1 / Time.unscaledDeltaTime).ToString("0"); // 1 / time since last frame gives amount of frames per second
        }

        // Convert values of memory into kB
        totalMemory.text = (memoryUsage.LastValue / 1000).ToString() + "kB";
        reservedMemory.text = (memoryReserved.LastValue / 1000).ToString() + "kB";
    }
}
