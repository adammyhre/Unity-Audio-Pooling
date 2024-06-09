# Unity Audio Pooling
![SoundPooling](https://github.com/adammyhre/Unity-Audio-Pooling/assets/38876398/eeac93e7-1ba4-45d9-bf08-200f2c980428)

Take control of the sounds in your game by pooling your Audio Sources! Reduce the number of real voices required to play a multitude of audio clips, manage their lifecycle, and enhance performance. Learn how to streamline your audio management and make your game sound fantastic with efficient audio source pooling!

## Example Usage

1. Create a prefab with a `SoundEmitter` component for pooling.
2. Add a `SoundManager` component to a new empty Game Object in your project.
3. Add an Audio Mixer with at least one channel.
4. Add a `SoundData` field with references to an `AudioClip` and an `AudioMixerGroup`

```csharp
[SerializeField] SoundData soundData;

SoundManager.Instance.CreateSound()
    .WithSoundData(soundData)
    .WithRandomPitch()
    .WithPosition(transform.position)
    .Play();
}
```

## YouTube

- [Game Audio Optimization in Unity](#)

You can also check out my [YouTube channel](https://www.youtube.com/@git-amend?sub_confirmation=1) for more Unity content.
