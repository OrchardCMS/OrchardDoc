
Code generation is an Orchard module that automates the task of creating additional files and extensions. This feature is useful for developers that want to create controllers, data migration classes, modules, and themes. However, the code generation feature is not installed by default when you install Orchard.

You can install the code generation feature using the Orchard Gallery. Open the admin panel, click **Modules** under the **Gallery** heading.

![](../Upload/screenshots_675/gallery_modules_675.PNG)

Find the **Code Generation** module, and click **Install**.

![](../Upload/screenshots_675/gallery_code_generation_675.png)

To enable code generation, click **Features** under **Configuration**, find the **Code Generation** feature, and click **Enable**.

![](../Upload/screenshots/enable_codegen.png)

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


For a walkthrough of using the code generation feature to create a new module and data migration, see [Writing a content part](Writing-a-content-part).
