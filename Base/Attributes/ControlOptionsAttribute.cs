//**********************
//SwEx.Pmp
//Copyright(C) 2018 www.codestack.net
//License: https://github.com/codestack-net-dev/vpages-sw/blob/master/LICENSE
//Product URL: https://www.codestack.net/labs/solidworks/swex/pmp/
//**********************

using SolidWorks.Interop.swconst;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using Xarial.VPages.Framework.Base;

namespace CodeStack.SwEx.PMPage.Attributes
{
    /// <summary>
    /// Generic options for all controls
    /// </summary>
    public class ControlOptionsAttribute : Attribute, IAttribute
    {
        /// <summary>
        /// Generic control options as defined in <see href="http://help.solidworks.com/2016/english/api/swconst/solidworks.interop.swconst~solidworks.interop.swconst.swaddcontroloptions_e.html">swAddControlOptions_e Enumeration</see>
        /// </summary>
        public swAddControlOptions_e Options { get; private set; }

        /// <summary>
        /// Control alignment options as defined in <see href="http://help.solidworks.com/2016/english/api/swconst/solidworks.interop.swconst~solidworks.interop.swconst.swpropertymanagerpagecontrolleftalign_e.html">swPropertyManagerPageControlLeftAlign_e Enumeration</see>
        /// </summary>
        public swPropertyManagerPageControlLeftAlign_e Align { get; private set; }

        /// <summary>
        /// Background color of control
        /// </summary>
        /// <remarks>Use 0 for default color</remarks>
        public KnownColor BackgroundColor { get; private set; }

        /// <summary>
        /// Color of the text on the control
        /// </summary>
        /// <remarks>Use 0 for default color</remarks>
        public KnownColor TextColor { get; private set; }

        /// <summary>
        /// Left alignment of the control
        /// </summary>
        /// -1 for default alignment
        public short Left { get; private set; }

        /// <summary>
        /// Top alignment of the control
        /// </summary>
        /// <remarks>Use -1 to align the control under the previous control</remarks>
        public short Top { get; private set; }

        /// <summary>
        /// Width of the control
        /// </summary>
        /// <remarks>-1 for auto width</remarks>
        public short Width { get; private set; }

        /// <summary>
        /// Height of the control in property manager page dialog box units
        /// </summary>
        /// <remarks>Use -1 for the auto height</remarks>
        public short Height { get; private set; }

        /// <summary>
        /// Options to resize as defined in <see href="http://help.solidworks.com/2016/english/api/swconst/solidworks.interop.swconst~solidworks.interop.swconst.swpropmgrpagecontrolonresizeoptions_e.html">swPropMgrPageControlOnResizeOptions_e Enumeration</see>
        /// </summary>
        public swPropMgrPageControlOnResizeOptions_e ResizeOptions { get; private set; }

        public ControlOptionsAttribute(
            swAddControlOptions_e opts = swAddControlOptions_e.swControlOptions_Enabled | swAddControlOptions_e.swControlOptions_Visible,
            swPropertyManagerPageControlLeftAlign_e align = swPropertyManagerPageControlLeftAlign_e.swControlAlign_LeftEdge,
            KnownColor backgroundColor = 0, KnownColor textColor = 0, short left = -1, short top = -1, short width = -1, short height = -1,
            swPropMgrPageControlOnResizeOptions_e resizeOptions = 0)
        {
            Options = opts;
            Align = align;
            BackgroundColor = backgroundColor;
            TextColor = textColor;
            Left = left;
            Top = top;
            Width = width;
            Height = height;
            ResizeOptions = resizeOptions;
        }
    }
}
