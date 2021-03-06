using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using WeifenLuo.WinFormsUI.Docking;
using System.Net.NetworkInformation;
using Argon.Windows;
using Argon.Windows.Network;
using Argon.UseCase;
using Argon.Models;


/*
 * Copyright 2012 Francesco Benincasa
 *
 *  Licensed under the Apache License, Version 2.0 (the "License");
 *  you may not use this file except in compliance with the License.
 *  You may obtain a copy of the License at
 *
 *      http://www.apache.org/licenses/LICENSE-2.0
 *
 *  Unless required by applicable law or agreed to in writing, software
 *  distributed under the License is distributed on an "AS IS" BASIS,
 *  WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
 *  See the License for the specific language governing permissions and
 *  limitations under the License.
 */
namespace Argon.Windows.Forms
{
    public partial class FormNetworkCard : ArgonDockContent
    {
        /// <summary>
        /// Gets or sets the NIC.
        /// </summary>
        /// <value>
        /// The NIC.
        /// </value>
        public WindowsNetworkCard NetworkCard
        {
            get { return (WindowsNetworkCard)Tag; }
            set { Tag = value; }
        }

        public FormNetworkCard()
        {
            InitializeComponent();
            SetStyle(ControlStyles.OptimizedDoubleBuffer |
                        ControlStyles.UserPaint |
                        ControlStyles.AllPaintingInWmPaint, true);

        }

        private string formatIpString(string input)
        {
            return input;
        }


        private void FormCardInfo_Load(object sender, EventArgs e)
        {
            this.Activated += new System.EventHandler(this.ArgonDockContent_Activated);
            FromDataToView();
        }

        private void FormCardInfo_FormClosed(object sender, FormClosedEventArgs e)
        {
            bool ret = ViewModel.NetworkCardViewList.Remove(this);
            UseCaseLogger.ShowInfo("Network card form closed " + ret);
        }

        /// <summary>
        /// Froms the data to view. Get the NetworkCard attribute and display it on form
        /// </summary>
        private void FromDataToView()
        {
            txtCardType.Text = NetworkCard.CardType.ToString();
            txtDescription.Text = NetworkCard.Description;
            txtName.Text = NetworkCard.Name;            
            txtMAC.Text = NetworkCard.MacAddress;
            txtDHCP.Text = NetworkCard.Dhcp.ToString();
            txtIP.Text = NetworkCard.IpAddress;
            txtGateway.Text = NetworkCard.GatewayAddress;
            txtSubnetMask.Text = NetworkCard.SubnetMask;
            txtDns1.Text = NetworkCard.Dns;
            txtDns2.Text = NetworkCard.Dns2;
            txtStatus.Text = NetworkCard.Status;
            switch(NetworkCard.CardType)
            {
                case WindowsNetworkCardType.ETHERNET:
                    pictureBox.Image = UseCaseApplication.GetImage("type_ethernet_300x400");
                    break;
                case WindowsNetworkCardType.WIRELESS:
                    pictureBox.Image = UseCaseApplication.GetImage("type_wifi_300x400");
                    break;
                case WindowsNetworkCardType.BLUETOOTH:
                    pictureBox.Image = UseCaseApplication.GetImage("type_bluetooth_300x400");
                    break;
                case WindowsNetworkCardType.VIRTUAL:
                    pictureBox.Image = UseCaseApplication.GetImage("type_virtual_300x400");
                    break;

            }
            
        }

        /// <summary>
        /// Stores the form on data.
        /// </summary>
        public override void StoreFormOnData()
        {
            //TODO: to implements
        }

        /// <summary>
        /// Views the data on form.
        /// </summary>
        public override void ViewDataOnForm()
        {
            //TODO: to implements
        }


    }
}