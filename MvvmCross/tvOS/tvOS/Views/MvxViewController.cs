﻿// MvxViewController.cs

// MvvmCross is licensed using Microsoft Public License (Ms-PL)
// Contributions and inspirations noted in readme.md and license.txt
//
// Project Lead - Stuart Lodge, @slodge, me@slodge.com

using System;
using Foundation;
using MvvmCross.Binding.BindingContext;
using MvvmCross.Core.ViewModels;
using MvvmCross.Platform.tvOS.Views;
using UIKit;

namespace MvvmCross.tvOS.Views
{
    public class MvxViewController
        : MvxEventSourceViewController, IMvxTvosView
    {
        public MvxViewController()
        {
            this.AdaptForBinding();
        }

        public MvxViewController(IntPtr handle)
            : base(handle)
        {
            this.AdaptForBinding();
        }

        protected MvxViewController(string nibName, NSBundle bundle)
            : base(nibName, bundle)
        {
            this.AdaptForBinding();
        }

        public object DataContext
        {
            get { return BindingContext.DataContext; }
            set { BindingContext.DataContext = value; }
        }

        public IMvxViewModel ViewModel
        {
            get { return DataContext as IMvxViewModel; }
            set { DataContext = value; }
        }

        public MvxViewModelRequest Request { get; set; }

        public IMvxBindingContext BindingContext { get; set; }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();
            ViewModel?.ViewCreated();
        }

        public override void ViewWillAppear(bool animated)
        {
            base.ViewWillAppear(animated);
            ViewModel?.ViewAppearing();
        }

        public override void ViewDidAppear(bool animated)
        {
            base.ViewDidAppear(animated);
            ViewModel?.ViewAppeared();
        }

        public override void ViewWillDisappear(bool animated)
        {
            base.ViewWillDisappear(animated);
            ViewModel?.ViewDisappearing();
        }

        public override void ViewDidDisappear(bool animated)
        {
            base.ViewDidDisappear(animated);
            ViewModel?.ViewDisappeared();
        }

        public override void DidMoveToParentViewController(UIViewController parent)
        {
            base.DidMoveToParentViewController(parent);
            if(parent == null)
            {
                ViewModel?.ViewDestroy();
            }
        }

        public override void PrepareForSegue(UIStoryboardSegue segue, NSObject sender)
        {
            base.PrepareForSegue(segue, sender);
            this.ViewModelRequestForSegue(segue, sender);
        }
    }

    public class MvxViewController<TViewModel>
        : MvxViewController, IMvxTvosView<TViewModel> where TViewModel : class, IMvxViewModel
    {
        public MvxViewController()
        {
        }

        public MvxViewController(IntPtr handle)
            : base(handle)
        {
        }

        protected MvxViewController(string nibName, NSBundle bundle)
            : base(nibName, bundle)
        {
        }

        public new TViewModel ViewModel
        {
            get { return (TViewModel)base.ViewModel; }
            set { base.ViewModel = value; }
        }
    }
}