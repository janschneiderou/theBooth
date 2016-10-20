/**
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
    /// Interaction logic for SuperInspiration1.xaml
    /// </summary>
    public partial class SuperInspiration1 : UserControl
    {
        public delegate void SelectionEvent(object sender, string x);
        public event SelectionEvent selectionEvent;
        public string value;
        public KinectCoreWindow window;

        public static bool CONFIDENCE = false;
        public static bool KINDNESS = false;
        public static bool FRIENDLINESS = false;
        public static bool FUN = false;
        public static bool DISCIPLINE = false;
        public static bool COURAGE = false;
        public static bool CREATIVITY = false;
        public static bool FLEXIBILITY  = false;
        public static bool CHARM = false;
        public static bool BRIGHTNESS = false;
        public static bool HONESTY = false;
        public static bool WITTINESS = false;
        public static bool RELIABILITY = false;
        public static bool MODESTY = false;
        public static bool LOYALTY = false;

        public SuperInspiration1()
        {
            InitializeComponent();
            
            

        }
        public void loadInspiration()
        {
            this.Visibility = Visibility.Visible;
            window = KinectCoreWindow.GetForCurrentThread();
            window.PointerMoved += window_PointerMoved;
        }

        public void resetbooleans()
        {
            HeroAnalysis.nextCommand = false;
            CONFIDENCE = false;
            KINDNESS = false;
            FRIENDLINESS = false;
            FUN = false;
            DISCIPLINE = false;
            COURAGE = false;
            CREATIVITY = false;
            FLEXIBILITY  = false;
            CHARM = false;
            BRIGHTNESS = false;
            HONESTY = false;
            WITTINESS = false;
            RELIABILITY = false;
            MODESTY = false;
            LOYALTY = false;
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
                        if (e.CurrentPoint.Position.X * this.ActualWidth > Confidence.Margin.Left && e.CurrentPoint.Position.X * this.ActualWidth < Confidence.Margin.Left + Confidence.Width
                       && e.CurrentPoint.Position.Y * this.ActualHeight > Confidence.Margin.Top && e.CurrentPoint.Position.Y * this.ActualHeight < Confidence.Margin.Top + Confidence.Height)
                        {

                            Confidence.Background = new BrushConverter().ConvertFromString("#9bff43") as SolidColorBrush;

                        }
                        else
                        {
                            Confidence.Background = new BrushConverter().ConvertFromString("#262262") as SolidColorBrush;
                        }

                        if (e.CurrentPoint.Position.X * this.ActualWidth > Kind.Margin.Left && e.CurrentPoint.Position.X * this.ActualWidth < Kind.Margin.Left + Kind.Width
                       && e.CurrentPoint.Position.Y * this.ActualHeight > Kind.Margin.Top && e.CurrentPoint.Position.Y * this.ActualHeight < Kind.Margin.Top + Kind.Height)
                        {

                            Kind.Background = new BrushConverter().ConvertFromString("#9bff43") as SolidColorBrush;

                        }
                        else
                        {
                            Kind.Background = new BrushConverter().ConvertFromString("#262262") as SolidColorBrush;
                        }

                        if (e.CurrentPoint.Position.X * this.ActualWidth > Friendly.Margin.Left && e.CurrentPoint.Position.X * this.ActualWidth < Friendly.Margin.Left + Friendly.Width
                       && e.CurrentPoint.Position.Y * this.ActualHeight > Friendly.Margin.Top && e.CurrentPoint.Position.Y * this.ActualHeight < Friendly.Margin.Top + Friendly.Height)
                        {

                            Friendly.Background = new BrushConverter().ConvertFromString("#9bff43") as SolidColorBrush;

                        }
                        else
                        {
                            Friendly.Background = new BrushConverter().ConvertFromString("#262262") as SolidColorBrush;
                        }
                        if (e.CurrentPoint.Position.X * this.ActualWidth > Fun.Margin.Left && e.CurrentPoint.Position.X * this.ActualWidth < Fun.Margin.Left + Fun.Width
                       && e.CurrentPoint.Position.Y * this.ActualHeight > Fun.Margin.Top && e.CurrentPoint.Position.Y * this.ActualHeight < Fun.Margin.Top + Fun.Height)
                        {

                            Fun.Background = new BrushConverter().ConvertFromString("#9bff43") as SolidColorBrush;

                        }
                        else
                        {
                            Fun.Background = new BrushConverter().ConvertFromString("#262262") as SolidColorBrush;
                        }
                        if (e.CurrentPoint.Position.X * this.ActualWidth > Disciplined.Margin.Left && e.CurrentPoint.Position.X * this.ActualWidth < Disciplined.Margin.Left + Disciplined.Width
                       && e.CurrentPoint.Position.Y * this.ActualHeight > Disciplined.Margin.Top && e.CurrentPoint.Position.Y * this.ActualHeight < Disciplined.Margin.Top + Disciplined.Height)
                        {

                            Disciplined.Background = new BrushConverter().ConvertFromString("#9bff43") as SolidColorBrush;

                        }
                        else
                        {
                            Disciplined.Background = new BrushConverter().ConvertFromString("#262262") as SolidColorBrush;
                        }
                        if (e.CurrentPoint.Position.X * this.ActualWidth > Attractive.Margin.Left && e.CurrentPoint.Position.X * this.ActualWidth < Attractive.Margin.Left + Attractive.Width
                       && e.CurrentPoint.Position.Y * this.ActualHeight > Attractive.Margin.Top && e.CurrentPoint.Position.Y * this.ActualHeight < Attractive.Margin.Top + Attractive.Height)
                        {

                            Attractive.Background = new BrushConverter().ConvertFromString("#9bff43") as SolidColorBrush;

                        }
                        else
                        {
                            Attractive.Background = new BrushConverter().ConvertFromString("#262262") as SolidColorBrush;
                        }
                        if (e.CurrentPoint.Position.X * this.ActualWidth > Balanced.Margin.Left && e.CurrentPoint.Position.X * this.ActualWidth < Balanced.Margin.Left + Balanced.Width
                       && e.CurrentPoint.Position.Y * this.ActualHeight > Balanced.Margin.Top && e.CurrentPoint.Position.Y * this.ActualHeight < Balanced.Margin.Top + Balanced.Height)
                        {

                            Balanced.Background = new BrushConverter().ConvertFromString("#9bff43") as SolidColorBrush;

                        }
                        else
                        {
                            Balanced.Background = new BrushConverter().ConvertFromString("#262262") as SolidColorBrush;
                        }
                        if (e.CurrentPoint.Position.X * this.ActualWidth > Intelligent.Margin.Left && e.CurrentPoint.Position.X * this.ActualWidth < Intelligent.Margin.Left + Intelligent.Width
                       && e.CurrentPoint.Position.Y * this.ActualHeight > Intelligent.Margin.Top && e.CurrentPoint.Position.Y * this.ActualHeight < Intelligent.Margin.Top + Intelligent.Height)
                        {

                            Intelligent.Background = new BrushConverter().ConvertFromString("#9bff43") as SolidColorBrush;

                        }
                        else
                        {
                            Intelligent.Background = new BrushConverter().ConvertFromString("#262262") as SolidColorBrush;
                        }
                        if (e.CurrentPoint.Position.X * this.ActualWidth > Brave.Margin.Left && e.CurrentPoint.Position.X * this.ActualWidth < Brave.Margin.Left + Brave.Width
                       && e.CurrentPoint.Position.Y * this.ActualHeight > Brave.Margin.Top && e.CurrentPoint.Position.Y * this.ActualHeight < Brave.Margin.Top + Brave.Height)
                        {

                            Brave.Background = new BrushConverter().ConvertFromString("#9bff43") as SolidColorBrush;

                        }
                        else
                        {
                            Brave.Background = new BrushConverter().ConvertFromString("#262262") as SolidColorBrush;
                        }
                        if (e.CurrentPoint.Position.X * this.ActualWidth > Brave.Margin.Left && e.CurrentPoint.Position.X * this.ActualWidth < Creative.Margin.Left + Creative.Width
                      && e.CurrentPoint.Position.Y * this.ActualHeight > Brave.Margin.Top && e.CurrentPoint.Position.Y * this.ActualHeight < Creative.Margin.Top + Creative.Height)
                        {

                            Creative.Background = new BrushConverter().ConvertFromString("#9bff43") as SolidColorBrush;

                        }
                        else
                        {
                            Creative.Background = new BrushConverter().ConvertFromString("#262262") as SolidColorBrush;
                        }
                        if (e.CurrentPoint.Position.X * this.ActualWidth > Flexible.Margin.Left && e.CurrentPoint.Position.X * this.ActualWidth < Flexible.Margin.Left + Flexible.Width
                      && e.CurrentPoint.Position.Y * this.ActualHeight > Flexible.Margin.Top && e.CurrentPoint.Position.Y * this.ActualHeight < Flexible.Margin.Top + Flexible.Height)
                        {

                            Flexible.Background = new BrushConverter().ConvertFromString("#9bff43") as SolidColorBrush;

                        }
                        else
                        {
                            Flexible.Background = new BrushConverter().ConvertFromString("#262262") as SolidColorBrush;
                        }
                        if (e.CurrentPoint.Position.X * this.ActualWidth > Charming.Margin.Left && e.CurrentPoint.Position.X * this.ActualWidth < Charming.Margin.Left + Charming.Width
                      && e.CurrentPoint.Position.Y * this.ActualHeight > Charming.Margin.Top && e.CurrentPoint.Position.Y * this.ActualHeight < Charming.Margin.Top + Charming.Height)
                        {

                            Charming.Background = new BrushConverter().ConvertFromString("#9bff43") as SolidColorBrush;

                        }
                        else
                        {
                            Charming.Background = new BrushConverter().ConvertFromString("#262262") as SolidColorBrush;
                        }
                        if (e.CurrentPoint.Position.X * this.ActualWidth > Bright.Margin.Left && e.CurrentPoint.Position.X * this.ActualWidth < Bright.Margin.Left + Bright.Width
                      && e.CurrentPoint.Position.Y * this.ActualHeight > Bright.Margin.Top && e.CurrentPoint.Position.Y * this.ActualHeight < Bright.Margin.Top + Bright.Height)
                        {

                            Bright.Background = new BrushConverter().ConvertFromString("#9bff43") as SolidColorBrush;

                        }
                        else
                        {
                            Bright.Background = new BrushConverter().ConvertFromString("#262262") as SolidColorBrush;
                        }
                        if (e.CurrentPoint.Position.X * this.ActualWidth > Loyal.Margin.Left && e.CurrentPoint.Position.X * this.ActualWidth < Loyal.Margin.Left + Loyal.Width
                      && e.CurrentPoint.Position.Y * this.ActualHeight > Loyal.Margin.Top && e.CurrentPoint.Position.Y * this.ActualHeight < Loyal.Margin.Top + Loyal.Height)
                        {

                            Loyal.Background = new BrushConverter().ConvertFromString("#9bff43") as SolidColorBrush;

                        }
                        else
                        {
                            Loyal.Background = new BrushConverter().ConvertFromString("#262262") as SolidColorBrush;
                        }
                        if (e.CurrentPoint.Position.X * this.ActualWidth > Honest.Margin.Left && e.CurrentPoint.Position.X * this.ActualWidth < Honest.Margin.Left + Honest.Width
                      && e.CurrentPoint.Position.Y * this.ActualHeight > Honest.Margin.Top && e.CurrentPoint.Position.Y * this.ActualHeight < Honest.Margin.Top + Honest.Height)
                        {

                            Honest.Background = new BrushConverter().ConvertFromString("#9bff43") as SolidColorBrush;

                        }
                        else
                        {
                            Honest.Background = new BrushConverter().ConvertFromString("#262262") as SolidColorBrush;
                        }
                        if (e.CurrentPoint.Position.X * this.ActualWidth > Modest.Margin.Left && e.CurrentPoint.Position.X * this.ActualWidth < Modest.Margin.Left + Modest.Width
                      && e.CurrentPoint.Position.Y * this.ActualHeight > Modest.Margin.Top && e.CurrentPoint.Position.Y * this.ActualHeight < Modest.Margin.Top + Modest.Height)
                        {

                            Modest.Background = new BrushConverter().ConvertFromString("#9bff43") as SolidColorBrush;

                        }
                        else
                        {
                            Modest.Background = new BrushConverter().ConvertFromString("#262262") as SolidColorBrush;
                        }
                        if (e.CurrentPoint.Position.X * this.ActualWidth > Reliable.Margin.Left && e.CurrentPoint.Position.X * this.ActualWidth < Reliable.Margin.Left + Reliable.Width
                      && e.CurrentPoint.Position.Y * this.ActualHeight > Reliable.Margin.Top && e.CurrentPoint.Position.Y * this.ActualHeight < Reliable.Margin.Top + Reliable.Height)
                        {

                            Reliable.Background = new BrushConverter().ConvertFromString("#9bff43") as SolidColorBrush;

                        }
                        else
                        {
                            Reliable.Background = new BrushConverter().ConvertFromString("#262262") as SolidColorBrush;
                        }
                        if (e.CurrentPoint.Position.X * this.ActualWidth > Witty.Margin.Left && e.CurrentPoint.Position.X * this.ActualWidth < Witty.Margin.Left + Witty.Width
                      && e.CurrentPoint.Position.Y * this.ActualHeight > Witty.Margin.Top && e.CurrentPoint.Position.Y * this.ActualHeight < Witty.Margin.Top + Witty.Height)
                        {

                            Witty.Background = new BrushConverter().ConvertFromString("#9bff43") as SolidColorBrush;

                        }
                        else
                        {
                            Witty.Background = new BrushConverter().ConvertFromString("#262262") as SolidColorBrush;
                        }




                    }

                    if (this.Visibility == Visibility.Visible)
                    {
                        if (CONFIDENCE == true)
                        {
                            try
                            {
                                selectionEvent(this, "Confidence");
                            }
                            catch
                            {

                            }
                        }
                        if (KINDNESS == true)
                        {
                            try
                            {
                                selectionEvent(this, "Kindness");
                            }
                            catch
                            {

                            }
                        }
                        if (FRIENDLINESS == true)
                        {
                            try
                            {
                                selectionEvent(this, "Friendliness");
                            }
                            catch
                            {

                            }
                        }
                        if (FUN == true)
                        {
                            try
                            {
                                selectionEvent(this, "Fun");
                            }
                            catch
                            {

                            }
                        }
                        if (DISCIPLINE == true)
                        {
                            try
                            {
                                selectionEvent(this, "Discipline");
                            }
                            catch
                            {

                            }
                        }
                        if (COURAGE == true)
                        {
                            try
                            {
                                selectionEvent(this, "Courage");
                            }
                            catch
                            {

                            }
                        }
                        if (CREATIVITY == true)
                        {
                            try
                            {
                                selectionEvent(this, "Creativity");
                            }
                            catch
                            {

                            }
                        }
                        if (FLEXIBILITY == true)
                        {
                            try
                            {
                                selectionEvent(this, "Flexibility");
                            }
                            catch
                            {

                            }
                        }
                        if (CHARM == true)
                        {
                            try
                            {
                                selectionEvent(this, "Charm");
                            }
                            catch
                            {

                            }
                        }
                        if (BRIGHTNESS == true)
                        {
                            try
                            {
                                selectionEvent(this, "Brightness");
                            }
                            catch
                            {

                            }

                        }
                        if (HONESTY == true)
                        {
                            try
                            {
                                selectionEvent(this, "Honesty");
                            }
                            catch
                            {

                            }
                        }
                        if (WITTINESS == true)
                        {
                            try
                            {
                                selectionEvent(this, "Wittiness");
                            }
                            catch
                            {

                            }
                        }
                        if (RELIABILITY == true)
                        {
                            try
                            {
                                selectionEvent(this, "Reliability");
                            }
                            catch
                            {

                            }

                        }
                        if (MODESTY == true)
                        {
                            try
                            {
                                selectionEvent(this, "Modesty");
                            }
                            catch
                            {

                            }
                        }
                        if (LOYALTY == true)
                        {
                            try
                            {
                                selectionEvent(this, "Loyalty");
                            }
                            catch
                            {

                            }
                        }
                    }
                }

            }
            catch
            {

            }
            
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
