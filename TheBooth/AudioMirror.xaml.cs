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
    /// Interaction logic for AudioMirror.xaml
    /// </summary>
    public partial class AudioMirror : UserControl
    {
        MainWindow parent;

        public AudioMirror()
        {
            InitializeComponent();
        }
        public void initialize(MainWindow parent)
        {
            this.parent = parent;

            if (parent.audioHandler.reader != null)
            {
                // Subscribe to new audio frame arrived events
                parent.audioHandler.reader.FrameArrived += Reader_FrameArrived;
            }


                //    CompositionTarget.Rendering += this.UpdateEnergy;

            //if (this.reader != null)
            //{
            //    // Subscribe to new audio frame arrived events
            //    this.reader.FrameArrived += this.Reader_FrameArrived;
            //}

        }

        public void Reader_FrameArrived(object sender, AudioBeamFrameArrivedEventArgs e)
        {
            parent.audioHandler.Reader_FrameArrived(sender, e);
            

        }
    }
}
