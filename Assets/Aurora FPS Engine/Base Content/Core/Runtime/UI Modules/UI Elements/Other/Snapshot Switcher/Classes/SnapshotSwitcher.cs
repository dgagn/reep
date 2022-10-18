/* ================================================================
   ----------------------------------------------------------------
   Project   :   Aurora FPS Engine
   Publisher :   Infinite Dawn
   Developer :   Tamerlan Shakirov
   ----------------------------------------------------------------
   Copyright © 2017 Tamerlan Shakirov All rights reserved.
   ================================================================ */

using AuroraFPSRuntime.Attributes;
using UnityEngine;
using UnityEngine.Audio;

namespace AuroraFPSRuntime.UIModules.UIElements
{
    [HideScriptField]
    [AddComponentMenu("Aurora FPS Engine/UI Modules/UI Elements/Event Wrappers/Snapshot Switcher")]
    public sealed class SnapshotSwitcher : MonoBehaviour
    {
        [SerializeField]
        private AudioMixerSnapshot game;

        [SerializeField]
        private AudioMixerSnapshot pause;

        [SerializeField]
        private float duration = 1.0f;

        public void Paused(bool value)
        {
            if (value)
                pause.TransitionTo(duration);
            else
                game.TransitionTo(duration);
        }

        public AudioMixerSnapshot GetGameSnapshot()
        {
            return game;
        }

        public void SetGameSnapshot(AudioMixerSnapshot value)
        {
            game = value;
        }

        public AudioMixerSnapshot GetPauseSnapshot()
        {
            return pause;
        }

        public void SetPauseSnapshot(AudioMixerSnapshot value)
        {
            pause = value;
        }

        public float GetTransitionDuration()
        {
            return duration;
        }

        public void SetTransitionDuration(float value)
        {
            duration = value;
        }
    }
}
