﻿/* ================================================================
   ----------------------------------------------------------------
   Project   :   Aurora FPS Engine
   Publisher :   Infinite Dawn
   Developer :   Tamerlan Shakirov, Deryabin Vladimir
   ----------------------------------------------------------------
   Copyright © 2017 Tamerlan Shakirov All rights reserved.
   ================================================================ */

using UnityEngine;

namespace AuroraFPSRuntime.SystemModules.ControllerSystems
{
    public interface IControllerBounds
    {
        /// <summary>
        /// Copy controller collider bounds.
        /// </summary>
        /// <param name="center">Controller collider center.</param>
        /// <param name="height">Controller collider height.</param>
        void CopyBounds(out Vector3 center, out float height);

        /// <summary>
        /// Edit current controller collider bounds.
        /// </summary>
        /// <param name="center">Controller collider center.</param>
        /// <param name="height">Controller collider height.</param>
        void EditBounds(Vector3 center, float height);
    }
}