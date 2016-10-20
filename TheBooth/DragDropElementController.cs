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
using Microsoft.Kinect.Toolkit.Input;
using Microsoft.Kinect.Wpf.Controls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace TheBooth
{
    public class DragDropElementController : IKinectManipulatableController
    {
        private ManipulatableModel _inputModel;
        private KinectRegion _kinectRegion;
        private DragDropElement _dragDropElement;
        private bool _disposedValue;

        public delegate void DropSendEvent(object sender);
        public event DropSendEvent dropSendEvent;

        public DragDropElementController(IInputModel inputModel, KinectRegion kinectRegion)
        {
            _inputModel = inputModel as ManipulatableModel;
            _kinectRegion = kinectRegion;
            _dragDropElement = _inputModel.Element as DragDropElement;

            _inputModel.ManipulationStarted += OnManipulationStarted;
            _inputModel.ManipulationUpdated += OnManipulationUpdated;
            _inputModel.ManipulationCompleted += OnManipulationCompleted;
        }

        private void OnManipulationCompleted(object sender,
            KinectManipulationCompletedEventArgs kinectManipulationCompletedEventArgs)
        {
            

            object a = ((ManipulatableModel)sender).Element;
            double widthA = ((DragDropElement)a).Width;
            double heightA = ((DragDropElement)a).Height;
            if (Canvas.GetLeft((UIElement)(a)) >= HeroAnalysis.targetLeft1 - widthA && Canvas.GetLeft((UIElement)(a)) <= HeroAnalysis.targetLeft2 &&
                Canvas.GetTop((UIElement)(a)) >= HeroAnalysis.targetTop1 - heightA && Canvas.GetTop((UIElement)(a)) <= HeroAnalysis.targetTop2)
            {
                ((DragDropElement)a).dropCorrecly = true;
                ((DragDropElement)a).Visibility = Visibility.Collapsed;
            }
           
        }

        private void OnManipulationUpdated(object sender, KinectManipulationUpdatedEventArgs e)
        {
            var parent = _dragDropElement.Parent as Canvas;
            if (parent != null)
            {
                var d = e.Delta.Translation;
                var y = Canvas.GetTop(_dragDropElement);
                var x = Canvas.GetLeft(_dragDropElement);

                if (double.IsNaN(y)) y = 0;
                if (double.IsNaN(x)) x = 0;

                // Delta value is between 0.0 and 1.0 so they need to be scaled within the kinect region.
                var yD = d.Y * _kinectRegion.ActualHeight;
                var xD = d.X * _kinectRegion.ActualWidth;

                Canvas.SetTop(_dragDropElement, y + yD);
                Canvas.SetLeft(_dragDropElement, x + xD);
            }
        }

        private void OnManipulationStarted(object sender, KinectManipulationStartedEventArgs e)
        {

        }

        ManipulatableModel IKinectManipulatableController.ManipulatableInputModel
        {
            get { return _inputModel; }
        }

        FrameworkElement IKinectController.Element
        {
            get { return _inputModel.Element as FrameworkElement; }
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!_disposedValue)
            {
                _kinectRegion = null;
                _inputModel = null;
                _dragDropElement = null;

                _inputModel.ManipulationStarted -= OnManipulationStarted;
                _inputModel.ManipulationUpdated -= OnManipulationUpdated;
                _inputModel.ManipulationCompleted -= OnManipulationCompleted;

                _disposedValue = true;
            }
        }

        void IDisposable.Dispose()
        {
            Dispose(true);
        }
    }
}
