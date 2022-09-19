﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Vigicom.ViewModels;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Vigicom.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CreateAccountPage : ContentPage
    {
        public CreateAccountPage()
        {
            InitializeComponent();
            BindingContext = new CreateAccountViewModel(Navigation);
        }
    }
}