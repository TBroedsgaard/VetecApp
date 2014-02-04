using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Xml.Serialization;
using Interfaces;
using Model;
using DataAccess;
using Newtonsoft.Json;
using System.Runtime.Serialization.Formatters.Binary;

namespace Controller
{
    public class SubController
    {
        // static is ugly??

        //public static Order order = new Order(); 
        //public static Customer customer = new Customer();
        //public static List<ContactPerson> cpList = new List<ContactPerson>();
        //public static List<Form> formList = new List<Form>();

        private DataAccessFacade dataAccessFacade;

        public SubController()
        {
            dataAccessFacade = new DataAccessFacade();
        }

        public IOrder CreateOrder()
        {
            Order order = new Order();
            order.Id = 1;
            order.Customer = new Customer();
            order.Form = new Form();

            return order;
        }


        public void SaveOrder(string filename, IOrder iorder)
        {
            string xml = serializeOrder(iorder);

            dataAccessFacade.Save(filename, xml);
        }

        public IOrder LoadOrder(string filename)
        {
            string xml = dataAccessFacade.Load(filename);

            Order order = deserializeOrder(xml);

            return order;
        }

        private string serializeOrder(IOrder iorder)
        { 
            Order order = (Order)iorder;

            string xml = JsonConvert.SerializeObject(order, Formatting.Indented);

            return xml;

            //XmlSerializer serializer = new XmlSerializer(form.GetType());

            //using (StringWriter writer = new StringWriter())
            //{
            //    serializer.Serialize(writer, order);

            //    return writer.ToString();
            //}
        }

        private Order deserializeOrder(string xml)
        {
            Order order = new Order();

            order = JsonConvert.DeserializeObject<Order>(xml);

            return order;

            //XmlSerializer serializer = new XmlSerializer(order.GetType());

            //using (StringReader reader = new StringReader(xml))
            //{
            //    order = (Order)serializer.Deserialize(reader);

            //    return order;
            //}
        }

        public IForm CreateForm(int DimA, int DimB, int DimC, int DimD, int DimE, int DimF, int DimFPlus, int DimG, int DimTol, int LPCapacity, bool OO2Wire, bool OO3Wire, bool OO420mA, bool OOBDouble, bool OOBR1000, bool OOBR2000, bool OOBR700, bool OOBSingle, bool OOHHose, bool OOMvV, bool SPAxial, bool SPRadial, bool SPConnector, bool SPGland, bool SPGreaseway, bool SPKeeplateEnd, bool SPOtherEnd, int dimH, bool OOWet, bool OODry,bool OOExp,bool OOChem, int SPCLength)
        {
            Form form = new Form();

            form.DimA = DimA;
            form.DimB = DimB;
            form.DimC = DimC;
            form.DimD = DimD;
            form.DimE = DimE;
            form.DimF = DimF;
            form.DimFPlus = DimFPlus;
            form.DimG = DimG;
            form.DimTol = DimTol;
            form.DimH = dimH;
            form.LPCapacity = LPCapacity;
            form.SPCLength = SPCLength;

            form.WEWet = OOWet;
            form.WEDry = OODry;
            form.WEExpl = OOExp;
            form.WEChem = OOChem;

            form.OO2Wire = OO2Wire;
            form.OO3Wire = OO3Wire;
            form.OO420mA = OO420mA;
            form.OOBDouble = OOBDouble;
            form.OOBR1000 = OOBR1000;
            form.OOBR2000 = OOBR2000;
            form.OOBR700 = OOBR700;
            form.OOBSingle = OOBSingle;
            form.OOHHose = OOHHose;
            form.OOMvV = OOMvV;

            form.SPAxial = SPAxial;
            form.SPRadial = SPRadial;
            form.SPConnector = SPConnector;
            form.SPGland = SPGland;
            form.SPGreaseway = SPGreaseway;
            form.SPKeeplateEnd = SPKeeplateEnd;
            form.SPOtherEnd = SPOtherEnd;

            IForm iForm = (IForm)form;
            return iForm;
        }

        //public static IContactPerson CreateContact(string name, string phone, string email, string available)
        //{
        //    ContactPerson cp = new ContactPerson();

        //    cp.Name = name;
        //    cp.Phone = int.Parse(phone);
        //    cp.Email = email;

        //    IContactPerson iCP = cp as IContactPerson;
        //    return iCP;

        //}

        //public static void AddFormToList(IForm form)
        //{
        //    formList.Add(form as Form);
        //}

        //public static List<IContactPerson> getCpList()
        //{
        //    List<IContactPerson> iCpList = new List<IContactPerson>();
        //    foreach (ContactPerson contactPerson in cpList)
        //    {
        //        iCpList.Add(contactPerson as IContactPerson);
        //    }

        //    return iCpList;
        //}

        //public static void AddCPToList(IContactPerson cp)
        //{
        //    cpList.Add(cp as ContactPerson);
        //}

        //public static void DeleteCPFromList(IContactPerson iCP)
        //{
        //    ContactPerson cp = iCP as ContactPerson;
        //    cpList.Remove(cp);
        //}

        //public static List<IForm> getFormList()
        //{
        //    List<IForm> iformList = new List<IForm>();
        //    foreach (Form form in formList)
        //    {
        //        iformList.Add(form as IForm);
        //    }
        //    return iformList;
        //}

        //public static ICustomer getCustomer()
        //{
        //    ICustomer ic = customer as ICustomer;
        //    return ic;
        //}

        //public static IOrder CreateOrder(List<IForm> list, ICustomer customer)
        //{
        //    order.Form = list;
        //    order.Customer = customer;

        //    IOrder iorder = order as IOrder;
        //    return iorder;
        //}

        //public static string SaveOrder(IOrder createOrder)
        //{
        //    Order order2 = (Order) createOrder;

        //    XmlSerializer serializer = new XmlSerializer(order2.GetType());

        //    using (StringWriter writer = new StringWriter())
        //    {
        //        serializer.Serialize(writer,order2);

        //        return writer.ToString();
        //    }
        //}
        }
    }

