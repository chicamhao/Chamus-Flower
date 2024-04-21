using UnityEngine;
using System;
using UnityEngine.Assertions;

namespace Utility
{
    public class Audio 
    {
        public static Audio Instance => DIContainer.Get<Audio>();

        private readonly SoundCollection _data;

        public Audio(SoundCollection data, GameObject container)
        {
            Assert.IsNotNull(data);
            _data = data;

            foreach (var s in _data.Sounds)
            {
                var source = s.Source = container.AddComponent<AudioSource>();
                source.clip = s.Clip;
                source.volume = s.Volume;
                source.pitch = s.Pitch;
                source.loop = s.Loop;
            }
        }

        public void Play(Sound sound)
        {
            Find(sound).Play();
        }

        public void Pause(Sound sound)
        {
            Find(sound).Pause();
        }

        private AudioSource Find(Sound sound)
        {
            // improvement: consider using a dictionary
            foreach (var s in Instance._data.Sounds)
            {
                if (s.Sound == sound)
                {
                    return s.Source;
                }
            }
            throw new InvalidOperationException($"Can't find sound {sound}.");
        }
    }

    public enum Sound
    {
        Background,
        Teddy,
        Cupboard,
        Toilet,
        Key,
        Door,
        Screaming,
        Finding,
        TV,
        IntoRoom
    }
}