targetScope = 'resourceGroup'

resource storageAccount 'Microsoft.Storage/storageAccounts@2021-04-01' = {
	name: 'st${uniqueString(resourceGroup().id)}'
	location: resourceGroup().location
	kind: 'Storage'
	sku: {
	  name: 'Standard_LRS'
	}
}
