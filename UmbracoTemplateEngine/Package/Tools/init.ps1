param($rootPath, $toolsPath, $package, $project)

if ($project) {
	$DTE.ItemOperations.OpenFile($toolsPath + '\readme.md')
}
