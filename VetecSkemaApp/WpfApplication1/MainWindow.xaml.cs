﻿using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Controller;
using Interfaces;
using Microsoft.Win32;


namespace WpfApplication1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private SubController controller;
        private IForm iFormz;

        private IContactPerson icp;

        private WeightDrawing drawing;


        public MainWindow()
        {
            controller = new SubController();
            
            InitializeComponent();

            drawing = new WeightDrawing(canvas);

        }

        private void outputHelperClicked(object sender, MouseButtonEventArgs e)
        {
            MessageBox.Show("Success!");
        }

        private List<List<string>> createCPData()
        {
            List<List<string>> cpDataList = new List<List<string>>();
            //insert cpData into list
            return cpDataList;
        }

        private List<string> createCustomerData()
        {
            List<string> customerDataList = new List<string>();
            //insert customerData into list
            return customerDataList;
        }

        private IForm createForm()
        {
            
            int DimA = int.Parse(txtboxA.Text);
            int DimB = int.Parse(txtboxB.Text);
            int DimC = int.Parse(txtboxC.Text);
            int DimD = int.Parse(txtboxD.Text);
            int DimE = int.Parse(txtboxE.Text);
            int DimF = int.Parse(txtboxF.Text);
            int DimFPlus = int.Parse(txtboxF_.Text);
            int DimG = int.Parse(txtboxG.Text);
            int DimH = int.Parse(txtboxH.Text);
            int DimTol = int.Parse(txtboxGTol.Text);
            int LPCapacity = int.Parse(txtboxLoadCap.Text);
            int SPCLength = int.Parse(txtboxCableLength.Text);

            bool OO2Wire = chckbox2wire.IsChecked != null && chckbox2wire.IsChecked.Value;
            bool OO3Wire = chckbox3wire.IsChecked != null && chckbox3wire.IsChecked.Value;

            bool OOWet = chckboxWet.IsChecked != null && chckboxWet.IsChecked.Value;
            bool OODry = chckboxDry.IsChecked != null && chckboxDry.IsChecked.Value;
            bool OOExp = chckboxExp.IsChecked != null && chckboxExp.IsChecked.Value;
            bool OOChem = chckboxChem.IsChecked != null && chckboxChem.IsChecked.Value;

            bool OO420mA = chckbox420ma.IsChecked != null && chckbox420ma.IsChecked.Value;
            bool OOBDouble = chckboxDouble.IsChecked != null && chckboxDouble.IsChecked.Value;
            bool OOBR1000 = chckbox1000.IsChecked != null && chckbox1000.IsChecked.Value;
            bool OOBR2000 = chckbox2000.IsChecked != null && chckbox2000.IsChecked.Value;
            bool OOBR700 = chckbox700.IsChecked != null && chckbox700.IsChecked.Value;
            bool OOBSingle = chckboxSingle.IsChecked != null && chckboxSingle.IsChecked.Value;
            bool OOHHose = chckboxHose.IsChecked.Value;
            bool OOMvV = chckboxMvv.IsChecked.Value;
            
            bool SPAxial = chckboxAxial.IsChecked.Value;
            bool SPRadial = chckboxRadial.IsChecked.Value;
            bool SPConnector = chckboxConnector.IsChecked.Value;
            bool SPGland = chckboxGland.IsChecked.Value;
            bool SPGreaseway = chckboxGrease.IsChecked.Value;
            bool SPKeeplateEnd = chckboxKeep.IsChecked.Value;
            bool SPOtherEnd = chckboxOther.IsChecked.Value;
            
            int AOLMF = int.Parse(txtboxAolmf.Text);
            int AOLLF = int.Parse(txtboxAollf.Text);
            int AOLHF = int.Parse(txtboxAolhf.Text);
            int AolLfDegreees = int.Parse(TxtboxAollfDegrees.Text);
            int AolHfdegrees = int.Parse(txtboxAolhfDegrees.Text);
           
            iFormz = controller.CreateForm(DimA, DimB, DimC, DimD, DimE, DimF, DimFPlus, DimG, DimTol, LPCapacity,
                        OO2Wire, OO3Wire, OO420mA, OOBDouble, OOBR1000, OOBR2000, OOBR700, OOBSingle, OOHHose, OOMvV, 
                        SPAxial, SPRadial, SPConnector,SPGland,SPGreaseway,SPKeeplateEnd,SPOtherEnd, DimH, OOWet, OODry, OOExp, OOChem, 
                        SPCLength,AOLMF, AOLLF,AOLHF,AolLfDegreees,AolHfdegrees );
            return iFormz;
        }

        private IContactPerson CreateContactPerson()
        {
            icp = controller.CreateContactPerson(ContactNametxtbox.Text, TelNoTextbox.Text, EmailTextbox.Text,                                         CompanyNametxtbox.Text);
                                                               

            return icp;
        }

        //outputoptions checkbox checkced Eventhandlers
        private void outputCheckboxChecked(object sender, RoutedEventArgs e)
        {
            //mvv checkbox - checked = disable 420, 2wire, 3wire
            if (chckboxMvv.IsChecked == true)
            {
                chckbox420ma.IsEnabled = false;
                chckbox2wire.IsEnabled = false;
                chckbox3wire.IsEnabled = false;
            }


            //420ma checkbox - checked = disable mvv
            if (chckbox420ma.IsChecked == true)
            {
                chckboxMvv.IsEnabled = false;
            }


            //2wire checkbox - checked = disable 3wire
            if (chckbox2wire.IsChecked == true)
            {
                chckbox3wire.IsEnabled = false;
                chckbox420ma.IsChecked = true;
                chckbox420ma.IsEnabled = false;
            }

            //3wire checkbox - checked = disable 2 wire
            if (chckbox3wire.IsChecked == true)
            {
                chckbox2wire.IsEnabled = false;
                chckbox420ma.IsChecked = true;
                chckbox420ma.IsEnabled = false;
            }

           
        }
        //outputoptions checkbox unchecked eventhandler
        private void outputCheckboxUnchecked(object sender, RoutedEventArgs e)
        {
            //mvv unchecked
            if (chckboxMvv.IsChecked == false)
            {
                chckbox420ma.IsEnabled = true;
                chckbox2wire.IsEnabled = true;
                chckbox3wire.IsEnabled = true;
            }
            //420ma
            if (chckbox420ma.IsChecked == false)
            {
                chckboxMvv.IsEnabled = true;
            }
            //2wire
            if (chckbox2wire.IsChecked == false)
            {
                chckbox3wire.IsEnabled = true;
            }
        }
        // bridge checkbox event handlers
        private void bridgecheckboxChecked(object sender, RoutedEventArgs e)
        {  //single checkbox - checked = disable double
            if (chckboxSingle.IsChecked == true)
            {
                chckboxDouble.IsEnabled = false;
            }


            //double checkbox - checked = disable single
            if (chckboxDouble.IsChecked == true)
            {
                chckboxSingle.IsEnabled = false;
            }

        }
        private void bridgeCheckboxUnchecked(object sender, RoutedEventArgs e)
        {   //single
            if (chckboxSingle.IsChecked == false)
            {
                chckboxDouble.IsEnabled = true;
            }
            //double
            if (chckboxDouble.IsChecked == false)
            {
                chckboxSingle.IsEnabled = true;
            }
        }

        //working environment eventhandlers
        private void workingenvironmentCheckboxChecked(object sender, RoutedEventArgs e)
        {  
            #region working environment2
            //dry checkbox
            if (chckboxDry.IsChecked == true)
            {
                chckboxExp.IsEnabled = false;
                chckboxWet.IsEnabled = false;
                chckboxChem.IsEnabled = false;
            }

            //wet checkbox
            if (chckboxWet.IsChecked == true)
            {
                chckboxExp.IsEnabled = false;
                chckboxDry.IsEnabled = false;
                chckboxChem.IsEnabled = false;
            }
            //chem checkbox
            if (chckboxChem.IsChecked == true)
            {
                chckboxDry.IsEnabled = false;
                chckboxWet.IsEnabled = false;
                chckboxExp.IsEnabled = false;
            }
            //exp checkbox
            if (chckboxExp.IsChecked == true)
            {
                chckboxDry.IsEnabled = false;
                chckboxWet.IsEnabled = false;
                chckboxChem.IsEnabled = false;
            }

            #endregion
        }
        private void workingenvironmentCheckboxUnchecked(object sender, RoutedEventArgs e)
        {
            #region 
            //dry
            if (chckboxDry.IsChecked == false)
            {
                chckboxChem.IsEnabled = true;
                chckboxWet.IsEnabled = true;
                chckboxExp.IsEnabled = true;
            }
            //wet
            if (chckboxWet.IsChecked == false)
            {
                chckboxChem.IsEnabled = true;
                chckboxDry.IsEnabled = true;
                chckboxExp.IsEnabled = true;
            }
            //chem
            if (chckboxChem.IsChecked == false)
            {
                chckboxDry.IsEnabled = true;
                chckboxWet.IsEnabled = true;
                chckboxExp.IsEnabled = true;
            }
            //exp
            if (chckboxExp.IsChecked == false)
            {
                chckboxChem.IsEnabled = true;
                chckboxWet.IsEnabled = true;
                chckboxDry.IsEnabled = true;
            }
            #endregion
        }

        private void bridgeResistanceCheckboxChecked(object sender, RoutedEventArgs e)
        { //350 ohm checkbox - checked = disable other ohms
            if (chckbox350.IsChecked == true)
            {
                chckbox700.IsEnabled = false;
                chckbox1000.IsEnabled = false;
                chckbox2000.IsEnabled = false;
                ChckboxStandard.IsEnabled = false;
            }


            //700 ohm checkbox - checked = disable other ohms
            if (chckbox700.IsChecked == true)
            {
                chckbox350.IsEnabled = false;
                chckbox1000.IsEnabled = false;
                chckbox2000.IsEnabled = false;
                ChckboxStandard.IsEnabled = false;
            }
            //1000 ohm checkbox - checked = disable other ohms
            if (chckbox1000.IsChecked == true)
            {
                chckbox700.IsEnabled = false;
                chckbox350.IsEnabled = false;
                chckbox2000.IsEnabled = false;
                ChckboxStandard.IsEnabled = false;
            }

            //2000 ohm checkbox - checked = disable other ohms
            if (chckbox2000.IsChecked == true)
            {
                chckbox700.IsEnabled = false;
                chckbox1000.IsEnabled = false;
                chckbox350.IsEnabled = false;
                ChckboxStandard.IsEnabled = false;
            }

            // standard
            if (ChckboxStandard.IsChecked == true)
            {
                chckbox350.IsEnabled = false;
                chckbox700.IsEnabled = false;
                chckbox1000.IsEnabled = false;
                chckbox2000.IsEnabled = false;
            }
        }
        private void bridgeResistanceCheckboxUnchecked(object sender, RoutedEventArgs e)
        {
            //350
            if (chckbox350.IsChecked == false)
            {
                chckbox700.IsEnabled = true;
                chckbox1000.IsEnabled = true;
                chckbox2000.IsEnabled = true;
                ChckboxStandard.IsEnabled = true;
            }
            //700
            if (chckbox700.IsChecked == false)
            {
                chckbox350.IsEnabled = true;
                chckbox1000.IsEnabled = true;
                chckbox2000.IsEnabled = true;
                ChckboxStandard.IsEnabled = true;
            }
            //1000
            if (chckbox1000.IsChecked == false)
            {
                chckbox700.IsEnabled = true;
                chckbox350.IsEnabled = true;
                chckbox2000.IsEnabled = true;
                ChckboxStandard.IsEnabled = true;
            }
            //2000
            if (chckbox2000.IsChecked == false)
            {
                chckbox700.IsEnabled = true;
                chckbox1000.IsEnabled = true;
                chckbox350.IsEnabled = true;
                ChckboxStandard.IsEnabled = true;
            }

            //Standard
            if (ChckboxStandard.IsChecked == false)
            {
                chckbox350.IsEnabled = true;
                chckbox700.IsEnabled = true;
                chckbox1000.IsEnabled = true;
                chckbox2000.IsEnabled = true;
            }
        }


        private void checkboxChecked(object sender, RoutedEventArgs e)
        {
          
          
            //axial
            if (chckboxAxial.IsChecked == true)
            {
                chckboxRadial.IsEnabled = false;
            }
            //radial
            if (chckboxRadial.IsChecked == true)
            {
                chckboxAxial.IsEnabled = false;
            }
            //gland
            if (chckboxGland.IsChecked == true)
            {
                chckboxConnector.IsEnabled = false;
            }
            //connector
            if (chckboxConnector.IsChecked == true)
            {
                chckboxGland.IsEnabled = false;
            }
            //keepEnd
            if (chckboxKeep.IsChecked == true)
            {
                chckboxOther.IsEnabled = false;
            }
            //otherEnd
            if (chckboxOther.IsChecked == true)
            {
                chckboxKeep.IsEnabled = false;
            }
        }

        private void checkboxUnchecked(object sender, RoutedEventArgs e)
        {
           
            //single
            if (chckboxSingle.IsChecked == false)
            {
                chckboxDouble.IsEnabled = true;
            }
            //double
            if (chckboxDouble.IsChecked == false)
            {
                chckboxSingle.IsEnabled = true;
            }
          
          
            //axial
            if (chckboxAxial.IsChecked == false)
            {
                chckboxRadial.IsEnabled = true;
            }
            //radial
            if (chckboxRadial.IsChecked == false)
            {
                chckboxAxial.IsEnabled = true;
            }
            //gland
            if (chckboxGland.IsChecked == false)
            {
                chckboxConnector.IsEnabled = true;
            }
            //connector
            if (chckboxConnector.IsChecked == false)
            {
                chckboxGland.IsEnabled = true;
            }
            //keepEnd
            if (chckboxKeep.IsChecked == false)
            {
                chckboxOther.IsEnabled = true;
            }
            //otherEnd
            if (chckboxOther.IsChecked == false)
            {
                chckboxKeep.IsEnabled = true;
            }
        }

        

        private void dimTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            uint A = 0, B = 0, C = 0, D = 0, E = 0, F = 0, G = 0, H = 0;

            if (uint.TryParse(txtboxA.Text, out A)
                && uint.TryParse(txtboxB.Text, out B)
                && uint.TryParse(txtboxC.Text, out C)
                && uint.TryParse(txtboxD.Text, out D)
                && uint.TryParse(txtboxE.Text, out E)
                && uint.TryParse(txtboxF.Text, out F)
                && uint.TryParse(txtboxG.Text, out G)
                && uint.TryParse(txtboxH.Text, out H)
                )
            {
                drawing.DrawWeight(A, B, C, D, E, F, G, H);
            }
        }

        private void onClickSaveForm(object sender, RoutedEventArgs e)
        {
                //ValidateFormNotNull();

                if (ValidateFormNotNull())
                {


                    IOrder order = controller.CreateOrder();
                    order.Form = createForm();
                    order.ContactPerson = CreateContactPerson();

                    order.OrderDate = DateTime.Now;

                    SaveFileDialog sfd = new SaveFileDialog();
                    sfd.Filter = "Form file | *.form";
                    sfd.DefaultExt = "form";
                    sfd.ShowDialog();

                    string filename = sfd.FileName;

                    controller.SaveOrder(filename, order);
                    //StreamWriter sw = new StreamWriter(sfd.FileName);
                    //sw.WriteLine(serializedString);
                    //sw.Close();
                }
                else
                {
                    MessageBox.Show("Incorrect or missing data");
                }
           
        }

        
        private bool ValidateFormNotNull()
        {
            
            if (validateoutputoptions() && validateloadpincapacity() && validateWorkingEnvironment() && validateBridgeResistance() 
                && validateSpecification() && validateDimensions() && validateContact())
            {
                return true;
            }

            return false;  
        }
        private bool validateoutputoptions() 
        {
         if (chckboxMvv.IsChecked != null || chckbox420ma.IsChecked !=null && (chckbox3wire.IsChecked != null || chckbox2wire.IsChecked !=null))
            {
                return true;
            }

            return false;
        }
        private bool validateloadpincapacity()
        {
            if (txtboxLoadCap.Text != "")
            {
                    try
                    {
                        
                        if (int.Parse(txtboxLoadCap.Text) >= 200 && int.Parse(txtboxLoadCap.Text) <= 3000000)
                        {
                            
                            return true;
                        }
                        else
                        {
                            
                            return false;
                        }
                        
                        
                    }
                    
                   catch (Exception)
                   {

                       return false;
                   }

                
                    }
           
            return false;
        }


        private bool validateWorkingEnvironment()
        {   
            if (chckboxExp !=null || chckboxWet != null || chckboxDry !=null ||chckboxChem != null)
            {
                return true;
            }

            return false;
        }
        private bool validateBridge() 
        {
            if (chckboxSingle !=null || chckboxDouble != null)
	{
		 return true;
	}
            else
	{
                return false;
	}


        }
        private bool validateBridgeResistance()
            {
                if (ChckboxStandard.IsChecked != null || chckbox350.IsChecked != null || chckbox700.IsChecked != null || chckbox1000 != null                
                    || chckbox2000.IsChecked != null)
                {
                    return true;
                }
                   return false;
                }
        private bool validateSpecification()
        {
            if (chckboxRadial.IsChecked != null || chckboxAxial.IsChecked != null && chckboxKeep.IsChecked != null
                || chckboxOther.IsChecked != null && chckboxGland.IsChecked != null || chckboxConnector.IsChecked!= null && chckboxCable != null)
            {
                return true;
            }
           
	       
            return false;
	       
            
        }
        private bool validateDimensions()
        {
            if (txtboxF_.Text != "" && txtboxA.Text != "" && txtboxB.Text != "" && txtboxC.Text != "" &&
            txtboxD.Text != "" && txtboxE.Text != "" &&  txtboxF.Text != "" && txtboxG.Text != "" && txtboxH.Text != "")
            {
                
                    try
                    {
                        int.Parse(txtboxF_.Text); int.Parse(txtboxA.Text); int.Parse(txtboxB.Text);
                        int.Parse(txtboxC.Text); int.Parse(txtboxD.Text); int.Parse(txtboxE.Text);
                        int.Parse(txtboxG.Text); int.Parse(txtboxLoadCap.Text); int.Parse(txtboxAolhf.Text);
                        int.Parse(txtboxAolhfDegrees.Text); int.Parse(txtboxAollf.Text); int.Parse(TxtboxAollfDegrees.Text);
                        int.Parse(txtboxAolmf.Text);
                        int.Parse(txtboxGTol.Text);
                       
                        return true;
                    }
                    catch (Exception)
                    {
                        return false;

                    }
               
            }
            return false;
        }





        private bool validateContact()
        {
            if (ContactNametxtbox.Text != "" && CompanyNametxtbox.Text != null && EmailTextbox.Text != null && TelNoTextbox.Text!= "")
            {
                return true;
            }

            return false;
        }
        private bool validateAngle()
        {
            if (txtboxAolhf.Text != "" && txtboxAolhfDegrees.Text != "" && TxtboxAollfDegrees.Text != "" && txtboxAollf.Text != "" && txtboxAolmf.Text != "")
            {
                return true;
            }
            return false;
        }


    
       
        private void onClickLoadForm(object sender, RoutedEventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "Form file | *.form";
            ofd.ShowDialog();

            string filename = ofd.FileName;

            if (filename == null || filename == "")
            {
                return;
            }

            IOrder order = controller.LoadOrder(filename);
            loadIContactPersontoUI(order.ContactPerson);
            loadFormToUI(order.Form);
            //try
            //{
            //    OpenFileDialog ofd = new OpenFileDialog();
            //    ofd.Filter = "Form file | *.form";
            //    ofd.ShowDialog();

            //    string loadedFile = File.ReadAllText(ofd.FileName);

            //    IForm form = SubController.DeserializeToForm(loadedFile);

            //    LoadFormToUI(form);
            //}
            //catch (Exception exception)
            //{
            //    Console.WriteLine(exception);
            //}
        }

        private void loadFormToUI(IForm form)
        {
            txtboxA.Text = form.DimA.ToString();
            txtboxB.Text = form.DimB.ToString();
            txtboxC.Text = form.DimC.ToString();
            txtboxD.Text = form.DimD.ToString();
            txtboxE.Text = form.DimE.ToString();
            txtboxF.Text = form.DimF.ToString();
            txtboxF_.Text = form.DimFPlus.ToString();
            txtboxG.Text = form.DimG.ToString();
            txtboxGTol.Text = form.DimTol.ToString();
            txtboxH.Text = form.DimH.ToString();
            txtboxLoadCap.Text = form.LPCapacity.ToString();
            txtboxCableLength.Text = form.SPCLength.ToString();

            chckboxMvv.IsChecked = form.OOMvV;
            chckbox420ma.IsChecked = form.OO420mA;
            chckbox2wire.IsChecked = form.OO2Wire;
            chckbox3wire.IsChecked = form.OO3Wire;

            chckboxDry.IsChecked = form.WEDry;
            chckboxWet.IsChecked = form.WEWet;
            chckboxChem.IsChecked = form.WEChem;
            chckboxExp.IsChecked = form.WEExpl;

            chckboxSingle.IsChecked = form.OOBSingle;
            chckboxDouble.IsChecked = form.OOBDouble;

            chckbox350.IsChecked = form.OOBR350;
            chckbox700.IsChecked = form.OOBR700;
            chckbox1000.IsChecked = form.OOBR1000;
            chckbox2000.IsChecked = form.OOBR2000;
            chckboxHose.IsChecked = form.OOHHose;

            chckboxAxial.IsChecked = form.SPAxial;
            chckboxRadial.IsChecked = form.SPRadial;
            chckboxKeep.IsChecked = form.SPKeeplateEnd;
            chckboxOther.IsChecked = form.SPOtherEnd;
            chckboxGland.IsChecked = form.SPGland;
            chckboxConnector.IsChecked = form.SPConnector;
            chckboxGrease.IsChecked = form.SPGreaseway;

            txtboxAolhf.Text = form.AOLHF.ToString();
            txtboxAollf.Text = form.AOLLF.ToString();
            txtboxAolmf.Text = form.AOLMF.ToString();
            txtboxAolhfDegrees.Text = form.AOLHFDegrees.ToString();
            TxtboxAollfDegrees.Text = form.AOLLFDegrees.ToString();
        }

        private void loadIContactPersontoUI(IContactPerson icontactperson)
        {
            ContactNametxtbox.Text = icontactperson.Name;
            CompanyNametxtbox.Text = icontactperson.CompanyName;
            EmailTextbox.Text = icontactperson.Email;
            TelNoTextbox.Text = icontactperson.Phone;

        }



       

        private void CheckBox_Checked(object sender, RoutedEventArgs e)
        {
            //bridge resistance
              
            chckbox1000.IsEnabled = false;   
            chckbox2000.IsEnabled = false;
            chckbox700.IsEnabled = false;
            chckbox350.IsEnabled = false;
                                
        }

        private void CheckBox_Unchecked(object sender, RoutedEventArgs e)
        {
            chckboxHose.IsEnabled = true;
            chckbox1000.IsEnabled = true;
            chckbox2000.IsEnabled = true;
            chckbox700.IsEnabled =  true;
            chckbox350.IsEnabled =  true;
 
        }

        /*
        private void standardCheckboxChecked(object sender, RoutedEventArgs e)
        {
            chckbox1000.IsChecked = false;
            chckbox2000.IsChecked = false;
            chckbox700.IsChecked = false;
            chckbox350.IsChecked = false;
            
            chckbox1000.IsEnabled = false;
            chckbox2000.IsEnabled = false;
            chckbox700.IsEnabled = false;
            chckbox350.IsEnabled = false;
        }
        private void standardCheckboxUnchecked(object sender, RoutedEventArgs e)
        {
            chckbox1000.IsEnabled = true;
            chckbox2000.IsEnabled = true;
            chckbox700.IsEnabled = true;
            chckbox350.IsEnabled = true;
                             
            chckbox1000.IsEnabled = true;
            chckbox2000.IsEnabled = true;
            chckbox700.IsEnabled = true;
            chckbox350.IsEnabled = true;
        }
        */

        private void txtboxLoadCap_TextChanged(object sender, TextChangedEventArgs e)
        {
            try
            {
                int.Parse(txtboxLoadCap.Text);
                if (int.Parse(txtboxLoadCap.Text) >= 200 && int.Parse(txtboxLoadCap.Text) <= 3000000)
                {
                    txtboxLoadCap.Background = Brushes.LimeGreen;
                }
                else
                {
                    txtboxLoadCap.Background = Brushes.Red;
                }

            }
            catch (Exception)
            {
                txtboxLoadCap.Background = Brushes.Red;

            }
        }
      

        private void txtboxF__TextChanged(object sender, TextChangedEventArgs e)
        {
            dimTextBox_TextChanged(sender, e);
            if (txtboxF_.Text != "")
            {
                        try
                   {
                       int.Parse(txtboxF_.Text);
                       txtboxF_.Background = Brushes.LimeGreen;
                   }
                   catch (Exception)
                   {
                       txtboxF_.Background = Brushes.Red;

                   }
            }
            else
            {
                txtboxF_.Background = Brushes.White;
            }
           

            chckboxHose.IsEnabled = true;   
        }

        private void txtboxA_TextChanged(object sender, TextChangedEventArgs e)
        {
             dimTextBox_TextChanged(sender, e);
             if (txtboxA.Text != "" )
            {
                try
                {
                    int.Parse(txtboxA.Text);
                    if (int.Parse(txtboxA.Text) >=50 && int.Parse(txtboxA.Text) <= 1500)
                    {
                        txtboxA.Background = Brushes.LimeGreen;
                    }
                    else
                    {
                        txtboxA.Background = Brushes.Red;
                    }
                    
                }
                catch (Exception)
                {
                    txtboxA.Background = Brushes.Red;

                }
            }
            else
            {
                txtboxA.Background = Brushes.White;
            }
        }

        private void txtboxB_TextChanged(object sender, TextChangedEventArgs e)
        {
            dimTextBox_TextChanged(sender, e);
            if (txtboxB.Text != "")
            {
                try
                {
                    int.Parse(txtboxB.Text);
                    txtboxB.Background = Brushes.LimeGreen;
                }
                catch (Exception)
                {
                    txtboxB.Background = Brushes.Red;

                }
            }
            else
            {
                txtboxB.Background = Brushes.White;
            }

        }

        private void txtboxC_TextChanged(object sender, TextChangedEventArgs e)
        {
             dimTextBox_TextChanged(sender, e);
            if (txtboxC.Text != "")
            {
                try
                {
                    int.Parse(txtboxC.Text);
                    txtboxC.Background = Brushes.LimeGreen;
                }
                catch (Exception)
                {
                    txtboxC.Background = Brushes.Red;

                }
            }
            else
            {
                txtboxC.Background = Brushes.White;
            }
        }

        private void txtboxD_TextChanged(object sender, TextChangedEventArgs e)
        {

            dimTextBox_TextChanged(sender, e);
            if (txtboxD.Text != "")
            {
                try
                {
                    int.Parse(txtboxD.Text);
                    txtboxD.Background = Brushes.LimeGreen;
                }
                catch (Exception)
                {
                    txtboxD.Background = Brushes.Red;

                }
            }
            else
            {
                txtboxD.Background = Brushes.White;
            }
        }

        private void txtboxE_TextChanged(object sender, TextChangedEventArgs e)
        {
             dimTextBox_TextChanged(sender, e);
            if (txtboxE.Text != "")
            {
                try
                {
                    int.Parse(txtboxE.Text);
                    txtboxE.Background = Brushes.LimeGreen;
                }
                catch (Exception)
                {
                    txtboxE.Background = Brushes.Red;

                }
            }
            else
            {
                txtboxE.Background = Brushes.White;
            }

        }

        private void txtboxH_TextChanged(object sender, TextChangedEventArgs e)
        {
            dimTextBox_TextChanged(sender, e);
            if (txtboxH.Text != "")
            {
                try
                {
                    int.Parse(txtboxH.Text);
                    txtboxH.Background = Brushes.LimeGreen;
                }
                catch (Exception)
                {
                    txtboxH.Background = Brushes.Red;

                }
            }
            else
            {
                txtboxH.Background = Brushes.White;
            }

        }

        private void txtboxD_TextChanged_1(object sender, TextChangedEventArgs e)
        {
            dimTextBox_TextChanged(sender, e);
            if (txtboxD.Text != "")
            {
                try
                {
                    int.Parse(txtboxD.Text);
                    txtboxD.Background = Brushes.LimeGreen;
                }
                catch (Exception)
                {
                    txtboxD.Background = Brushes.Red;

                }
            }
            else
            {
                txtboxD.Background = Brushes.White;
            }
        }

        private void diameterGTextChanged(object sender, TextChangedEventArgs e)
        {
            dimTextBox_TextChanged(sender, e);
            //int gTal = Convert.ToInt32(txtboxG.Text);
            int gtallio;

            if (int.TryParse(txtboxG.Text, out gtallio) == false)
            {
                warningImg.Visibility = Visibility.Visible;
                warningImg.ToolTip = "Du må kun bruge tal og komma/decimal!";

            }

            if (gtallio > 500 || gtallio < 10)
            {
                warningImg.Visibility = Visibility.Visible;
                warningImg.ToolTip = "Min ø 10  max 100 ";
                btnCheckForm.IsEnabled = false;
                txtboxG.Background = Brushes.Red;
            }
            else
            {
                warningImg.Visibility = Visibility.Hidden;
                btnCheckForm.IsEnabled = true;
                txtboxG.Background = Brushes.LimeGreen;
            }

            dimTextBox_TextChanged(sender, e);
        }

        private void txtboxAolmf_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (txtboxAolmf.Text != "")
            {
                try
                {
                    int.Parse(txtboxAolmf.Text);
                    txtboxAolmf.Background = Brushes.LimeGreen;
                }
                catch (Exception)
                {
                    txtboxAolmf.Background = Brushes.Red;

                }
            }
            else
            {
                txtboxAolmf.Background = Brushes.White;
            }
        }

        private void txtboxAollf_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (txtboxAollf.Text != "")
            {
                try
                {
                    int.Parse(txtboxAollf.Text);
                    txtboxAollf.Background = Brushes.LimeGreen;
                }
                catch (Exception)
                {
                    txtboxAollf.Background = Brushes.Red;

                }
            }
            else
            {
                txtboxAollf.Background = Brushes.White;
            }
        }

        private void txtboxAolhf_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (txtboxAolhf.Text != "")
            {
                try
                {
                    int.Parse(txtboxAolhf.Text);
                    txtboxAolhf.Background = Brushes.LimeGreen;
                }
                catch (Exception)
                {
                    txtboxAolhf.Background = Brushes.Red;

                }
            }
            else
            {
                txtboxAolhf.Background = Brushes.White;
            }
        }

        private void TxtboxAollfDegrees_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (TxtboxAollfDegrees.Text != "")
            {
                try
                {
                    int.Parse(TxtboxAollfDegrees.Text);
                    TxtboxAollfDegrees.Background = Brushes.LimeGreen;
                }
                catch (Exception)
                {
                    TxtboxAollfDegrees.Background = Brushes.Red;

                }
            }
            else
            {
                TxtboxAollfDegrees.Background = Brushes.White;
            }
        }

        private void txtboxAolhfDegrees_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (txtboxAolhfDegrees.Text != "")
            {
                try
                {
                    int.Parse(txtboxAolhfDegrees.Text);
                    txtboxAolhfDegrees.Background = Brushes.LimeGreen;
                }
                catch (Exception)
                {
                    txtboxAolhfDegrees.Background = Brushes.Red;

                }
            }
            else
            {
                txtboxAolhfDegrees.Background = Brushes.White;
            }
        }

        private void txtboxF_TextChanged(object sender, TextChangedEventArgs e)
        {
            dimTextBox_TextChanged(sender, e);
            if (txtboxF.Text != "")
            {
                try
                {
                    int.Parse(txtboxF.Text);
                    txtboxF.Background = Brushes.LimeGreen;
                }
                catch (Exception)
                {
                    txtboxF.Background = Brushes.Red;

                }
            }
            else
            {
                txtboxF.Background = Brushes.White;
            }
        }

        private void txtboxGTol_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (txtboxGTol.Text != "")
            {
                try
                {
                    int.Parse(txtboxGTol.Text);
                    txtboxGTol.Background = Brushes.LimeGreen;
                }
                catch (Exception)
                {
                    txtboxGTol.Background = Brushes.Red;

                }
            }
            else
            {
                txtboxGTol.Background = Brushes.White;
            }
        }

        private void txtboxCableLength_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (txtboxCableLength.Text != "")
            {
                try
                {
                    int.Parse(txtboxCableLength.Text);
                    txtboxCableLength.Background = Brushes.LimeGreen;
                }
                catch (Exception)
                {
                    txtboxCableLength.Background = Brushes.Red;

                }
            }
            else
            {
                txtboxCableLength.Background = Brushes.White;
            }

        }


      

    

        
           

        

       

  
                                             
        //private void addFormToList(object sender, RoutedEventArgs e)
        //{
        //    IForm form = CreateForm();

        //    SubController.AddFormToList(form);

        //}

        //private void onClickSaveOrder(object sender, RoutedEventArgs e)
        //{
        //    IOrder order = SubController.CreateOrder(SubController.getFormList(), SubController.getCustomer());

        //    string serializedString = SubController.SaveOrder(order);

        //    SaveFileDialog sfd = new SaveFileDialog();
        //    sfd.Filter = "Order file | *.ord";
        //    sfd.DefaultExt = ".ord";
        //    sfd.ShowDialog();

        //    StreamWriter sw = new StreamWriter(sfd.FileName);
        //    sw.WriteLine(serializedString);
        //    sw.Close();
            
        //}

    }
}
