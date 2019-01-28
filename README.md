#### Notes
- `func init` (select dotnet)
- `mv [name].csproj [name].fsproj`

- In [name].fsproj, change configuration for `host.json` and `local.settings.json` to:
    ~~~~
    <None Include="host.json">
       <CopyToOutputDirectory>PreserveNewest</CopyToOutputDirectory>
    </None>
    <None Include="local.settings.json">
      <CopyToOutputDirectory>PreserveNewest</CopyToOutputDirectory>
      <CopyToPublishDirectory>PreserveNewest</CopyToPublishDirectory>
    </None>
    ~~~~

- Add file(s) into `ItemGroup`:
    ```
    <Compile Include="[filename].fs" />
    ```
    
- Build: `dotnet build`
- Publish: `dotnet publish --configuration Release`
- Test: In the publish directory (ex. `bin/Release/netcoreapp2.1/publish/`): `func start`
- Publish to Azure: `func azure functionapp publish [functionappname]`
