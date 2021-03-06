﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Argon.Windows.Forms;
using WeifenLuo.WinFormsUI.Docking;
using Argon.Models;
using System.Windows.Forms;
using Argon.Windows.Network.Profile;

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
namespace Argon.UseCase
{
    public abstract class UseCaseView
    {
        /// <summary>
        /// Toggles the display.
        /// </summary>
        /// <param name="dockContent">Content of the dock.</param>
        public static void ToggleDisplay(ArgonDockContent dockContent)
        {
            if (dockContent.Visible)
            {
                // hide content
                Hide(dockContent);
            }
            else
            {
                // display content
                Display(dockContent, true, dockContent.OldDockState);
            }
        }

        /// <summary>
        /// Displays the specified dock content.
        /// </summary>
        /// <param name="dockContent">Content of the dock.</param>
        /// <param name="dockState">State of the dock.</param>
        /// <returns></returns>
        public static bool Display(ArgonDockContent dockContent, bool forceShow=false,DockState dockState=DockState.Unknown)
        {
            if (forceShow)
            {
                dockContent.DockState = dockState;

                if (dockState == DockState.Unknown && dockContent.OldDockState != DockState.Unknown)
                {
                    dockContent.DockState = dockContent.OldDockState;
                }

                dockContent.Show(ViewModel.MainView.dockPanel);
            }

            // check ribbon button
            if (dockContent == ViewModel.ProfilesView)
            {                
                CheckRibbonButton(dockContent, ViewModel.MainView.rbtnViewProfiles);
            }
            else if (dockContent == ViewModel.NetworkCardsView)
            {
                CheckRibbonButton(dockContent, ViewModel.MainView.rbtnViewNetworkCards);
            }
            else if (dockContent == ViewModel.ConsoleView)
            {
                CheckRibbonButton(dockContent, ViewModel.MainView.rbtnViewConsole);
            }
            else if (dockContent == ViewModel.OptionsView)
            {
                CheckRibbonButton(dockContent, ViewModel.MainView.rbtnViewSettings);
            }    

            return true;
        }

        /// <summary>
        /// Displays the specified dock content.
        /// </summary>
        /// <param name="dockContent">Content of the dock.</param>
        /// <param name="dockState">State of the dock.</param>
        /// <returns></returns>
        public static void Hide(ArgonDockContent dockContent)
        {            
            dockContent.OldDockState = dockContent.DockState;
            dockContent.DockState = DockState.DockBottom;
            dockContent.Hide();

            // check ribbon button
            if (dockContent == ViewModel.ProfilesView)
            {
                CheckRibbonButton(dockContent, ViewModel.MainView.rbtnViewProfiles);
            }
            else if (dockContent == ViewModel.NetworkCardsView)
            {
                CheckRibbonButton(dockContent, ViewModel.MainView.rbtnViewNetworkCards);
            }
            else if (dockContent == ViewModel.ConsoleView)
            {
                CheckRibbonButton(dockContent, ViewModel.MainView.rbtnViewConsole);
            }
            else if (dockContent == ViewModel.OptionsView)
            {
                CheckRibbonButton(dockContent, ViewModel.MainView.rbtnViewSettings);
            }  
            
        }

        /// <summary>
        /// Checks the ribbon button.
        /// </summary>
        /// <param name="dockContent">Content of the dock.</param>
        /// <param name="button">The button.</param>
        /// <returns></returns>
        internal static void CheckRibbonButton(ArgonDockContent dockContent, RibbonButton button)
        {
            //ActionRefreshNetworkAdapters();
            if (dockContent.Visible)
            {
                button.Checked = true;
            }
            else
            {
                button.Checked = false;
            }
        }


        /// <summary>
        /// Activates the form cards.
        /// </summary>
        public static void ActivateFormCards()
        {
            FormMain main = ViewModel.MainView;

            // form selezionati
            ViewModel.SelectedView = ViewModel.NetworkCardsView;
        }

        /// <summary>
        /// Activates the form network card.
        /// </summary>
        /// <param name="selectedNetworkCardForm">The selected network card form.</param>
        public static void ActivateFormNetworkCard(FormNetworkCard selectedNetworkCardForm)
        {/*
            // profili
            ViewModel.MainView.rbtnProfileNew.Enabled = false;
            ViewModel.MainView.rbtnProfileView.Enabled = false;
            ViewModel.MainView.rbtnProfileDelete.Enabled = false;

            // profilo
            ViewModel.MainView.rbtnProfileRun.Enabled = false;
            ViewModel.MainView.rbtnProfileSave.Enabled = false;

            // documento
            ViewModel.MainView.rbtnConfigSave.Enabled = false;
            ViewModel.MainView.rbtnConfigLoad.Enabled = false;

            // networkcard
            ViewModel.MainView.rbtnCardsRefresh.Enabled = false;
            ViewModel.MainView.rbtnCardView.Enabled = false;*/

            ViewModel.MainView.ribbon.ActiveTab = ViewModel.MainView.rtOperations;

            // form selezionati            
            ViewModel.SelectedView = selectedNetworkCardForm;
        }

        /// <summary>
        /// Activates the form network card.
        /// </summary>
        /// <param name="selectedNetworkCardForm">The selected network card form.</param>
        public static void ActivateFormProfile(FormProfile selectedProfileForm)
        {
            /*
            // profili
            ViewModel.MainView.rbtnProfileNew.Enabled = true;
            ViewModel.MainView.rbtnProfileView.Enabled = true;
            ViewModel.MainView.rbtnProfileDelete.Enabled = true;

            // profilo
            ViewModel.MainView.rbtnProfileRun.Enabled = true;
            ViewModel.MainView.rbtnProfileSave.Enabled = true;

            // documento
            ViewModel.MainView.rbtnConfigSave.Enabled = true;
            ViewModel.MainView.rbtnConfigLoad.Enabled = true;

            // networkcard
            ViewModel.MainView.rbtnCardsRefresh.Enabled = false;
            ViewModel.MainView.rbtnCardView.Enabled = false;*/

            ViewModel.MainView.ribbon.ActiveTab = ViewModel.MainView.rtOperations;

            // form selezionati            
            ViewModel.SelectedView = selectedProfileForm;
        }

        /// <summary>
        /// Shows the specified profile.
        /// </summary>
        /// <param name="profile">The profile.</param>
        public static void ShowProfile(NetworkProfile profile)
        {
            if (profile == null) return;

            NetworkProfile item;

            foreach (FormProfile itemForm in ViewModel.ProfileViewList)
            {
                if ((itemForm.Tag is NetworkProfile))
                {
                    item = (NetworkProfile)itemForm.Tag;

                    if (item.Id.Equals(profile.Id))
                    {
                        if (!itemForm.Visible)
                        {
                            itemForm.Show(ViewModel.MainView.Pannello);
                        }

                        itemForm.Focus();
                        //UseCaseView.ActivateFormProfile(itemForm);
                        return;
                    }
                }
            }            

            FormProfile form = new FormProfile();
            form.Profile = profile;

            // update networkcard for security
            //profile.NetworkCardInfo = DataModel.FindNetworkCard(profile.NetworkCardInfo.Id);

            form.ViewDataOnForm();

            ViewModel.ProfileViewList.Add(form);
            form.Show(ViewModel.MainView.Pannello);
            form.DockState = DockState.Document;            
        }



        /// <summary>
        /// Shows the new profile.
        /// </summary>
        public static void ShowNewProfile()
        {
            // check if it is possibile to do operation
            if (UseCaseApplication.CheckIsOperationNotAllowedNow()) return; 

            NetworkProfile profile = new NetworkProfile();
            profile.Name = UseCaseProfile.NEW_NIC_NAME;

            ShowProfile(profile);
        }

        /// <summary>
        /// Finds the and close profile.
        /// </summary>
        /// <param name="profile">The profile.</param>
        public static bool FindAndCloseProfile(NetworkProfile profile)
        {
            foreach (FormProfile form in ViewModel.ProfileViewList)
            {
                if (form.Profile.Id.Equals(profile.Id))
                {
                    form.Close();
                    ViewModel.ProfileViewList.Remove(form);
                    return true;
                }

            }

            return false;
        }

        /// <summary>
        /// Clears the console.
        /// </summary>
        public static void ClearConsole()
        {
            ViewModel.ConsoleView.lstBox.Items.Clear();
        }
    }
}
