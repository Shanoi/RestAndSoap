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
    private ServiceHost HostVelibs;
    //private WebServiceHost HostAdmin; 

    /**
     * Start the web server on the given port, and host the expected service
     */
    public void start()
    {
        string url = "http://localhost:"+ PortVelibs + "/JCDLibrary";

        BasicHttpBinding b = new BasicHttpBinding();

        HostVelibs = new ServiceHost(typeof(VelibsRetriever), new Uri(url));

        // Check to see if the service host already has a ServiceMetadataBehavior
        ServiceMetadataBehavior smb = HostVelibs.Description.Behaviors.Find<ServiceMetadataBehavior>();
        // If not, add one
        if (smb == null)
        {
            smb = new ServiceMetadataBehavior();
        }

        smb.HttpGetEnabled = true;

        HostVelibs.Description.Behaviors.Add(smb);

        HostVelibs.Description.Behaviors.Find<ServiceDebugBehavior>().IncludeExceptionDetailInFaults = true;

        // Add MEX endpoint
        HostVelibs.AddServiceEndpoint(
          ServiceMetadataBehavior.MexContractName,
          MetadataExchangeBindings.CreateMexHttpBinding(),
          "mex"
        );

        HostVelibs.AddServiceEndpoint(typeof(IVelibsRetriever), b, "/Client");
        //Host.AddServiceEndpoint(typeof(IAdminServices), b, "/WS/AdminService");

        //HostVelibs = new ServiceHost(typeof(VelibsRetriever), new Uri("http://localhost:" + PortVelibs));
        //HostVelibs.AddServiceEndpoint(typeof(IAdminCommands), new BasicHttpBinding(), "admin");
        //HostVelibs.Description.Behaviors.Find<ServiceDebugBehavior>().IncludeExceptionDetailInFaults = true;
        // HostVelibs.AddServiceEndpoint(typeof(IVelibsRetriever), new BasicHttpBinding(), "JCDLibrary/Client");
        /*ServiceEndpoint endpoint = host.AddServiceEndpoint(typeof(IService), new WebHttpBinding(), "Web");
        endpoint.Behaviors.Add(new WebHttpBehavior());*/


        HostVelibs.Open();

        // var Address = new EndpointAddress(URI, DNSIdentity);

        /*var binding = new BasicHttpBinding();


        Console.WriteLine("Starting a WCF self-hosted .Net server... ");
        string urlClient = "http://localhost:" + PortVelibs + "/JCDLibrary/Client/";
        //string urlAdmin = "http://localhost:"+PortAdmin+"/JCDLibrary/Admin/";*/


        /* HostAdmin = new WebServiceHost(typeof(AdminCommands));
         HostAdmin.AddServiceEndpoint(typeof(IAdminCommands), new WSHttpBinding(), urlAdmin);
         HostAdmin.Open();*/

        /*ContractDescription cd = new ContractDescription("VelibsRetriever");
        ServiceEndpoint endpoint = new ServiceEndpoint(cd);


        HostVelibs = new WebServiceHost(typeof(VelibsRetriever));
        HostVelibs.AddServiceEndpoint(typeof(IVelibsRetriever), binding, urlClient);

        HostVelibs.Open();

        HostVelibs.Open();*/
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
