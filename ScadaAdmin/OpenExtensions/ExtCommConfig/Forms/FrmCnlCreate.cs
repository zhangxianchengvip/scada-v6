﻿// Copyright (c) Rapid Software LLC. All rights reserved.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using Scada.Admin.Extensions.ExtCommConfig.Code;
using Scada.Admin.Project;
using Scada.Forms;
using System;
using System.Windows.Forms;

namespace Scada.Admin.Extensions.ExtCommConfig.Forms
{
    /// <summary>
    /// Represents a form for creating channels.
    /// <para>Представляет форму для создания каналов.</para>
    /// </summary>
    public partial class FrmCnlCreate : Form
    {
        private readonly IAdminContext adminContext;      // the Administrator context
        private readonly ScadaProject project;            // the project under development
        private readonly RecentSelection recentSelection; // the recently selected objects
        private int step;                                 // the current step of the wizard


        /// <summary>
        /// Initializes a new instance of the class.
        /// </summary>
        private FrmCnlCreate()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Initializes a new instance of the class.
        /// </summary>
        public FrmCnlCreate(IAdminContext adminContext, ScadaProject project, RecentSelection recentSelection)
            : this()
        {
            this.adminContext = adminContext ?? throw new ArgumentNullException(nameof(adminContext));
            this.project = project ?? throw new ArgumentNullException(nameof(project));
            this.recentSelection = recentSelection ?? throw new ArgumentNullException(nameof(recentSelection));
            step = 1;
        }


        /// <summary>
        /// Applies the wizard step.
        /// </summary>
        private void ApplyStep(int offset)
        {
            step += offset;

            if (step < 1)
                step = 1;
            else if (step > 3)
                step = 3;

            ctrlCnlCreate1.Visible = false;
            ctrlCnlCreate2.Visible = false;
            ctrlCnlCreate3.Visible = false;
            chkPreview.Visible = false;
            btnBack.Visible = false;
            btnNext.Visible = false;
            btnCreate.Visible = false;

            switch (step)
            {
                case 1:
                    lblStep.Text = ExtensionPhrases.CreateCnlsStep1;
                    ctrlCnlCreate1.Visible = true;
                    btnNext.Visible = true;

                    ctrlCnlCreate1.SetFocus();
                    btnNext.Enabled = ctrlCnlCreate1.StatusOK;
                    break;
                case 2:
                    lblStep.Text = ExtensionPhrases.CreateCnlsStep2;
                    ctrlCnlCreate2.Visible = true;
                    btnBack.Visible = true;
                    btnNext.Visible = true;

                    ctrlCnlCreate2.DeviceName = ctrlCnlCreate1.SelectedDevice?.Name;
                    ctrlCnlCreate2.SetFocus();
                    break;
                case 3:
                    lblStep.Text = ExtensionPhrases.CreateCnlsStep3;
                    ctrlCnlCreate3.Visible = true;
                    chkPreview.Visible = true;
                    btnBack.Visible = true;
                    btnCreate.Visible = true;

                    if (ctrlCnlCreate1.StatusOK)
                    {
                        ctrlCnlCreate3.ResetCnlNums(ctrlCnlCreate1.CnlPrototypes.Count);
                        btnCreate.Enabled = true;
                    }
                    else
                    {
                        btnCreate.Enabled = false;
                    }

                    ctrlCnlCreate3.DeviceName = ctrlCnlCreate1.SelectedDevice?.Name;
                    ctrlCnlCreate3.SetFocus();
                    break;
            }
        }


        private void FrmCnlCreate_Load(object sender, EventArgs e)
        {
            FormTranslator.Translate(this, GetType().FullName);
            FormTranslator.Translate(ctrlCnlCreate1, ctrlCnlCreate1.GetType().FullName);
            FormTranslator.Translate(ctrlCnlCreate2, ctrlCnlCreate2.GetType().FullName);
            FormTranslator.Translate(ctrlCnlCreate3, ctrlCnlCreate3.GetType().FullName);

            ctrlCnlCreate1.Init(adminContext, project, recentSelection);
            ctrlCnlCreate2.Init(project, recentSelection);
            ctrlCnlCreate3.Init();
            ApplyStep(0);
        }

        private void ctrlCnlCreate1_SelectedDeviceChanged(object sender, EventArgs e)
        {
            if (step == 1)
                btnNext.Enabled = ctrlCnlCreate1.StatusOK;
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            ApplyStep(-1);
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            ApplyStep(1);
        }

        private void btnCreate_Click(object sender, EventArgs e)
        {

        }
    }
}