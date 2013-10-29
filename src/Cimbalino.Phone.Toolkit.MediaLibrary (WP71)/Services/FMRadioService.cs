// ****************************************************************************
// <copyright file="FMRadioService.cs" company="Pedro Lamas">
// Copyright © Pedro Lamas 2013
// </copyright>
// ****************************************************************************
// <author>Pedro Lamas</author>
// <email>pedrolamas@gmail.com</email>
// <date>07-08-2013</date>
// <project>Cimbalino.Phone.Toolkit.MediaLibrary</project>
// <web>http://www.pedrolamas.com</web>
// <license>
// See license.txt in this solution or http://www.pedrolamas.com/license_MIT.txt
// </license>
// ****************************************************************************

using Microsoft.Devices.Radio;

namespace Cimbalino.Phone.Toolkit.Services
{
    /// <summary>
    /// Represents an implementation of the <see cref="IFMRadioService"/>.
    /// </summary>
    public class FMRadioService : IFMRadioService
    {
        private bool? _isAvailable;

        /// <summary>
        /// Gets a value indicating whether the FM radio is available.
        /// </summary>
        /// <value>true if the FM radio is available; otherwise, false.</value>
        public bool IsAvailable
        {
            get
            {
                if (!_isAvailable.HasValue)
                {
                    try
                    {
                        _isAvailable = FMRadio.Instance != null;
                    }
                    catch
                    {
                        _isAvailable = false;
                    }
                }

                return _isAvailable.Value;
            }
        }

        /// <summary>
        /// Gets or sets the FM radio frequency region information.
        /// </summary>
        /// <value>The FM radio frequency region information.</value>
        public RadioRegion CurrentRegion
        {
            get
            {
                return FMRadio.Instance.CurrentRegion;
            }
            set
            {
                FMRadio.Instance.CurrentRegion = value;
            }
        }

        /// <summary>
        /// Gets or sets the FM radio frequency.
        /// </summary>
        /// <value>The FM radio frequency.</value>
        public double Frequency
        {
            get
            {
                return FMRadio.Instance.Frequency;
            }
            set
            {
                FMRadio.Instance.Frequency = value;
            }
        }

        /// <summary>
        /// Gets or sets a value indicating whether the FM radio power is on or off.
        /// </summary>
        /// <value>true if the FM radio power in on; otherwise, false.</value>
        public bool IsRadioPowerOn
        {
            get
            {
                return FMRadio.Instance.PowerMode == RadioPowerMode.On;
            }
            set
            {
                if (value)
                {
                    PowerOn();
                }
                else
                {
                    PowerOff();
                }
            }
        }

        /// <summary>
        /// Gets the received signal strength indicator (RSSI) value for the currently tuned frequency.
        /// </summary>
        /// <value>The received signal strength indicator (RSSI) value for the currently tuned frequency.</value>
        public double SignalStrength
        {
            get
            {
                return FMRadio.Instance.SignalStrength;
            }
        }

        /// <summary>
        /// Power on the FM radio.
        /// </summary>
        public void PowerOn()
        {
            FMRadio.Instance.PowerMode = RadioPowerMode.On;
        }

        /// <summary>
        /// Power off the FM radio.
        /// </summary>
        public void PowerOff()
        {
            FMRadio.Instance.PowerMode = RadioPowerMode.Off;
        }
    }
}