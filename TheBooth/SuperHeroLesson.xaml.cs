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
    /// Interaction logic for SuperHeroLesson.xaml
    /// </summary>
    public partial class SuperHeroLesson : UserControl
    {
        int lessonNumber = 1;
        public delegate void NextEvent(object sender, int x);
        public event NextEvent nextEvent;
        public bool loaded = true;

        public KinectCoreWindow window;

        public SuperHeroLesson()
        {
            InitializeComponent();
            setStrings(1);
          
            
        }
        public void loadLesson()
        {
            this.Visibility = Visibility.Visible;
            window = KinectCoreWindow.GetForCurrentThread();
            window.PointerMoved += window_PointerMoved;
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
                        if (e.CurrentPoint.Position.X * this.ActualWidth > button1.Margin.Left && e.CurrentPoint.Position.X * this.ActualWidth < button1.Margin.Left + button1.Width
                       && e.CurrentPoint.Position.Y * this.ActualHeight > button1.Margin.Top && e.CurrentPoint.Position.Y * this.ActualHeight < button1.Margin.Top + button1.ActualHeight)
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
                }


                if (this.Visibility == Visibility.Visible && loaded == false)
                {
                    loaded = true;

                    playsounds();
                }

                if (HeroAnalysis.nextCommand == true && this.Visibility == System.Windows.Visibility.Visible)
                {
                    Button_Click(null, null);
                }
            }
            catch
            {

            }
           
        }

        private void playsounds()
        {
            
            switch (lessonNumber)
            {
                case 1:
                    lessonDescription1.MediaEnded += lessonDescription_MediaEnded;
                    lessonDescription1.Stop();
                    lessonDescription1.Play();
                    break;
                case 2:
                    lessonDescription2.MediaEnded += lessonDescription_MediaEnded;
                    lessonDescription2.Stop();
                    lessonDescription2.Play();

                    break;
                case 3:
                case 4:
                    lessonDescription3.MediaEnded += lessonDescription_MediaEnded;
                    lessonDescription3.Stop();
                    lessonDescription3.Play();

                    break;
                case 5:
                    lessonDescription4.MediaEnded += lessonDescription_MediaEnded;
                    lessonDescription4.Stop();
                    lessonDescription4.Play();
                    break;
                case 6:
                case 7:
                    lessonDescription5.MediaEnded += lessonDescription_MediaEnded;
                    lessonDescription5.Stop();
                    lessonDescription5.Play();
                    TwitterClient t = new TwitterClient();
                    t.sendImage();
                    break;

            }
        }

       

        

        public void setStrings(int lesson)
        {
            HeroAnalysis.startCommand = false;
            HeroAnalysis.nextCommand = false;
            lessonNumber = lesson;
           // var uriSource = new Uri(@"/TheBooth;component/Images/Button_start.png", UriKind.Relative);

            switch(lesson)
            {
                case 1:
                    LabelLessonNumber.Content = "1";
                    LabelLessonName.Content = "\"Posture\"";
                    LabelLessonExplanation.Content = "In this lesson you will learn \nthe Super Hero Posture.";
                    postureImage.Visibility = Visibility.Visible;
                    
                    break;
                case 2:
                    LabelLessonNumber.Content = "2";
                    LabelLessonName.Content = "\"Super Powers\"";
                    LabelLessonExplanation.Content = "In this lesson you will select 3 \nsuper powers \nthat fit your personality.";
                    postureImage.Visibility = Visibility.Collapsed;
                    break;
                case 3:
                    LabelLessonNumber.Content = "3";
                    LabelLessonName.Content = "\"Inspiration\"";
                    LabelLessonExplanation.Content = "In this lesson you will select \na value that you find \nsuper inspiring. ";
                    postureImage.Visibility = Visibility.Collapsed;
                    break;
                case 4:
                    LabelLessonNumber.Content = "4";
                    LabelLessonName.Content = "Inspiration 2";
                    LabelLessonExplanation.Content = "In this lesson you will reflect on \nwhat you find inspiring \nin others.";
                    postureImage.Visibility = Visibility.Collapsed;
                    break;
                case 5:
                    LabelLessonNumber.Content = "4";
                    LabelLessonName.Content = "\"Impact\"";
                    LabelLessonExplanation.Content = "In this lesson you will use\nyour super powers \n to make a better world.";
                    postureImage.Visibility = Visibility.Collapsed;
                    break;
                case 6:
                    LabelLessonNumber.Content = "5";
                    LabelLessonName.Content = "\"Celebration\"";
                    LabelLessonExplanation.Content = "In this lesson you will celebrate your \n Super Hero Achievements";
                    postureImage.Visibility = Visibility.Collapsed;
                    break;
                case 7:
                    LabelLessonNumber.Content = "5";
                    LabelLessonName.Content = "Celebration";
                    LabelLessonExplanation.Content = "In this lesson you will celebrate your \n Super Hero Achievements";
                    postureImage.Visibility = Visibility.Collapsed;
                    break;
            }
        }

        void lessonDescription_MediaEnded(object sender, RoutedEventArgs e)
        {
            button1.IsEnabled = true;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            HeroAnalysis.startCommand = false;
            HeroAnalysis.nextCommand = false;
            nextEvent(this, lessonNumber);
            window.PointerMoved -= window_PointerMoved;
            this.Visibility = Visibility.Collapsed;
            
        }
    }
}
