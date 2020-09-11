using System;
using System.Collections.Generic;
using System.Text;

namespace Cube.Enums
{
    /// <summary>
    /// Instruction on which part of the cube that should be turned
    /// </summary>
    public enum CubeNotation
    {
        /// <summary>
        /// Left clockwise
        /// </summary>
        LC,

        /// <summary>
        /// Left counter clockwise
        /// </summary>
        LCC,

        /// <summary>
        /// Right clockwise
        /// </summary>
        RC,

        /// <summary>
        /// Right counter clockwise
        /// </summary>
        RCC,

        /// <summary>
        /// Up clockwise
        /// </summary>
        UC,

        /// <summary>
        /// Up counter clockwise
        /// </summary>
        UCC,

        /// <summary>
        /// Down clockwise
        /// </summary>
        DC,

        /// <summary>
        /// Down counter clockwise
        /// </summary>
        DCC,

        /// <summary>
        /// Front clockwise
        /// </summary>
        FC,

        /// <summary>
        /// Front counter clockwise
        /// </summary>
        FCC,

        /// <summary>
        /// Back clockwise
        /// </summary>
        BC,

        /// <summary>
        /// Back counter clockwise
        /// </summary>
        BCC
    }
}
