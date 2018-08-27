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

namespace CodeStack.SwEx.Pmp.Attributes
{
    public class PropertyManagerPageControlOptionsAttribute : Attribute, IAttribute
    {
        public swAddControlOptions_e Options { get; private set; }
        public swPropertyManagerPageControlLeftAlign_e Align { get; private set; }
        public KnownColor BackgroundColor { get; private set; }
        public KnownColor TextColor { get; private set; }
        public short Left { get; private set; }
        public short Top { get; private set; }
        public short Width { get; private set; }
        public swPropMgrPageControlOnResizeOptions_e ResizeOptions { get; private set; }

        public PropertyManagerPageControlOptionsAttribute(
            swAddControlOptions_e opts = swAddControlOptions_e.swControlOptions_Enabled | swAddControlOptions_e.swControlOptions_Visible,
            swPropertyManagerPageControlLeftAlign_e align = swPropertyManagerPageControlLeftAlign_e.swControlAlign_LeftEdge,
            KnownColor backgroundColor = 0, KnownColor textColor = 0, short left = -1, short top = -1, short width = -1,
            swPropMgrPageControlOnResizeOptions_e resizeOptions = 0)
        {
            Options = opts;
            Align = align;
            BackgroundColor = backgroundColor;
            TextColor = textColor;
            Left = left;
            Top = top;
            Width = width;
            ResizeOptions = resizeOptions;
        }
    }
}
