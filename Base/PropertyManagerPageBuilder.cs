//**********************
//SwEx.PMPage - data driven framework for SOLIDWORKS Property Manager Pages
//Copyright(C) 2019 www.codestack.net
//License: https://github.com/codestackdev/swex-pmpage/blob/master/LICENSE
//Product URL: https://www.codestack.net/labs/solidworks/swex/pmp/
//**********************

using CodeStack.SwEx.Common.Icons;
using CodeStack.SwEx.PMPage.Constructors;
using CodeStack.SwEx.PMPage.Controls;
using SolidWorks.Interop.sldworks;
using Xarial.VPages.Core;
using Xarial.VPages.Framework.Base;
using Xarial.VPages.Framework.Binders;
using Xarial.VPages.Framework.PageElements;
using System.Linq;
using System.Collections.Generic;
using CodeStack.SwEx.Common.Diagnostics;
using System;
using CodeStack.SwEx.PMPage.Base;
using CodeStack.SwEx.PMPage.Attributes;
using CodeStack.SwEx.PMPage.Data;
using System.Reflection;

namespace CodeStack.SwEx.PMPage
{
    internal class PropertyManagerPageBuilder<THandler>
        : PageBuilder<PropertyManagerPagePageEx<THandler>, PropertyManagerPageGroupEx<THandler>, IPropertyManagerPageControlEx>
        where THandler : PropertyManagerPageHandlerEx, new()
    {
        private class PmpTypeDataBinder : TypeDataBinder
        {
            internal event Action<IEnumerable<IBinding>> BeforeControlsDataLoad;
            internal event Func<IAttributeSet, IAttributeSet> GetPageAttributeSet;
            protected override void OnBeforeControlsDataLoad(IEnumerable<IBinding> bindings)
            {
                base.OnBeforeControlsDataLoad(bindings);

                BeforeControlsDataLoad?.Invoke(bindings);
            }

            protected override void OnGetPageAttributeSet(Type pageType, ref IAttributeSet attSet)
            {
                attSet = GetPageAttributeSet?.Invoke(attSet);
            }
        }

        private class PmpAttributeSet : IAttributeSet
        {
            private readonly IAttributeSet m_BaseAttSet;
            private readonly string m_Title;

            public Type BoundType => m_BaseAttSet.BoundType;
            public string Description => m_BaseAttSet.Description;
            public int Id => m_BaseAttSet.Id;
            public string Name => m_Title;
            public object Tag => m_BaseAttSet.Tag;
            public MemberInfo BoundMemberInfo => m_BaseAttSet.BoundMemberInfo;

            public void Add<TAtt>(TAtt att) where TAtt : Xarial.VPages.Framework.Base.IAttribute
            {
                m_BaseAttSet.Add<TAtt>(att);
            }

            public TAtt Get<TAtt>() where TAtt : Xarial.VPages.Framework.Base.IAttribute
            {
                return m_BaseAttSet.Get<TAtt>();
            }

            public IEnumerable<TAtt> GetAll<TAtt>() where TAtt : Xarial.VPages.Framework.Base.IAttribute
            {
                return m_BaseAttSet.GetAll<TAtt>();
            }

            public bool Has<TAtt>() where TAtt : Xarial.VPages.Framework.Base.IAttribute
            {
                return m_BaseAttSet.Has<TAtt>();
            }
            
            internal PmpAttributeSet(IAttributeSet baseAttSet, IPageSpec pageSpec)
            {
                m_BaseAttSet = baseAttSet;

                if (!Has<PageOptionsAttribute>())
                {
                    Add(new PageOptionsAttribute(new TitleIcon(pageSpec.Icon), pageSpec.Options));
                }

                if (string.IsNullOrEmpty(baseAttSet.Name) 
                    || baseAttSet.Name == BoundType.Name)
                {
                    m_Title = pageSpec.Title;
                }
                else
                {
                    m_Title = baseAttSet.Name;
                }
            }
        }

        private readonly IPropertyManagerPageElementConstructor<THandler>[] m_CtrlsContstrs;
        private readonly PmpTypeDataBinder m_DataBinder;
        private readonly IPageSpec m_PageSpec;

        internal PropertyManagerPageBuilder(ISldWorks app, IconsConverter iconsConv, THandler handler, IPageSpec pageSpec, ILogger logger)
            : this(new PmpTypeDataBinder(), 
                  new PropertyManagerPageConstructor<THandler>(app, iconsConv, handler),
                  new PropertyManagerPageGroupConstructor<THandler>(),
                  new PropertyManagerPageTextBoxConstructor<THandler>(iconsConv),
                  new PropertyManagerPageNumberBoxConstructor<THandler>(iconsConv),
                  new PropertyManagerPageCheckBoxConstructor<THandler>(iconsConv),
                  new PropertyManagerPageComboBoxConstructor<THandler>(iconsConv),
                  new PropertyManagerPageSelectionBoxConstructor<THandler>(app, iconsConv, logger),
                  new PropertyManagerPageOptionBoxConstructor<THandler>(iconsConv),
                  new PropertyManagerPageButtonConstructor<THandler>(iconsConv),
                  new PropertyManagerPageBitmapConstructor<THandler>(iconsConv))
        {
            m_PageSpec = pageSpec;
        }

        private PropertyManagerPageBuilder(PmpTypeDataBinder dataBinder, PropertyManagerPageConstructor<THandler> pageConstr,
            params IPropertyManagerPageElementConstructor<THandler>[] ctrlsContstrs)
            : base(dataBinder, pageConstr, ctrlsContstrs)
        {
            m_DataBinder = dataBinder;
            m_CtrlsContstrs = ctrlsContstrs;

            m_DataBinder.GetPageAttributeSet += OnGetPageAttributeSet;
            m_DataBinder.BeforeControlsDataLoad += OnBeforeControlsDataLoad;
        }

        private IAttributeSet OnGetPageAttributeSet(IAttributeSet attSet)
        {
            if (m_PageSpec != null)
            {
                return new PmpAttributeSet(attSet, m_PageSpec);
            }

            return attSet;
        }

        private void OnBeforeControlsDataLoad(IEnumerable<IBinding> bindings)
        {
            var ctrls = bindings.Select(b => b.Control)
                .OfType<IPropertyManagerPageControlEx>().ToArray();

            foreach (var ctrlGroup in ctrls.GroupBy(c => c.GetType()))
            {
                foreach (var constr in m_CtrlsContstrs.Where(c => c.ControlType == ctrlGroup.Key))
                {
                    constr.PostProcessControls(ctrlGroup);
                }
            }
        }

        protected override void UpdatePageDependenciesState(PropertyManagerPagePageEx<THandler> page)
        {
            //NOTE: skipping the updated before page is shown otherwise control state won't be updated correctly
            //instead updating it with UpdateAll after page is shown
        }
    }
}
