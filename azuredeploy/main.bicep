targetScope = 'resourceGroup'

module appPlanDeploy 'appPlan.bicep' = {
	name: '${deployment().name}-AppPlan'
}

module siteDeploy 'siteDeploy.bicep' = {
	name: '${deployment().name}-Site'
}
