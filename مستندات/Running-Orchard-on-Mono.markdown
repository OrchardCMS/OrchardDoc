
All command line examples in this article assume you are using a Linux machine.

You can test the CMS using our [virtual machine and/or Live CD](http://susegallery.com/a/n1C2rA/orchard-cms-mono-demo) SuSE Studio appliance.


#  Prerequisites 

You will need the following software in order to <b>run</b> Orchard on your Linux distribution of choice:

* PostgreSQL RDBMS version 8.2 or newer (8.4 recommended) installed, with rights to create databases
* [Mono 2.10.1](http://www.go-mono.com/mono-downloads/download.html) or newer
* Apache 2 (optional, you can use [Mono's](http://mono-project.com/) XSP development server for testing)
* A set of Linux utilities installed on your machine: wget, patch, unzip and sudo (for root access - you must have administrative/root rights on the machine)

If you want to compile Orchard from source on Linux (compiling with VisualStudio is, of course, also supported), you will also need:

* [MonoDevelop 2.6 Beta 1](http://monodevelop.com/Download) or newer
* [Mono versions of certain assemblies](http://dl.dropbox.com/u/22037511/orchard/orchard-mono-sources-overlay-current.zip) used by Orchard

#  Common Setup Steps 

##  Add a Host Name Alias for the Demo 

Since you are using a non-existing DNS name for this demo, you need to let the system know how to find the server. To do so, execute the following sequence of commands:

    
    sudo -i
    echo "127.0.0.1 orchard-demo" >> /etc/hosts


If you want to visit the Orchard demo from another machine, you will need to modify the machine's <tt>/etc/hosts</tt> file in the similar way, replacing <tt>127.0.0.1</tt> with your server's IP address.

#  Database Setup 

First, make sure you have PostgreSQL installed and running:

    
    ps ax|grep postgres


Output of the command should be similar to:

    
     1275 ?        Ss     0:00 postgres: logger process                  
     1277 ?        Ss     0:00 postgres: writer process                  
     1278 ?        Ss     0:00 postgres: wal writer process              
     1279 ?        Ss     0:00 postgres: autovacuum launcher process     
     1280 ?        Ss     0:00 postgres: stats collector process 


When PostgreSQL is running and ready, type the commands below to create the database and the user:

    
    sudo -i
    su - postgres
    createuser -l -D -R -S -P orchard


Type the password when prompted and then create the database (it will be named <b>orchard</b>):

    
    createdb -E UTF8 -O orchard orchard


At this point you must make sure the new <b>orchard</b> user has access rights to the database. In order to do it, you need to find the <tt>pg_hba.conf</tt> file and open it in the editor (you must be doing that with administrator/root rights). The file is located in <tt>/var/lib/pgsql/data/</tt> on SuSE and in <tt>/etc/postgresql/X.Y/main/</tt> on distributions derived from Debian (X.Y is the major.minor version number of your PostgreSQL server). After the file is found and opened, make sure it contains a line similar to this:

    
    host    all             all             127.0.0.1/32            md5


It is <b>extremely</b> important that the last item in the line above is <b>not</b> <tt>indent</tt> - it should be <tt>md5</tt>, <tt>password</tt> or <tt>trust</tt> (for other authentication methods please refer to the PostgreSQL documentation). After the line is in the file, restart PostgreSQL and you're ready to use the new database from Orchard.

#  Configuring with Apache 2 and mod_mono 

Make sure you have Apache 2 (the Worker MPM is recommended) and mod-mono 2.10.1 (or newer) installed. Configuration paths given below are specific to OpenSuSE 11.4, you will need to adjust them for your distribution. Contents of the created files does not change (save for the filesystem paths, of course).

##  Create Apache Virtual Host Configuration File 

    
    sudo -i
    cd /etc/apache2/vhosts.d


At this point you will need a working text editor. You can try typing any of the following commands to launch one: gedit, mcedit, joe, vi. <tt>editor</tt> below is used as a placeholder:

    
    editor /etc/apache2/vhosts.d/orchard-demo.conf


One of them should result in the editor starting. If you don't know how to use the started editor, refer to its online help. After the editor is started, paste the following code in it:

    
    <VirtualHost *:80>
        ServerAdmin webmaster@orchard-demo
        ServerName orchard-demo
    
        # Change the path below to suit your configuration
        DocumentRoot /srv/www/vhosts/orchard-demo
    
        # The paths used here should be common for all Linux distributions
        ErrorLog /var/log/apache2/orchard-demo_error.log
        CustomLog /var/log/apache2/orchard-demo_access.log combined
    
        HostnameLookups Off
        UseCanonicalName Off
        ServerSignature On
    
        # Make ABSOLUTELY sure that the path in double quotes ends with a slash!
        Alias / "/srv/www/vhosts/orchard-demo/"
    
        AddMonoApplications OrchardDemo "/:/srv/www/vhosts/orchard-demo"
    
        # Orchard is a .NET 4.0 application. If your Mono was installed in a different prefix, replace /usr/bin/ with that prefix below.
        MonoServerPath OrchardDemo /usr/bin/mod-mono-server4
    
        # Helps when you get stack traces
        MonoDebug OrchardDemo True
    
        # Orchard assumes a case-insensitive filesystem
        MonoIOMAP OrchardDemo all
    
        <Directory "/srv/www/vhosts/orchard-demo">
    	SetHandler mono
    	MonoSetServerAlias OrchardDemo
        </Directory>
    </VirtualHost>


Save the file, close the editor and type one the following commands to restart Apache (use only one of those):

    
    service apache2 restart


    
    /etc/init.d/apache2 restart


To make sure Mono backend has been started correctly, type:

    
    ps ax|grep OrchardDemo


As the result you should see output similar to:

    
    2252 ?        Ssl    0:00 /usr/bin/mono --debug /usr/lib/mono/4.0/mod-mono-server4.exe --filename /tmp/mod_mono_server_OrchardDemo --applications /:/srv/www/vhosts/orchard-demo --nonstop


Now you are ready to start your favorite web browser and point it to <tt>http://orchard-demo/</tt>!

#  Configuring for XSP 

No extra steps are necessary. You need to run <tt>xsp4</tt> in the <tt>Orchard.Web</tt> directory using the following command line:

    
    MONO_IOMAP=all xsp4


#  Using Binary Version of Orchard 

Currently Orchard needs to be patched in order to run on Mono with PostgreSQL database, so for your convenience a [precompiled version is available](http://dl.dropbox.com/u/22037511/orchard/orchard-1.0.20-mono_bin.zip). All you need to do is to download the archive, create a directory on your server in which you want to put the application and unzip the archive in that directory (locations used here are samples which would work without changing on a machine running [OpenSuSE 11.4](http://software.opensuse.org)):

    
    sudo -i
    mkdir -p /srv/www/vhosts/orchard-demo
    cd /tmp
    wget http://dl.dropbox.com/u/22037511/orchard/orchard-1.0.20-mono_bin.zip
    cd /srv/www/vhosts/orchard-demo
    unzip /tmp/orchard-1.0.20-mono_bin.zip


#  Compiling Orchard from Source 

We will use the current (as of March 11 2011) version of Orchard sources - [1.0.20](http://orchard.codeplex.com/releases/view/50197#DownloadId=197217). After downloading and unzipping them in a directory of your choice, you need to perform the steps outlined below in before compiling the application.

##  Patching the Source 

Ideally, in the future Orchard will not need to be patched in order to work under Mono, but for the moment you need to [download two little patches](http://dl.dropbox.com/u/22037511/orchard/orchard-mono-patches-current.zip) and apply them to the source. Unzip the archive in the directory where you unpacked the Orchard sources and issue the following commands:

    
    patch -p1 < 01.\ orchard-1.0-mono-support.patch
    patch -p1 < 02.\ orchard-1.0-postgresql-support.patch


And Orchard is patched!

##  Overlaying Mono Versions of Some Assemblies 

Orchard comes with a host of assemblies it depends upon both during compilation and the execution. Two of those assemblies (<tt>Microsoft.Web.Infrastructure.dll</tt> and <tt>NHibernate.dll</tt>) have to be replaced because the versions shipped with Orchard will work only in the Microsoft .NET environment. The assemblies can be found in [this archive](http://dl.dropbox.com/u/22037511/orchard/orchard-mono-sources-overlay-current.zip) which has to be unzipped in the directory where you unpacked your Orchard sources.

##  Compiling 

You <b>must</b> use MonoDevelop 2.6 or newer to compile on Orchard on Linux (you can also use VisualStudio after performing the steps above) since its earlier versions had a bug which would require you to edit assembly references in all of the Orchard projects. Compilation using Mono's xbuild is also currently not possible because of missing features (but we're working on it and soon you should be able to compile Orchard from command line).

You must make absolutely sure that the full Mono 2.10.1 (or newer) stack is installed - all of the development files, assemblies, compilers have to be present on your system.

After opening the solution in MonoDevelop just type <tt>F8</tt> (or use the <tt>Build -> Build All</tt> menu option) and after a while you should have Orchard compiled and ready to run.

###  Deploying 

Unfortunately at the time of this writing MonoDevelop will not deploy Orchard properly, so you need to do it manually. To do so, copy contents of the <tt>src/Orchard.Web/</tt> directory to your website root. If you want to remove the source and binary files which aren't necessary for the CMS to run, please consult the [binary release of Orchard](http://orchard.codeplex.com/releases/view/50197#DownloadId=197216) and use it as a template of what has to remain and what can be removed safely.

#  Resources 

##  SuSE Studio Appliance with Orchard and Mono 

We have prepared a [virtual machine and a Live CD](http://susegallery.com/a/n1C2rA/orchard-cms-mono-demo) based on OpenSuSE 11.4 with Orchard 1.0.20 and Mono 2.10.1 preinstalled so that you can test the CMS without having to go through any of the steps above.

The Virtual Machine can be loaded both in Virtual Box (recommended, tested with version 4.0.4) and VMware.

After starting the VM/Live CD, type <tt>http://orchard-demo/</tt> in the browser (FireFox will auto-start) and watch it work!

The first time you browse the above URL you will be greeted with Orchard setup screen and prompted for database connection string. You need to use the following:

    
    Server=localhost;Database=orchard;User ID=orchard;Password=orchard


#  Known Issues 

* Orchard requires [Mono IOMAP](http://mono-project.com/IOMap) to be active since there are a few files and directories that use inconsistent name case.
* After a few requests you might get <tt>npgsql</tt> (PostgreSQL ADO.NET provider) connection errors. Only restarting the application will cure it.
