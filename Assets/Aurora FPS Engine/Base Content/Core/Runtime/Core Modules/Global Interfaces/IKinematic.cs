﻿/* ================================================================
   ----------------------------------------------------------------
   Project   :   Aurora FPS Engine
   Publisher :   Infinite Dawn
   Developer :   Tamerlan Shakirov
   ----------------------------------------------------------------
   Copyright © 2017 Tamerlan Shakirov All rights reserved.
   ================================================================ */

namespace AuroraFPSRuntime.CoreModules
{
    public interface IKinematic
    {
        void IsKinematic(bool value);
        bool IsKinematic();
    }
}