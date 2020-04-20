using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LiveSplit.ComponentUtil;
using System.Diagnostics;
using System.Threading;
using System.Windows.Forms;
using System.Collections;

namespace NieRAutoIntelTracker
{

    class GameMemory
    {
        public const int SLEEP_TIME = 1000;

        private Task _thread;
        private CancellationTokenSource _cancelSource;
        private SynchronizationContext _uiThread;
        private DeepPointer _intelFishPtr;
        private DeepPointer _intelFishPtrDebug;
        public ulong IntelFishCurrent { get; set; }
        public ulong IntelFishOld { get; set; }

        private IntelDisplay _fishIntelDisplay;

        public GameMemory(IntelDisplay fishIntelDisplay)
        {
            _intelFishPtr = new DeepPointer(0x197C460); // release
            _intelFishPtrDebug = new DeepPointer(0x25A77E0); // debug
            _fishIntelDisplay = fishIntelDisplay;
        }

        public void StartMonitoring()
        {
            if (_thread != null && _thread.Status == TaskStatus.Running)
            {
                throw new InvalidOperationException();
            }

            if (!(SynchronizationContext.Current is WindowsFormsSynchronizationContext))
            {
                throw new InvalidOperationException("SynchronizationContext.Current is not a UI thread.");
            }

            _uiThread = SynchronizationContext.Current;
            _cancelSource = new CancellationTokenSource();
            _thread = Task.Factory.StartNew(MemoryReadThread);
        }

        public void Stop()
        {
            if (_cancelSource == null || _thread == null || _thread.Status != TaskStatus.Running)
            {
                return;
            }

            _cancelSource.Cancel();
            _thread.Wait();
        }

        void MemoryReadThread()
        {
            Debug.WriteLine("[NierFishTracker] MemoryReadThread");

            while (!_cancelSource.IsCancellationRequested)
            {
                try
                {
                    Trace.WriteLine("[NierFishTracker] Waiting for NieRAutomata.exe...");

                    Process game;
                    while ((game = GetGameProcess()) == null)
                    {
                        Thread.Sleep(500);
                        if (_cancelSource.IsCancellationRequested)
                        {
                            return;
                        }
                    }

                    Trace.WriteLine("[NierFishTracker] Got NieRAutomata.exe!");

                    IEnumerator coll = game.Modules.GetEnumerator();
                    coll.MoveNext();

                    DeepPointer FishPtr;
                    var memSize = ((ProcessModule)coll.Current).ModuleMemorySize;
                    switch (memSize)
                    {
                        case 106266624:
                            FishPtr = _intelFishPtr;
                            break;
                        default:
                            FishPtr = _intelFishPtrDebug;
                            break;
                    }
                    Debug.WriteLine("[NierFishTracker] ModuleMemorySize: " + memSize.ToString());

                    while (!game.HasExited)
                    {
                        ulong _intelFishCurrent;
                        FishPtr.Deref(game, out _intelFishCurrent);
                        IntelFishOld = IntelFishCurrent;
                        IntelFishCurrent = _intelFishCurrent;

                        if (IntelFishCurrent != IntelFishOld)
                        {
                            this._fishIntelDisplay.UpdateDebugDisplay(IntelFishCurrent.ToString("X"));

                            // split long into byte array to simplify flags
                            byte[] _buffer = new byte[8];

                            _buffer[0] = (byte) IntelFishCurrent;
                            _buffer[1] = (byte)(IntelFishCurrent >> 8);
                            _buffer[2] = (byte)(IntelFishCurrent >> 16);
                            _buffer[3] = (byte)(IntelFishCurrent >> 24);

                            //_buffer[4] = (byte)(IntelFishCurrent >> 32);
                            //_buffer[5] = (byte)(IntelFishCurrent >> 40);
                            _buffer[4] = (byte)(IntelFishCurrent >> 48);
                            _buffer[5] = (byte)(IntelFishCurrent >> 56);

                            // Debug.WriteLine("[NierFishTracker] breakdown: " + string.Join(", ", _buffer));

                            this._fishIntelDisplay.UpdateDisplay(_buffer);
                        }

                        Thread.Sleep(SLEEP_TIME);

                        if (_cancelSource.IsCancellationRequested)
                        {
                            return;
                        }
                    }
                }
                catch (Exception ex)
                {
                    Debug.WriteLine(ex.ToString());
                    Thread.Sleep(1000);
                }
            }
        }

        Process GetGameProcess()
        {
            Process game = Process.GetProcesses().FirstOrDefault(p => p.ProcessName.ToLower() == "nierautomata" && !p.HasExited);
            if (game == null)
            {
                return null;
            }

            return game;
        }

    }
}
