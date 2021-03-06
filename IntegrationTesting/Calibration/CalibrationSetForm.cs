﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using IntegrationTesting.Tool;
using IntegrationTesting.Robot;

namespace IntegrationTesting
{
    public partial class CalibrationSetForm : Form
    {
        AqCalibration m_calibrationCenter = new AqCalibration();
        int m_cameraInOutHand = 0; //0-kCameraInHand, 1-kCameraOutHand
        public int CameraInOutHand
        {
            get { return m_cameraInOutHand; }
            set { m_cameraInOutHand = value; }
        }
        bool m_Ispositive = true;
        public bool IsPositive
        {
            get { return m_Ispositive; }
            set { m_Ispositive = value; }
        }

        public CalibrationSetForm()
        {
            InitializeComponent();
            string[] modeList = new string[]{"Camera in  Hand with Angle is Positive", "Camera in  Hand with Angle is Negative",
                                             "Camera out Hand with Angle is Positive", "Camera out Hand with Angle is Negative"};
            foreach (string mode in modeList)
            {
                comboBoxModeList.Items.Add(mode);
            }
            comboBoxModeList.SelectedIndex = 2;

            m_calibrationCenter.CalibrationResultSavePath = Application.StartupPath + @"\location\\ResultNormal.txt";
            if(File.Exists(m_calibrationCenter.CalibrationResultSavePath))
            {
                if(!m_calibrationCenter.LoadCalibrationResult())
                {
                    MessageBox.Show("loadCalibrationResult Error");
                }
            }

            IniFile.IniFillFullPath = Application.StartupPath + "\\Config.ini";
            if (!File.Exists(IniFile.IniFillFullPath))
            {
                File.Create(IniFile.IniFillFullPath);
            }
            else
            {
                ReadCalibrationDataFromFile();
            }
            panelSingleInput.Enabled = false;
            panelBatchInput.Enabled = true;
        }

        public void SetCurrentRobotPosition(double robotX, double robotY, double robotRz)
        {
            m_calibrationCenter.RobotPoint.RobotX = robotX;
            m_calibrationCenter.RobotPoint.RobotY = robotY;
            m_calibrationCenter.RobotPoint.RobotRz = robotRz;
        }

        public void SetCurrentImagePosition(double imageX, double imageY, double imageA)
        {
            m_calibrationCenter.ImagePoint.ImageX = imageX;
            m_calibrationCenter.ImagePoint.ImageY = imageY;
            m_calibrationCenter.ImagePoint.ImageA = imageA;
        }

        public void GetCurrentCatchPosition(ref double posX, ref double posY,ref double theta, string resultPath)
        {
            m_calibrationCenter.CalibrationResultSavePath = resultPath;
            m_calibrationCenter.LoadCalibrationResult();
            m_calibrationCenter.GetRobotPoint();
            posX = m_calibrationCenter.CatchPoint.CatchX;
            posY = m_calibrationCenter.CatchPoint.CatchY;
            theta = m_calibrationCenter.CatchPoint.CatchRz;
        }

        private bool ReadCalibrationDataFromFile()
        {
            m_calibrationCenter.AllLineData.Clear();
            string sectionName = "Calibration";
            string keyValue = "LineGroupCount";
            int lineGroup = IniFile.ReadValue(sectionName, keyValue, 0);
            for(int i = 0; i < lineGroup; i++)
            {
                AqCalibration.CalibrationDataGroup calibrationlineData = new AqCalibration.CalibrationDataGroup();
                keyValue = string.Format("CameraX{0}", i);
                calibrationlineData.CameraPosition.ImageX = Convert.ToDouble(IniFile.ReadValue(sectionName, keyValue, "0"));
                keyValue = string.Format("CameraY{0}", i);
                calibrationlineData.CameraPosition.ImageY = Convert.ToDouble(IniFile.ReadValue(sectionName, keyValue, "0"));
                keyValue = string.Format("RobotX{0}", i);
                calibrationlineData.RobotCoordinate.RobotX = Convert.ToDouble(IniFile.ReadValue(sectionName, keyValue, "0"));
                keyValue = string.Format("RobotY{0}", i);
                calibrationlineData.RobotCoordinate.RobotY = Convert.ToDouble(IniFile.ReadValue(sectionName, keyValue, "0"));
                keyValue = string.Format("RobotRz{0}", i);
                calibrationlineData.RobotCoordinate.RobotRz = Convert.ToDouble(IniFile.ReadValue(sectionName, keyValue, "0"));
                m_calibrationCenter.AllLineData.Add(calibrationlineData);
            }

            keyValue = "ResultImageX";
            textBoxImageX.Text = IniFile.ReadValue(sectionName, keyValue, "0");
            keyValue = "ResultImageY";
            textBoxImageY.Text = IniFile.ReadValue(sectionName, keyValue, "0");
            keyValue = "ResultImageRz";
            textBoxImageA.Text = IniFile.ReadValue(sectionName, keyValue, "0");

            keyValue = "RobotPosX";
            textBoxRobotPosX.Text = IniFile.ReadValue(sectionName, keyValue, "0");
            keyValue = "RobotPosY";
            textBoxRobotPosY.Text = IniFile.ReadValue(sectionName, keyValue, "0");
            keyValue = "RobotPosRz";
            textBoxRobotPosRz.Text = IniFile.ReadValue(sectionName, keyValue, "0");

            keyValue = "CatchPosX";
            textBoxCatchRobotX.Text = IniFile.ReadValue(sectionName, keyValue, "0");
            keyValue = "CatchPosY";
            textBoxCatchRobotY.Text = IniFile.ReadValue(sectionName, keyValue, "0");
            keyValue = "CatchPosRz";
            textBoxCatchRobotRz.Text = IniFile.ReadValue(sectionName, keyValue, "0");

            return true;
        }

        private bool WriteCalibrationDataToFile()
        {
            string sectionName = "Calibration";
            string keyValue = "LineGroupCount";
            IniFile.WriteValue(sectionName, keyValue, m_calibrationCenter.AllLineData.Count.ToString());
            foreach (AqCalibration.CalibrationDataGroup singleLine in m_calibrationCenter.AllLineData)
            {
                keyValue = string.Format("CameraX{0}", m_calibrationCenter.AllLineData.IndexOf(singleLine));
                IniFile.WriteValue(sectionName, keyValue, singleLine.CameraPosition.ImageX.ToString());

                keyValue = string.Format("CameraY{0}", m_calibrationCenter.AllLineData.IndexOf(singleLine));
                IniFile.WriteValue(sectionName, keyValue, singleLine.CameraPosition.ImageY.ToString());

                keyValue = string.Format("RobotX{0}", m_calibrationCenter.AllLineData.IndexOf(singleLine));
                IniFile.WriteValue(sectionName, keyValue, singleLine.RobotCoordinate.RobotX.ToString());

                keyValue = string.Format("RobotY{0}", m_calibrationCenter.AllLineData.IndexOf(singleLine));
                IniFile.WriteValue(sectionName, keyValue, singleLine.RobotCoordinate.RobotY.ToString());

                keyValue = string.Format("RobotRz{0}", m_calibrationCenter.AllLineData.IndexOf(singleLine));
                IniFile.WriteValue(sectionName, keyValue, singleLine.RobotCoordinate.RobotRz.ToString());
            }

            IniFile.WriteValue(sectionName, "ResultImageX", textBoxImageX.Text);
            IniFile.WriteValue(sectionName, "ResultImageY", textBoxImageY.Text);
            IniFile.WriteValue(sectionName, "ResultImageRz", textBoxImageA.Text);

            IniFile.WriteValue(sectionName, "RobotPosX", textBoxRobotPosX.Text);
            IniFile.WriteValue(sectionName, "RobotPosY", textBoxRobotPosY.Text);
            IniFile.WriteValue(sectionName, "RobotPosRz", textBoxRobotPosRz.Text);

            IniFile.WriteValue(sectionName, "CatchPosX", textBoxCatchRobotX.Text);
            IniFile.WriteValue(sectionName, "CatchPosY", textBoxCatchRobotY.Text);
            IniFile.WriteValue(sectionName, "CatchPosRz", textBoxCatchRobotRz.Text);

            return true;
        }

        public void UpdataCalibrationDataShow()
        {
            while (listViewParameterSet.Items.Count > 0)
            {
                listViewParameterSet.Items.Remove(listViewParameterSet.Items[0]);
            }

            foreach(AqCalibration.CalibrationDataGroup singleLine in m_calibrationCenter.AllLineData)
            {
                ListViewItem line = new ListViewItem(singleLine.CameraPosition.ImageX.ToString(), 0);
                line.SubItems.Add(singleLine.CameraPosition.ImageY.ToString());
                line.SubItems.Add(singleLine.RobotCoordinate.RobotX.ToString());
                line.SubItems.Add(singleLine.RobotCoordinate.RobotY.ToString());
                line.SubItems.Add(singleLine.RobotCoordinate.RobotRz.ToString());
                listViewParameterSet.Items.Add(line);
            }
        }

        private void listViewParameterSet_SelectedIndexChanged(object sender, EventArgs e)
        {
            //MessageBox.Show(listViewParameterSet.Items.IndexOf(listViewParameterSet.SelectedItems[0]).ToString());
            if(listViewParameterSet.SelectedItems.Count > 0 )
            {
                textBoxCameraX.Text = listViewParameterSet.SelectedItems[0].SubItems[0].Text;
                textBoxCameraY.Text = listViewParameterSet.SelectedItems[0].SubItems[1].Text;
                textBoxRobotX.Text = listViewParameterSet.SelectedItems[0].SubItems[2].Text;
                textBoxRobotY.Text = listViewParameterSet.SelectedItems[0].SubItems[3].Text;
                textBoxRobotRz.Text = listViewParameterSet.SelectedItems[0].SubItems[4].Text;
            }
        }

        private void buttonNewLine_Click(object sender, EventArgs e)
        {
            ListViewItem line = new ListViewItem(textBoxCameraX.Text, 0);
            line.SubItems.Add(textBoxCameraY.Text);
            line.SubItems.Add(textBoxRobotX.Text);
            line.SubItems.Add(textBoxRobotY.Text);
            line.SubItems.Add(textBoxRobotRz.Text);
            listViewParameterSet.Items.Add(line);

            AqCalibration.CalibrationDataGroup calibrationlineData = new AqCalibration.CalibrationDataGroup();
            calibrationlineData.CameraPosition.ImageX = Convert.ToDouble(textBoxCameraX.Text);
            calibrationlineData.CameraPosition.ImageY = Convert.ToDouble(textBoxCameraY.Text);
            calibrationlineData.RobotCoordinate.RobotX = Convert.ToDouble(textBoxRobotX.Text);
            calibrationlineData.RobotCoordinate.RobotY = Convert.ToDouble(textBoxRobotY.Text);
            calibrationlineData.RobotCoordinate.RobotRz = Convert.ToDouble(textBoxRobotRz.Text);
            m_calibrationCenter.AllLineData.Add(calibrationlineData);
            textBoxCameraX.Text = "";
            textBoxCameraY.Text = "";
            textBoxRobotX.Text = "";
            textBoxRobotY.Text = "";
            textBoxRobotRz.Text = "";
        }

        private void buttonDeleteLine_Click(object sender, EventArgs e)
        {
            if (listViewParameterSet.SelectedItems.Count > 0)
            {
                int index = listViewParameterSet.Items.IndexOf(listViewParameterSet.SelectedItems[0]);
                listViewParameterSet.Items.Remove(listViewParameterSet.SelectedItems[0]);
                m_calibrationCenter.AllLineData.RemoveAt(index);
            }
        }

        private void buttonUpdateLine_Click(object sender, EventArgs e)
        {
            if(listViewParameterSet.SelectedItems.Count > 0)
            {
                listViewParameterSet.SelectedItems[0].SubItems[0].Text = textBoxCameraX.Text;
                listViewParameterSet.SelectedItems[0].SubItems[1].Text = textBoxCameraY.Text;
                listViewParameterSet.SelectedItems[0].SubItems[2].Text = textBoxRobotX.Text;
                listViewParameterSet.SelectedItems[0].SubItems[3].Text = textBoxRobotY.Text;
                listViewParameterSet.SelectedItems[0].SubItems[4].Text = textBoxRobotRz.Text;
                int index = listViewParameterSet.Items.IndexOf(listViewParameterSet.SelectedItems[0]);
                m_calibrationCenter.AllLineData.ElementAt(index).CameraPosition.ImageX = Convert.ToDouble(textBoxCameraX.Text);
                m_calibrationCenter.AllLineData.ElementAt(index).CameraPosition.ImageY = Convert.ToDouble(textBoxCameraY.Text);
                m_calibrationCenter.AllLineData.ElementAt(index).RobotCoordinate.RobotX = Convert.ToDouble(textBoxRobotX.Text);
                m_calibrationCenter.AllLineData.ElementAt(index).RobotCoordinate.RobotY = Convert.ToDouble(textBoxRobotY.Text);
                m_calibrationCenter.AllLineData.ElementAt(index).RobotCoordinate.RobotRz = Convert.ToDouble(textBoxRobotRz.Text);
            }
        }

        private void buttonCalibration_Click(object sender, EventArgs e)
        {
            m_calibrationCenter.ClearPoint();
            int rowCounts = listViewParameterSet.Items.Count;
            for(int i=0; i<rowCounts; i++)
            {
                try
                {
                    m_calibrationCenter.ImagePoint.SetValue(
                    Convert.ToDouble(listViewParameterSet.Items[i].SubItems[0].Text),
                    Convert.ToDouble(listViewParameterSet.Items[i].SubItems[1].Text), 0);

                    m_calibrationCenter.RobotPoint.SetValue(
                    Convert.ToDouble(listViewParameterSet.Items[i].SubItems[2].Text),
                    Convert.ToDouble(listViewParameterSet.Items[i].SubItems[3].Text),
                    Convert.ToDouble(listViewParameterSet.Items[i].SubItems[4].Text)*Math.PI/180);

                    if(!m_calibrationCenter.AddMoveMatchPointPair())
                    {
                        MessageBox.Show("Add Move Match Point Pair Error");
                        return ;
                    }
                }
                catch (FormatException ex)
                {
                    MessageBox.Show(ex.Message);
                }

            }
            if(m_calibrationCenter.NPoint2AngleCalibartion())
            {
                MessageBox.Show("N Point to Angle Calibration Error =>" + string.Format("RMS:{0}",m_calibrationCenter.ResultRMS));
            }
        }

        private void buttonSetCatchSet_Click(object sender, EventArgs e)
        {
            try
            {
                m_calibrationCenter.ImagePoint.SetValue(Convert.ToDouble(textBoxImageX.Text),
                                        Convert.ToDouble(textBoxImageY.Text),
                                        Convert.ToDouble(textBoxImageA.Text)*Math.PI/180);

                m_calibrationCenter.RobotPoint.SetValue(Convert.ToDouble(textBoxRobotPosX.Text),
                                                        Convert.ToDouble(textBoxRobotPosY.Text),
                                                        Convert.ToDouble(textBoxRobotPosRz.Text)*Math.PI/180);

                m_calibrationCenter.CatchPoint.SetValue(Convert.ToDouble(textBoxCatchRobotX.Text),
                                                        Convert.ToDouble(textBoxCatchRobotY.Text),
                                                        Convert.ToDouble(textBoxCatchRobotRz.Text)*Math.PI/180);

                if (!m_calibrationCenter.SetCatchPoint())
                {
                    MessageBox.Show("Set Catch Point Error");
                }
                else
                {
                    MessageBox.Show("Set Catch Point Success");
                }
            }
            catch (FormatException ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void buttonGetResult_Click(object sender, EventArgs e)
        {
            try
            {
                m_calibrationCenter.SetConfig(CameraInOutHand, IsPositive);
                m_calibrationCenter.ImagePoint.SetValue(Convert.ToDouble(textBoxImageX.Text),
                                        Convert.ToDouble(textBoxImageY.Text),
                                        Convert.ToDouble(textBoxImageA.Text)*Math.PI/180);

                m_calibrationCenter.RobotPoint.SetValue(Convert.ToDouble(textBoxRobotPosX.Text),
                                                        Convert.ToDouble(textBoxRobotPosY.Text),
                                                        Convert.ToDouble(textBoxRobotPosRz.Text)*Math.PI/180);

                if (!m_calibrationCenter.GetRobotPoint())
                {
                    MessageBox.Show("Set Catch Point Error");
                }

                textBoxCatchRobotX.Text = Convert.ToString(m_calibrationCenter.CatchPoint.CatchX);
                textBoxCatchRobotY.Text = Convert.ToString(m_calibrationCenter.CatchPoint.CatchY);
                textBoxCatchRobotRz.Text = Convert.ToString(m_calibrationCenter.CatchPoint.CatchRz*180/Math.PI);
            }
            catch (FormatException ex)
            {
                MessageBox.Show(ex.Message);
            }


        }

        private void buttonSaveResult_Click(object sender, EventArgs e)
        {
            WriteCalibrationDataToFile();
            if(!m_calibrationCenter.SetConfig(CameraInOutHand, IsPositive))
            {
                MessageBox.Show("SetConfig error");
            }
            else
            {
                SaveFileDialog fileDialog = new SaveFileDialog();
                fileDialog.Filter = "txt files (*.txt)|*.txt";
                if(fileDialog.ShowDialog() == DialogResult.OK)
                {
                    m_calibrationCenter.CalibrationResultSavePath = fileDialog.FileName;
                    if (!m_calibrationCenter.SaveCalibrationResult())
                    {
                        MessageBox.Show("Save calibration Result error");
                    }
                    else
                    {
                        MessageBox.Show("Save calibration Result done");
                    }
                }
            }
            
        }

        private void buttonLoadResult_Click(object sender, EventArgs e)
        {
            if(!m_calibrationCenter.LoadCalibrationResult())
            {
                MessageBox.Show("Load Calibration Result error");
            }
            else
            {
                MessageBox.Show("Load Calibration Result done");
            }
        }

        private void CalibrationSetForm_Load(object sender, EventArgs e)
        {
            listViewParameterSet.Columns.Add("Camera X", 100, HorizontalAlignment.Center);
            listViewParameterSet.Columns.Add("Camera Y", 100, HorizontalAlignment.Center);
            listViewParameterSet.Columns.Add("Robot X", 100, HorizontalAlignment.Center);
            listViewParameterSet.Columns.Add("Robot Y", 100, HorizontalAlignment.Center);
            listViewParameterSet.Columns.Add("Robot Rz", 100, HorizontalAlignment.Center);
            UpdataCalibrationDataShow();
        }

        private void comboBoxModeList_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(comboBoxModeList.SelectedIndex == 0)
            {
                CameraInOutHand = 0;
                IsPositive = true;
                textBoxRobotPosX.Enabled = true;
                textBoxRobotPosY.Enabled = true;
                textBoxRobotPosRz.Enabled = true;
            }
            else if (comboBoxModeList.SelectedIndex == 1)
            {
                CameraInOutHand = 0;
                IsPositive = false;
                textBoxRobotPosX.Enabled = true;
                textBoxRobotPosY.Enabled = true;
                textBoxRobotPosRz.Enabled = true;
            }
            else if (comboBoxModeList.SelectedIndex == 2)
            {
                CameraInOutHand = 1;
                IsPositive = true;
                textBoxRobotPosX.Enabled = false;
                textBoxRobotPosY.Enabled = false;
                textBoxRobotPosRz.Enabled = false;
            }
            else if (comboBoxModeList.SelectedIndex == 3)
            {
                CameraInOutHand = 0;
                IsPositive = false;
                textBoxRobotPosX.Enabled = false;
                textBoxRobotPosY.Enabled = false;
                textBoxRobotPosRz.Enabled = false;
            }
        }

        private void buttonSelectCalPic_Click(object sender, EventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Multiselect = false;//该值确定是否可以选择多个文件
            dialog.Title = "选择输入文件";
            dialog.Filter = "所有文件(*.*)|*.*";
            if (dialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {   
                textBoxCalibrateImagPath.Text = dialog.FileName;
                double[] cols = new double[11];
                double[] rows = new double[11];
                if (!m_calibrationCenter.Get11PointFromCalibrationBoard(dialog.FileName, ref rows, ref cols))
                {
                    MessageBox.Show("找11圆失败");
                    return;
                }
                for (int i = 0; i < m_calibrationCenter.AllLineData.Count; i++ )
                {
                    int robotIndexAtCalibrationList = Convert.ToInt32(m_calibrationCenter.AllLineData[i].CameraPosition.ImageA);
                    listViewParameterSet.Items[i].SubItems[0].Text = cols[robotIndexAtCalibrationList].ToString();
                    listViewParameterSet.Items[i].SubItems[1].Text = rows[robotIndexAtCalibrationList].ToString();

                    m_calibrationCenter.AllLineData[i].CameraPosition.ImageX = cols[robotIndexAtCalibrationList];
                    m_calibrationCenter.AllLineData[i].CameraPosition.ImageY = rows[robotIndexAtCalibrationList];
                }
                buttonSelectCalPic.Enabled = false;
            }
        }

        private void buttonSelectWorldPos_Click(object sender, EventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Multiselect = false;//该值确定是否可以选择多个文件
            dialog.Title = "选择输入文件";
            dialog.Filter = "所有文件(*.*)|*.*";
            if (dialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                textBoxWorldCoordianteFilePath.Text = dialog.FileName;
                string filePath = dialog.FileName;

                listViewParameterSet.Items.Clear();
                m_calibrationCenter.AllLineData.Clear();

                StreamReader sr = new StreamReader(filePath, Encoding.Default);
                String sourceMessage;
                while ((sourceMessage = sr.ReadLine()) != null) 
                {
//                     sourceMessage = "02, 240.45, -321.864, -341.843, -179.9956, 0.0033, -0.0098";
                    AqCalibration.CalibrationDataGroup calibrationlineData = new AqCalibration.CalibrationDataGroup();
                    int startIndex = 0;
                    for (int i = 0; i < 6; i++)
                    {
                        int endIndex = sourceMessage.IndexOf(",", startIndex);
                        if (i == 0)
                        {
                            //ImageA，暂时用作用来标记世界坐标系下对应图像中圆点的索引
                            calibrationlineData.CameraPosition.ImageA = Convert.ToUInt16(sourceMessage.Substring(startIndex, endIndex - startIndex));
                        }
                        else if (i == 1)
                        {
                            calibrationlineData.RobotCoordinate.RobotX = Convert.ToDouble(sourceMessage.Substring(startIndex, endIndex - startIndex));
                        }
                        else if (i == 2)
                        {
                            calibrationlineData.RobotCoordinate.RobotY = Convert.ToDouble(sourceMessage.Substring(startIndex, endIndex - startIndex));
                        }
                        else if (i == 5)
                        {
                            calibrationlineData.RobotCoordinate.RobotRz = Convert.ToDouble(sourceMessage.Substring(endIndex + 1, sourceMessage.Length - endIndex-1));
                        }
                        startIndex = endIndex + 1;
                    }
                    m_calibrationCenter.AllLineData.Add(calibrationlineData);
                    ListViewItem line = new ListViewItem("", 0);
                    line.SubItems.Add("");
                    line.SubItems.Add(calibrationlineData.RobotCoordinate.RobotX.ToString());
                    line.SubItems.Add(calibrationlineData.RobotCoordinate.RobotY.ToString());
                    line.SubItems.Add(calibrationlineData.RobotCoordinate.RobotRz.ToString());
                    listViewParameterSet.Items.Add(line);
                }

                buttonSelectCalPic.Enabled = true;
            }
        }

        private void radioButtonSingleInput_CheckedChanged(object sender, EventArgs e)
        {
            panelSingleInput.Enabled = true;
            panelBatchInput.Enabled = false;
        }

        private void radioButtonBatchInput_CheckedChanged(object sender, EventArgs e)
        {
            panelSingleInput.Enabled = false;
            panelBatchInput.Enabled = true;
        }
    }
}