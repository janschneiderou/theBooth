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
using System;
using System.Collections.Generic;
using System.Diagnostics;
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
    /// Interaction logic for IdleMode.xaml
    /// </summary>
    public partial class IdleMode : UserControl
    {
        public MainWindow parent;
        public BodyFramePreAnalysis bfpa;
        public FaceFramePreAnalisys ffpa;

        public bool isLoaded = false;
        public bool foundUser = false;
        public bool userEngaged = false;

        public double timeToReset = 300000;

        public bool soundNotPlaying = true;
        public IdleMode()
        {
            InitializeComponent();
        }
        public void loaded()
        {
            isLoaded = true;

            if (parent.bodyFrameHandler.bodyFrameReader != null)
            {
                parent.bodyFrameHandler.bodyFrameReader.FrameArrived += this.Reader_FrameArrived;

            }
            if (parent.faceFrameHandler.bodyFrameReader != null)
            {
                // wire handler for body frame arrival
                parent.faceFrameHandler.bodyFrameReader.FrameArrived += this.Reader_BodyFrameArrived;

                for (int i = 0; i < parent.faceFrameHandler.bodyCount; i++)
                {
                    if (parent.faceFrameHandler.faceFrameReaders[i] != null)
                    {
                        // wire handler for face frame arrival
                        parent.faceFrameHandler.faceFrameReaders[i].FrameArrived += Reader_FaceFrameArrived;
                        //break;
                    }
                }
            }


        }

        private void Reader_FaceFrameArrived(object sender, Microsoft.Kinect.Face.FaceFrameArrivedEventArgs e)
        {
            parent.faceFrameHandler.Reader_FaceFrameArrived(sender, e);
        }

        private void Reader_BodyFrameArrived(object sender, Microsoft.Kinect.BodyFrameArrivedEventArgs e)
        {
            parent.faceFrameHandler.Reader_BodyFrameArrived(sender, e);
        }

        private void Reader_FrameArrived(object sender, Microsoft.Kinect.BodyFrameArrivedEventArgs e)
        {
            parent.bodyFrameHandler.Reader_FrameArrived(sender, e);
        }
        public void lookForUser()
        {
            bfpa = parent.bodyFrameHandler.bodyFramePreAnalysis;
            ffpa = parent.faceFrameHandler.faceFramePreAnalysis;
            if (parent.bodyFrameHandler.bodyDetected)
            {
                foundUser = true;
            }
            else
            {
                if( DateTime.Now.TimeOfDay.TotalMilliseconds > MainWindow.startTime + timeToReset)
                {
                    Process.Start(Application.ResourceAssembly.Location);
                    Application.Current.Shutdown();
                }
            }
            if(foundUser)
            {
                if (soundNotPlaying)
                {
                    intro.Stop();
                    intro.Play();
                    soundNotPlaying = false;
                    sensei.Visibility = Visibility.Visible;
                }
                
                
                if(bfpa.handsUp)
                {
                    userEngaged = true;
                    intro.Stop();
                }
            }
            else
            {
                intro.Stop();
                soundNotPlaying = true;
                sensei.Visibility = Visibility.Collapsed;
            }
        }

       
    }
}
