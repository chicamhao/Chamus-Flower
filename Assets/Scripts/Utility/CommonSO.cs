using System;
using UnityEngine;

namespace Utility
{
    [CreateAssetMenu]
	public sealed class CommonSO : ScriptableObject
	{
        public Constants Constants;

        public Appearance Appearance;

        public SoundCollection SoundCollection;
    }

    [Serializable]
    public sealed class Constants
    {
        public float PlayerSpeed = 20f;

        // UI
        public float ConnectedPuzzleDistance = 50f;

        [TextArea(5, 5)]
        public string Newspaper_1;

        [TextArea(5, 5)]
        public string Introduction_1;
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

    [Serializable]
    public sealed class Appearance
    {
        public Data LivingRoom;
        public Data BedRoom;
        public Data Toilet;

        [Serializable]
        public sealed class Data
        {
            public Vector3 Camera;
            public Vector3 Player;
        }
    }

}