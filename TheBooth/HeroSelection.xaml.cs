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
    /// Interaction logic for HeroSelection.xaml
    /// </summary>
    public partial class HeroSelection : UserControl
    {
        public KinectCoreWindow window;
        public HeroSelection()
        {
            InitializeComponent();
             window = KinectCoreWindow.GetForCurrentThread();
              window.PointerMoved += window_PointerMoved;
            
       
        }

        private void Button1_MouseEnter(object sender, MouseEventArgs e)
        {
            var uriSource = new Uri(@"/TheBooth;component/Images/female_hero_selected.png", UriKind.Relative);
            button1Img.Source = new BitmapImage(uriSource);
           
         
        }

      
        private void window_PointerMoved(object sender, KinectPointerEventArgs e)
        {
            try
            {
                var uriSource = new Uri(@"/TheBooth;component/Images/female_hero.png", UriKind.Relative);

                if ((!BodyFramePreAnalysis.rightHandUp && e.CurrentPoint.Properties.HandType == HandType.LEFT) ||
                  (BodyFramePreAnalysis.rightHandUp && e.CurrentPoint.Properties.HandType == HandType.RIGHT))
                {
                    if (e.CurrentPoint.Position.X * this.Width > Canvas.GetLeft(button1) && e.CurrentPoint.Position.X * this.Width < Canvas.GetLeft(button1) + button1.Width
                   && e.CurrentPoint.Position.Y * this.Height > Canvas.GetTop(button1) && e.CurrentPoint.Position.Y * this.Height < Canvas.GetTop(button1) + button1.Height)
                    {
                        uriSource = new Uri(@"/TheBooth;component/Images/female_hero_selected.png", UriKind.Relative);
                        button1Img.Source = new BitmapImage(uriSource);
                    }
                    else
                    {
                        uriSource = new Uri(@"/TheBooth;component/Images/female_hero.png", UriKind.Relative);
                        button1Img.Source = new BitmapImage(uriSource);
                    }

                    if (e.CurrentPoint.Position.X * this.Width > Canvas.GetLeft(button2) && e.CurrentPoint.Position.X * this.Width < Canvas.GetLeft(button2) + button2.Width
                        && e.CurrentPoint.Position.Y * this.Height > Canvas.GetTop(button2) && e.CurrentPoint.Position.Y * this.Height < Canvas.GetTop(button2) + button2.Height)
                    {
                        uriSource = new Uri(@"/TheBooth;component/Images/male_hero_selected.png", UriKind.Relative);
                        button2Img.Source = new BitmapImage(uriSource);
                    }
                    else
                    {
                        uriSource = new Uri(@"/TheBooth;component/Images/male_hero.png", UriKind.Relative);
                        button2Img.Source = new BitmapImage(uriSource);
                    }
                }
            }
            catch
            {

            }
           
            
           

        }

        private void button1_MouseLeave(object sender, MouseEventArgs e)
        {
            var uriSource = new Uri(@"/TheBooth;component/Images/female_hero.png", UriKind.Relative);
            button1Img.Source = new BitmapImage(uriSource);
        }

        private void button1_GotFocus(object sender, RoutedEventArgs e)
        {
            var uriSource = new Uri(@"/TheBooth;component/Images/female_hero_selected.png", UriKind.Relative);
            button1Img.Source = new BitmapImage(uriSource);
        }
    }
}
