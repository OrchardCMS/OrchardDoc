
We recommend that deployed versions of Orchard are configured with a fixed machine key rather than the default setting, which is to automatically generate the key at runtime. This default setting can cause the key to change unexpectedly, which can cause validation errors.


# Setting Up the Machine Key Using IIS Manager

If you have access to the IIS management console for the server where Orchard is installed, it is the easiest way to set-up a machine key.

Start the management console and then select the web site. Open the machine key configuration:

![The IIS web site configuration panel](../Attachments/Setting-up-a-machine-key/IisManagerMachineKey.PNG)

The machine key control panel has the following settings:

![The machine key configuration panel](../Attachments/Setting-up-a-machine-key/UncheckAutoMachineKey.PNG)

Uncheck "Automatically generate at runtime" for both the validation key and the decryption key.

Click "Generate Keys" under "Actions" on the right side of the panel.

Click "Apply".

# Setting Up the Machine Key Directly in the Web.config File

If you do not have access to the IIS management console, it is still possible to set-up a machine key for an Orchard application.

To do so, open the web.config file that is at the root of the Orchard web site. The machine key settings can be found or created under configuration/system.web:

    
    <configuration>
      <system.web>
        <machineKey decryptionKey="Decryption key goes here,IsolateApps" 
                    validationKey="Validation key goes here,IsolateApps" />
      </system.web>
    </configuration>


To create the keys that go into the placeholders above, you can use one of the available online generators, such as:

* [http://aspnetresources.com/tools/machineKey](http://aspnetresources.com/tools/machineKey)
* [http://www.eggheadcafe.com/articles/GenerateMachineKey/GenerateMachineKey.aspx](http://www.eggheadcafe.com/articles/GenerateMachineKey/GenerateMachineKey.aspx)
* [http://www.betterbuilt.com/machinekey/](http://www.betterbuilt.com/machinekey/)
* [http://www.codeproject.com/KB/aspnet/Machine_Key_Generator.aspx](http://www.codeproject.com/KB/aspnet/Machine_Key_Generator.aspx)
* [http://www.developerfusion.com/tools/generatemachinekey/](http://www.developerfusion.com/tools/generatemachinekey/)
