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
using Microsoft.Kinect;

namespace TheBooth
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private KinectSensor kinectSensor;
        public HeroMode heroMode;
        public IdleMode idleMode;
        public FirstQuestion firstQuestion;
        public superHeroExit exitQuestion;

        public string firstLogString;

        public enum States { idle, firstQuestion, hero, lastQuestions, end, volumeCalibration };
        public static States myState;

        public InfraredFrameReader frameReader = null;

        public HeroAnalysis heroAnalysis;

        public VideoHandler videoHandler;
        public AudioHandler audioHandler;
        public FaceFrameHandler faceFrameHandler;
 
        public BodyFrameHandler bodyFrameHandler;
        public static double startTime;

        public static ImageSource heroSource;
        public static Uri characterUri;

        public MainWindow()
        {
            InitializeComponent();
            this.kinectSensor = KinectSensor.GetDefault();
            this.kinectSensor.Open();
            this.frameReader = this.kinectSensor.InfraredFrameSource.OpenReader();
            heroAnalysis = new HeroAnalysis(this);


            videoHandler = new VideoHandler(this.kinectSensor);
            audioHandler = new AudioHandler(this.kinectSensor);
            bodyFrameHandler = new BodyFrameHandler(this.kinectSensor);
            faceFrameHandler = new FaceFrameHandler(this.kinectSensor);

            startTime = DateTime.Now.TimeOfDay.TotalMilliseconds;

           

        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            backgroundImg.Height = this.ActualHeight;
            backgroundImg.Width = this.ActualWidth;
            if (this.frameReader != null)
            {
                this.frameReader.FrameArrived += frameReader_FrameArrived;
            }
            myState = States.idle;
            loadMode();

        }


        #region control

        public void loadMode()
        {
            switch (myState)
            {
                case States.volumeCalibration:
                    break;
                case States.idle:
                    loadIdleMode();
                    break;
                case States.hero:
                    loadHeroMode();
                    break;
                case States.firstQuestion:
                    loadFirstQuestion();
                    break;
            }
        }

        private void loadFirstQuestion()
        {
            firstQuestion = new FirstQuestion();
            MainCanvas.Children.Add(firstQuestion);
            Canvas.SetTop(firstQuestion, 0);
            Canvas.SetLeft(firstQuestion, 0);
            firstQuestion.Loaded += firstQuestion_Loaded;

            //exitQuestion = new superHeroExit();
            //MainCanvas.Children.Add(exitQuestion);
            //Canvas.SetTop(exitQuestion, 0);
            //Canvas.SetLeft(exitQuestion, 0);
            

        }

        void firstQuestion_Loaded(object sender, RoutedEventArgs e)
        {
            firstQuestion.parent = this;
            firstQuestion.loaded();
            //firstQuestion.Visibility = Visibility.Collapsed;

            //exitQuestion.parent = this;
            //exitQuestion.loaded();
           

         }

        private void loadIdleMode()
        {
            idleMode = new IdleMode();
            MainCanvas.Children.Add(idleMode);
            Canvas.SetTop(idleMode, 0);
            Canvas.SetLeft(idleMode, 0);
            idleMode.Loaded += idleMode_Loaded;
           
        }

        void idleMode_Loaded(object sender, RoutedEventArgs e)
        {
            
            idleMode.parent = this;
            idleMode.loaded();
        }
        void closeIdleMode()
        {
            MainCanvas.Children.Remove(idleMode);
        }

        private void closeFirstQuestionMode()
        {
            MainCanvas.Children.Remove(firstQuestion);
        }

        private void loadHeroMode()
        {
            heroMode = new HeroMode();
            MainCanvas.Children.Add(heroMode);
            Canvas.SetTop(heroMode, 0);
            Canvas.SetLeft(heroMode, 0);
            heroMode.Loaded += heroMode_Loaded;
            heroMode.exitEvent += heroMode_exitEvent;
        }

        private void heroMode_exitEvent(object sender)
        {
            closeHeroMode();
            myState = States.idle;
            loadMode();
        }

        private void closeHeroMode()
        {
            MainCanvas.Children.Remove(heroMode);
        }

        private void heroMode_Loaded(object sender, RoutedEventArgs e)
        {
            heroMode.parent = this;
            heroMode.loaded();
        }

        #endregion

        private void frameReader_FrameArrived(object sender, InfraredFrameArrivedEventArgs e)
        {
            switch (myState)
            {
                case States.idle:
                    if(idleMode.isLoaded)
                    {
                        doIdleStuff();
                    }
                    
                    break;
                case States.firstQuestion:
                    if (bodyFrameHandler.bodyDetected)
                    {
                        doFirstQuestionStuff();
                    }
                    else
                    {
                        closeFirstQuestionMode();
                        myState = States.idle;
                        loadMode();
                    }
                    break;
                case States.hero:
                    if(bodyFrameHandler.bodyDetected)
                    {
                        if (heroMode.isLoaded)
                        {
                            heroAnalysis.analyseCycle();
                        }
                    }
                    else
                    {
                        closeHeroMode();
                        myState = States.idle;
                        loadMode();
                    }
                    break;
                case States.lastQuestions:
                    break;
            }
        }

        private void doFirstQuestionStuff()
        {
            if(firstQuestion.ready)
            {
                myState = States.hero;
                loadMode();
                closeFirstQuestionMode();
            }
        }

       

        private void doIdleStuff()
        {
            idleMode.lookForUser();
            if(idleMode.userEngaged)
            {
                myState = States.firstQuestion;
                loadMode();
                closeIdleMode();
            }
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (this.kinectSensor != null)
            {
                this.kinectSensor.Close();
                this.kinectSensor = null;
            }
            //  audioHandlerControl.close();
            // bodyFrameHandlerControl.close();
            videoHandler.close();
        }
    }
}
