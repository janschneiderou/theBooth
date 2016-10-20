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
    /// Interaction logic for HeroMode.xaml
    /// </summary>
    public partial class HeroMode : UserControl
    {
        public delegate void ExitEvent(object sender);
        public  event ExitEvent exitEvent;

        public MainWindow parent;
        public string value;
        public string InstructionHeroPosture = "Lets start by standing in the Superhero posture.";
        public string InstructionValue = "Select a value that you identify with.";
        public bool isLoaded = false;
        public static bool heroFemale = true;
        public static string superPowers = "";
        public static string impacts = "";
        public static string inspirations = "";
        bool first = true;

       public SuperHeroLesson HeroLesson;
        public SuperHeroAffirmation HeroAffirmation;
        public SuperInspiration1 inspiration1;
        public SuperHeroInspiration2 heroInspiration2;
        public SuperHeroImpact heroImpact;
        public SuperHeroCelebration heroCelebration;
        public superHeroExit heroExit;
        public SuperHeroPowers heroPower;
       

        public HeroMode()
        {
            InitializeComponent();
        }

        public void loaded()
        {
            myCanvas.Height = parent.ActualWidth;
            myCanvas.Width = parent.ActualHeight;
            backgroundImg.Width = parent.ActualWidth;
            backgroundImg.Height = parent.ActualHeight;
            Canvas.SetLeft(backgroundImg, 0);
            Canvas.SetTop(backgroundImg, 0);
            myBody.initializeB(parent);
            myAudio.initialize(parent);
            mySkeleton.initialize(parent);
            //parent.heroAnalysis.loadStuff();

           // values.Visibility = Visibility.Collapsed;

            HeroLesson = new SuperHeroLesson();
            heroPower = new SuperHeroPowers();
            HeroAffirmation = new SuperHeroAffirmation();
            inspiration1 = new SuperInspiration1();
            heroInspiration2 = new SuperHeroInspiration2();
            heroImpact = new SuperHeroImpact();
            heroCelebration = new SuperHeroCelebration();
            heroExit = new superHeroExit();


            parent.heroAnalysis.loadStuff();

            //myCanvas.Children.Add(heroPower);
            //myCanvas.Children.Add(HeroAffirmation);
            //myCanvas.Children.Add(inspiration1);
            //myCanvas.Children.Add(heroImpact);
            //myCanvas.Children.Add(heroCelebration);
            //myCanvas.Children.Add(heroExit);
            //myCanvas.Children.Add(HeroLesson);

            //Canvas.SetLeft(HeroAffirmation, 260);
            //Canvas.SetLeft(HeroLesson, 260);
            //Canvas.SetTop(HeroAffirmation, 50);
            //Canvas.SetTop(HeroLesson, 50);

            //heroPower.Visibility = Visibility.Collapsed;
            //HeroAffirmation.Visibility = Visibility.Collapsed;
            //inspiration1.Visibility = Visibility.Collapsed;
            //heroInspiration2.Visibility = System.Windows.Visibility.Collapsed;
            //heroImpact.Visibility = System.Windows.Visibility.Collapsed;
            //heroCelebration.Visibility = Visibility.Collapsed;
            //heroExit.Visibility = Visibility.Collapsed;
            //heroExit.nextButton.Click += nextButton_Click;
            //heroExit.exitButton += heroExit_exitButton;
            //heroExit.parent = this.parent;
           // HeroLesson.Visibility = Visibility.Collapsed;

            heroSelection.button1.Click += button1Selection_Click;
            heroSelection.button2.Click +=button2Selection_Click;

            superPowers = "";
            impacts = "";
            inspirations = "";

            isLoaded = true;
        }

        void heroExit_exitButton(object sender)
        {

            parent.soundeffect.Stop();
            parent.soundeffect.Play();
            music.Stop();

            string filename = (int)DateTime.Now.TimeOfDay.TotalMilliseconds + ".txt";
            System.IO.File.WriteAllText(filename, parent.firstLogString);
            
            //parent.soundeffect.Stop();
            //parent.soundeffect.Play();
            //exitEvent(this);
            Process.Start(Application.ResourceAssembly.Location);
            Application.Current.Shutdown();

        }

        private void button2Selection_Click(object sender, RoutedEventArgs e)
        {
            heroFemale = false;
            heroSelection.Visibility = Visibility.Collapsed;
            var uriSource = new Uri(@"/TheBooth;component/Images/male_hero_silhouette.png", UriKind.Relative);

            myCanvas.Children.Add(HeroLesson);
            Canvas.SetLeft(HeroLesson, 260);
            Canvas.SetTop(HeroLesson, 50);


            HeroLesson.Visibility = Visibility.Visible;
            HeroLesson.loadLesson();
           
            parent.soundeffect.Stop();
            parent.soundeffect.Play();
            parent.soundeffect.MediaEnded += soundeffect_MediaEnded;

            heroPower.backgroundImg.Source = new BitmapImage(uriSource);
            heroInspiration2.backgroundImg.Source = new BitmapImage(uriSource);
            heroImpact.backgroundImg.Source = new BitmapImage(uriSource);
            MainWindow.characterUri = uriSource;
        }

      
        void button1Selection_Click(object sender, RoutedEventArgs e)
        {
            heroFemale = true;
            heroSelection.Visibility = Visibility.Collapsed;

            var uriSource = new Uri(@"/TheBooth;component/Images/female_hero_silhouette.png", UriKind.Relative);
            parent.soundeffect.Stop();
            parent.soundeffect.Play();

            myCanvas.Children.Add(HeroLesson);
            Canvas.SetLeft(HeroLesson, 260);
            Canvas.SetTop(HeroLesson, 50);

            HeroLesson.Visibility = Visibility.Visible;
            HeroLesson.loadLesson();
            
            parent.soundeffect.MediaEnded += soundeffect_MediaEnded;

            heroPower.backgroundImg.Source = new BitmapImage(uriSource);
            heroInspiration2.backgroundImg.Source = new BitmapImage(uriSource);
            heroImpact.backgroundImg.Source = new BitmapImage(uriSource);
            MainWindow.characterUri = uriSource;
            
        }

        void soundeffect_MediaEnded(object sender, RoutedEventArgs e)
        {
            if(HeroLesson.Visibility==Visibility.Visible)
            {
                HeroLesson.loaded = false;
            }
            if(HeroAffirmation.Visibility== Visibility.Visible)
            {
                HeroAffirmation.loaded = false;
            }
           
           
        }


        void nextButton_Click(object sender, RoutedEventArgs e)
        {
            parent.soundeffect.Stop();
            parent.soundeffect.Play();
            music.Stop();

            string filename = (int)DateTime.Now.TimeOfDay.TotalMilliseconds + ".txt";
            System.IO.File.WriteAllText(filename, parent.firstLogString);

            Process.Start(Application.ResourceAssembly.Location);
            Application.Current.Shutdown();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            parent.soundeffect.Stop();
            parent.soundeffect.Play();
            exitEvent(this);
        }
    }
}
