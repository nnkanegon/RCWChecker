using Microsoft.Diagnostics.Runtime;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Windows.Forms;

namespace RCWChecker
{
    public partial class MainForm : Form
    {
        private const bool IsHideITypeInfo = true;

        private const int WM_COPYDATA = 0x4A;

        private const int RCWCHECKER_ATTACH = 0x01;
        private const int RCWCHECKER_DUMP = 0x02;

        private bool isAttached = false;
        private string processName = null;
        private string logFileName = null;

        public MainForm()
        {
            InitializeComponent();
        }

        private void ShowText(string msg)
        {
            StatusViewTextBox.Text = msg;
        }

        private void WriteLog(string logText)
        {
            if (logFileName == null)
            {
                return;
            }
            using (var writer = new StreamWriter(logFileName, true, Encoding.UTF8))
            {
                writer.WriteLine("-----------------------------------------------------------");
                writer.WriteLine(logText);
            }
        }

        private void UpdateButtonStatus()
        {
            AttachButton.Enabled = !isAttached;
            DetachButton.Enabled = isAttached;
            SnapshotButton.Enabled = isAttached;
        }

        private void AttachProcess(string appMsg = "", bool log = false, bool force = false)
        {
            if (isAttached)
            {
                if (force)
                {
                    DetachProcess();
                }
                else
                {
                    return;
                }
                return;
            }
            var name = ProcessNameTextBox.Text.Trim();
            if (string.IsNullOrEmpty(name))
            {
                return;
            }
            processName = name;

            string rcwData = GetRCWData(appMsg);
            if (rcwData == null)
            {
                processName = null;
                return;
            }
            logFileName = Path.Combine(Path.GetDirectoryName(Application.ExecutablePath), String.Format(@"{0}.log", DateTime.Now.ToString("yyyyMMdd-HHmmss")));
            ShowText(rcwData);
            if (log)
            {
                WriteLog(rcwData);
            }
            isAttached = true;
            timer1.Enabled = true;
            UpdateButtonStatus();
        }

        private void DetachProcess()
        {
            if (!isAttached)
            {
                return;
            }
            timer1.Enabled = false;
            isAttached = false;
            processName = null;
            logFileName = null;
            ShowText("process detached.");
            UpdateButtonStatus();
        }

        private void UpdateView(string appMsg = "", bool log = false)
        {
            if (!isAttached)
            {
                return;
            }
            string rcwData = GetRCWData(appMsg);
            if (rcwData == null)
            {
                DetachProcess();
                return;
            }
            ShowText(rcwData);
            if (log)
            {
                WriteLog(rcwData);
            }
        }

        private string GetRCWData(string appMsg = "")
        {
            int objCount = 0;
            System.Diagnostics.Process[] procs = System.Diagnostics.Process.GetProcessesByName(processName);
            if (procs.Length == 0)
            {
                ShowText($"[ERROR] process {processName} not found.");
                DetachProcess();
                return null;
            }
            // If multiple processes are found, only the first one is processed.
            StringBuilder diagMsg = new StringBuilder();
            using (DataTarget dataTarget = DataTarget.AttachToProcess(procs[0].Id, true))
            {
                ClrInfo runtimeInfo = dataTarget.ClrVersions[0];
                ClrRuntime runtime = runtimeInfo.CreateRuntime();
                ClrHeap heap = runtime.Heap;
                foreach (ClrObject obj in heap.EnumerateObjects())
                {
                    if (obj.HasRuntimeCallableWrapper)
                    {
                        RuntimeCallableWrapper rcw = obj.GetRuntimeCallableWrapper();
                        if (rcw != null)
                        {
                            List<string> ifnames = new List<string>();
                            foreach (ComInterfaceData i in rcw.Interfaces)
                            {
                                ifnames.Add(i.Type.Name);
                            }
                            string ifname = String.Join(",", ifnames);
                            if (!IsHideITypeInfo || ifname != "System.Runtime.InteropServices.ComTypes.ITypeInfo")
                            {
                                objCount += 1;
                                diagMsg.AppendLine(String.Format("{0,16:X} {1} {2} {3} {4}", rcw.Address, obj.Type.Name, rcw.RefCount, rcw.IsDisconnected, ifname));
                            }
                        }
                        else
                        {
                            diagMsg.AppendLine(String.Format("{0,16:X} {1} (failed to GetRCWData())", obj.Address, obj.Type.Name));
                        }
                    }
                }
            }
            return String.Format("[{0}]== memorycheck ({1}, {2}) {3} : {4}\r\n", objCount, processName, procs[0].Id, DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"), appMsg) + diagMsg.ToString();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            UpdateButtonStatus();
        }

        private void MainForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            DetachProcess();
        }

        private void AttachButton_Click(object sender, EventArgs e)
        {
            AttachProcess();
        }

        private void DetachButton_Click(object sender, EventArgs e)
        {
            DetachProcess();
        }

        private void SnapshotButton_Click(object sender, EventArgs e)
        {
            UpdateView("(snapshot)", true);
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            UpdateView();
        }

        protected override void WndProc(ref Message m)
        {
            if (m.Msg == WM_COPYDATA)
            {
                NativeMethods.COPYDATASTRUCT cds = (NativeMethods.COPYDATASTRUCT)m.GetLParam(typeof(NativeMethods.COPYDATASTRUCT));
                int command = cds.dwData.ToInt32();
                string msg = cds.lpData;

                switch (command)
                {
                    case RCWCHECKER_ATTACH:
                        ProcessNameTextBox.Text = msg;
                        AttachProcess("(attach)", true, true);
                        break;
                    case RCWCHECKER_DUMP:
                        UpdateView(msg, true);
                        break;
                }
            }
            base.WndProc(ref m);
        }
    }
}
