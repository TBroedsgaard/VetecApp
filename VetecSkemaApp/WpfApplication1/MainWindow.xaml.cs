using System;
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

        public MainWindow()
        {
            controller = new SubController();
            
            InitializeComponent();
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
            int DimC = int.Parse(txtboxA.Text);
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

           
            iFormz = controller.CreateForm(DimA, DimB, DimC, DimD, DimE, DimF, DimFPlus, DimG, DimTol, LPCapacity,
                        OO2Wire, OO3Wire, OO420mA, OOBDouble, OOBR1000, OOBR2000, OOBR700, OOBSingle, OOHHose, OOMvV, SPAxial, SPRadial, SPConnector,SPGland,SPGreaseway,SPKeeplateEnd,SPOtherEnd, DimH, OOWet, OODry, OOExp, OOChem, SPCLength);
            return iFormz;
        }

        private IContactPerson CreateContactPerson()
        {
            icp = controller.CreateContactPerson(ContactNametxtbox.Text,  ContactNametxtbox.Text,
                                                       CompanyNametxtbox.Text, TelNoTextbox.Text);
            return icp;
        }

        private void checkboxChecked(object sender, RoutedEventArgs e)
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

           
            

            //single checkbox - checked = disable double
            if (chckboxSingle.IsChecked == true)
            {
                chckboxDouble.IsEnabled = false;
            }
            

            //double checkbox - checked = disable single
            if (chckboxDouble.IsChecked == true)
            {
                chckboxSingle.IsEnabled = false;
            }
            

            //350 ohm checkbox - checked = disable other ohms
            if (chckbox350.IsChecked == true)
            {
                chckbox700.IsEnabled = false;
                chckbox1000.IsEnabled = false;
                chckbox2000.IsEnabled = false;
            }
            

            //700 ohm checkbox - checked = disable other ohms
            if (chckbox700.IsChecked == true)
            {
                chckbox350.IsEnabled = false;
                chckbox1000.IsEnabled = false;
                chckbox2000.IsEnabled = false;
            }
            //1000 ohm checkbox - checked = disable other ohms
            if (chckbox1000.IsChecked == true)
            {
                chckbox700.IsEnabled = false;
                chckbox350.IsEnabled = false;
                chckbox2000.IsEnabled = false;
            }

            //2000 ohm checkbox - checked = disable other ohms
            if (chckbox2000.IsChecked == true)
            {
                chckbox700.IsEnabled = false;
                chckbox1000.IsEnabled = false;
                chckbox350.IsEnabled = false;
            }
            

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
            //350
            if (chckbox350.IsChecked == false)
            {
                chckbox700.IsEnabled = true;
                chckbox1000.IsEnabled = true;
                chckbox2000.IsEnabled = true;
            }
            //700
            if (chckbox700.IsChecked == false)
            {
                chckbox350.IsEnabled = true;
                chckbox1000.IsEnabled = true;
                chckbox2000.IsEnabled = true;
            }
            //1000
            if (chckbox1000.IsChecked == false)
            {
                chckbox700.IsEnabled = true;
                chckbox350.IsEnabled = true;
                chckbox2000.IsEnabled = true;
            }
            //2000
            if (chckbox2000.IsChecked == false)
            {
                chckbox700.IsEnabled = true;
                chckbox1000.IsEnabled = true;
                chckbox350.IsEnabled = true;
            }
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

        private void diameterGTextChanged(object sender, TextChangedEventArgs e)
        {
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
            }
            else
            {
                warningImg.Visibility = Visibility.Hidden;
                btnCheckForm.IsEnabled = true;
            }
        }

        private void onClickSaveForm(object sender, RoutedEventArgs e)
        {
            if (ValidateFormNotNull())
            {


                IOrder order = controller.CreateOrder();
                order.Form = createForm();
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
            else MessageBox.Show("please enter all required fields");

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
            { return true; }
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
                return true;
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
            if (txtboxFDegree.Text != "" && txtboxFMDegree1.Text != "" && txtboxFMDegree2.Text != "" && txtboxFPDegree1.Text != "" &&txtboxFPDegree2.Text != "")
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

            IOrder order = controller.LoadOrder(filename);

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
        }



       

        private void CheckBox_Checked(object sender, RoutedEventArgs e)
        {
            chckboxHose.IsEnabled = false;   
            chckbox1000.IsEnabled = false;   
            chckbox2000.IsEnabled = false;
            chckbox700.IsEnabled = false;
            chckbox350.IsEnabled = false;
            chckboxHose.IsEnabled = false;                     
        }

        private void CheckBox_Unchecked(object sender, RoutedEventArgs e)
        {
            chckboxHose.IsEnabled = true;
            chckbox1000.IsEnabled = true;
            chckbox2000.IsEnabled = true;
            chckbox700.IsEnabled =  true;
            chckbox350.IsEnabled =  true;
            chckboxHose.IsEnabled = true;   
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
