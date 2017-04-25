﻿using System;
using EZReporting.Attributes;
using EZReporting.Data;
using EZReporting.Interface;

namespace EZReporting.Implementation {

    /// <summary>
    //++ DefaultRenderer
    ///
    //+  Purpose:
    ///     Default implementation of IRenderer.
    /// </summary>
    [ImplementationDescriptor(category: ImplementationCategory.Renderer, @interface: typeof(IRenderer))]
    public class DefaultRenderer : IRenderer {

        #region IRenderer

        public string Render(Report report, int userID) {
            throw new NotImplementedException();
        }

        public bool CanRender(Report report) {
            throw new NotImplementedException();
        }

        #endregion

    }
}