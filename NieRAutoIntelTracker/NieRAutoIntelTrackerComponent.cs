using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//these are necessary to allow for you to do most anything you need within your component
using LiveSplit.Model;
using LiveSplit.Model.Input;
using LiveSplit.UI.Components;
using System.Drawing;
using System.Windows.Forms;
using System.Xml;
using LiveSplit.UI;
using System.Diagnostics;

namespace NieRAutoIntelTracker
{
    public class NieRAutoIntelTrackerComponent : IComponent
    {
        public Settings settings;

        public LiveSplitState state;

        private GameMemory _gameMemory;
        private IntelDisplay _fishIntelDisplay;

        public NieRAutoIntelTrackerComponent(LiveSplitState state)
        {
            this.state = state;

            this.settings = new Settings(state);

            //set the width and height(horizontal and vertical refer to which mode livesplit is in)
            HorizontalWidth = 0;
            VerticalHeight = 0;

            _fishIntelDisplay = new IntelDisplay(settings);
            _gameMemory = new GameMemory(_fishIntelDisplay);

            _gameMemory.StartMonitoring();

        }

        //make sure this matches the factory
        //this should really only be read-only
        public string ComponentName => "NieR:Automata Intel Tracker";

        //depending on your component you can make these readonly or changeable, just as long as they are readable
        public float HorizontalWidth { get; set; }

        //minimums are where the window can only be so small
        public float MinimumHeight { get; set; }

        public float VerticalHeight { get; set; }

        public float MinimumWidth { get; set; }

        //padding determines how much space is put between the component and the rest of livesplit
        public float PaddingTop { get; set; }

        public float PaddingBottom { get; set; }

        public float PaddingLeft { get; set; }

        public float PaddingRight { get; set; }

        //this is for when your component is right clicked, I haven't really had to use this but you can certainly mess around and add contexstmenu items
        public IDictionary<string, Action> ContextMenuControls { get; set; }

        //this method draws the component when Livesplit is in horizontal mode
        public void DrawHorizontal(Graphics g, LiveSplitState state, float height, Region clipRegion)
        {
            //here is where you draw what you want for your component, I would recommend looking at microsoft c# tutorials on graphics and painting/drawing
            //Pen pen = new Pen(Color.Red, 5);
            //g.DrawLine(pen, 0, 0, HorizontalWidth, VerticalHeight);
        }

        //this method draws the component when Livesplit is in vertical mode
        public void DrawVertical(Graphics g, LiveSplitState state, float width, Region clipRegion)
        {
            //for simplicity I am just going to keep the drawing the same for each layout mode
            DrawHorizontal(g, state, width, clipRegion);
        }

        public XmlNode GetSettings(XmlDocument document)
        {
            return settings.GetSettings(document);
        }

        public Control GetSettingsControl(LayoutMode mode)
        {
            return settings;
        }

        public void SetSettings(XmlNode settings)
        {
            this.settings.SetSettings(settings);
        }

        public void Update(IInvalidator invalidator, LiveSplitState state, float width, float height, LayoutMode mode)
        {

        }

        #region IDisposable Support
        private bool disposedValue = false; // To detect redundant calls

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    if (_gameMemory != null)
                    {
                        _gameMemory.Stop();
                    }
                }

                disposedValue = true;
            }
        }

        void IDisposable.Dispose()
        {
            Dispose(true);
            // TODO: uncomment the following line if the finalizer is overridden above.
            // GC.SuppressFinalize(this);
        }
        #endregion
    }
}
