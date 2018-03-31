using System;
using System.IO;
using System.Threading;
using System.ServiceModel;
using System.ServiceModel.Web;

using JCDLibrary;
using System.ServiceModel.Description;
using System.Text;
/**
* References:
* http://badger.developpez.com/tutoriels/dotnet/web-service-rest-avec-wcf-3-5/#LII-B
*  - mono server.exe /standalone  => start the server in standalone mode
*  - mono server.exe /port 9191   => starts the server on port 9191
* Default is interactive mode on port 9090. Options can obviously be combined
**/
public class Server
{
    // Attirbutes to support port selection and standalone mode
    private bool Standalone = false;
    private string PortVelibs = "8733";
    //private string PortAdmin = "8734";
    private string Locker = "server.LOCK";

    // Web Server used to host services
    private WebServiceHost HostVelibs;
    //private WebServiceHost HostAdmin;

    WSHttpBinding BindingConfig;
    EndpointIdentity DNSIdentity;
    Uri URI;
    ContractDescription ConfDescription;

    /**
     * Start the web server on the given port, and host the expected service
     */
    public void start()
    {

        // In constructor initializing configuration elements by code
        BindingConfig = ConfigBinding();
        DNSIdentity = ConfigEndPoint();
        URI = ConfigURI();
        ConfDescription = ConfigContractDescription();

       // var Address = new EndpointAddress(URI, DNSIdentity);

        Console.WriteLine("Starting a WCF self-hosted .Net server... ");
        string urlClient = "http://localhost:" + PortVelibs + "/JCDLibrary/Client/";
        //string urlAdmin = "http://localhost:"+PortAdmin+"/JCDLibrary/Admin/";


       /* HostAdmin = new WebServiceHost(typeof(AdminCommands));
        HostAdmin.AddServiceEndpoint(typeof(IAdminCommands), new WSHttpBinding(), urlAdmin);
        HostAdmin.Open();*/
        
        HostVelibs = new WebServiceHost(typeof(VelibsRetriever), URI);
        HostVelibs.AddServiceEndpoint(typeof(IVelibsRetriever), BindingConfig, "");
     
        HostVelibs.Open();

        HostVelibs.Open();
        //HostAdmin.Open();

        /*Console.WriteLine("Starting a WCF self-hosted .Net server... ");
        string url = "net.tcp://" + "localhost" + ":" + PortVelibs;
        
        NetTcpBinding bTCP = new NetTcpBinding();
        WSHttpBinding bws = new WSHttpBinding();
        HostVelibs = new WebServiceHost(typeof(VelibsRetriever), new Uri(url));

        url = "http://" + "localhost" + ":" + PortAdmin;

        HostAdmin = new WebServiceHost(typeof(AdminCommands), new Uri(url));

        // Adding the service to the host
        HostVelibs.AddServiceEndpoint(typeof(IVelibsRetriever), bTCP, "");

        HostAdmin.AddServiceEndpoint(typeof(IAdminCommands), bws, "");

        // Staring the Host server
        HostVelibs.Open();
        HostAdmin.Open();*/

        Console.WriteLine("\nListening to " + "localhost" + ":" + PortVelibs + "\n");

        if (Standalone) { lockServer(); } else { interactive(); }

    }
    
    public WSHttpBinding ConfigBinding()
    {
        // ----- Programmatic definition of the SomeService Binding -----
        var wsHttpBinding = new WSHttpBinding();

        wsHttpBinding.Name = "Client";
        wsHttpBinding.CloseTimeout = TimeSpan.FromMinutes(1);
        wsHttpBinding.OpenTimeout = TimeSpan.FromMinutes(1);
        wsHttpBinding.ReceiveTimeout = TimeSpan.FromMinutes(10);
        wsHttpBinding.SendTimeout = TimeSpan.FromMinutes(1);
        wsHttpBinding.HostNameComparisonMode = HostNameComparisonMode.StrongWildcard;
        wsHttpBinding.MaxBufferPoolSize = 524288;
        wsHttpBinding.MaxReceivedMessageSize = 65536;
        wsHttpBinding.MessageEncoding = WSMessageEncoding.Text;
        wsHttpBinding.TextEncoding = Encoding.UTF8;

        wsHttpBinding.ReaderQuotas.MaxDepth = 32;
        wsHttpBinding.ReaderQuotas.MaxArrayLength = 16384;
        wsHttpBinding.ReaderQuotas.MaxStringContentLength = 8192;
        wsHttpBinding.ReaderQuotas.MaxBytesPerRead = 4096;
        wsHttpBinding.ReaderQuotas.MaxNameTableCharCount = 16384;

        

        // ----------- End Programmatic definition of the SomeServiceServiceBinding --------------

        return wsHttpBinding;

    }

    public Uri ConfigURI()
    {
        // ----- Programmatic definition of the Service URI configuration -----
        Uri URI = new Uri("http://localhost:" + PortVelibs + "/JCDLibrary/Client/");

        return URI;
    }

    public EndpointIdentity ConfigEndPoint()
    {
        // ----- Programmatic definition of the Service EndPointIdentitiy configuration -----
        EndpointIdentity DNSIdentity = EndpointIdentity.CreateDnsIdentity("tempCert");

        return DNSIdentity;
    }


    public ContractDescription ConfigContractDescription()
    {
        // ----- Programmatic definition of the Service ContractDescription Binding -----
        ContractDescription Contract = ContractDescription.GetContract(typeof(IVelibsRetriever), typeof(VelibsRetriever));

        return Contract;
    }
    /**
     * Stop the already started web server
     */
    private void stop()
    {
        HostVelibs.Close();
        //HostAdmin.Close();
        Console.WriteLine("Server shutdown complete!");
    }

    /**
     * Read options fron the command line. Does not support inconsistent commands
     */
   /* public void configure(string[] args)
    {
        int aloneIdx = Array.FindIndex(args, key => key == "/standalone");
        if (aloneIdx != -1) { this.Standalone = true; }
        int portIndex = Array.FindLastIndex(args, key => key == "/port");
        if (portIndex != -1) { this.Port = args[portIndex + 1]; }
    }*/

    /**
     * Start the server in interactive mode, waiting for Return to
     */
    private void interactive()
    {
        Console.WriteLine("Hit Return to shutdown the server.");
        Console.ReadLine();
        stop();
    }

    /**
     * Lock the server in standalone mode using a given file
     */
    private void lockServer()
    {
        File.Create(Locker);
        Console.WriteLine("Delete the lock file (" + Locker + ") to stop the server");
        watchforLockRemoval();
    }

    /**
     * Active polling of the file system (ugly) to check the existence of the lock file
     */
    private void watchforLockRemoval()
    {
        var shouldStop = false;
        while (!shouldStop)
        {
            Thread.Sleep(1000);
            if (!File.Exists(Locker)) { shouldStop = true; }
        }
        stop();
    }

    /**
     * Main method, called with `mono server.exe`
     */
    public static void Main(string[] args)
    {
        var server = new Server();
        //server.configure(args);
        server.start();
    }

}
