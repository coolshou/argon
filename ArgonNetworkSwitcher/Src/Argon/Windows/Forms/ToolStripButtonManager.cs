﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

namespace Argon.Windows.Forms
{
    public class ToolStripButtonManager
    {
        //protected ToolStrip _toolStrip;

        public ToolStripButtonManager(FormMain formMain)
        {
            //_toolStrip = formMain.toolStrip;
        }

        public void EnableButtons(params RibbonButton[] buttons)
        {
            SetValue(true, buttons);
        }

        public void DisableButtons(params RibbonButton[] buttons)
        {
            SetValue(false, buttons);
        }

        internal void SetValue(bool foundValue, params RibbonButton[] buttons)
        {
            //TODO to disable others ones
            foreach (RibbonButton item in buttons)
            {
                item.Enabled = true;
            }
            /*
            bool notFoundValue = !foundValue;
            bool found;
            ToolStripButton item;
            foreach (ToolStripItem a in _toolStrip.Items)
            {
                found = false;

                item = a as ToolStripButton;

                if (item == null) continue;

                foreach (ToolStripButton button in buttons)
                {
                    if (item.Name.Equals(button.Name))
                    {
                        found = true;
                        break;
                    }
                }

                if (found)
                {
                    item.Enabled = foundValue;
                }
                else
                {
                    item.Enabled = notFoundValue;
                }
            }*/
        }       

    }
}
