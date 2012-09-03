include Rake::DSL
require 'albacore'
require 'version_bumper'
require './rakefile.config'

task :deploy => [:zip, :nuget_push] do
end

zip :zip => :output do | zip |
	Dir.mkdir("build") unless Dir.exists?("build")
    zip.directories_to_zip "out"
    zip.output_file = "Mandrill.v#{bumper_version.to_s}.zip"
    zip.output_path = "build"
end

output :output => :test do |out|
	out.from '.'
	out.to 'out'
	out.file 'src/bin/release/Mandrill.dll', :as=>'Mandrill.dll'
	out.file 'LICENSE.txt'
	out.file 'README.md'
	out.file 'VERSION'
end

desc "Test"
nunit :test => :build do |nunit|
	nunit.command = "tools/NUnit/nunit-console.exe"
	nunit.assemblies "tests/bin/Release/Mandrill.Tests.dll"
end

desc "Build"
msbuild :build => :assemblyinfo do |msb|
  msb.properties :configuration => :Release
  msb.targets :Clean, :Build
  msb.solution = "Mandrill.sln"
end

nugetpush :nuget_push => :nup do |nuget|
    nuget.command = "nuget.exe"
    nuget.package = "Mandrill.#{bumper_version.to_s}.nupkg"
    nuget.apikey = "#{Configuration::Build.api_key}"
    nuget.create_only = true
end

##This does not work from albacore.
#nugetpack :nup => :nus do |nuget|
#   nuget.command     = "tools/NuGet/NuGet.exe"
#   nuget.nuspec      = "Mandrill.nuspec"
#   nuget.base_folder = "out/"
#   nuget.output      = "build/"
#end

##use this until patched
task :nup => :nus do
	sh "tools/NuGet/NuGet.exe pack -BasePath out/ -Output build/ out/Mandrill.nuspec"
end

nuspec :nus => :output do |nuspec|
   nuspec.id="Mandrill"
   nuspec.version = bumper_version.to_s
   nuspec.authors = "Shawn Mclean"
   nuspec.description = "Mandrill .Net is a quick and easy wrapper for getting started with the Mandrill API."
   nuspec.title = "Mandrill"
   nuspec.language = "en-US"
   nuspec.licenseUrl = "http://www.apache.org/licenses/LICENSE-2.0"
   nuspec.dependency "RestSharp", "103.4.0.0"
   nuspec.dependency "Newtonsoft.Json", "4.5.8"
   nuspec.projectUrl = "https://github.com/shawnmclean/Mandrill-dotnet"
   nuspec.working_directory = "out/"
   nuspec.output_file = "Mandrill.nuspec"
   nuspec.file "Mandrill.dll", "lib"
end


assemblyinfo :assemblyinfo do |asm|
  asm.version = bumper_version.to_s
  asm.file_version = bumper_version.to_s
  asm.company_name = "Self"
  asm.product_name = "Mandrill"
  asm.copyright = "Shawn Mclean (c) 2012"
  asm.output_file = "AssemblyInfo.cs"
end