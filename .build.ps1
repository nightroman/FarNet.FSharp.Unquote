<#
.Synopsis
	Build script, https://github.com/nightroman/Invoke-Build
#>

param(
	$Configuration = (property Configuration Release),
	$FarHome = (property FarHome C:\Bin\Far\x64)
)

Set-StrictMode -Version 3
$ModuleName = 'FarNet.FSharp.Unquote'
$ModuleRoot = "$FarHome\FarNet\Lib\$ModuleName"
$Description = 'F# Unquote package for FarNet.FSharpFar'

# Synopsis: Remove temp files.
task clean {
	remove src\bin, src\obj, README.htm, *.nupkg, z
}

# Synopsis: Build and publish (post build event).
task build {
	Set-Location src
	exec { dotnet build -c $Configuration }
}

# Synopsis: Post build event.
task publish {
	Set-Location src
	$null = mkdir $ModuleRoot -Force

	$dir1 = "$HOME\.nuget\packages\Unquote\$((Select-Xml 'Project/ItemGroup/PackageReference[@Include="Unquote"]' "$ModuleName.fsproj").Node.Version)"

	Copy-Item -Destination $ModuleRoot $(
		"$ModuleName.ini"
		"$dir1\lib\netstandard2.0\Unquote.dll"
	)
}

# Synopsis: Set $script:Version.
task version {
	($script:Version = switch -Regex -File Release-Notes.md {'##\s+v(\d+\.\d+\.\d+)' {$Matches[1]; break} })
	assert $script:Version
}

# Synopsis: Convert markdown to HTML.
task markdown {
	assert (Test-Path $env:MarkdownCss)
	exec { pandoc.exe @(
		'README.md'
		'--output=README.htm'
		'--from=gfm'
		'--embed-resources'
		'--standalone'
		"--css=$env:MarkdownCss"
		"--metadata=pagetitle=$ModuleName"
	)}
}

# Synopsis: Collect package files.
task package markdown, {
	remove z
	$toModule = mkdir "z\tools\FarHome\FarNet\Lib\$ModuleName"

	Copy-Item -Destination z @(
		'README.md'
	)

	Copy-Item -Destination $toModule @(
		'README.htm'
		'LICENSE'
		"$ModuleRoot\FarNet.FSharp.Unquote.ini"
		"$ModuleRoot\Unquote.dll"
	)
}

# Synopsis: Make NuGet package.
task nuget package, version, {
	Set-Content z\Package.nuspec @"
<?xml version="1.0"?>
<package xmlns="http://schemas.microsoft.com/packaging/2010/07/nuspec.xsd">
	<metadata>
		<id>$ModuleName</id>
		<version>$Version</version>
		<authors>Roman Kuzmin</authors>
		<owners>Roman Kuzmin</owners>
		<license type="expression">Apache-2.0</license>
		<readme>README.md</readme>
		<projectUrl>https://github.com/nightroman/$ModuleName</projectUrl>
		<description>$Description</description>
		<releaseNotes>https://github.com/nightroman/$ModuleName/blob/main/Release-Notes.md</releaseNotes>
		<tags>FarManager FarNet FSharp Unquote Assert Testing</tags>
	</metadata>
</package>
"@

	exec { NuGet.exe pack z\Package.nuspec }
}

# Synopsis: Test samples by FarHost.
task testFarHost -If ($Host.Name -ne 'FarHost') {
	Start-Far -Test 0 'ps: Invoke-Build ** tests'
}

# Synopsis: Test samples.
task test testFarHost, {
	Invoke-Build ** tests
}

task . build, clean
