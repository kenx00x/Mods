using UnityEngine;

namespace SuchArt_VR.Helpers
{
    class Logs
    {
        public static void WriteInfo(object data)
        {
#if DEBUG
            Debug.Log(data);
#endif
        }

        public static void WriteWarning(object data)
        {
#if DEBUG
            Debug.LogWarning(data);
#endif
        }

        public static void WriteError(object data)
        {
#if DEBUG
            Debug.LogError(data);
#endif
        }
    }
}
