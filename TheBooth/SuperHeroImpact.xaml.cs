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
using Microsoft.Kinect.Input;
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
    /// Interaction logic for SuperHeroImpact.xaml
    /// </summary>
    public partial class SuperHeroImpact : UserControl
    {
        public delegate void SelectionEvent(object sender);
        public event SelectionEvent nextEvent;
        public KinectCoreWindow window;

        public static bool JUSTICE = false;
        public static bool CLARITY = false;
        public static bool PASSION = false;
        public static bool UNDERSTANDING = false;
        public static bool LOVE = false;
        public static bool PEACE = false;
        public static bool RESPECT = false;
        public static bool ACCEPTANCE = false;
        public static bool JOY = false;
        public static bool KINDNESS = false;

        public SuperHeroImpact()
        {
            InitializeComponent();
            
            
            setTexts();
        }
        public void loadImpact()
        {
            this.Visibility = Visibility.Visible;
            window = KinectCoreWindow.GetForCurrentThread();
            window.PointerMoved += window_PointerMoved;
            kinectRegion.Height = 800;
            kinectRegion.Width = 1200;
        }

        public void resetbooleans()
        {
            JUSTICE = false;
            CLARITY = false;
            PASSION = false;
            UNDERSTANDING = false;
            LOVE = false;
            PEACE = false;
            RESPECT = false;
            ACCEPTANCE = false;
            JOY = false;
            KINDNESS = false;
        }

        private void window_PointerMoved(object sender, KinectPointerEventArgs e)
        {
            try
            {
                var uriSource = new Uri(@"/TheBooth;component/Images/Button_start.png", UriKind.Relative);

                if (this.Visibility == Visibility.Visible)
                {

                    if ((!BodyFramePreAnalysis.rightHandUp && e.CurrentPoint.Properties.HandType == HandType.LEFT) ||
                     (BodyFramePreAnalysis.rightHandUp && e.CurrentPoint.Properties.HandType == HandType.RIGHT))
                    {
                        if (e.CurrentPoint.Position.X * this.ActualWidth > Canvas.GetLeft(nextButton) && e.CurrentPoint.Position.X * this.ActualWidth < Canvas.GetLeft(nextButton) + nextButton.Width
                       && e.CurrentPoint.Position.Y * this.ActualHeight > Canvas.GetTop(nextButton) && e.CurrentPoint.Position.Y * this.ActualHeight < Canvas.GetTop(nextButton) + nextButton.Height)
                        {
                            uriSource = new Uri(@"/TheBooth;component/Images/Button_next_hover.png", UriKind.Relative);
                            imgButton.Source = new BitmapImage(uriSource);
                        }
                        else
                        {
                            uriSource = new Uri(@"/TheBooth;component/Images/Button_next.png", UriKind.Relative);
                            imgButton.Source = new BitmapImage(uriSource);
                        }

                    }
                    if (nextButton.Visibility == Visibility.Visible && this.Visibility == System.Windows.Visibility.Visible)
                    {
                        if (HeroAnalysis.nextCommand == true)
                        {
                            Button_Click(null, null);
                        }
                    }
                    else if (this.Visibility == Visibility.Visible)
                    {
                        HeroAnalysis.nextCommand = false;
                    }
                }
            }
            catch
            {

            }
            
        }



       

        private void setTexts()
        {
           

            drop1.setText("", "Justice");
            drop2.setText("", "Clarity");
            drop3.setText("", "Passion");
            drop4.setText("", "Understanding");
            drop5.setText("", "Love");
            drop6.setText("", "Peace");
            drop7.setText("", "Respect");
            drop8.setText("", "Acceptance");
            drop9.setText("", "Joy");
            drop10.setText("", "Kindness");

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            HeroAnalysis.nextCommand = false;
            window.PointerMoved -= window_PointerMoved;
            nextEvent(this);
            this.Visibility = Visibility.Collapsed;
        }
    }
}
