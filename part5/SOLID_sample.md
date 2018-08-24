# SRP simple

```c#
    #if Old
        // THE class is doing things WHICH HE IS NOT SUPPOSED TO DO. 
        // its over loaded with lot of responsibility.
        // customer class should do customer data validations. 
        // but if you see the catch block closely it also doing LOGGING activity.  
    class Customer
    {
        public void Add()
        {
            try
            {
                //database code goes here
            }
            catch (Exception ex)
            {
                System.IO.File.WriteAllText(@"c:\error.text", 
                DateTime.Now.ToString() + ex.StackTrace + ex.Message);
            }
        }
    }
    #endif

    #if Improve
    class FileLogger
        {
        public void Handle(string error)
        {
            System.IO.File.WriteAllText(@"c:\error.text", error);
        }
    }
    class Customer
    {
        private FileLogger obj = new FileLogger();
        public virtual void Add()
        {
            try
            {
                //database code goes here
            }
            catch (Exception ex)
            {
                obj.Handle(DateTime.Now.ToString() + ex.StackTrace + ex.Message);
            }
        }
    }
    #endif

            
#   OCP sample
     #if Old
    class customer
    {
        private int _CustType;
        public int CustType
        {
            get { return _CustType; }
            set { _CustType = value; }
        }
        public double getDiscount(double TotalSales)
        {
            /* if we add a new customer type we need to go 
             * and add one more "IF" condition in the "getDiscount" function, 
             * we need change the customer class. */
            if (_CustType == 1) return TotalSales - 100;
            else return TotalSales - 50;
        }
    }
    #endif

    #if Improve
    // putting in simple words the "Customer" class is now closed for any new modificatin 
    // but it's open for extensions when new customer types are added to the project.
    class Customer
    {
        public virtual double getDiscount(double TotalSales) { return TotalSales; }
    }

    class SilverCustomer : Customer
    {
        public override double getDiscount(double TotalSales)
        {
            return base.getDiscount(TotalSales) - 50;
        }
    }
    class goldCusomter : Customer
    {
        public override double getDiscount(double TotalSales)
        {
            return base.getDiscount(TotalSales) - 100;
        }
    }
        #endif

            
#   LSP sample
    #if Old
    class Customer
    {
        public virtual double getDiscount(double TotalSales) { return TotalSales; }
        public virtual void Add() { }
    }

    /// <summary>
    /// per the inheritance hierarchy the "Customer" object can point to any one of its child objects 
    /// and we do not expect any unusual behavior.
    /// but when "Add" method of the "Enquiry" object is invoked 
    /// it leads to error "Exception was unhandled" during runingtime.
    /// because our "Equiry" object does save enquires to database as they are not actual customer.
    /// </summary>
    class Enquiry:Customer
    {
        public override double getDiscount(double TotalSales)
        {
            return base.getDiscount(TotalSales)-5;
        }
        public override void Add()
        {
            throw new Exception("Not allowed");
        }
    }
    #endif

    #if Improve
    /// <summary>
    /// per the inheritance hierarchy the "Customer" object can point to any one of its child objects 
    /// and we do not expect any unusual behavior.
    /// but when "Add" method of the "Enquiry" object is invoked 
    /// it leads to error "Exception was unhandled" during runingtime.
    /// because our "Equiry" object does save enquires to database as they are not actual customer.
    /// 
    /// In other words the "Enquiry" has discount calculation, it looks like a "Customer" but it is not a customer. 
    /// so the parent cannot replace the child object seamlessly. 
    /// "Customer" is not the actual parent for the "Enquiry" class. "Enquiry" is a different entity altogether.
    /// 
    /// So LISKOV principle says the parent should easily replace the child object.
    /// So to implement LISKOV we need to create two interfaces one is for discount and other for database. 
    /// </summary>

    interface IDiscount
    {
        double getDiscount(double TotalSales);
    }
    interface IDatabase
    {
        void Add();
    }
    class Enquiry : IDiscount
    {
        public double getDiscount(double TotalSales)
        {
            return TotalSales - 5;
        }
    }
    class Cusomer : IDiscount, IDatabase
    {
        private FileLogger obj = new FileLogger();
        public virtual void Add()
        {
            try { }
            catch (Exception ex)
            {
                obj.Handle(DateTime.Now.ToString() + ex.StackTrace + ex.Message);
            }
        }
        public virtual double getDiscount(double TotalSales) { return TotalSales; }
    }
    /// <summary>
    /// assisitant class
    /// </summary>
    class FileLogger
    {
        public void Handle(string error)
        {
            System.IO.File.WriteAllText(@"c:\error.text", error);
        }
    }
    #endif

                
#   ISP sample

    #if Old
    /// <summary>
    /// the new requirement which as come up, 
    /// we have two kinds of client's: who want's just use "Add" method. another who wants to use "Add" + "Read".
    /// 
    /// it's not good idea to add Read method in IDatabase interface, it will affect current client.
    /// </summary>
    interface IDatabase
    {
        void Add(); // old client are happy with these.
        void Read(); // add for new clients.
    }
    #endif

    #if Improve
    interface IDatabase
    {
        void Add(); // old client are happy with these.
    }
    /// <summary>
    /// a better approach would be to keep exisitng clients in their own sweet world 
    /// and the serve the new clients's separately.
    /// </summary>
    interface IDatabaseV1 : IDatabase
    {
        void Read();
    }
    class CusomterWithRead : IDatabase, IDatabaseV1
    {
        public void Add() {
            Cusomter obj = new Cusomter();
            obj.Add();
        }
        public void Read() { // logic for read
        }
    }
    #endif
    //IDatabase i = new Customer(); // 1000 happy old clients not touched
    //i.Add();

    //IDatabaseV1 iv1 = new CustomerWithread(); // new clients
    //Iv1.Read();


#   DIP sample
    #if Old
    /// <summary>
    /// the logger class is satisfy SRP. 
    /// If we want change logger , for example, database logger, EventViewer logger, 
    /// we have to change customer code, it's not good idea.
    /// </summary>
    class Customer
    {
        private FileLogger obj = new FileLogger();
        public virtual void Add()
        {
            try {
                // database code logic.
            }
            catch(Exception ex) { obj.Handle(ex.ToString()); }
        }
    }
    class FileLogger
    {
        public void Handle(string error)
        {
            System.IO.File.WriteAllText(@"c:\error.text", error);
        }
    }
    #endif

    #if Improve
    interface ILogger
    {
        void Handle(string error);
    }
    class FileLogger: ILogger
    {
        public void Handle(string error)
        {
            System.IO.File.WriteAllText(@"c:\error.text", error);
        }
    }
    class DatabaseLogger : ILogger
    {
        public void Handle(string error)
        {
            // log wirte to database table.
        }
    }
    class EventViewerLogger : ILogger
    {
        public void Handle(string error)
        {
           // log errors to event viewer.
        }
    }
    class Customer : IDiscount, IDatabase
    {
        private ILogger logObj;
        public Customer(ILogger log)
        {
            logObj = log;
        }
    }
    #endif
```
