﻿using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace C18_Ex01_Gregory_317612950_Mariya_321373136
{
    public abstract partial class Widget : UserControl
    {
        public List<EventHandler> WidgetEvents = new List<EventHandler>();

        public string WidgetName{ get; set; }
        public string WidgetTitle
        {
            get
            {
                return Title.Text;
            }
            set
            {
                Title.Text = value;
            }
        }

        public Widget()
        {
            InitializeComponent();
        }

        public abstract void Update(params object[] str);

        protected void ClearWidgetContainer<T>(List<T> i_Controlls = null)
        {
            if (i_Controlls != null)
            {
                foreach (T item in i_Controlls)
                {
                    Control control = item as Control;
                    WidgetContainer.Controls.Remove(control);
                    control.Dispose();
                }
            }

        }

        public void ClearWidgetContainer()
        {
            WidgetContainer.Controls.Clear();
        }

    }
}
