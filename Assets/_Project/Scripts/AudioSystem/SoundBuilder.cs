using UnityEngine;

namespace AudioSystem {
    public class SoundBuilder {
        readonly SoundManager soundManager;
        Vector3 position = Vector3.zero;
        bool randomPitch;

        public SoundBuilder(SoundManager soundManager) {
            this.soundManager = soundManager;
        }

        public SoundBuilder WithPosition(Vector3 position) {
            this.position = position;
            return this;
        }

        public SoundBuilder WithRandomPitch() {
            this.randomPitch = true;
            return this;
        }

        public void Play(SoundData soundData) {
            if (soundData == null) {
                Debug.LogError("SoundData is null");
                return;
            }
            
            if (!soundManager.CanPlaySound(soundData)) return;
            
            SoundEmitter soundEmitter = soundManager.Get();
            soundEmitter.Initialize(soundData);
            soundEmitter.transform.position = position;
            soundEmitter.transform.parent = soundManager.transform;

            if (randomPitch) {
                soundEmitter.WithRandomPitch();
            }

            if (soundData.frequentSound) {
                soundEmitter.Node = soundManager.FrequentSoundEmitters.AddLast(soundEmitter);
            }
            
            soundEmitter.Play();
        }
    }
}