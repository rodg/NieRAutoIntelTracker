using System;
using System.Collections.Generic;

using LiveSplit.Model;
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
        private IntelDisplay _intelDisplay;

        public NieRAutoIntelTrackerComponent(LiveSplitState state)
        {
            this.state = state;

            this._intelDisplay = new IntelDisplay();
            this.settings = new Settings(visible => _intelDisplay.SetVisibility(visible));

            this._gameMemory = new GameMemory(_intelDisplay);
            this._gameMemory.StartMonitoring();

            HorizontalWidth = 0;
            VerticalHeight = 0;

            ContextMenuControls = new Dictionary<string, Action>
            {
                { "Toggle NieR:Automata Intel Tracker", new Action(_intelDisplay.ToggleVisibility) }
            };
        }

        public string ComponentName => "NieR:Automata Intel Tracker";

        public float HorizontalWidth { get; set; }

        public float MinimumHeight { get; set; }

        public float VerticalHeight { get; set; }

        public float MinimumWidth { get; set; }

        public float PaddingTop { get; set; }

        public float PaddingBottom { get; set; }

        public float PaddingLeft { get; set; }

        public float PaddingRight { get; set; }

        public IDictionary<string, Action> ContextMenuControls { get; set; }

        public void DrawHorizontal(Graphics g, LiveSplitState state, float height, Region clipRegion)
        {
            SolidBrush brush = new SolidBrush(state.LayoutSettings.TextColor);
            g.DrawString(this.ComponentName, state.LayoutSettings.TextFont, brush, 0, 0);
        }

        public void DrawVertical(Graphics g, LiveSplitState state, float width, Region clipRegion)
        {
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
                        _intelDisplay.Hide();
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
