/* ================================================================
   ----------------------------------------------------------------
   Project   :   Apex Inspector
   Publisher :   Infinite Dawn
   Developer :   Tamerlan Shakirov
   ----------------------------------------------------------------
   Copyright © 2017 Tamerlan Shakirov All rights reserved.
   ================================================================ */

namespace AuroraFPSRuntime.CoreModules.InputSystem
{
    public interface IInputListener
    {
        /// <summary>
        /// Register required input actions.
        /// </summary>
        void RegisterInputActions();

        /// <summary>
        /// Remove registered input actions.
        /// </summary>
        void RemoveInputActions();
    }
}