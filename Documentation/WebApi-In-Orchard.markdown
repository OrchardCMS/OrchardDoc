
# Web Api in Orchard
Web Api is available in Orchard. You can implement a web api to fit your needs in a custom module.


## Creating Api Controllers
The process of creating an Api Controller in Orchard is very similar to how you would do so in a standard .NET Web Api application. Create your controller class and have it inherit from ApiController:

	namespace MyCustomModule.Controllers.Api{
		public class MyApiController : ApiController{
			public IHttpActionResult Get(){
				var itemsList = new List<string>{
					"Item 1",
					"Item 2", 
					"Item 3"
				};
				
				return Ok(itemsList);
			}
		}
	}
	
The above code sample will return the 3 item list shown in code when you hit the endpoint "/api/MyCustomModule/MyApi".

## Declaring custom Api Routes

To generate more friendly Api routes, you follow a similar process to declaring custom MVC routes in Orchard. Implement the IHttpRouteProvider interface like so:

	namespace MyCustomModule {
		public class ApiRoutes : IHttpRouteProvider {
			public IEnumerable<RouteDescriptor> GetRoutes() {
				return new RouteDescriptor[] {
					new HttpRouteDescriptor {
						Name = "Default Api",
						Priority = 0,
						RouteTemplate = "api/myapi/{id}",
						Defaults = new {
							area = "MyCustomModule",
							controller = "MyApi",
							id = RouteParameter.Optional
						}
					}
				};
			}
	
			public void GetRoutes(ICollection<RouteDescriptor> routes) {
				foreach (RouteDescriptor routeDescriptor in GetRoutes()) {
					routes.Add(routeDescriptor);
				}
			}
		}
	}
	
Now, the Api endpoint can be reached by hitting "/api/myapi".

## Configuring Web Api in Orchard

Since Orchard doesn't have the concept of an AppStart file, in order to add custom configuration to Web Api in Orchard, you must do so in an Autofac module. For example, the following will set the default Web Api return type to Json, and will ensure that Json objects/properties returned by the Api follow the camelCased naming convention.

	namespace MyCustomModule {
		public class WebApiConfig : Module {
			protected override void Load(ContainerBuilder builder) {
				GlobalConfiguration.Configuration.Formatters.JsonFormatter.SupportedMediaTypes.Add(new MediaTypeHeaderValue("text/html"));
	
				var jsonFormatter = GlobalConfiguration.Configuration.Formatters.OfType<JsonMediaTypeFormatter>().FirstOrDefault();
	
				if (jsonFormatter != null) {
					jsonFormatter.SerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();
				}
			}
		}
	}

## Conclusion

This document should provide the basics of getting started with Web Api in Orchard. Enjoy!
