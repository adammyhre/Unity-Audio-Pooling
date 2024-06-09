using UnityEngine;

namespace AudioSystem {
    public static class AudioExtensions {
        /// <summary>
        /// Converts a float value representing a volume slider position into a logarithmic volume,
        /// giving us a smoother and more natural-sounding progression when a volume slider is moved.
        /// The math here performs the following steps:
        /// - Ensures the slider value is equal to or greater than 0.0001 to avoid passing 0 to the logarithm function.
        /// - Takes the base-10 logarithm of the slider value.
        /// - Multiplies the result by 20. In audio engineering, a change of 1 unit in a dB scale is approximately equivalent 
        ///   to what the human ear perceives as a doubling or halving of the volume, hence the multiplication by 20.
        ///
        /// This method is useful for normalizing UI Volume Sliders used with Unity's Audio Mixer.
        /// </summary>
        public static float ToLogarithmicVolume(this float sliderValue) {
            return Mathf.Log10(Mathf.Max(sliderValue, 0.0001f)) * 20;
        }

        /// <summary>
        /// Given a fraction in the range of [0, 1], convert it to a logarithmic scale (also in range [0, 1])
        /// that mimics the way we hear volume (since human perception of sound volume is logarithmic).
        /// The math here performs the following steps:
        /// - Within the Log10 function, we're adding 9 times the original fraction to 1 before taking the logarithm. 
        ///   This makes sure that the fraction is smoothly scaled to our logarithmic curve, and it fits the range [0, 1].
        /// - Takes the base-10 logarithm of the interpolated fraction.
        /// - Divides the result by Log10(10) simply to normalize the result and ensure it fits within the [0, 1] range, 
        ///   since as we know the input to Log10 function can vary between 1 and 10 after the interpolation.
        ///
        /// This method is useful for improved fading effects between Audio Clips.
        /// </summary>
        public static float ToLogarithmicFraction(this float fraction) {
            return Mathf.Log10(1 + 9 * fraction) / Mathf.Log10(10);
        }
    }
}