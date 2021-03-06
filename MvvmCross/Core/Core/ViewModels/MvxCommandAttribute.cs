﻿// MvxCommandAttribute.cs

// MvvmCross is licensed using Microsoft Public License (Ms-PL)
// Contributions and inspirations noted in readme.md and license.txt
//
// Project Lead - Stuart Lodge, @slodge, me@slodge.com

using System;

namespace MvvmCross.Core.ViewModels
{
    [AttributeUsage(AttributeTargets.Method)]
    public class MvxCommandAttribute : Attribute
    {
        public MvxCommandAttribute(string commandName, string canExecutePropertyName = null)
        {
            CanExecutePropertyName = canExecutePropertyName;
            CommandName = commandName;
        }

        public string CommandName { get; set; }
        public string CanExecutePropertyName { get; set; }
    }
}