﻿/**
 * ****************************************************************************
 * Copyright (C) 2016 Open Universiteit Nederland
 * <p/>
 * This library is free software: you can redistribute it and/or modify
 * it under the terms of the GNU Lesser General Public License as published by
 * the Free Software Foundation, either version 3 of the License, or
 * (at your option) any later version.
 * <p/>
 * This library is distributed in the hope that it will be useful,
 * but WITHOUT ANY WARRANTY; without even the implied warranty of
 * MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
 * GNU Lesser General Public License for more details.
 * <p/>
 * You should have received a copy of the GNU Lesser General Public License
 * along with this library.  If not, see <http://www.gnu.org/licenses/>.
 * <p/>
 * Contributors: Jan Schneider
 * ****************************************************************************
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace TheBooth
{
    /// <summary>
    /// Interaction logic for ValueSelection.xaml
    /// </summary>
    public partial class ValueSelection : UserControl
    {


        public delegate void SelectionEvent(object sender, string x);
        public event SelectionEvent selectionEvent;
        public string value;
        public ValueSelection()
        {
            InitializeComponent();
            
        }

        private void GoTo_Click(object sender, RoutedEventArgs e)
        {
            value = ((Button)sender).Content.ToString();
            try
            {
                selectionEvent(this, value);
            }
            catch
            {

            }
           
        }
    }
}
