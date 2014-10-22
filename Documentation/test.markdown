## Some Test MarkDown

```cs
using Orchard.ContentManagement;

namespace RelationSample.Models {
	public class AddressPart : ContentPart<AddressPartRecord> {
		public string Address {
			get { return Record.Address; }
			set { Record.Address = value; }
		}
		public string City {
			get { return Record.City; }
			set { Record.City = value; }
		}
		public StateRecord State {
			get { return Record.StateRecord; }
			set { Record.StateRecord = value; }
		}
		public string Zip {
			get { return Record.Zip; }
			set { Record.Zip = value; }
		}
	}
}
```

