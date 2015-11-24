Command-Line Code Generation
============================

Code generation is an Orchard module that automates the task of creating additional files and extensions. This feature is useful for developers that want to create controllers, data migration classes, modules, and themes. The code generation feature is installed by default but has to be enabled by the end user/developer.


![](../Upload/screenshots_675/codegen.PNG)

To enable code generation, click **Features** under **Modules**, find the **Code Generation** feature, and click **Enable**.


![](../Upload/screenshots_675/codegenenable.png)


To enable the feature from the Orchard command-line, open the orchard command-line, and enter the following command. For more information about the Orchard command-line, see [Using the command-line interface](Using-the-command-line-interface).

    
    orchard> feature enable Orchard.CodeGeneration
    Enabling features Orchard.CodeGeneration
    Orchard.CodeGeneration was enabled


Once the code generation feature is enabled, new commmands are available for creating a module, theme, data migration, or controller. Currently, the code generation commands add files to the appropriate location.

    
    codegen controller <module-name> <controller-name>
            Create a new Orchard controller in a module
    
    codegen datamigration <feature-name>
            Create a new Data Migration class
    
    codegen module <module-name> [/IncludeInSolution:true|false]
            Create a new Orchard module
    
    codegen theme <theme-name> [/CreateProject:true|false][/IncludeInSolution:true|false][/BasedOn:<theme-name>]
            Create a new Orchard theme

    codegen moduletests <module-name> 
            Create a new test for a module
            
For a walkthrough of using the code generation feature to create a new module and data migration, read the [Getting Started with Modules course](Getting-Started-with-Modules).
Change History
--------------

* Updates for Orchard 1.8
	* 9-04-14: Updated the screen shots for Code Generation Module.