using System;
using UnityEngine;

namespace Utility
{
    [CreateAssetMenu]
	public sealed class CommonSO : ScriptableObject
	{
        public float PlayerSpeed = 20f;
        public SoundCollection SoundCollection;
    }

    [Serializable]
    public sealed class SoundCollection
    {
        public SoundData[] Sounds;

        [Serializable]
        public class SoundData
        {
            public Sound Sound;
            public AudioClip Clip;
            [Range(0f, 1f)]
            public float Volume;
            [Range(.1f, 3f)]
            public float Pitch;
            [HideInInspector]
            public AudioSource Source;
            public bool Loop;
        }
    }

}