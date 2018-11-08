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
        internal swAddControlOptions_e Options { get; private set; }
        internal swPropertyManagerPageControlLeftAlign_e Align { get; private set; }
        internal KnownColor BackgroundColor { get; private set; }
        internal KnownColor TextColor { get; private set; }
        internal short Left { get; private set; }
        internal short Top { get; private set; }
        internal short Width { get; private set; }
        internal short Height { get; private set; }
        internal swPropMgrPageControlOnResizeOptions_e ResizeOptions { get; private set; }

        /// <summary>
        /// Constructor allowing to specify control common parameters
        /// </summary>
        /// <param name="opts">Generic control options as defined in <see href="http://help.solidworks.com/2016/english/api/swconst/solidworks.interop.swconst~solidworks.interop.swconst.swaddcontroloptions_e.html">swAddControlOptions_e Enumeration</see></param>
        /// <param name="align">Control alignment options as defined in <see href="http://help.solidworks.com/2016/english/api/swconst/solidworks.interop.swconst~solidworks.interop.swconst.swpropertymanagerpagecontrolleftalign_e.html">swPropertyManagerPageControlLeftAlign_e Enumeration</see></param>
        /// <param name="backgroundColor">Background color of control. Use 0 for default color</param>
        /// <param name="textColor">Color of the text on the control. Use 0 for default color</param>
        /// <param name="left">Left alignment of the control. Use -1 for default alignment</param>
        /// <param name="top">Top alignment of the control. Use -1 to align the control under the previous control</param>
        /// <param name="width">Width of the control. Use -1 for auto width</param>
        /// <param name="height">Height of the control in property manager page dialog box units. Use -1 for the auto height</param>
        /// <param name="resizeOptions">Options to resize as defined in <see href="http://help.solidworks.com/2016/english/api/swconst/solidworks.interop.swconst~solidworks.interop.swconst.swpropmgrpagecontrolonresizeoptions_e.html">swPropMgrPageControlOnResizeOptions_e Enumeration</see></param>
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
