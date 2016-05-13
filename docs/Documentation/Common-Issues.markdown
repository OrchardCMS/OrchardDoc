
If you receive this error:

    
    Server Error in '/' Application.
    
    Configuration Error
    
    Description: An error occurred during the processing of a configuration
    file required to service this request. Please review the specific error
    details below and modify your configuration file appropriately. 
    
    Parser Error Message: It is an error to use a section registered as
    allowDefinition='MachineToApplication' beyond application level.
    This error can be caused by a virtual directory not being configured as
    an application in IIS.


It may be because the folder where the Orchard web application is installed is not configured to be an application. This can be fixed by going into the IIS configuration and making the folder an IIS application.
