﻿using System;
using System.Timers;
using ChromeCast.Desktop.AudioStreamer.Application.Interfaces;

namespace ChromeCast.Desktop.AudioStreamer.Application
{
    public class DeviceStatusTimer : IDeviceStatusTimer
    {
        public const int Interval = 30000;
        private Action onGetStatus;
        private Timer timer;

        public void StartPollingDevice(Action onGetStatusIn)
        {
            onGetStatus = onGetStatusIn;

            timer = new Timer
            {
                Interval = Interval,
                Enabled = true
            };
            timer.Elapsed += new ElapsedEventHandler(OnGetStatus);
            timer.Start();
        }

        private void OnGetStatus(object sender, ElapsedEventArgs e)
        {
            onGetStatus?.Invoke();
        }
    }
}